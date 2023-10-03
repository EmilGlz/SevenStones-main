using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using System.Collections.Generic;
using System.Collections;

public class BotController : MonoBehaviour
{
    private const int STONETRIGGERLAYER = 9;
    private const int BALLZONELAYER = 10;
    private const int TRAPLAYER = 12;
    private const int SDTRAPLAYER = 14;

    private const byte PlayerPlaceStoneEventCode = 3;

    private static System.Random random;

    private float stoneStayTime = 0;
    private float nextAttackTime = 0;
    private bool greenStone = false;
    private bool hasBall = true;

    [SerializeField] Transform ballInitialPosition;
    [SerializeField] int attackForce;

    private PhotonView photonView;
    private Transform selectedPlayer;
    private Vector3 direction;
    private NavMeshAgent navAgent;

    public bool isActive = false;
    readonly byte ballIndex = 0;
    private int currentStoneInt;
    private float nextSkillTime = 0;
    private float skillTime = 0;
    private float speedTemp;
    private bool isCatcher;
    private bool insideTrap = false;

    private void Awake()
    {
        GetComponent<LocalPlayer>().isBOT = true;
        navAgent = GetComponent<NavMeshAgent>();
        photonView = GetComponent<PhotonView>();
        random = new System.Random();
        GetComponent<BotController>().enabled = PhotonNetwork.IsMasterClient;
    }

    private void Update()
    {
        if (isActive && isCatcher && hasBall)
        {
            navAgent.SetDestination(selectedPlayer.position);
            if(Vector3.Distance(transform.position,selectedPlayer.position) < 10f && Time.time > nextAttackTime)
            {
                direction = (selectedPlayer.position - transform.position).normalized;
                photonView.RPC("PlayerShoot", RpcTarget.All, ballInitialPosition.position, direction, ListToByteArray(GetComponent<LocalPlayer>().teamMembers), ballIndex, GetComponent<LocalPlayer>().actNum);
                hasBall = false;
                navAgent.SetDestination(GameObjectsData.Instance.ballZones[new System.Random().Next(4)].position);
                nextAttackTime = Time.time + 1f;
            }
        }
        if(!isCatcher && isActive && nextSkillTime != 0 && Time.time > nextSkillTime)
        {
            DoSkill();
        }
        if (skillTime > 0)
        {
            skillTime -= Time.deltaTime;
            if (skillTime <= 0)
            {
                //GetComponent<PhotonView>().RPC("HideShield", RpcTarget.All);
                //GetComponent<LocalPlayer>().hasShield = false;
                navAgent.speed /= 1.3f;
            }
        }
    }

    private void DoSkill()
    {
        //Shield can work (not sure) with kinematic rigidbody on shield
        //GetComponent<PhotonView>().RPC("ShowShield", RpcTarget.All);
        //GetComponent<LocalPlayer>().hasShield = true;
        navAgent.speed *= 1.3f;
        nextSkillTime = Time.time + 25f;
        skillTime = 4;
    }

    public void StartRound(bool catcher)
    {
        navAgent.enabled = true;
        isCatcher = catcher;
        isActive = true;
        photonView.RPC("OnAnimChange", RpcTarget.All, (byte)0, true);
        if (isCatcher) //Catcher BOT
        {
            navAgent.speed = 10.4f;
            selectedPlayer = RandomPlayer();
        }
        else //Runner BOT
        {
            navAgent.speed = 8f;
            navAgent.SetDestination(GameObjectsData.Instance.RandomStoneZone());
            nextSkillTime = Time.time + 25f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isActive && PhotonNetwork.IsMasterClient)
        {
            if (other.gameObject.layer == STONETRIGGERLAYER && !isCatcher) // Runner Bot enters stone zone
            {
                if (GameLogicData.Instance.collectedStones[int.Parse(other.gameObject.name)] == 0) // if stone zone is red, bot stops on it
                {
                    navAgent.SetDestination(other.transform.position);
                    stoneStayTime = Time.time + 4f;
                    greenStone = false;
                    photonView.RPC("OnAnimChange", RpcTarget.All, (byte)0, false);
                }
                else // if stone zone is green, bot goes to another stone
                {
                    photonView.RPC("OnAnimChange", RpcTarget.All, (byte)0, true);
                    navAgent.SetDestination(GameObjectsData.Instance.RandomStoneZone());
                    greenStone = true;
                }
                return;
            }
            else if(other.gameObject.layer == TRAPLAYER && !GetComponent<LocalPlayer>().teamMembers.Contains(other.gameObject.GetComponent<Trap>().ownerActNum))
            {
                EnterTrapAndWall(3f);
            }
            else if (other.gameObject.layer == SDTRAPLAYER && !GetComponent<LocalPlayer>().teamMembers.Contains(other.gameObject.GetComponent<SDTrap>().ownerActNum))
            {
                speedTemp = navAgent.speed;
                navAgent.speed = speedTemp / 2;
                IEnumerator enumerator = ExitFromSDTrap(other.gameObject.GetComponent<SDTrap>().timeToDestroy);
                StartCoroutine(enumerator);
                insideTrap = true;
            }
        }
    }

    public void EnterTrapAndWall(float time)
    {
        isActive = false;
        photonView.RPC("OnAnimChange", RpcTarget.All, (byte)0, false);
        Vector3 lastPos = navAgent.destination;
        navAgent.SetDestination(transform.position);
        IEnumerator enumerator = ExitTrap(time, lastPos);
        StartCoroutine(enumerator);
    }

    IEnumerator ExitTrap(float time, Vector3 position)
    {
        yield return new WaitForSeconds(time);
        photonView.RPC("OnAnimChange", RpcTarget.All, (byte)0, true);
        isActive = true;
        if (!isCatcher && navAgent.isActiveAndEnabled) navAgent.SetDestination(position);
    }

    private void OnTriggerStay(Collider other)
    {
        if (isActive && PhotonNetwork.IsMasterClient)
        {
            if (other.gameObject.layer == STONETRIGGERLAYER && !isCatcher)
            {
                currentStoneInt = int.Parse(other.gameObject.name);
                if (stoneStayTime != 0 && Time.time > stoneStayTime && GameLogicData.Instance.collectedStones[currentStoneInt] == 0) // if stone zone is red and bot stands for 4 seconds, bot send raise event and goes to new zone
                {
                    object[] content = new object[] { other.gameObject.name, GetComponent<LocalPlayer>().actNum, (float)PhotonNetwork.Time };
                    RaiseEventOptions rEO = new RaiseEventOptions { Receivers = ReceiverGroup.All };
                    PhotonNetwork.RaiseEvent(PlayerPlaceStoneEventCode, content, rEO, SendOptions.SendReliable);
                    stoneStayTime = 0;
                    //other.gameObject.GetComponent<Renderer>().material.color = Color.green;
                    greenStone = true;
                    StartCoroutine(WaitAndGoRandom());
                }
                else if (GameLogicData.Instance.collectedStones[currentStoneInt] == 1 && !greenStone) // if stone zone is green (when bot goes to another stone and go through this one)
                {
                    photonView.RPC("OnAnimChange", RpcTarget.All, (byte)0, true);
                    navAgent.SetDestination(GameObjectsData.Instance.RandomStoneZone());
                    greenStone = true;
                }
                return;
            }
            if (other.gameObject.layer == BALLZONELAYER && !hasBall)
            {
                selectedPlayer = RandomPlayer();
                hasBall = true;
                return;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isActive && PhotonNetwork.IsMasterClient)
        {
            if(other.gameObject.layer == TRAPLAYER && !GetComponent<LocalPlayer>().teamMembers.Contains(other.gameObject.GetComponent<Trap>().ownerActNum))
            {
                photonView.RPC("OnAnimChange", RpcTarget.All, (byte)0, true);
            }
            else if (other.gameObject.layer == SDTRAPLAYER && !GetComponent<LocalPlayer>().teamMembers.Contains(other.gameObject.GetComponent<SDTrap>().ownerActNum))
            {
                navAgent.speed = speedTemp;
                insideTrap = false;
            }
        }
    }

    IEnumerator WaitAndGoRandom()
    {
        yield return new WaitForSeconds(.2f);
        if(navAgent.isActiveAndEnabled)
        {
            navAgent.SetDestination(GameObjectsData.Instance.RandomStoneZone());
            photonView.RPC("OnAnimChange", RpcTarget.All, (byte)0, true);
        }
    }

    IEnumerator ExitFromSDTrap(float time)
    {
        yield return new WaitForSeconds(time);
        if (insideTrap)
        {
            navAgent.speed = speedTemp;
            insideTrap = false;
        }
    }

    public void RoundEnd()
    {
        isActive = false;
        navAgent.SetDestination(transform.position);
        navAgent.enabled = false;
    }

    public void ChangePosition(Vector3 position)
    {
        navAgent.enabled = false;
        transform.position = position;
        navAgent.enabled = true;
    }

    public void ZonesChanged()
    {
        if (!isCatcher && navAgent.isActiveAndEnabled)
        {
            navAgent.SetDestination(GameObjectsData.Instance.RandomStoneZone());
            photonView.RPC("OnAnimChange", RpcTarget.All, (byte)0, true);
        }
    }

    public Transform RandomPlayer()
    {
        int alivePlayers = GameLogicData.Instance.alivePlayers;
        if (alivePlayers <= 0)
        {
            return GameObjectsData.Instance.zeroPosition;
        }
        int rand = random.Next(alivePlayers);

        foreach (Transform player in GetComponent<LocalPlayer>().IdAndPlace.First == 1 ? GameObjectsData.Instance.team2Players : GameObjectsData.Instance.team1Players)
        {
            if (player.GetComponent<LocalPlayer>().lives >= 1 && player.GetComponent<PlayerScript>().isActive)
            {
                if (rand == 0)
                {
                    return player;
                }
                else rand--;
            }
        }
        return GameObjectsData.Instance.zeroPosition;
    }

    private byte[] ListToByteArray(List<byte> myTeamMembersActorNumbers)
    {
        byte[] array = new byte[myTeamMembersActorNumbers.Count];
        for (int i = 0; i < myTeamMembersActorNumbers.Count; i++)
        {
            array[i] = (byte)myTeamMembersActorNumbers[i];
        }
        return array;
    }
}