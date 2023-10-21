using System.Collections;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;
using System.Text;

//BOT oppteammembers with remote players has bot in it for scoring

public class GameLogicPlayer : MonoBehaviour, IOnEventCallback
{
    private const string PLAYERLVLPREF = "lvl";
    private const string MAPINDEXPREF = "map";
    //Constants
    //private readonly string SAVE_NAME = "savegames";

    private const byte BallHitEventCode = 1;
    //private const byte RoundStartEventCode = 2;
    private const byte PlayerPlaceStoneEventCode = 3;
    private const byte EndFirstRoundEventCode = 4;
    private const byte GameStartEventCode = 5;
    //private const byte EndGameEventCode = 8;
    private const byte RoundEndScoreChangeEventCode = 9;
    private const byte StoneZonesChangeEventCode = 10;

    readonly int maxPlayers = 8;

    //DATA
    //private string DATA;

    //UI elements
    [SerializeField] GameObject loadingScreen;
    [SerializeField] GameObject runnerCanvas;
    [SerializeField] GameObject attackerCanvas;
    [SerializeField] GameObject commonCanvas;
    [SerializeField] GameObject controllerCanvas;
    [SerializeField] GameObject endGameCanvas;
    [SerializeField] Camera endGameCamera;
    [SerializeField] Camera mainCamera;
    [SerializeField] GameObject timeAndScore;
    [SerializeField] GameObject panelAvatars;
    [SerializeField] GameObject panelScoreboard;
    [SerializeField] GameObject buttonScoreboard;
    [SerializeField] GameObject buttonToMenu;
    [SerializeField] GameObject buttonNext;
    [SerializeField] GameObject runImage;
    [SerializeField] GameObject catchImage;
    [SerializeField] Image dashButton;
    [SerializeField] List<Sprite> dashButtonRes; // 0 - Catcher  1 - Runner
    [SerializeField] List<Sprite> boardsRes; // 0 - Runners  1 - Catchers
    [SerializeField] Sprite[] lvlBackRes;
    [SerializeField] List<Sprite> rightJoystickImage;// 0 - Catcher, 1 - Runner
    [SerializeField] List<Image> commonAvatars;
    [SerializeField] List<Image> runnersAvatarsOnAttackerCanvas;
    [SerializeField] List<Image> stonesOnRunnerCanvas;
    //[SerializeField] List<Image> ballIconsOnCommonCanvas; // TODO Change Ball place to Canvas
    [SerializeField] TMP_Text textWaiting;
    [SerializeField] TMP_Text textTimer;
    [SerializeField] TMP_Text myLeftScore;
    [SerializeField] TMP_Text opponentRightScore;

    [SerializeField] GameObject runnerSkillButton;
    [SerializeField] TMP_Text runnerSkillTime;
    [SerializeField] GameObject catcherSkillButton;
    [SerializeField] TMP_Text catcherSkillTime;
    [HideInInspector] GameObject currentSkillButton;
    [HideInInspector] TMP_Text currentSkillTime;
    [SerializeField] Sprite[] runnerSkillImageRes;
    [SerializeField] Sprite[] catcherSkillImageRes;
    //

    //Scoreboard
    [SerializeField] Image myTeamBoard;
    [SerializeField] Image oppTeamBoard;
    [SerializeField] List<Image> myTeamLvlsImages;
    [SerializeField] List<Image> oppTeamLvlsImages;
    [SerializeField] List<Image> myTeamAvatars;
    [SerializeField] List<Image> oppTeamAvatars;
    [SerializeField] List<TMP_Text> myTeamNicknames;
    [SerializeField] List<TMP_Text> oppTeamNicknames;
    [SerializeField] List<TMP_Text> myTeamLvls;
    [SerializeField] List<TMP_Text> oppTeamLvls;
    [SerializeField] List<TMP_Text> myTeamScores;
    [SerializeField] List<TMP_Text> oppTeamScores;
    [SerializeField] List<TMP_Text> myTeamShoots;
    [SerializeField] List<TMP_Text> oppTeamShoots;
    [SerializeField] List<TMP_Text> myTeamStones;
    [SerializeField] List<TMP_Text> oppTeamStones;
    [SerializeField] TMP_Text myTeamScoreTxt;
    [SerializeField] TMP_Text oppTeamScoreTxt;
    [SerializeField] TMP_Text roundScoreboard;
    [SerializeField] TMP_Text myTeamName;
    [SerializeField] TMP_Text oppTeamName;
    //

    //EndGameUI
    //ScoreBoard
    [SerializeField] Sprite winBackImage;
    [SerializeField] Sprite loseBackImage;
    [SerializeField] Image backImage;
    [SerializeField] List<Image> myTeamLvlsImagesEnd;
    [SerializeField] List<Image> oppTeamLvlsImagesEnd;
    [SerializeField] List<Image> myTeamAvatarsEnd;
    [SerializeField] List<Image> oppTeamAvatarsEnd;
    [SerializeField] List<TMP_Text> myTeamNicknamesEnd;
    [SerializeField] List<TMP_Text> oppTeamNicknamesEnd;
    [SerializeField] List<GameObject> myTeamMVPsEnd;
    [SerializeField] List<GameObject> oppTeamMVPsEnd;
    [SerializeField] List<TMP_Text> myTeamLvlsEnd;
    [SerializeField] List<TMP_Text> oppTeamLvlsEnd;
    [SerializeField] List<TMP_Text> myTeamScoresEnd;
    [SerializeField] List<TMP_Text> oppTeamScoresEnd;
    [SerializeField] List<TMP_Text> myTeamShootsEnd;
    [SerializeField] List<TMP_Text> oppTeamShootsEnd;
    [SerializeField] List<TMP_Text> myTeamStonesEnd;
    [SerializeField] List<TMP_Text> oppTeamStonesEnd;
    [SerializeField] TMP_Text myTeamScoreTxtEnd;
    [SerializeField] TMP_Text oppTeamScoreTxtEnd;
    [SerializeField] TMP_Text myTeamWLEnd;
    [SerializeField] TMP_Text oppTeamWLEnd;
    //UI
    /*[SerializeField] RectTransform threeIcon;
    [SerializeField] RectTransform ball;
    [SerializeField] RectTransform stone;
    [SerializeField] RectTransform star;
    [SerializeField] RectTransform cup;
    [SerializeField] RectTransform mvp;
    [SerializeField] RectTransform coin;
    [SerializeField] RectTransform XP;
    [SerializeField] TMP_Text cnTxt;
    [SerializeField] TMP_Text xpTxt;
    */
    [SerializeField] GameObject[] mvpOnCharsEnd;
    [SerializeField] List<TMP_Text> characterNames;
    [SerializeField] List<TMP_Text> characterLevels;
    [SerializeField] RectTransform threeIcon;
    [SerializeField] TMP_Text myBallLeftPanel;
    [SerializeField] TMP_Text myStoneLeftPanel;
    [SerializeField] TMP_Text myScoreLeftPanel;
    [SerializeField] TMP_Text myCoinUpPanel;
    [SerializeField] TMP_Text myXPUpPanel;
    [SerializeField] GameObject winImageLeftPanel;
    [SerializeField] GameObject mVPImageLeftPanel;
    [SerializeField] GameObject scoreBoardEnd;
    [SerializeField] GameObject exitButton;
    //

    //[SerializeField] GameObject[] stoneZones;
    [SerializeField] GameObject sDTrapGhost;
    [SerializeField] GameObject trapGhost;
    [SerializeField] GameObject wallGhost;
    [SerializeField] GameObject hookGhost;
    [SerializeField] LineRenderer hookLine;
    [SerializeField] LineRenderer deadlyHitLine;
    [SerializeField] GameObject runnerCancelSkill;
    [SerializeField] Joystick runnerSkillJoystick;
    [SerializeField] GameObject catcherCancelSkill;
    [SerializeField] Joystick catcherSkillJoystick;
    [SerializeField] GameObject[] stones;
    [SerializeField] GameObject cinemachine;
    [SerializeField] RectTransform map;
    [SerializeField] Light directionalLight;
    [SerializeField] GameObject[] endGameCharacters;
    [SerializeField] GameObject[] offlineCharacters;

    //Data for scoreboard
    Dictionary<int, Pair<byte, byte>> allPlayersIDPlace;
    Dictionary<int, string> allPlayersNicknames;
    [HideInInspector] public Dictionary<int, RemotePlayer> myTeamMembers;
    [HideInInspector] public Dictionary<int, RemotePlayer> oppTeamMembers;
    [HideInInspector] public Dictionary<int, RemotePlayer> oppTeamBots;
    //

    //Skills
    [HideInInspector] public int runnerSkill;
    [HideInInspector] public int runnerSkillLevel;
    [HideInInspector] public int catcherSkill;
    [HideInInspector] public int catcherSkillLevel;
    [SerializeField] int currentSkill;//0 - Extra Ball OR Extra Life, 1 - shield, 2 - invisibility, 3 - trap, 4 - slowdowntrap, 5 - topView, 6 - wall, 7 - hook, 8 - deadlyHit, 9 - botClone
    float skillRefreshTime;
    float currentSkillTimeLVL;
    bool hookRay = false;
    bool drag = false;
    Vector3 hookDirection;
    Color32 colorSkill;
    List<GameObject> teamMateGameObjects;

    //
    StringBuilder sb;
    GameLogicServer gameLogic;
    GameObject myGameObject;
    GameObject movementJoystick;
    GameObject attackJoystick;

    //
    List<int> myTeamMembersActorNumbers; // Local player is not in
    List<int> oppTeamMembersActorNumbers;

    //My "RemotePlayer"
    private int charIndex;
    private int catcherValue = 1;
    private Pair<byte, byte> myIdAndPlace;
    private int myScore = 0;
    private byte myStones = 0;
    private byte myShoot = 0;
    private bool isDead = false;
    private int myTeamScore = 0;
    private int oppTeamScore = 0;
    [HideInInspector] public byte lives = 1;


    //Only MasterClient
    int placedStonesCounter = 0;
    int runnersLeft = 4;

    //Follow player
    int followIndex = 0; // After hit follow other players. Index for List
    int deadPeople = 0;

    //Time
    int gameTime = 180;
    float serverGameStartTime; // Photon.Time
    float firstRoundStartTime; // Photon.Time
    float secondRoundStartTime; // Photon.Time
    float changeStonesTime;
    bool firstRoundStart = false; // True when game (not round) start and false after first round start
    bool firstRoundEnd = false; // True when first round end and false after second round start
    bool roundStart = false;
    bool firstRound = true;

    private void Start()
    {
        sb = new StringBuilder();
        StartCoroutine(WaitingPlayers());
        gameLogic = GetComponent<GameLogicServer>();
        MapScript.Instance.currentMap = PlayerPrefs.GetInt(MAPINDEXPREF);
        SceneManager.LoadSceneAsync(string.Format("Map{0}", MapScript.Instance.currentMap + 1), LoadSceneMode.Additive);//.completed += (_) => { for (int i = 0; i < SceneManager.sceneCount; i++) Debug.Log(SceneManager.GetSceneAt(i).name); };
    }

    // Update is called once per frame
    void Update()
    {
        if(firstRoundStart && PhotonNetwork.Time > firstRoundStartTime)
        {
            StartCoroutine(StartFirstRound());
        }
        if(firstRoundEnd && PhotonNetwork.Time > secondRoundStartTime)
        {
            StartCoroutine(StartSecondRound());
        }
        //Random Stone Zones Change
        if (roundStart && Time.time > changeStonesTime && PhotonNetwork.IsMasterClient)
        {
            ChangeStoneZones();
            changeStonesTime = Time.time + 30f;
        }
    }
    
    IEnumerator TimerUpdate()
    {
        while(true)
        {
            if (roundStart && gameTime <= 5 && gameTime > 0)
            {
                if(gameTime > 1)
                {
                    AudioManager.Instance.Play(19);
                }
                else
                {
                    AudioManager.Instance.Play(20);
                }
            }
            
            if(roundStart && gameTime <= 0)
            {
                textTimer.text = "0:00";
                EndRound();
                yield break;
            }
            else if (!roundStart)
            {
                yield break;
            }
            textTimer.text = sb.Append(gameTime / 60).Append(":").Append(gameTime % 60).ToString();
            gameTime -= 1;
            sb.Clear();
            yield return new WaitForSecondsRealtime(1f);
        }
    }

    IEnumerator WaitingPlayers()
    {
        while (true)
        {
            if (firstRoundStart)
            {
                StartCoroutine(StartTimer());
                yield break;
            }
            textWaiting.text = sb.Append("Waiting for players: ").Append(PhotonNetwork.PlayerList.Length).Append("/8").ToString();// string.Format("Waiting for players: {0}/8", PhotonNetwork.PlayerList.Length);
            sb.Clear();
            yield return new WaitForSeconds(.3f);
        }
    }

    IEnumerator StartTimer()
    {
        while (true)
        {
            if (firstRoundStart && (firstRoundStartTime - PhotonNetwork.Time > 0))
            {
                textWaiting.text = sb.Append((int)(firstRoundStartTime - PhotonNetwork.Time)).ToString();// string.Format("{0}", (int)(firstRoundStartTime - PhotonNetwork.Time));
                sb.Clear();
                yield return new WaitForSeconds(.1f);
            }
            else
            {
                yield break;
            }
        }
    }
    void FixedUpdate()
    {
        if (skillRefreshTime > 0)
        {
            skillRefreshTime -= Time.fixedDeltaTime;
            currentSkillTime.text = ((int)skillRefreshTime + 1).ToString();
            if(skillRefreshTime <= 0)
            {
                colorSkill = currentSkillButton.GetComponent<Image>().color ;
                colorSkill.a = 255;
                currentSkillButton.GetComponent<Image>().color = colorSkill;
                currentSkillTime.enabled = false;
            }
        }
    }
    
    public void OnEvent(EventData photonEvent)
    {
        byte eventCode = photonEvent.Code;

        if (eventCode == BallHitEventCode)
        {
            //Disable player movement if i was hit
            if (roundStart)
            {
                byte whoShootBall = (byte)((object[])photonEvent.CustomData)[0];
                byte whoHitBall = (byte)((object[])photonEvent.CustomData)[1];
                byte place;
                if(PhotonNetwork.IsMasterClient && whoHitBall >= 100)// BOT was hit
                {
                    AudioManager.Instance.Play(12);
                    foreach (GameObject bot in GameObjectsData.Instance.bots)
                    {
                        if(bot.GetComponent<LocalPlayer>().actNum == whoHitBall)
                        {
                            bot.GetPhotonView().RPC("LostLifeBOT", RpcTarget.All);
                        }
                    }
                }
                if (myGameObject.GetComponent<LocalPlayer>().isCatcher ) //We are catchers
                {
                    if (!oppTeamMembers[whoHitBall].isDead)
                    {
                        AudioManager.Instance.Play(12);
                        myTeamScore += 100;
                        myLeftScore.text = myTeamScore.ToString();
                        myTeamScoreTxt.text = myTeamScore.ToString();
                        oppTeamMembers[whoHitBall].isDead = true;

                        if (PhotonNetwork.LocalPlayer.ActorNumber == whoShootBall) // I shot ball
                        {
                            myScore += 100;
                            myTeamScores[myIdAndPlace.Second].text = myScore.ToString();
                            myShoot++;
                            myTeamShoots[myIdAndPlace.Second].text = myShoot.ToString();
                        }
                        else // My teammate shot ball
                        {
                            myTeamMembers[whoShootBall].score += 100;
                            myTeamScores[myTeamMembers[whoShootBall].Place].text = myTeamMembers[whoShootBall].score.ToString();
                            myTeamMembers[whoShootBall].shoot++;
                            myTeamShoots[myTeamMembers[whoShootBall].Place].text = myTeamMembers[whoShootBall].shoot.ToString();
                        }
                        place = oppTeamMembers[whoHitBall].Place; // Runner's avatar on attacker canvas
                        runnersLeft--;

                        Color avatarColorRunner = runnersAvatarsOnAttackerCanvas[place].color;
                        avatarColorRunner.a = 0.25f;
                        runnersAvatarsOnAttackerCanvas[place].color = avatarColorRunner;
                    }
                }
                else// We are runners
                {
                    if (whoHitBall == PhotonNetwork.LocalPlayer.ActorNumber) // I was hit
                    {
                        if (!isDead)
                        {
                            AudioManager.Instance.Play(12);
                            isDead = true;
                            GameLogicData.Instance.enduranceTime = (int)(180f - gameTime);
                            place = myIdAndPlace.Second;
                            myGameObject.GetPhotonView().RPC("LostLife", RpcTarget.All);
                            buttonNext.SetActive(true);

                            oppTeamScore += 100;
                            opponentRightScore.text = oppTeamScore.ToString();
                            oppTeamScoreTxt.text = oppTeamScore.ToString();

                            oppTeamMembers[whoShootBall].score += 100;
                            oppTeamScores[oppTeamMembers[whoShootBall].Place].text = oppTeamMembers[whoShootBall].score.ToString();
                            oppTeamMembers[whoShootBall].shoot++;
                            oppTeamShoots[oppTeamMembers[whoShootBall].Place].text = oppTeamMembers[whoShootBall].shoot.ToString();
                            runnersLeft--;
                            runnerSkillButton.SetActive(false);

                            if (currentSkill == 3) trapGhost.SetActive(false);
                            else if (currentSkill == 4) sDTrapGhost.SetActive(false);
                            else if (currentSkill == 6) wallGhost.SetActive(false);
                            else if (currentSkill == 7)
                            {
                                hookGhost.SetActive(false);
                                hookLine.gameObject.SetActive(false);
                            }

                            Color avatarColor = commonAvatars[place].color;
                            avatarColor.a = 0.25f;
                            commonAvatars[place].color = avatarColor;
                        }
                    }
                    else // My teammate was hit
                    {
                        if (!myTeamMembers[whoHitBall].isDead)
                        {
                            AudioManager.Instance.Play(12);
                            oppTeamScore += 100;
                            opponentRightScore.text = oppTeamScore.ToString();
                            oppTeamScoreTxt.text = oppTeamScore.ToString();

                            oppTeamMembers[whoShootBall].score += 100;
                            oppTeamScores[oppTeamMembers[whoShootBall].Place].text = oppTeamMembers[whoShootBall].score.ToString();
                            oppTeamMembers[whoShootBall].shoot++;
                            oppTeamShoots[oppTeamMembers[whoShootBall].Place].text = oppTeamMembers[whoShootBall].shoot.ToString();
                            runnersLeft--;

                            myTeamMembers[whoHitBall].isDead = true;
                            place = myTeamMembers[whoHitBall].Place;
                            Color avatarColor = commonAvatars[place].color;
                            avatarColor.a = 0.25f;
                            commonAvatars[place].color = avatarColor;
                        }
                    }
                }                
                
                if (runnersLeft == 0)
                {
                    float timeDiff = (float)PhotonNetwork.Time - (float)((object[])photonEvent.CustomData)[2];
                    int scoreDiff = (int)(gameTime - timeDiff) * 10;
                    if(PhotonNetwork.LocalPlayer.ActorNumber == whoShootBall) // If I shot last runner
                    {
                        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
                        object[] content = { myIdAndPlace.First, scoreDiff};
                        PhotonNetwork.RaiseEvent(RoundEndScoreChangeEventCode,content,raiseEventOptions,SendOptions.SendReliable);
                    }
                    else if (PhotonNetwork.IsMasterClient && whoShootBall >= 100) // I am master AND BOT shot player
                    {
                        if (myTeamMembersActorNumbers.Contains(whoShootBall)) //BOT is my teammate
                        {
                            RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
                            object[] content = { myIdAndPlace.First, scoreDiff };
                            PhotonNetwork.RaiseEvent(RoundEndScoreChangeEventCode, content, raiseEventOptions, SendOptions.SendReliable);
                        }
                        else // BOT is opponent
                        {
                            RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
                            object[] content = {(byte)(myIdAndPlace.First == 1 ? 2 : 1), scoreDiff };
                            PhotonNetwork.RaiseEvent(RoundEndScoreChangeEventCode, content, raiseEventOptions, SendOptions.SendReliable);
                        }
                    }
                    EndRound();
                }
            }
        }

        // TODO IMPORTANT:      when one player disconnect send info and change runner left value
        else if(eventCode == PlayerPlaceStoneEventCode)
        {
            byte whoPlaceStone = (byte)((object[])photonEvent.CustomData)[1];
            stones[placedStonesCounter].SetActive(true);
            placedStonesCounter++;
            GameLogicData.Instance.placedStonesCounter++;
            //Score change and change color of stone image on Runner Canvas
            if (!myGameObject.GetComponent<LocalPlayer>().isCatcher) // We are Runners
            {
                Color avatarColor = stonesOnRunnerCanvas[placedStonesCounter-1].color;
                avatarColor.a = 1f;
                stonesOnRunnerCanvas[placedStonesCounter - 1].color = avatarColor;

                myTeamScore += 100;
                myLeftScore.text = myTeamScore.ToString();
                myTeamScoreTxt.text = myTeamScore.ToString();

                if(PhotonNetwork.LocalPlayer.ActorNumber == whoPlaceStone)
                {
                    myScore += 100;
                    myTeamScores[myIdAndPlace.Second].text = myScore.ToString();
                    myStones++;
                    myTeamStones[myIdAndPlace.Second].text = myStones.ToString();
                }
                else
                {
                    myTeamMembers[whoPlaceStone].score += 100;
                    myTeamScores[myTeamMembers[whoPlaceStone].Place].text = myTeamMembers[whoPlaceStone].score.ToString();
                    myTeamMembers[whoPlaceStone].stones++;
                    myTeamStones[myTeamMembers[whoPlaceStone].Place].text = myTeamMembers[whoPlaceStone].stones.ToString();
                }
            }
            else // We are Catchers
            {
                oppTeamScore += 100;
                opponentRightScore.text = oppTeamScore.ToString();
                oppTeamScoreTxt.text = oppTeamScore.ToString();

                oppTeamMembers[whoPlaceStone].score += 100;
                oppTeamScores[oppTeamMembers[whoPlaceStone].Place].text = oppTeamMembers[whoPlaceStone].score.ToString();
                oppTeamMembers[whoPlaceStone].stones ++;
                oppTeamStones[oppTeamMembers[whoPlaceStone].Place].text = oppTeamMembers[whoPlaceStone].stones.ToString();

            }

            //Zone color change on map
            int whichStone = int.Parse((string)((object[])photonEvent.CustomData)[0]);
            ParticleSystem.MainModule main = MapScript.Instance.randomPoss[whichStone].GetComponent<ParticleSystem>().main;
            main.startColor = Color.green;
            GameLogicData.Instance.collectedStones[whichStone] = 1;

            //If last stone - add time score and end game
            if (placedStonesCounter == 7)
            {
                float timeDiff = (float)PhotonNetwork.Time - (float)((object[])photonEvent.CustomData)[2];
                int scoreDiff = (int)(gameTime - timeDiff) * 10;
                if (PhotonNetwork.LocalPlayer.ActorNumber == whoPlaceStone) // If I placed last stone
                {
                    RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
                    object[] content = { myIdAndPlace.First, scoreDiff };
                    PhotonNetwork.RaiseEvent(RoundEndScoreChangeEventCode, content, raiseEventOptions, SendOptions.SendReliable);
                }
                else if(PhotonNetwork.IsMasterClient && whoPlaceStone >= 100) // I am master AND BOT place stone
                {
                    if (myTeamMembersActorNumbers.Contains(whoPlaceStone)) //BOT is my teammate
                    {
                        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
                        object[] content = { myIdAndPlace.First, scoreDiff };
                        PhotonNetwork.RaiseEvent(RoundEndScoreChangeEventCode, content, raiseEventOptions, SendOptions.SendReliable);
                    }
                    else // BOT is opponent
                    {
                        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
                        object[] content = { (byte)(myIdAndPlace.First == 1 ? 2 : 1), scoreDiff };
                        PhotonNetwork.RaiseEvent(RoundEndScoreChangeEventCode, content, raiseEventOptions, SendOptions.SendReliable);
                    }
                }
                AudioManager.Instance.Play(15);
                EndRound();
            }
            else
            {
                AudioManager.Instance.Play(14);
            }
        }

        else if(eventCode == GameStartEventCode) // Game will start after 5 seconds
        {
            AudioManager.Instance.Stop(0);
            AudioManager.Instance.Play(18);
            gameLogic.GameStarted();
            SetPlayersData();

            //First round start time is here - 5;
            serverGameStartTime = (float)((object[])photonEvent.CustomData)[0];
            firstRoundStartTime = serverGameStartTime + 5;
            firstRoundStart = true;

            myIdAndPlace = allPlayersIDPlace[PhotonNetwork.LocalPlayer.ActorNumber];
            GameLogicData.Instance.myTeamID = myIdAndPlace.First;

            //Canvas setting
            timeAndScore.SetActive(true);

            SetTeams();
            myGameObject.GetComponent<PlayerMovement>().GameStart();

            byte lvl = (byte)PlayerPrefs.GetInt(PLAYERLVLPREF);
            myGameObject.GetPhotonView().RPC("SetTeamInfo",RpcTarget.All,myIdAndPlace.First,myIdAndPlace.Second, ListToByteArray(myTeamMembersActorNumbers), lives, lvl);

            byte random = (byte)((object[])photonEvent.CustomData)[1];
            if (PhotonNetwork.IsMasterClient) //All players has bots in GameObjectsData for master client changing
            {
                foreach (var bot in GameObjectsData.Instance.bots)
                {
                    if(bot.GetComponent<LocalPlayer>().IdAndPlace.First == 1)
                    {
                        bot.transform.position = GameLogicData.Instance.mapsCatcherStartPositions[bot.GetComponent<LocalPlayer>().IdAndPlace.Second];
                        bot.GetPhotonView().RPC("SetBotInfo", RpcTarget.All, ListToByteArray(myTeamMembersActorNumbers));
                    }
                    else
                    {
                        bot.transform.position = GameLogicData.Instance.mapsRunnerStartPositions[MapScript.Instance.currentMap, random,bot.GetComponent<LocalPlayer>().IdAndPlace.Second];
                        bot.GetPhotonView().RPC("SetBotInfo", RpcTarget.All, ListToByteArray(oppTeamMembersActorNumbers));
                    }
                }
            }

            if (myIdAndPlace.First == 1) // I am Catcher
            {
                catcherValue = 1;
                runnersLeft = oppTeamMembersActorNumbers.Count;
                myGameObject.transform.position = GameLogicData.Instance.mapsCatcherStartPositions[myIdAndPlace.Second];
            }
            else // I am Runner
            {
                catcherValue = -1;
                runnersLeft = myTeamMembersActorNumbers.Count + 1;
                myGameObject.transform.position = GameLogicData.Instance.mapsRunnerStartPositions[MapScript.Instance.currentMap, random, myIdAndPlace.Second];
                GameLogicData.Instance.myStartPoint = myGameObject.transform.position;
            }
            GameLogicData.Instance.alivePlayers = runnersLeft;
            placedStonesCounter = 0;
            GameLogicData.Instance.placedStonesCounter = 0;
            if (PhotonNetwork.IsMasterClient) ChangeStoneZones();
        }

        else if(eventCode == EndFirstRoundEventCode)
        {
            firstRoundEnd = true;
            secondRoundStartTime = (float)((object[])photonEvent.CustomData)[0] + 6;
            if (myIdAndPlace.First == 2)
            {
                catcherValue = 1;
                runnersLeft = oppTeamMembersActorNumbers.Count;
            }
            else
            {
                catcherValue = -1;
                runnersLeft = myTeamMembersActorNumbers.Count + 1;
            }
            byte random = (byte)((object[])photonEvent.CustomData)[1];
            if (PhotonNetwork.IsMasterClient)
            {
                foreach (var bot in GameObjectsData.Instance.bots)
                {
                    if (bot.GetComponent<LocalPlayer>().IdAndPlace.First == 2)
                    {
                        bot.GetComponent<BotController>().ChangePosition(GameLogicData.Instance.mapsCatcherStartPositions[bot.GetComponent<LocalPlayer>().IdAndPlace.Second]);
                    }
                    else
                    {
                        bot.GetComponent<BotController>().ChangePosition(GameLogicData.Instance.mapsRunnerStartPositions[MapScript.Instance.currentMap, random, bot.GetComponent<LocalPlayer>().IdAndPlace.Second]);
                    }
                    bot.GetComponent<BotController>().RoundEnd();
                    bot.GetPhotonView().RPC("ShowCharacterBOT", RpcTarget.AllBuffered);
                }
            }

            if (myIdAndPlace.First == 2) // I am Catcher
            {
                runnersLeft = oppTeamMembersActorNumbers.Count;
                myGameObject.transform.position = GameLogicData.Instance.mapsCatcherStartPositions[myIdAndPlace.Second];
            }
            else // I am Runner
            {
                runnersLeft = myTeamMembersActorNumbers.Count + 1;
                myGameObject.transform.position = GameLogicData.Instance.mapsRunnerStartPositions[MapScript.Instance.currentMap, random, myIdAndPlace.Second];
                GameLogicData.Instance.myStartPoint = myGameObject.transform.position;
            }

            GameLogicData.Instance.alivePlayers = runnersLeft;
            placedStonesCounter = 0;
            GameLogicData.Instance.placedStonesCounter = 0;
            if(PhotonNetwork.IsMasterClient) ChangeStoneZones();
            foreach (var s in stones) s.SetActive(false);
            myGameObject.GetComponent<PlayerMovement>().GameStart();
        }

        else if(eventCode == RoundEndScoreChangeEventCode)
        {
            byte teamId = (byte)((object[])photonEvent.CustomData)[0];
            int scoreDiff = (int)((object[])photonEvent.CustomData)[1];
            if (myIdAndPlace.First == teamId)
            {
                myTeamScore += scoreDiff;
                myLeftScore.text = myTeamScore.ToString();
                myTeamScoreTxt.text = myTeamScore.ToString();
            }
            else
            {
                oppTeamScore += scoreDiff;
                opponentRightScore.text = oppTeamScore.ToString();
                oppTeamScoreTxt.text = oppTeamScore.ToString();
            }
        }

        else if(eventCode == StoneZonesChangeEventCode)
        {
            byte[] data = (byte[])photonEvent.CustomData;
            MapScript.Instance.ChangeZonesManually(data);
            if (PhotonNetwork.IsMasterClient)
            {
                foreach(GameObject bot in GameObjectsData.Instance.bots)
                {
                    bot.GetComponent<BotController>().ZonesChanged();
                }
            }
        }
    }
    
    private void SetPlayersData()
    {
        allPlayersNicknames = new Dictionary<int, string>();
        allPlayersIDPlace = new Dictionary<int, Pair<byte, byte>>();
        int playerCount = PhotonNetwork.PlayerList.Length;
        if (playerCount == 0)
        {
            //Debug.LogError("Room created but nobody is in the room!!!");
            SceneManager.LoadScene(0);
        }
        else
        {
            int i;
            for (i = 0; i < playerCount; i++)
            {
                // 0 1 2 3 4 5 6 7
                allPlayersNicknames.Add(PhotonNetwork.PlayerList[i].ActorNumber, PhotonNetwork.PlayerList[i].NickName);
                allPlayersIDPlace.Add(PhotonNetwork.PlayerList[i].ActorNumber, new Pair<byte, byte>((byte)(i % 2 == 0 ? 1 : 2), (byte)(i / 2)));
            }

            //BOT bots teaming start here
            //BOT code
            for (int j = 0;i<maxPlayers;i++,j++)
            {
                allPlayersNicknames.Add(100 + j, string.Format("BOT{0}",j));
                allPlayersIDPlace.Add(100 + j, new Pair<byte, byte>((byte)(i % 2 == 0 ? 1 : 2), (byte)(i / 2)));
            }
            //
        }
    }

    private void SetTeams()
    {
        teamMateGameObjects = new List<GameObject>();
        oppTeamMembersActorNumbers = new List<int>();
        myTeamMembersActorNumbers = new List<int>();
        oppTeamMembers = new Dictionary<int, RemotePlayer>();
        myTeamMembers = new Dictionary<int, RemotePlayer>();

        foreach (int actorNumber in allPlayersIDPlace.Keys)
        {
            if (actorNumber != PhotonNetwork.LocalPlayer.ActorNumber)
            {
                if (allPlayersIDPlace[actorNumber].First == myIdAndPlace.First)
                {
                    myTeamMembersActorNumbers.Add((byte)actorNumber);
                    myTeamMembers.Add(actorNumber, new RemotePlayer(allPlayersIDPlace[actorNumber].First, allPlayersIDPlace[actorNumber].Second, (byte)actorNumber));
                }
                else
                {
                    oppTeamMembersActorNumbers.Add(actorNumber);
                    oppTeamMembers.Add(actorNumber, new RemotePlayer(allPlayersIDPlace[actorNumber].First, allPlayersIDPlace[actorNumber].Second, (byte)actorNumber));
                }
            }
        }

        GameLogicData.Instance.myTeamActNums = myTeamMembersActorNumbers;

        //For Camera Follow
        GameObject[] playersGameObjects = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject gO in playersGameObjects)
        {
            if (myTeamMembersActorNumbers.Contains(gO.GetPhotonView().OwnerActorNr))
            {
                teamMateGameObjects.Add(gO);
            }
        }

        //BOT code
        GameObject[] botsGameObjects = GameObject.FindGameObjectsWithTag("Bot");
        foreach(GameObject bot in botsGameObjects)
        {
            if (myTeamMembersActorNumbers.Contains(bot.GetComponent<LocalPlayer>().actNum))
            {
                teamMateGameObjects.Add(bot);
            }
        }
        //
    }

    private void SetAvatarsFirstRound()
    {
        if (myIdAndPlace.First == 1) // We are catchers
        {
            myTeamBoard.sprite = boardsRes[1];
            foreach(Image image in myTeamLvlsImages) image.sprite = lvlBackRes[1];
            oppTeamBoard.sprite = boardsRes[0];
            foreach(Image image in oppTeamLvlsImages) image.sprite = lvlBackRes[0];
            myTeamName.text = "catchers";
            //myTeamName.color = new Color32(167,68,0,255);
            oppTeamName.text = "runners";
            //oppTeamName.color = new Color32(0,110,0,255);
            //00BA00 - green FF6600 - orange
            myLeftScore.color = new Color32(10, 157, 241, 255);
            //myTeamScoreTxt.color = new Color32(10, 157, 241, 255);
            opponentRightScore.color = new Color32(186, 44, 255, 255);
            //oppTeamScoreTxt.color = new Color32(186, 44, 255, 255);
        }
        else // We are runners
        {
            myTeamBoard.sprite = boardsRes[0];
            foreach(Image image in myTeamLvlsImages) image.sprite = lvlBackRes[0];
            oppTeamBoard.sprite = boardsRes[1];
            foreach(Image image in oppTeamLvlsImages) image.sprite = lvlBackRes[1];
            myTeamName.text = "runners";
            //myTeamName.color = new Color32(0,110,0,255);
            oppTeamName.text = "catchers";
            //oppTeamName.color = new Color32(167,68,0,255);
            myLeftScore.color = new Color32(186, 44, 255, 255);
            //myTeamScoreTxt.color = new Color32(186, 44, 255, 255);
            opponentRightScore.color = new Color32(10, 157, 241, 255);
            //oppTeamScoreTxt.color = new Color32(10, 157, 241, 255);
        }
        //TODO EndGame characters initializing will be here
        Sprite avatar;
        int i = 0, j = 1;
        for (; i < PhotonNetwork.PlayerList.Length;i++)
        {
            charIndex = (int)PhotonNetwork.PlayerList[i].CustomProperties["c"];
            avatar = GameObjectsData.Instance.avatarsRes[charIndex];
            int pAN = PhotonNetwork.PlayerList[i].ActorNumber;
            if (myTeamMembers.ContainsKey(pAN))
            {
                commonAvatars[myTeamMembers[pAN].Place].sprite = avatar;
                myTeamAvatars[myTeamMembers[pAN].Place].sprite = avatar;
                myTeamNicknames[myTeamMembers[pAN].Place].text = PhotonNetwork.PlayerList[i].NickName;
                myTeamLvls[myTeamMembers[pAN].Place].text = GameLogicData.Instance.playerLvls[pAN].ToString();
                characterNames[j].text = PhotonNetwork.PlayerList[i].NickName; //EndGameUI
                GameObjectsData.Instance.endGameChars.Add(Instantiate(offlineCharacters[charIndex], endGameCharacters[j].transform));
                characterLevels[j++].text = GameLogicData.Instance.playerLvls[pAN].ToString();
            }
            else if (oppTeamMembers.ContainsKey(pAN))
            {
                runnersAvatarsOnAttackerCanvas[oppTeamMembers[pAN].Place].sprite = avatar;
                oppTeamAvatars[oppTeamMembers[pAN].Place].sprite = avatar;
                oppTeamNicknames[oppTeamMembers[pAN].Place].text = PhotonNetwork.PlayerList[i].NickName;
                oppTeamLvls[oppTeamMembers[pAN].Place].text = GameLogicData.Instance.playerLvls[pAN].ToString();
            }
            else//it is me
            {
                commonAvatars[myIdAndPlace.Second].sprite = avatar;
                myTeamAvatars[myIdAndPlace.Second].sprite = avatar;
                myTeamNicknames[myIdAndPlace.Second].text = PhotonNetwork.LocalPlayer.NickName;
                myTeamLvls[myIdAndPlace.Second].text = GameLogicData.Instance.playerLvls[pAN].ToString();
                characterNames[0].text = PhotonNetwork.LocalPlayer.NickName;
                GameObjectsData.Instance.endGameChars.Add(Instantiate(offlineCharacters[charIndex], endGameCharacters[0].transform));
                characterLevels[0].text = GameLogicData.Instance.playerLvls[PhotonNetwork.LocalPlayer.ActorNumber].ToString();
            }
        }
        foreach (GameObject bot in GameObjectsData.Instance.bots)
        {
            int pAN = bot.GetComponent<LocalPlayer>().actNum;
            avatar = bot.GetComponent<LocalPlayer>().avatar;
            if (myTeamMembers.ContainsKey(pAN))
            {
                commonAvatars[myTeamMembers[pAN].Place].sprite = avatar;
                myTeamAvatars[myTeamMembers[pAN].Place].sprite = avatar;
                //myTeamNicknames[myTeamMembers[pAN].Place].text = string.Format("BOT{0}",pAN);
                myTeamNicknames[myTeamMembers[pAN].Place].text = bot.GetComponent<LocalPlayer>().nickName;
                myTeamLvls[myTeamMembers[pAN].Place].text = GameLogicData.Instance.playerLvls[pAN].ToString();
                //characterNames[j].text = string.Format("BOT{0}",pAN);
                characterNames[j].text = bot.GetComponent<LocalPlayer>().nickName;
                GameObjectsData.Instance.endGameChars.Add(Instantiate(offlineCharacters[bot.GetComponent<LocalPlayer>().charIndex], endGameCharacters[j].transform));
                characterLevels[j++].text = GameLogicData.Instance.playerLvls[pAN].ToString();
            }
            else if (oppTeamMembers.ContainsKey(pAN))
            {
                runnersAvatarsOnAttackerCanvas[oppTeamMembers[pAN].Place].sprite = avatar;
                oppTeamAvatars[oppTeamMembers[pAN].Place].sprite = avatar;
                //oppTeamNicknames[oppTeamMembers[pAN].Place].text = string.Format("BOT{0}", pAN);
                oppTeamNicknames[oppTeamMembers[pAN].Place].text = bot.GetComponent<LocalPlayer>().nickName;
                oppTeamLvls[oppTeamMembers[pAN].Place].text = GameLogicData.Instance.playerLvls[pAN].ToString();
            }
        }
    }
    
    private IEnumerator StartFirstRound()
    {
        firstRoundStart = false;
        loadingScreen.SetActive(false);
        if(myIdAndPlace.First == 1)
        {
            map.rotation = Quaternion.Euler(0, 0, 0);
            cinemachine.transform.rotation = Quaternion.Euler(65, 0, 0);
            LeanTween.scale(catchImage, Vector3.one, .4f);
            LeanTween.value(catchImage, 0, 1, .4f).setOnUpdate(SetAlphaCatcher);
            yield return new WaitForSeconds(1.6f);
            LeanTween.scale(catchImage, Vector3.zero, .4f);
            LeanTween.value(catchImage, 1, 0, .4f).setOnUpdate(SetAlphaCatcher);
            Destroy(catchImage, .4f);
        }
        else
        {
            map.rotation = Quaternion.Euler(0, 0, 180);
            cinemachine.transform.rotation = Quaternion.Euler(65, 180, 0);
            LeanTween.scale(runImage, Vector3.one, .4f);
            LeanTween.value(runImage, 0, 1, .4f).setOnUpdate(SetAlphaRunner);
            yield return new WaitForSeconds(1.6f);
            LeanTween.scale(runImage, Vector3.zero, .4f);
            LeanTween.value(runImage, 1, 0, .4f).setOnUpdate(SetAlphaRunner);
            Destroy(runImage, .4f);
        }
        yield return new WaitForSeconds(.4f);
        AudioManager.Instance.Play(9);

        SetAvatarsFirstRound();
        //Canvas settings
        panelAvatars.SetActive(true);
        buttonScoreboard.SetActive(true);
        controllerCanvas.SetActive(true);


        //First round - Team 1 has ball and start on positions on bottom of map
        myGameObject.GetComponent<LocalPlayer>().isCatcher = myIdAndPlace.First == 1;
        myGameObject.GetPhotonView().RPC("ChangeColor", RpcTarget.AllBufferedViaServer);

        //BOT code
        if (PhotonNetwork.IsMasterClient)
        {
            foreach (GameObject bot in GameObjectsData.Instance.bots)
            {
                bot.GetPhotonView().RPC("ChangeColor", RpcTarget.AllBuffered);
            }
        }
        //

        if (myIdAndPlace.First == 1)
        {
            myGameObject.GetComponent<PlayerMovement>().isAttacker = true;
            myGameObject.GetComponent<PlayerMovement>().SetCatcherVal(1);
            myGameObject.GetPhotonView().RPC("SetCatcherValue",RpcTarget.All,true);
            myGameObject.GetComponent<PlayerScript>().lineRenderer.material.SetTexture("_MainTex",rightJoystickImage[0].texture);
            dashButton.sprite = dashButtonRes[0];

            if (catcherSkill == 0) currentSkill = 10;
            else if (catcherSkill == 3) currentSkill = 0;
            else currentSkill = catcherSkill;

            currentSkillButton = catcherSkillButton;
            currentSkillTime = catcherSkillTime;
            currentSkillTimeLVL = GameLogicData.Instance.catcherSkillLevels[catcherSkill, catcherSkillLevel - 1];

            attackerCanvas.SetActive(true);
            runnerCanvas.SetActive(false);
        }
        else
        {
            myGameObject.GetComponent<PlayerMovement>().isAttacker = false;
            myGameObject.GetComponent<PlayerMovement>().SetCatcherVal(-1);
            myGameObject.GetPhotonView().RPC("SetCatcherValue", RpcTarget.All, false);
            myGameObject.GetComponent<PlayerScript>().lineRenderer.material.SetTexture("_MainTex", rightJoystickImage[1].texture);
            dashButton.sprite = dashButtonRes[1];

            //0 - Extra Ball OR Extra Life, 1 - shield, 2 - invisibility, 3 - trap, 4 - slowdowntrap, 5 - topView, 6 - wall, 7 - hook, 8 - deadlyHit, 9 - botClone, 10 - speed
            if (runnerSkill == 0) currentSkill = 10;
            else if (runnerSkill == 1) currentSkill = 0;
            else if (runnerSkill == 2) currentSkill = 1;
            else if (runnerSkill == 3) currentSkill = 3;
            else if (runnerSkill == 4) currentSkill = 2;
            else if (runnerSkill == 5) currentSkill = 4;
            else if (runnerSkill == 6) currentSkill = 5;
            else if (runnerSkill == 7) currentSkill = 6;
            else if (runnerSkill == 8) currentSkill = 7;
            else if (runnerSkill == 9) currentSkill = 9;

            currentSkillButton = runnerSkillButton;
            currentSkillTime = runnerSkillTime;
            currentSkillTimeLVL = GameLogicData.Instance.runnerSkillLevels[runnerSkill, runnerSkillLevel - 1];

            runnerCanvas.SetActive(true);
            attackerCanvas.SetActive(false);
        }

        //BOT code
        if (PhotonNetwork.IsMasterClient)
        {
            bool isCatcher;
            foreach(GameObject bot in GameObjectsData.Instance.bots)
            {
                isCatcher = bot.GetComponent<LocalPlayer>().IdAndPlace.First == 1;
                bot.GetPhotonView().RPC("SetCatcherValue", RpcTarget.All, isCatcher);
                bot.GetComponent<BotController>().StartRound(isCatcher);
            }
        }
        AudioManager.Instance.Play(8);
        //
        roundStart = true;
        firstRound = true;
        StartCoroutine(TimerUpdate());

        changeStonesTime = Time.time + 30f;
        myGameObject.GetComponent<PlayerMovement>().StartRoundForPlayer();
    }

    private void SetAvatarsSecondRound()
    {
        if (myIdAndPlace.First == 2) // We are catchers
        {
            Color color;
            myTeamName.text = "catchers";
            oppTeamName.text = "runners";
            foreach (Image image in commonAvatars)
            {
                color = image.color;
                color.a = 1f;
                image.color = color;
            }
        }
        else // We are runners
        {
            myTeamName.text = "runners";
            oppTeamName.text = "catchers";
        }
    }
    
    private IEnumerator StartSecondRound()
    {
        firstRoundEnd = false;
        panelScoreboard.SetActive(false);
        if (myIdAndPlace.First == 2)
        {
            map.rotation = Quaternion.Euler(0, 0, 0);
            cinemachine.transform.rotation = Quaternion.Euler(65, 0, 0);
            LeanTween.scale(catchImage, Vector3.one, .4f);
            LeanTween.value(catchImage, 0, 1, .4f).setOnUpdate(SetAlphaCatcher);
            yield return new WaitForSeconds(1.6f);
            LeanTween.scale(catchImage, Vector3.zero, .4f);
            LeanTween.value(catchImage, 1, 0, .4f).setOnUpdate(SetAlphaCatcher);
            Destroy(catchImage, .4f);
        }
        else
        {
            map.rotation = Quaternion.Euler(0, 0, 180);
            cinemachine.transform.rotation = Quaternion.Euler(65, 180, 0);
            LeanTween.scale(runImage, Vector3.one, .4f);
            LeanTween.value(runImage, 0, 1, .4f).setOnUpdate(SetAlphaRunner);
            yield return new WaitForSeconds(1.6f);
            LeanTween.scale(runImage, Vector3.zero, .4f);
            LeanTween.value(runImage, 1, 0, .4f).setOnUpdate(SetAlphaRunner);
            Destroy(runImage, .4f);
        }
        yield return new WaitForSeconds(.4f);
        changeStonesTime = Time.time + 30f;
        SetAvatarsSecondRound();
        //roundScreen.text = 2.ToString();
        roundScoreboard.text = 2.ToString();
        //for (int i = 0; i < 7; i++)
        //{
        //    stoneZones[i].GetComponent<Renderer>().material.color = Color.red;
        //}

        //Debug.Log("Client : Second round started.");
        myGameObject.GetComponent<LocalPlayer>().isCatcher = myIdAndPlace.First == 2;
        if (myGameObject.GetComponent<LocalPlayer>().isCatcher)
        {
            myGameObject.GetPhotonView().RPC("ShowCharacter", RpcTarget.AllBuffered);
            cinemachine.GetComponent<CinemachineVirtualCamera>().Follow = myGameObject.transform;
        }

        //myGameObject.GetComponent<PlayerMovement>().enabled = true;
        //movementJoystick.SetActive(true);
        //attackJoystick.SetActive(true);
        panelScoreboard.GetComponent<Button>().enabled = true;
        myGameObject.GetComponent<Collider>().enabled = true;
        //myGameObject.GetPhotonView().RPC("RoundStart", RpcTarget.AllBufferedViaServer, myIdAndPlace.First == 2);

        //BOT code
        if (PhotonNetwork.IsMasterClient)
        {
            foreach (GameObject bot in GameObjectsData.Instance.bots)
            {
                //bot.GetPhotonView().RPC("RoundStart", RpcTarget.AllBuffered, bot.GetComponent<BotData>().IdAndPlace.First == 2);
            }
        }
        //

        if (myIdAndPlace.First == 2)
        {
            myGameObject.GetComponent<PlayerMovement>().isAttacker = true;
            myGameObject.GetComponent<PlayerMovement>().SetCatcherVal(1);
            myGameObject.GetPhotonView().RPC("SetCatcherValue", RpcTarget.All, true);
            myGameObject.GetComponent<PlayerScript>().lineRenderer.material.SetTexture("_MainTex", rightJoystickImage[0].texture);
            dashButton.sprite = dashButtonRes[0];

            if (catcherSkill == 0) currentSkill = 10;
            else if (catcherSkill == 3) currentSkill = 0;
            else currentSkill = catcherSkill;

            currentSkillButton = catcherSkillButton;
            currentSkillTime = catcherSkillTime;
            currentSkillTimeLVL = GameLogicData.Instance.catcherSkillLevels[catcherSkill, catcherSkillLevel - 1];

            attackerCanvas.SetActive(true);
        }
        else
        {
            myGameObject.GetComponent<PlayerMovement>().isAttacker = false;
            myGameObject.GetComponent<PlayerMovement>().SetCatcherVal(-1);
            myGameObject.GetPhotonView().RPC("SetCatcherValue", RpcTarget.All, false);
            myGameObject.GetComponent<PlayerScript>().lineRenderer.material.SetTexture("_MainTex", rightJoystickImage[1].texture);
            dashButton.sprite = dashButtonRes[1];

            if (runnerSkill == 0) currentSkill = 10;
            else if (runnerSkill == 1) currentSkill = 0;
            else if (runnerSkill == 2) currentSkill = 1;
            else if (runnerSkill == 3) currentSkill = 3;
            else if (runnerSkill == 4) currentSkill = 2;
            else if (runnerSkill == 5) currentSkill = 4;
            else if (runnerSkill == 6) currentSkill = 5;
            else if (runnerSkill == 7) currentSkill = 6;
            else if (runnerSkill == 8) currentSkill = 7;
            else if (runnerSkill == 9) currentSkill = 9;

            currentSkillButton = runnerSkillButton;
            currentSkillTime = runnerSkillTime;
            currentSkillTimeLVL = GameLogicData.Instance.runnerSkillLevels[runnerSkill, runnerSkillLevel - 1];

            runnerCanvas.SetActive(true);
        }
        controllerCanvas.SetActive(true);
        myGameObject.GetComponent<PlayerScript>().UnFreeze();
        //BOT code
        if (PhotonNetwork.IsMasterClient)
        {
            bool isCatcher;
            foreach (GameObject bot in GameObjectsData.Instance.bots)
            {
                isCatcher = bot.GetComponent<LocalPlayer>().IdAndPlace.First == 2;
                bot.GetPhotonView().RPC("SetCatcherValue", RpcTarget.All, isCatcher);
                bot.GetComponent<BotController>().StartRound(isCatcher);
            }
        }
        //

        gameTime = 180;
        roundStart = true;
        firstRound = false;
        StartCoroutine(TimerUpdate());

        myGameObject.GetComponent<PlayerMovement>().StartRoundForPlayer();
    }

    private void EndRound()
    {
        roundStart = false;
        if (firstRound)
        {
            if (PhotonNetwork.IsMasterClient) gameLogic.EndFirstRound();
            EndFirstRound();
        }
        else
        {
            runnerCanvas.SetActive(false);
            attackerCanvas.SetActive(false);
            commonCanvas.SetActive(false);
            controllerCanvas.SetActive(false);
            if (!isDead)
            {
                GameLogicData.Instance.enduranceTime = 180;
            }
            StartCoroutine(EndGame());
        }
    }

    private void EndFirstRound()
    {
        runnerCanvas.SetActive(false);
        attackerCanvas.SetActive(false);
        myGameObject.GetComponent<PlayerScript>().Freeze();
        movementJoystick.GetComponent<FloatingJoystick>().OnDeactivate();
        attackJoystick.GetComponent<FloatingJoystick>().OnDeactivate();
        controllerCanvas.SetActive(false);
        skillRefreshTime = 0f;
        panelScoreboard.SetActive(true);
        panelScoreboard.GetComponent<Button>().enabled = false;
        sDTrapGhost.SetActive(false);
        trapGhost.SetActive(false);
        wallGhost.SetActive(false);
        hookGhost.SetActive(false);
        hookLine.gameObject.SetActive(false);
        deadlyHitLine.gameObject.SetActive(false);
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1f);
        endGameCanvas.SetActive(true);
        endGameCamera.depth = mainCamera.depth + 1;
        panelScoreboard.SetActive(true);
        panelScoreboard.GetComponent<Button>().enabled = false;
        buttonToMenu.SetActive(true);
        bool win = myTeamScore >= oppTeamScore;
        AudioManager.Instance.Stop(8);
        if (win)
        {
            AudioManager.Instance.Play(23);
        }
        else
        {
            AudioManager.Instance.Play(24);
        }
        bool mvp = AmIMVP(win);
        int myNewScore = (myScore + GameLogicData.Instance.enduranceTime) * 10 + (mvp ? 2000 : 0) + (win ? 1000 : 0);

        var user = Settings.User;
        user.gs.generalWin += win ? 1 : 0;
        user.gs.generalLose += win ? 0 : 1;
        user.gs.generalMVP += mvp ? 1 : 0;
        user.gs.generalStone += myStones;
        user.gs.generalKill += myShoot;
        user.gs.generalShot += GameLogicData.Instance.shootCounter;
        user.gs.generalEndurance += GameLogicData.Instance.enduranceTime;

        user.xp += (int)(myNewScore * .11) * 5;
        user.ssCoin += (int)(myNewScore * .11);
        user.starCoin += 0;
        Settings.User = user;
        SaveData();

        PhotonNetwork.LeaveRoom();
        CopyScoreboardToNew(win,mvp, myNewScore);
        StartCoroutine(Wait((int)(myNewScore * .11), (int)(myNewScore * .11) * 5));

    }

    IEnumerator Wait(int coin, int xp)
    {
        yield return new WaitForSeconds(.5f);
        TweenThreeImage();
        yield return new WaitForSeconds(.5f);
        TweenBllStnStr();
        yield return new WaitForSeconds(.9f);
        TweenCpMVP();
        yield return new WaitForSeconds(1f);
        TweenCnXP(coin, xp);
    }
    
    private void TweenThreeImage()
    {
        LeanTween.scale(threeIcon, Vector3.one, .5f).setEaseOutBack();
        AudioManager.Instance.Play(6);
    }
    private void TweenBllStnStr()
    {
        AudioManager.Instance.Play(6);
        LeanTween.scale(myBallLeftPanel.GetComponent<RectTransform>(), Vector3.one, .3f).setEaseOutBack()
            .setOnComplete(() => {
                AudioManager.Instance.Play(6);
                LeanTween.scale(myStoneLeftPanel.GetComponent<RectTransform>(), Vector3.one, .3f).setEaseOutBack().setOnComplete(() => { 
                    AudioManager.Instance.Play(6);
                    LeanTween.scale(myScoreLeftPanel.GetComponent<RectTransform>(), Vector3.one, .3f).setEaseOutBack(); 
                    });
                });
    }
    private void TweenCpMVP()
    {
        if(winImageLeftPanel.activeSelf) AudioManager.Instance.Play(6);
            LeanTween.scale(winImageLeftPanel.GetComponent<RectTransform>(), Vector3.one, .5f).setEaseOutBack().setOnComplete(() => { 
                if(mVPImageLeftPanel.activeSelf) AudioManager.Instance.Play(6);
                LeanTween.scale(mVPImageLeftPanel.GetComponent<RectTransform>(), Vector3.one, .5f).setEaseOutBack(); });
    }
    private void TweenCnXP(int coin, int xp)
    {
        AudioManager.Instance.Play(21);
        LeanTween.value(gameObject, 0, coin, .5f)
            .setEaseOutSine()
            .setOnUpdate(ChangeTextCoin)
            .setOnComplete(() => {
                AudioManager.Instance.Play(22);
                LeanTween.value(gameObject, 0, xp, .5f)
                    .setEaseOutSine()
                    .setOnUpdate(ChangeTextXP)
                    .setOnComplete(() => { LeanTween.scale(exitButton, Vector3.one, .5f).setEaseOutBack(); });
            });
    }
    private void ChangeTextCoin(float value)
    {
        myCoinUpPanel.text = string.Format("+{0}", (int)value);
    }
    private void ChangeTextXP(float value)
    {
        myXPUpPanel.text = string.Format("+{0}", (int)value);
    }

    #region ENDGAME UI
    private void CopyScoreboardToNew(bool win, bool mvp, int newScore)
    {
        for (int i = 0; i < 4; i++)
        {
            myTeamAvatarsEnd[i].sprite = myTeamAvatars[i].sprite;
            oppTeamAvatarsEnd[i].sprite = oppTeamAvatars[i].sprite;
            myTeamNicknamesEnd[i].text = myTeamNicknames[i].text;
            myTeamLvlsEnd[i].text = myTeamLvls[i].text;
            oppTeamNicknamesEnd[i].text = oppTeamNicknames[i].text;
            oppTeamLvlsEnd[i].text = oppTeamLvls[i].text;
            myTeamScoresEnd[i].text = myTeamScores[i].text;
            oppTeamScoresEnd[i].text = oppTeamScores[i].text;
            myTeamShootsEnd[i].text = myTeamShoots[i].text;
            oppTeamShootsEnd[i].text = oppTeamShoots[i].text;
            myTeamStonesEnd[i].text = myTeamStones[i].text;
            oppTeamStonesEnd[i].text = oppTeamStones[i].text;
            GameObjectsData.Instance.endGameChars[i].SetActive(true);
        }
        int mvpPlace = MVPPlace(win);
        //Debug.Log("MVP place : " + mvpPlace);
        if (win)
        {
            myTeamMVPsEnd[mvpPlace].SetActive(true);
            if (mvpPlace == myIdAndPlace.Second) mvpOnCharsEnd[0].SetActive(true);
            else if (mvpPlace < myIdAndPlace.Second) mvpOnCharsEnd[mvpPlace + 1].SetActive(true);
            else mvpOnCharsEnd[mvpPlace].SetActive(true);
        }
        else
        {
            oppTeamMVPsEnd[mvpPlace].SetActive(true);
        }
        myTeamScoreTxtEnd.text = myTeamScoreTxt.text;
        oppTeamScoreTxtEnd.text = oppTeamScoreTxt.text;
        myTeamWLEnd.text = win ? "VICTORY!" : "DEFEAT!";
        oppTeamWLEnd.text = win ? "DEFEAT!" : "VICTORY!";
        backImage.sprite = win ? winBackImage : loseBackImage;
        mVPImageLeftPanel.SetActive(mvp);
        winImageLeftPanel.SetActive(win);
        //myCoinUpPanel.text = ssCoin.ToString();
        //myXPUpPanel.text = xp.ToString();
        myBallLeftPanel.text = myShoot.ToString();
        myStoneLeftPanel.text = myStones.ToString();
        myScoreLeftPanel.text = newScore.ToString();
    }

    public void OnClickEndGameScoreBoardOpen()
    {
        scoreBoardEnd.SetActive(true);
    }
    
    public void OnClickEndGameScoreBoardClose()
    {
        scoreBoardEnd.SetActive(false);
    }
    #endregion
    
    bool AmIMVP(bool win)
    {
        if (!win) return false;
        foreach(RemotePlayer player in myTeamMembers.Values)
        {
            if (player.score > myScore) return false;
        }
        return true;
    }

    int MVPPlace(bool win)
    {
        int res = 0, max=0;
        if (win)
        {
            foreach (RemotePlayer player in myTeamMembers.Values)
            {
                if (player.score > max)
                {
                    max = player.score;
                    res = player.Place;
                }
            }
            if (myScore >= max) return myIdAndPlace.Second;
            return res;
        }
        else
        {
            foreach (RemotePlayer player in oppTeamMembers.Values)
            {
                if (player.score > max)
                {
                    max = player.score;
                    res = player.Place;
                }
            }
            return res;
        }
    }

    public void SetMyGameObject(GameObject gameObject)
    {
        myGameObject = gameObject;
    }
    
    public void OnClick_ScoreboardOpen()
    {
        panelScoreboard.SetActive(true);
        AudioManager.Instance.Play(16);
    } 
    
    public void OnClick_ScoreboardClose()
    {
        panelScoreboard.SetActive(false);
    }

    public void OnClick_GoToMenu()
    {
        exitButton.SetActive(false);
        PhotonNetworkingMain.Instance.inGame = false;
        AudioManager.Instance.Stop(8);
        PhotonNetwork.LoadLevel(1);
        //SceneManager.LoadScene(1);
    }

    public void OnClick_NextPlayer()
    {
        if (!myTeamMembers[int.Parse(teamMateGameObjects[followIndex].name)].isDead){
            cinemachine.GetComponent<CinemachineVirtualCamera>().Follow = teamMateGameObjects[followIndex].transform;
            followIndex++;
            if (followIndex == teamMateGameObjects.Count)
            {
                followIndex = 0;
            }
        }
        else
        {
            deadPeople++;
            followIndex++;
            if (followIndex == teamMateGameObjects.Count)
            {
                followIndex = 0;
            }
            if(deadPeople < 3) OnClick_NextPlayer();
        }
    }

    public void ManageSkills(int runnerSkill, int runnerSkillLevel, int catcherSkill, int catcherSkillLevel)
    {
        if (runnerSkillLevel == 0)
            runnerSkillLevel = 1;
        if (catcherSkillLevel == 0)
            catcherSkillLevel = 1;
        switch (runnerSkill)
        {
            //Add health skill checked on GameStart
            case 0: //Speed
                runnerSkillButton.GetComponent<Button>().onClick.AddListener(Skill_SpeedUp);
                runnerSkillButton.GetComponent<Image>().sprite = runnerSkillImageRes[0];
                break;
            case 1: //Life
                runnerSkillButton.gameObject.SetActive(false);
                lives = (byte)GameLogicData.Instance.runnerSkillLevels[runnerSkill, runnerSkillLevel - 1];
                StartCoroutine(ActivateHearts(lives));
                break;
            case 2: //Shield
                runnerSkillButton.GetComponent<Button>().onClick.AddListener(Skill_Shield);
                runnerSkillButton.GetComponent<Image>().sprite = runnerSkillImageRes[2];
                break;
            case 3: //Trap
                runnerSkillButton.GetComponent<Button>().enabled = false;
                runnerSkillButton.GetComponent<Image>().raycastTarget = false;
                runnerSkillButton.GetComponent<Image>().sprite = runnerSkillImageRes[3];
                runnerSkillJoystick.gameObject.SetActive(true);
                break;
            case 4: //Invisibility
                runnerSkillButton.GetComponent<Button>().onClick.AddListener(Skill_Invisibility);
                runnerSkillButton.GetComponent<Image>().sprite = runnerSkillImageRes[4];
                break;
            case 5: //Slow down Trap
                runnerSkillButton.GetComponent<Button>().enabled = false;
                runnerSkillButton.GetComponent<Image>().raycastTarget = false;
                runnerSkillButton.GetComponent<Image>().sprite = runnerSkillImageRes[5];
                runnerSkillJoystick.gameObject.SetActive(true);
                break;
            case 6: //Top view
                runnerSkillButton.GetComponent<Button>().onClick.AddListener(Skill_TopView);
                runnerSkillButton.GetComponent<Image>().sprite = runnerSkillImageRes[6];
                break;
            case 7: //Wall
                runnerSkillButton.GetComponent<Button>().enabled = false;
                runnerSkillButton.GetComponent<Image>().raycastTarget = false;
                runnerSkillButton.GetComponent<Image>().sprite = runnerSkillImageRes[7];
                runnerSkillJoystick.gameObject.SetActive(true);
                break;
            case 8: //Hook
                runnerSkillButton.GetComponent<Button>().enabled = false;
                runnerSkillButton.GetComponent<Image>().raycastTarget = false;
                runnerSkillButton.GetComponent<Image>().sprite = runnerSkillImageRes[8];
                runnerSkillJoystick.gameObject.SetActive(true);
                break;
            case 9: //Bot clone
                runnerSkillButton.GetComponent<Button>().onClick.AddListener(Skill_BotClone);
                runnerSkillButton.GetComponent<Image>().sprite = runnerSkillImageRes[9];
                break;
        }
        switch (catcherSkill)
        {
            case 0: //Speed
                catcherSkillButton.GetComponent<Button>().onClick.AddListener(Skill_SpeedUp);
                catcherSkillButton.GetComponent<Image>().sprite = catcherSkillImageRes[0];
                break;
            case 1: //Shield - Not used
                catcherSkillButton.GetComponent<Button>().onClick.AddListener(Skill_Shield);
                catcherSkillButton.GetComponent<Image>().sprite = catcherSkillImageRes[1];
                break;
            case 2: //Invisibility
                catcherSkillButton.GetComponent<Button>().onClick.AddListener(Skill_Invisibility);
                catcherSkillButton.GetComponent<Image>().sprite = catcherSkillImageRes[2];
                break;
            case 3: //Extra ball
                catcherSkillButton.GetComponent<Button>().enabled = false;
                catcherSkillButton.GetComponent<Image>().sprite = catcherSkillImageRes[3];
                myGameObject.GetComponent<PlayerMovement>().ballCountSkill = (int)GameLogicData.Instance.catcherSkillLevels[catcherSkill, catcherSkillLevel - 1];
                break;
            case 4: //Slow down trap
                catcherSkillButton.GetComponent<Button>().enabled = false;
                catcherSkillButton.GetComponent<Image>().raycastTarget = false;
                catcherSkillButton.GetComponent<Image>().sprite = catcherSkillImageRes[4];
                catcherSkillJoystick.gameObject.SetActive(true);
                break;
            case 5: //Top view
                catcherSkillButton.GetComponent<Button>().onClick.AddListener(Skill_TopView);
                catcherSkillButton.GetComponent<Image>().sprite = catcherSkillImageRes[5];
                break;
            case 6: //Wall
                catcherSkillButton.GetComponent<Button>().enabled = false;
                catcherSkillButton.GetComponent<Image>().raycastTarget = false;
                catcherSkillButton.GetComponent<Image>().sprite = catcherSkillImageRes[6];
                catcherSkillJoystick.gameObject.SetActive(true);
                break;
            case 7: //Hook
                catcherSkillButton.GetComponent<Button>().enabled = false;
                catcherSkillButton.GetComponent<Image>().raycastTarget = false;
                catcherSkillButton.GetComponent<Image>().sprite = catcherSkillImageRes[7];
                catcherSkillJoystick.gameObject.SetActive(true);
                break;
            case 8: //Deadly hit
                catcherSkillButton.GetComponent<Button>().enabled = false;
                catcherSkillButton.GetComponent<Image>().raycastTarget = false;
                catcherSkillButton.GetComponent<Image>().sprite = catcherSkillImageRes[8];
                catcherSkillJoystick.gameObject.SetActive(true);
                break;
            case 9: //Bot clone
                catcherSkillButton.GetComponent<Button>().onClick.AddListener(Skill_BotClone);
                catcherSkillButton.GetComponent<Image>().sprite = catcherSkillImageRes[9];
                break;
        }
        this.runnerSkill = runnerSkill;
        this.runnerSkillLevel = runnerSkillLevel;
        this.catcherSkill = catcherSkill;
        this.catcherSkillLevel = catcherSkillLevel;
    }

    IEnumerator ActivateHearts(int lives)
    {
        for (int i = 0; i < lives; i++)
        {
            GameObjectsData.Instance.lives[i].SetActive(true);
            yield return null;
        }
    }

    #region Skills With Button

    public void Skill_SpeedUp()
    {
        if (skillRefreshTime <= 0)
        {
            myGameObject.GetComponent<PlayerMovement>().SpeedUp(currentSkillTimeLVL);
            GameObjectsData.Instance.SkillFrameActivate(currentSkillTimeLVL);
            skillRefreshTime = 30;
            colorSkill = currentSkillButton.GetComponent<Image>().color;
            colorSkill.a = 70;
            currentSkillButton.GetComponent<Image>().color = colorSkill;
            currentSkillTime.enabled = true;
            AudioManager.Instance.Play(17);
        }
    }    
    
    public void Skill_BotClone()
    {
        if (skillRefreshTime <= 0)
        {
            GameObject clone1 = PhotonNetwork.Instantiate("BotClone", myGameObject.transform.position + new Vector3(1f,0,0), Quaternion.identity, 0 , new object[] { (byte)charIndex, currentSkillTimeLVL });
            clone1.GetComponent<BotClone>().CloneCommand(catcherValue == 1, 1);
            GameObject clone2 = PhotonNetwork.Instantiate("BotClone", myGameObject.transform.position + new Vector3(1f, 0, 0), Quaternion.identity, 0 , new object[] { (byte)charIndex, currentSkillTimeLVL });
            clone2.GetComponent<BotClone>().CloneCommand(catcherValue == 1, 2);

            GameObjectsData.Instance.SkillFrameActivate(currentSkillTimeLVL);

            skillRefreshTime = 30;
            colorSkill = currentSkillButton.GetComponent<Image>().color;
            colorSkill.a = 70;
            currentSkillButton.GetComponent<Image>().color = colorSkill;
            currentSkillTime.enabled = true;
            AudioManager.Instance.Play(17);
        }
    }

    public void Skill_TopView()
    {
        if(skillRefreshTime <= 0)
        {
            cinemachine.GetComponent<CinemachineVirtualCamera>().enabled = false;
            mainCamera.transform.position = new Vector3(0f, 110f, 0);
            mainCamera.transform.rotation = Quaternion.Euler(90f, cinemachine.transform.rotation.eulerAngles.y ,0f);
            StartCoroutine(NormalView());
            GameObjectsData.Instance.SkillFrameActivate(currentSkillTimeLVL);

            skillRefreshTime = 30;
            colorSkill = currentSkillButton.GetComponent<Image>().color;
            colorSkill.a = 70;
            currentSkillButton.GetComponent<Image>().color = colorSkill;
            currentSkillTime.enabled = true;
            AudioManager.Instance.Play(17);
        }
    }

    IEnumerator NormalView()
    {
        yield return new WaitForSeconds(currentSkillTimeLVL);
        cinemachine.GetComponent<CinemachineVirtualCamera>().enabled = true;
    }

    public void Skill_Shield()
    {
        if (skillRefreshTime <= 0)
        {
            myGameObject.GetPhotonView().RPC("ShowShield", RpcTarget.All, currentSkillTimeLVL);
            GameObjectsData.Instance.SkillFrameActivate(currentSkillTimeLVL);
            skillRefreshTime = 30;
            colorSkill = currentSkillButton.GetComponent<Image>().color;
            colorSkill.a = 70;
            currentSkillButton.GetComponent<Image>().color = colorSkill;
            currentSkillTime.enabled = true;
            AudioManager.Instance.Play(17);
        }
    }

    public void Skill_Invisibility()
    {
        if (skillRefreshTime <= 0)
        {
            myGameObject.GetPhotonView().RPC("InvisibilityHide", RpcTarget.All, currentSkillTimeLVL);
            GameObjectsData.Instance.SkillFrameActivate(currentSkillTimeLVL);
            skillRefreshTime = 30;
            colorSkill = currentSkillButton.GetComponent<Image>().color;
            colorSkill.a = 70;
            currentSkillButton.GetComponent<Image>().color = colorSkill;
            currentSkillTime.enabled = true;
            AudioManager.Instance.Play(17);
        }
    }    

    #endregion

    #region Skills With Drag Joystick
    public void OnRunnerSkillJoystickDown()
    {
        drag = true;
        StartCoroutine(OnRunnerSkillDrag());
        runnerCancelSkill.SetActive(true);
        if(currentSkill == 3) //trap
        {
            trapGhost.SetActive(true);
            trapGhost.transform.position = new Vector3( myGameObject.transform.position.x, 1.4f,  myGameObject.transform.position.z);
        }
        else if(currentSkill == 4)//slowdowntrap
        {
            sDTrapGhost.SetActive(true);
            sDTrapGhost.transform.position = new Vector3( myGameObject.transform.position.x, 1.4f,  myGameObject.transform.position.z); 
        }
        else if(currentSkill == 6)
        {
            wallGhost.SetActive(true);
            wallGhost.transform.position = new Vector3(myGameObject.transform.position.x, 1.8f, myGameObject.transform.position.z);
        }
        else if(currentSkill == 7)
        {
            if (Physics.Raycast(myGameObject.transform.position, myGameObject.transform.forward, out RaycastHit hit, 30f, 1 << 8 | 1 << 16))
            {
                if (!hookRay)
                {
                    hookRay = true;
                    hookGhost.SetActive(true);
                    hookLine.gameObject.SetActive(true);
                }
                hookLine.SetPosition(0, myGameObject.transform.position);
                hookLine.SetPosition(1, hit.point);
                hookGhost.transform.position = hit.point;
                hookDirection = myGameObject.transform.forward;
            }
            else
            {
                if (hookRay)
                {
                    hookRay = false;
                    hookGhost.SetActive(false);
                    hookLine.gameObject.SetActive(false);
                }
            }
        }
    }
    IEnumerator OnRunnerSkillDrag()
    {
        yield return null;
        while (true)
        {
            if (drag)
            {
                if (currentSkill == 3)
                {
                    trapGhost.transform.position = new Vector3(myGameObject.transform.position.x + catcherValue * runnerSkillJoystick.Horizontal * 10, 1.4f, myGameObject.transform.position.z + catcherValue * runnerSkillJoystick.Vertical * 10);
                }
                else if (currentSkill == 4)//slowdowntrap
                {
                    sDTrapGhost.transform.position = new Vector3(myGameObject.transform.position.x + catcherValue * runnerSkillJoystick.Horizontal * 10, 1.4f, myGameObject.transform.position.z + catcherValue * runnerSkillJoystick.Vertical * 10);
                }
                else if (currentSkill == 6)
                {
                    wallGhost.transform.position = new Vector3(myGameObject.transform.position.x + catcherValue * runnerSkillJoystick.Horizontal * 11, 1.8f, myGameObject.transform.position.z + catcherValue * runnerSkillJoystick.Vertical * 11);
                }
                else if (currentSkill == 7)
                {
                    if (Physics.Raycast(myGameObject.transform.position, new Vector3(runnerSkillJoystick.Horizontal, 0f, runnerSkillJoystick.Vertical).normalized * catcherValue, out RaycastHit hit, 30f, 1 << 8 | 1 << 16))
                    {
                        if (!hookRay)
                        {
                            hookRay = true;
                            hookGhost.SetActive(true);
                            hookLine.gameObject.SetActive(true);
                        }
                        hookLine.SetPosition(0, myGameObject.transform.position);
                        hookLine.SetPosition(1, hit.point);
                        hookGhost.transform.position = hit.point;
                        hookDirection = new Vector3(runnerSkillJoystick.Horizontal, 0f, runnerSkillJoystick.Vertical).normalized * catcherValue;
                    }
                    else
                    {
                        if (hookRay)
                        {
                            hookRay = false;
                            hookGhost.SetActive(false);
                            hookLine.gameObject.SetActive(false);
                        }
                    }
                }
            }
            else
            {
                yield break;
            }
            yield return null;
        }
    }
    //TODO AUDIO Settings here
    public void OnRunnerSkillJoystickUp()
    {
        drag = false;
        if (skillRefreshTime <= 0 && !GameLogicData.Instance.skillCancel)
        {
            if (currentSkill == 3)
            {
                myGameObject.GetPhotonView().RPC("TrapPlaced", RpcTarget.All, trapGhost.transform.position, currentSkillTimeLVL);
                GameObjectsData.Instance.SkillFrameActivate(currentSkillTimeLVL);
                AudioManager.Instance.Play(17);
            }
            else if (currentSkill == 4)//slowdowntrap
            {
                myGameObject.GetPhotonView().RPC("SDTrapPlaced", RpcTarget.All, sDTrapGhost.transform.position, currentSkillTimeLVL);
                GameObjectsData.Instance.SkillFrameActivate(currentSkillTimeLVL);
                AudioManager.Instance.Play(17);
            }
            else if (currentSkill == 6)
            {
                myGameObject.GetPhotonView().RPC("WallPlaced", RpcTarget.All, wallGhost.transform.position, currentSkillTimeLVL);
                GameObjectsData.Instance.SkillFrameActivate(currentSkillTimeLVL);
                AudioManager.Instance.Play(17);
            }
            else if(currentSkill == 7)
            {
                if (hookRay)
                {
                    myGameObject.GetComponent<Rigidbody>().AddForce(hookDirection * 40, ForceMode.VelocityChange);
                    GameLogicData.Instance.hookMove = true;
                    StartCoroutine(StopPlayer());
                    // TODO Movement code here
                    AudioManager.Instance.Play(17);
                }
            }

            if ((currentSkill == 7 && hookRay) || (currentSkill != 7))
            {
                skillRefreshTime = 30;
                colorSkill = currentSkillButton.GetComponent<Image>().color;
                colorSkill.a = 70;
                currentSkillButton.GetComponent<Image>().color = colorSkill;
                currentSkillTime.enabled = true;
            }
        }

        if (currentSkill == 3) trapGhost.SetActive(false);
        else if (currentSkill == 4) sDTrapGhost.SetActive(false);
        else if(currentSkill == 6)  wallGhost.SetActive(false);
        else if(currentSkill == 7)
        {
            hookGhost.SetActive(false);
            hookLine.gameObject.SetActive(false);
        }

        GameLogicData.Instance.skillCancel = false;
        runnerCancelSkill.GetComponent<Image>().color = Color.white;
        runnerCancelSkill.SetActive(false);
    }

    IEnumerator StopPlayer()
    {
        movementJoystick.GetComponent<FloatingJoystick>().enabled = false;
        movementJoystick.GetComponent<FloatingJoystick>().OnDeactivate();
        yield return new WaitForSeconds(1f);
        if (GameLogicData.Instance.hookMove)
        {
            myGameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            myGameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            movementJoystick.GetComponent<FloatingJoystick>().enabled = true;
            GameLogicData.Instance.hookMove = false;
        }
    }
    
    public void OnCatcherSkillJoystickDown()
    {
        drag = true;
        StartCoroutine(OnCatcherSkillDrag());
        catcherCancelSkill.SetActive(true);
        if (currentSkill == 4)//slowdowntrap
        {
            sDTrapGhost.SetActive(true);
            sDTrapGhost.transform.position = new Vector3(myGameObject.transform.position.x, 1.4f, myGameObject.transform.position.z );
        }
        else if(currentSkill == 6)
        {
            wallGhost.SetActive(true);
            wallGhost.transform.position = new Vector3(myGameObject.transform.position.x, 1.8f, myGameObject.transform.position.z);
        }
        else if (currentSkill == 7)
        {
            if (Physics.Raycast(myGameObject.transform.position, myGameObject.transform.forward, out RaycastHit hit, 30f, 1 << 8 | 1 << 16))
            {
                if (!hookRay)
                {
                    hookRay = true;
                    hookGhost.SetActive(true);
                    hookLine.gameObject.SetActive(true);
                }
                hookLine.SetPosition(0, myGameObject.transform.position);
                hookLine.SetPosition(1, hit.point);
                hookGhost.transform.position = hit.point;
                hookDirection = myGameObject.transform.forward;
            }
            else
            {
                if (hookRay)
                {
                    hookRay = false;
                    hookGhost.SetActive(false);
                    hookLine.gameObject.SetActive(false);
                }
            }
        }
        else if (currentSkill == 8)
        {
            deadlyHitLine.gameObject.SetActive(true);
            deadlyHitLine.SetPosition(0, myGameObject.transform.position);
            deadlyHitLine.SetPosition(1, myGameObject.transform.position + myGameObject.transform.forward * 70);
        }
    }
    IEnumerator OnCatcherSkillDrag()
    {
        yield return null;
        while (true)
        {
            if (drag)
            {
                if (currentSkill == 4)//slowdowntrap
                {
                    sDTrapGhost.transform.position = new Vector3(myGameObject.transform.position.x + catcherValue * catcherSkillJoystick.Horizontal * 10, 1.4f, myGameObject.transform.position.z + catcherValue * catcherSkillJoystick.Vertical * 10);
                }
                else if (currentSkill == 6)
                {
                    wallGhost.transform.position = new Vector3(myGameObject.transform.position.x + catcherValue * catcherSkillJoystick.Horizontal * 11, 1.8f, myGameObject.transform.position.z + catcherValue * catcherSkillJoystick.Vertical * 11);
                }
                else if (currentSkill == 7)
                {
                    if (Physics.Raycast(myGameObject.transform.position, new Vector3(catcherSkillJoystick.Horizontal, 0f, catcherSkillJoystick.Vertical).normalized * catcherValue, out RaycastHit hit, 30f, 1 << 8 | 1 << 16))
                    {

                        if (!hookRay)
                        {
                            hookRay = true;
                            hookGhost.SetActive(true);
                            hookLine.gameObject.SetActive(true);
                        }
                        hookLine.SetPosition(0, myGameObject.transform.position);
                        hookLine.SetPosition(1, hit.point);
                        hookGhost.transform.position = hit.point;
                        hookDirection = new Vector3(catcherSkillJoystick.Horizontal, 0f, catcherSkillJoystick.Vertical).normalized * catcherValue;
                    }
                    else
                    {
                        if (hookRay)
                        {
                            hookRay = false;
                            hookGhost.SetActive(false);
                            hookLine.gameObject.SetActive(false);
                        }
                    }
                }
                else if (currentSkill == 8)
                {
                    myGameObject.transform.forward = new Vector3(catcherSkillJoystick.Horizontal, 0f, catcherSkillJoystick.Vertical).normalized * catcherValue;
                    deadlyHitLine.SetPosition(0, myGameObject.transform.position);
                    deadlyHitLine.SetPosition(1, myGameObject.transform.position + new Vector3(catcherSkillJoystick.Horizontal, 0f, catcherSkillJoystick.Vertical).normalized * catcherValue * 70);
                }
            }
            else
            {
                yield break;
            }
            yield return null;
        }
    }
    public void OnCatcherSkillJoystickUp()
    {
        drag = false;
        Debug.Log("Skillrefreshtime : " + skillRefreshTime + " currentSkill : " + currentSkill);
        if (skillRefreshTime <= 0 && !GameLogicData.Instance.skillCancel)
        {
            bool res = false;
            if (currentSkill == 4)
            {
                myGameObject.GetPhotonView().RPC("SDTrapPlaced", RpcTarget.All, sDTrapGhost.transform.position, currentSkillTimeLVL);
                GameObjectsData.Instance.SkillFrameActivate(currentSkillTimeLVL);
            }
            else if(currentSkill == 6)
            {
                myGameObject.GetPhotonView().RPC("WallPlaced", RpcTarget.All, wallGhost.transform.position, currentSkillTimeLVL);
                GameObjectsData.Instance.SkillFrameActivate(currentSkillTimeLVL);
            }
            else if (currentSkill == 7)
            {
                if (hookRay)
                {
                    myGameObject.GetComponent<Rigidbody>().AddForce(hookDirection * 40, ForceMode.VelocityChange);
                    GameLogicData.Instance.hookMove = true;
                    StartCoroutine(StopPlayer());
                }
            }
            else if(currentSkill == 8)
            {
                res = myGameObject.GetComponent<PlayerMovement>().ShootFromSkill(myGameObject.transform.forward);
            }

            if((currentSkill == 7 && hookRay) || (currentSkill == 8 && res) || (currentSkill!=7 && currentSkill!=8))
            {
                skillRefreshTime = 30;
                colorSkill = currentSkillButton.GetComponent<Image>().color;
                colorSkill.a = 70;
                currentSkillButton.GetComponent<Image>().color = colorSkill;
                currentSkillTime.enabled = true;
                AudioManager.Instance.Play(17);
            }
        }


        if (currentSkill == 4)  sDTrapGhost.SetActive(false);
        else if (currentSkill == 6) wallGhost.SetActive(false);
        else if(currentSkill == 8)  deadlyHitLine.gameObject.SetActive(false);
        else if (currentSkill == 7)
        {
            hookGhost.SetActive(false);
            hookLine.gameObject.SetActive(false);
        }

        GameLogicData.Instance.skillCancel = false;
        catcherCancelSkill.GetComponent<Image>().color = Color.white;
        catcherCancelSkill.SetActive(false);
    }
    #endregion

    public void PlayerLeftRoom(int actorNumber)
    {
        // If disconnected player is from opp team
        if (oppTeamMembersActorNumbers.Contains(actorNumber))
        {
            oppTeamMembersActorNumbers.Remove(actorNumber);
            if (myGameObject.GetComponent<LocalPlayer>().isCatcher)
            {
                runnersLeft--;
            }
        }
        // If disconnected player is from my team
        else
        {
            myTeamMembersActorNumbers.Remove(actorNumber);
            if (!myGameObject.GetComponent<LocalPlayer>().isCatcher)
            {
                runnersLeft--;
            }
        }
    }

    public void SetJoysticks(GameObject move, GameObject attack)
    {
        movementJoystick = move;
        attackJoystick = attack;
    }

    private byte[] ListToByteArray(List<int> myTeamMembersActorNumbers)
    {
        byte[] array = new byte[myTeamMembersActorNumbers.Count];
        for(int i = 0; i < myTeamMembersActorNumbers.Count; i++)
        {
            array[i] = (byte)myTeamMembersActorNumbers[i];
        }
        return array;
    }

    private void ChangeStoneZones()
    {
        byte[] data = MapScript.Instance.ChangeZonesRandom(placedStonesCounter);
        RaiseEventOptions rEO = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        PhotonNetwork.RaiseEvent(StoneZonesChangeEventCode, data, rEO, SendOptions.SendReliable);
    }

    private void SetAlphaCatcher(float value)
    {
        Color tempColor = catchImage.GetComponent<Image>().color;
        tempColor.a = value;
        catchImage.GetComponent<Image>().color = tempColor;
    }

    private void SetAlphaRunner(float value)
    {
        Color tempColor = runImage.GetComponent<Image>().color;
        tempColor.a = value;
        runImage.GetComponent<Image>().color = tempColor;
    }

    private void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    private void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    #region FireBase
    public void SaveData()
    {
        SaveLoadManager.Save(Settings.User);
    }
    #endregion
}

// + When hook not move
// + Bot clone color problem
// + Maybe death shot and hook with coroutine
//Invisibility death BOTA AID
// + Extra life fsyu fsyu
// + Extra life heart icon
// + Extra life give kill not score
// + Invisible olanda olme
//Key already added
// + Vaxt tez gedir

// + Invisibility animation
// + Slow downda olende yavas olur helede
// + invisible olanda olur
// + 2ci round botlar
// (not important) oyun sonu raise event
// + index out of bounds (master client)
// + 5 nefer bawlamaq
// + second life rotation
// + second life urekler, second life hit effect
// Daw yiganda ozumzude ses gelmir
// bu zibil 5 saniyeni artir
// gorunmezlikden sonra poxu cixdi