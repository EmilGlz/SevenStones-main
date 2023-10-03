using UnityEngine;
using UnityEngine.EventSystems;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private const byte PlayerPlaceStoneEventCode = 3;
    //private const byte PlayerTakeBallEventCode = 6;
    //private const byte PlayerShootBallEventCode = 7;

    private const int STONETRIGGERLAYER = 9;
    private const int BALLZONELAYER = 10;
    private const int TRAPLAYER = 12;
    private const int SDTRAPLAYER = 14;

    [SerializeField] LineRenderer attackLine;
    [SerializeField] Transform attackRaycast;
    [SerializeField] GameObject attackLineGameObject;
    float speed = 400f;
    readonly float turnSmoothTime = 0.2f;
    readonly float attackLineDistance = 6f;
    readonly float attackTimeDelay = 1f;

    [SerializeField] Transform ballInitialPosition;

    [HideInInspector] public int ballCountSkill;
    [HideInInspector] public bool isAttacker = true;
    [HideInInspector] public bool roundStart = false;

    private Joystick movementJoystick;
    private Joystick attackJoystick;
    private Vector3 playerDirection;
    private Vector3 attackDirection;
    private TMP_Text dashTimeText;
    private RaycastHit hit;
    private Rigidbody rigidBody;
    private PhotonView photonView;

    // Check animator change
    public bool IsMoving { get => isMoving;}
    private bool isMoving = false;
    private bool isRTThrow = false;
    //

    float targetAngle;
    float angle;

    private byte ballIndex;
    private int attackerValue = 1;
    [HideInInspector] public int attackBalls;
    private float timeToPlaceStone = 0f;
    private float nextAttackTime;
    private float turnSmoothVelocity;
    private float movementHorizontal;
    private float movementVertical;
    private float attackHorizontal;
    private float attackVertical;
    private float dashTime = 0f;
    private float dashLvlTime = 4f;
    private float speedRatio = 1f;
    private bool attackButtonDown = false;
    private bool canShoot = false;
    private bool canDash = true;

    //Skills
    private float speedSkillTime;
    //private const float speedRatio = 1.3f;
    private float trapTime;
    private float speedRatioTemp;
    private bool insideTrap = false;


    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        attackLineGameObject.SetActive(true);
        photonView = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (!canDash && dashTime>0)
        {
            dashTime -= Time.deltaTime;
            if (dashTime <= 0)
            {
                canDash = true;
                GetComponent<PlayerScript>().dash.SetActive(true);
                dashTimeText.gameObject.SetActive(false);
            }
            else
            {
                dashTimeText.text = ((int)dashTime+1).ToString();
            }
        }
        if (speedSkillTime > 0)
        {
            speedSkillTime -= Time.deltaTime;
            if (speedSkillTime <= 0)
            {
                speedRatio /= 1.3f;
            }
        }
        if(trapTime > 0)
        {
            trapTime -= Time.deltaTime;
            if(trapTime <= 0)
            {
                movementJoystick.gameObject.SetActive(true);
                attackJoystick.gameObject.SetActive(true);
                speedRatio = speedRatioTemp;
            }
        }
    }
    
    void FixedUpdate()
    {
        movementHorizontal = movementJoystick.Horizontal;
        movementVertical = movementJoystick.Vertical;
        playerDirection = new Vector3(movementHorizontal, 0f, movementVertical).normalized;
        
        attackHorizontal = attackJoystick.Horizontal;
        attackVertical = attackJoystick.Vertical;
        attackDirection = new Vector3(attackHorizontal, 0f, attackVertical).normalized;

        if (playerDirection.magnitude >= 0.1f)
        {
            if (!attackButtonDown)
            {
                targetAngle = Mathf.Atan2(playerDirection.x * attackerValue, playerDirection.z * attackerValue) * Mathf.Rad2Deg;
                angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
            }
            Move(playerDirection * attackerValue * speed * Time.fixedDeltaTime);
            if (!isMoving) //RPC method is not calling each frame
            {
                photonView.RPC("OnAnimChange",RpcTarget.All, (byte)0, true);
                isMoving = true;
            }
        }
        else if(isMoving)
        {
                photonView.RPC("OnAnimChange", RpcTarget.All, (byte)0, false);
                isMoving = false;
        }
        attackLine.SetPosition(0, attackRaycast.position);
        if (Mathf.Abs(attackJoystick.Horizontal) >= 0.25f || Mathf.Abs(attackJoystick.Vertical) >= 0.25f)
        {
            if (isAttacker && !isRTThrow)
            {
                photonView.RPC("OnAnimChange", RpcTarget.All, (byte)1, true);
                isRTThrow = true;
            }
            if (dashTime <= 0) canDash = true;
            canShoot = true;
            if (attackButtonDown)
            {
                targetAngle = Mathf.Atan2(attackDirection.x * attackerValue, attackDirection.z * attackerValue) * Mathf.Rad2Deg;
                //float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            }
            if(Physics.Raycast(attackRaycast.position, attackDirection * attackerValue, out hit , attackLineDistance))
            {
                if(hit.transform.gameObject.layer == 7 || hit.transform.gameObject.layer == 8)
                attackLine.SetPosition(1,hit.point);
                else
                {
                    attackLine.SetPosition(1, attackRaycast.position + attackDirection * attackLineDistance * attackerValue);
                }
            }
            else
            {
                attackLine.SetPosition(1, attackRaycast.position + attackDirection * attackLineDistance * attackerValue);
            }
        }
        else
        {
            if (isAttacker && isRTThrow)
            {
                photonView.RPC("OnAnimChange", RpcTarget.All, (byte)1, false);
                isRTThrow = false;
            }
            canShoot = false;
            canDash = false;
            attackLine.SetPosition(1, attackRaycast.position);
        }
    }
    
    public void GameStart()
    {
        attackBalls = 0;
        attackButtonDown = false;
    }

    public void StartRoundForPlayer()
    {
        attackBalls = ballCountSkill == 0 ? 1 : ballCountSkill;
        if (GetComponent<LocalPlayer>().isCatcher)
        {
            speedRatio = 1.3f;
            for (int i = 0; i < attackBalls; i++)
            {
                GetComponent<PlayerScript>().projectile[i].SetActive(true);
            }
            GetComponent<PlayerScript>().dash.SetActive(false);
        }
        else
        {
            speedRatio = 1f;
            GetComponent<PlayerScript>().dash.SetActive(true);
            for (int i = 0; i < 3; i++)
            {
                GetComponent<PlayerScript>().projectile[i].SetActive(false);
            }
        }
        roundStart = true;
    }

    public void HideJoystick()
    {
        movementJoystick.GetComponent<FloatingJoystick>().OnDeactivate();
        attackJoystick.GetComponent<FloatingJoystick>().OnDeactivate();
        movementJoystick.gameObject.SetActive(false);
        attackJoystick.gameObject.SetActive(false);
    }

    public void ShowJoystick()
    {
        movementJoystick.gameObject.SetActive(true);
        attackJoystick.gameObject.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (GameLogicData.Instance.hookMove)
        {
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = Vector3.zero;
            movementJoystick.enabled = true;
            GameLogicData.Instance.hookMove = false;
        }
    }

    //Enter to stone zone or ball zone
    private void OnTriggerEnter(Collider other)
    {
        if (photonView.IsMine && !GetComponent<LocalPlayer>().isCatcher && other.gameObject.layer == STONETRIGGERLAYER
            && GameLogicData.Instance.collectedStones[int.Parse(other.gameObject.name)] == 0)
        {
            timeToPlaceStone = Time.time + 3f;
            return;
        }
        if (roundStart && photonView.IsMine && GetComponent<LocalPlayer>().isCatcher && other.gameObject.layer == BALLZONELAYER)
        {
            // Who takes ball sended over network
            //RaiseEventOptions rEO = new RaiseEventOptions { Receivers = ReceiverGroup.All };
            //PhotonNetwork.RaiseEvent(PlayerTakeBallEventCode, GetComponent<LocalPlayer>().place, rEO, SendOptions.SendReliable);
            attackBalls = ballCountSkill == 0 ? 1 : ballCountSkill;
            //GameObjectsData.Instance.ballOnCanvas.SetActive(true);
            for (int i = 0; i < attackBalls; i++)
            {
                GetComponent<PlayerScript>().projectile[i].SetActive(true);
            }
            AudioManager.Instance.Play(10);
            return;
        }
        if(other.gameObject.layer == TRAPLAYER && other.gameObject.GetComponent<Trap>().ownerActNum!=GetComponent<LocalPlayer>().actNum &&
            !GetComponent<LocalPlayer>().teamMembers.Contains(other.gameObject.GetComponent<Trap>().ownerActNum) && !GetComponent<LocalPlayer>().hasShield)
        {
            movementJoystick.gameObject.SetActive(false);
            speedRatioTemp = speedRatio;
            speedRatio = 0;
            if (!GetComponent<LocalPlayer>().isCatcher)
            {
                attackJoystick.gameObject.SetActive(false);
            }
            trapTime = 3f;
            return;
        }
        if (other.gameObject.layer == SDTRAPLAYER && other.gameObject.GetComponent<SDTrap>().ownerActNum != GetComponent<LocalPlayer>().actNum &&
                !GetComponent<LocalPlayer>().teamMembers.Contains(other.gameObject.GetComponent<SDTrap>().ownerActNum))
        {
            speedRatioTemp = speedRatio;
            speedRatio /= 3;
            StartCoroutine(ExitFromSDTrap(other.gameObject.GetComponent<SDTrap>().timeToDestroy));
            insideTrap = true;
        }
    }

    //Stay on stone zone
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == STONETRIGGERLAYER)
        {
            if (photonView.IsMine && timeToPlaceStone != 0 && Time.time > timeToPlaceStone && GameLogicData.Instance.collectedStones[int.Parse(other.gameObject.name)] == 0)
            {
                object[] content = new object[] { other.gameObject.name, (byte)GetComponent<PhotonView>().Owner.ActorNumber, (float)PhotonNetwork.Time };
                RaiseEventOptions rEO = new RaiseEventOptions { Receivers = ReceiverGroup.All };
                PhotonNetwork.RaiseEvent(PlayerPlaceStoneEventCode, content, rEO, SendOptions.SendReliable);
                timeToPlaceStone = 0;
            }
        }
    }

    //Exit from stone zone
    private void OnTriggerExit(Collider other)
    {
        if (photonView.IsMine && other.gameObject.layer == STONETRIGGERLAYER)
        {
            timeToPlaceStone = 0;
            return;
        }
        if (other.gameObject.layer == SDTRAPLAYER && other.gameObject.GetComponent<SDTrap>().ownerActNum != GetComponent<LocalPlayer>().actNum &&
                !GetComponent<LocalPlayer>().teamMembers.Contains(other.gameObject.GetComponent<SDTrap>().ownerActNum))
        {
            speedRatio = speedRatioTemp;
            insideTrap = false;
        }
    }

    public void ExitSDTWhenDie()
    {
        speedRatio = 1f;
        insideTrap = false;
        attackButtonDown = false;
    }

    IEnumerator ExitFromSDTrap(float time)
    {
        yield return new WaitForSeconds(time);
        if (insideTrap)
        {
            speedRatio = speedRatioTemp;
            insideTrap = false;
        }
    }

    //Attack Joystick Up
    public void ShootAttackButtonUp()
    {
        if (canShoot && isAttacker && Time.time > nextAttackTime && attackBalls > 0)
        {
            nextAttackTime = Time.time + attackTimeDelay;
            attackBalls--;
            GetComponent<PlayerScript>().projectile[attackBalls].SetActive(false);
            //RaiseEventOptions rEO = new RaiseEventOptions { Receivers = ReceiverGroup.All };
            //PhotonNetwork.RaiseEvent(PlayerShootBallEventCode, GetComponent<LocalPlayer>().place, rEO, SendOptions.SendReliable);
            photonView.RPC("PlayerShoot", RpcTarget.All, ballInitialPosition.position, attackerValue * attackDirection, ListToByteArray(GameLogicData.Instance.myTeamActNums), ballIndex, (byte)PhotonNetwork.LocalPlayer.ActorNumber);//Vector3 position, Vector3 direction, byte index, byte senderActNum
            GameLogicData.Instance.shootCounter++;
        }
        else if (canDash && !isAttacker)
        {
            if (Physics.Raycast(attackRaycast.position, attackDirection * attackerValue, out hit, attackLineDistance))
            {
                if (hit.transform.gameObject.layer == 7 || hit.transform.gameObject.layer == 8)
                {
                    transform.position = new Vector3(hit.point.x, 2, hit.point.z) - 0.5f * attackerValue * attackDirection;
                }
            }
            else
            {
                transform.position = transform.position + 6 * attackerValue * attackDirection;
            }
            GetComponent<PlayerScript>().dash.SetActive(false);
            AudioManager.Instance.Play(13);
            dashTime = dashLvlTime;
            canDash = false;
            dashTimeText.gameObject.SetActive(true);
        }
        attackButtonDown = false;
    }

    public bool ShootFromSkill(Vector3 attackDirection)
    {
        if (Time.time > nextAttackTime && attackBalls > 0)
        {
            nextAttackTime = Time.time + attackTimeDelay;
            attackBalls--;
            GetComponent<PlayerScript>().projectile[attackBalls].SetActive(false);
            photonView.RPC("DeadlyShoot", RpcTarget.All, ballInitialPosition.position, attackDirection, ListToByteArray(GameLogicData.Instance.myTeamActNums), ballIndex, (byte)PhotonNetwork.LocalPlayer.ActorNumber);//Vector3 position, Vector3 direction, byte[] myTeammates, byte index, byte senderActNum
            GameLogicData.Instance.shootCounter++;
            return true;
        }
        else return false;
    }

    public void AttackButtonDown()
    {
        attackButtonDown = true;
    }
    
    public void MoveButtonUp()
    {
        rigidBody.velocity = playerDirection;
    }

    //TODO MAIN CODE CHARACTER INDEX
    public void SetStartInfo(GameObject move, GameObject attack, TMP_Text dashTimer, int ballIndex, int characterIndex)
    {
        this.ballIndex = (byte)ballIndex;
        dashTimeText = dashTimer;
        movementJoystick = move.GetComponent<Joystick>();
        dashLvlTime = GameLogicData.Instance.characterDSLevels[characterIndex, 0];
        speed *= GameLogicData.Instance.characterDSLevels[characterIndex, 1];
        //Add events to joystick
        EventTrigger moveTrigger = movementJoystick.GetComponent<EventTrigger>();
        EventTrigger.Entry moveEntry = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerUp
        };
        moveEntry.callback.AddListener((eventData) => { MoveButtonUp(); });
        moveTrigger.triggers.Add(moveEntry);

        attackJoystick = attack.GetComponent<Joystick>();
        //Add events to joystick
        EventTrigger attackTrigger = attackJoystick.GetComponent<EventTrigger>();
        EventTrigger.Entry attackEntry = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerDown
        };
        attackEntry.callback.AddListener((eventData) => { AttackButtonDown(); });
        EventTrigger.Entry attackEntry2 = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerUp
        };
        attackEntry2.callback.AddListener((eventData) => { ShootAttackButtonUp(); });
        attackTrigger.triggers.Add(attackEntry);
        attackTrigger.triggers.Add(attackEntry2);
    }
    
    public void SpeedUp(float time)
    {
        speedRatio *= 1.3f;
        speedSkillTime = time;
    }

    private void Move(Vector3 direction)
    {
        rigidBody.velocity = direction * speedRatio;
    }
    
    public void SetCatcherVal(int v)
    {
        attackerValue = v;
    }

    private byte[] ListToByteArray(List<int> myTeamMembersActorNumbers)
    {
        byte[] array = new byte[myTeamMembersActorNumbers.Count];
        for (int i = 0; i < myTeamMembersActorNumbers.Count; i++)
        {
            array[i] = (byte)myTeamMembersActorNumbers[i];
        }
        return array;
    }
}