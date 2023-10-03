using Photon.Pun;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

#pragma warning disable IDE0051

public class PlayerScript : MonoBehaviourPun
{
    public GameObject characterVisual;
    [SerializeField] ParticleSystem[] ballExplode;
    [SerializeField] GameObject shield;
    public GameObject dash;
    public GameObject[] projectile;
    [SerializeField] GameObject trap;
    [SerializeField] GameObject sDTrap;
    [SerializeField] GameObject wall;
    [SerializeField] GameObject[] projectiles;

    [HideInInspector] public LineRenderer lineRenderer;
    [HideInInspector] public GameObject ballCloneRemote;
    [HideInInspector] public bool isActive;//for Invisibility
    [HideInInspector] public bool isCatcher; // online bool

    private Rigidbody rB;
    private Animator animator;
    readonly int attackForce = 30;

    public Animator Animator {set => animator = value; } // Decleration for BOTs

    private void Awake()
    {
        isActive = true;
        gameObject.name = photonView.Owner.ActorNumber.ToString();
        rB = GetComponent<Rigidbody>();
        if (!(photonView.IsMine || GetComponent<LocalPlayer>().isBOT))
        {
            rB.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
            rB.isKinematic = true;
            rB.useGravity = false;
            Destroy(GetComponent<PlayerMovement>());
        }
    }

    //When first roud end
    public void Freeze()
    {
        rB.constraints = RigidbodyConstraints.FreezePosition;
    }

    public void UnFreeze()
    {
        rB.constraints = RigidbodyConstraints.None;
        rB.constraints = RigidbodyConstraints.FreezeRotation;
    }

    [PunRPC]
    private void SetCharacter(byte index)
    {
        GameObject character = Instantiate(GameObjectsData.Instance.characterPrefabs[index], characterVisual.transform);
        animator = character.GetComponent<Animator>(); //Decleration is only for Real Players
        ballCloneRemote = character.GetComponent<CharacterData>().ballGO;
    }


    [PunRPC]
    public void SetCatcherValue(bool v)
    {
        if (GetComponent<PhotonView>().IsMine || GetComponent<LocalPlayer>().teamMembers.Contains((byte)PhotonNetwork.LocalPlayer.ActorNumber))
        {
            isCatcher = v;
        }
    }

    [PunRPC]
    private void BallHit(bool secondLife)
    {
        if(GetComponent<LocalPlayer>().lives > 0)
        {
            foreach (ParticleSystem pS in ballExplode)
            {
                pS.Play();
            }
            GetComponent<LocalPlayer>().lives--;
            if(photonView.IsMine && !GetComponent<LocalPlayer>().isBOT) GameObjectsData.Instance.lives[GetComponent<LocalPlayer>().lives].SetActive(false); // When has one life it will not be second life
            if (secondLife)
            {
                HideCharacter();
                StartCoroutine(SecondLife());
            }
        }
    }

    private void HideCharacter()
    {
        characterVisual.SetActive(false);
        GetComponent<LocalPlayer>().nameTag.enabled = false;
        if (photonView.IsMine)
        {
            GetComponent<PlayerMovement>().HideJoystick();
            rB.useGravity = false;
        }
        rB.constraints = RigidbodyConstraints.FreezePosition;
        GetComponent<Collider>().enabled = false;
    }

    IEnumerator SecondLife()
    {
        if (photonView.IsMine)
        {
            transform.position = GameLogicData.Instance.myStartPoint;
            GetComponent<PlayerMovement>().ExitSDTWhenDie();
        }
        yield return new WaitForSeconds(1f);
        photonView.RPC("ShowCharacter", RpcTarget.All);
    }

    [PunRPC]
    private void ShowCharacter()
    {
        characterVisual.SetActive(true);
        GetComponent<LocalPlayer>().nameTag.enabled = true;
        if (photonView.IsMine)
        {
            GetComponent<PlayerMovement>().ShowJoystick();
            rB.useGravity = true;
        }
        rB.constraints = RigidbodyConstraints.None;
        rB.constraints = RigidbodyConstraints.FreezeRotation;
        GetComponent<Collider>().enabled = true;
    }

    [PunRPC]
    private void ShowCharacterBOT()
    {
        characterVisual.SetActive(true);
        GetComponent<Collider>().enabled = true;
        GetComponent<LocalPlayer>().nameTag.enabled = true;
        animator.SetBool("IsMoving", false);
    }

    [PunRPC]
    private void LostLife()
    {
        characterVisual.SetActive(false);
        rB.useGravity = false;
        GetComponent<Collider>().enabled = false;
        rB.constraints = RigidbodyConstraints.FreezePosition;
        GetComponent<LocalPlayer>().nameTag.enabled = false;
        if (photonView.IsMine)
        {
            GetComponent<PlayerMovement>().HideJoystick();
        }
        GameLogicData.Instance.alivePlayers--;
    }

    [PunRPC]
    private void LostLifeBOT()
    {
        if (PhotonNetwork.IsMasterClient) GetComponent<BotController>().isActive = false;
        characterVisual.SetActive(false);
        GetComponent<Collider>().enabled = false;
        GetComponent<LocalPlayer>().nameTag.enabled = false;
        shield.SetActive(false);
        GameLogicData.Instance.alivePlayers--;
    }

    [PunRPC]
    private void InvisibilityHide(float time)
    {
        if (!photonView.IsMine)
        {
            characterVisual.SetActive(false);
            GetComponent<Collider>().enabled = false;
        }
        else
        {
            Color color = GetComponent<LocalPlayer>().nameTag.color;
            color.a = 0.1f;
            GetComponent<LocalPlayer>().nameTag.color = color;
            rB.useGravity = false;
            GetComponent<Collider>().enabled = false;
        }
        isActive = false;
        StartCoroutine(InvisibilityShow(time));
    }

    IEnumerator InvisibilityShow(float time)
    {
        yield return new WaitForSeconds(time);
        if (!photonView.IsMine)
        {
            characterVisual.SetActive(true);
            GetComponent<Collider>().enabled = true;
        }
        else
        {
            Color color = GetComponent<LocalPlayer>().nameTag.color;
            color.a = 1f;
            GetComponent<LocalPlayer>().nameTag.color = color;
            rB.useGravity = true;
            GetComponent<Collider>().enabled = true;
            photonView.RPC("OnAnimChange", RpcTarget.All, (byte)0, GetComponent<PlayerMovement>().IsMoving);
        }
        isActive = true;
    }

    [PunRPC]
    private void PlayerShoot(Vector3 position, Vector3 direction,byte[] ownerTeamActNums, byte index, byte senderActNum)
    {
        GameObject ball = Instantiate(projectiles[index], position, Quaternion.LookRotation(direction, Vector3.up));//, ballInitialPosition.position, Quaternion.LookRotation(attackDirection, Vector3.up), 0, new object[] { ballIndex });
        ball.GetComponent<Rigidbody>().AddForce(attackForce * direction, ForceMode.VelocityChange);
        ball.GetComponent<Ball>().ownerActNum = senderActNum;
        ball.GetComponent<Ball>().ownerTeamActNums = ownerTeamActNums;
        if (GetComponent<LocalPlayer>().isBOT)
        {
            animator.SetBool("ReadyToThrow", true);
        }
        animator.SetTrigger("Throw");
        if (GetComponent<LocalPlayer>().isBOT)
        {
            IEnumerator enumerator = DisableThrowing();
            StartCoroutine(enumerator);
        }
        if(Vector3.Distance(position, GameObjectsData.Instance.localPlayer.position) < 37)
        {
            AudioManager.Instance.Play(11);
        }
    }
    
    [PunRPC]
    private void DeadlyShoot(Vector3 position, Vector3 direction,byte[] ownerTeamActNums, byte index, byte senderActNum)
    {
        GameObject ball = Instantiate(projectiles[index], position, Quaternion.LookRotation(direction, Vector3.up));
        ball.GetComponent<SphereCollider>().radius = 1f;
        ball.GetComponent<Rigidbody>().AddForce(attackForce * direction, ForceMode.VelocityChange);
        ball.GetComponent<Ball>().isDeadly = true;
        ball.GetComponent<Ball>().ownerActNum = senderActNum;
        ball.GetComponent<Ball>().ownerTeamActNums = ownerTeamActNums;
        animator.SetTrigger("Throw");
        if (Vector3.Distance(position, GameObjectsData.Instance.localPlayer.position) < 37)
        {
            AudioManager.Instance.Play(11);
        }
    }

    IEnumerator DisableThrowing()
    {
        yield return 0;
        animator.SetBool("ReadyToThrow", false);
    }

    [PunRPC]
    private void OnAnimChange(byte index, bool state)
    {
        switch (index)
        {
            case 0:
                animator.SetBool("IsMoving", state);
                break;
            case 1:
                animator.SetBool("ReadyToThrow", state);
                break;
        }
    }

    [PunRPC]
    private void ShowShield( float time)
    {
        shield.SetActive(true);
        GetComponent<LocalPlayer>().hasShield = true;
        StartCoroutine(HideShield(time));
    }

    IEnumerator HideShield(float time)
    {
        yield return new WaitForSeconds(time);
        shield.SetActive(false);
        GetComponent<LocalPlayer>().hasShield = false;
    }

    [PunRPC]
    private void WallPlaced(Vector3 position, float activeTime)
    {
        GameObject gO = Instantiate(wall, position, Quaternion.Euler(-90,0,0));
        if (PhotonNetwork.IsMasterClient)
        {
            Collider[] colliders = Physics.OverlapSphere(position, 10f, 1<<7);
            foreach (Collider collider in colliders)
            {
                if (collider.gameObject.GetComponent<LocalPlayer>().isBOT && collider.GetComponent<NavMeshAgent>().isActiveAndEnabled)
                {
                    collider.GetComponent<BotController>().EnterTrapAndWall(activeTime);
                }
            }
        }
        Destroy(gO, activeTime);
    }

    [PunRPC]
    private void TrapPlaced(Vector3 position, float activeTime)
    {
        GameObject gO = Instantiate(trap, position, Quaternion.identity);
        gO.GetComponent<Trap>().ownerActNum = GetComponent<LocalPlayer>().actNum;
        Destroy(gO, activeTime);
    }
    [PunRPC]
    private void SDTrapPlaced(Vector3 position, float activeTime)
    {
        GameObject gO = Instantiate(sDTrap, position, Quaternion.identity);
        gO.GetComponent<SDTrap>().ownerActNum = GetComponent<LocalPlayer>().actNum;
        gO.GetComponent<SDTrap>().timeToDestroy = activeTime;
        Destroy(gO, activeTime);
        //IEnumerator enumerator = DestroySDTrap(gO, activeTime);
        //StartCoroutine(enumerator);
    }

    IEnumerator DestroySDTrap(GameObject gO, float activeTime)
    {
        yield return new WaitForSeconds(activeTime);
        gO.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        Destroy(gO);
    }
}