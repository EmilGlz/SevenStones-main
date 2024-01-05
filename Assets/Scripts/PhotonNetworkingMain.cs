using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhotonNetworkingMain : MonoBehaviourPunCallbacks
{
    //private const string TESTROOMNAME = "TESTROOM";
    //private const string GAMELOGICPREFABNAME = "GameLogic";

    private const string PLAYERNICKPREF = "nick";
    private const string PLAYERLVLPREF = "lvl";
    private const string CHARACTERINDEXPREF = "ch";
    private const string RUNNERSKILLPREF = "rs";
    private const string RUNNERSKILLLVLPREF = "rslvl";
    private const string CATCHERSKILLPREF = "cs";
    private const string CATCHERSKILLLVLPREF = "cslvl";
    private const string MAPINDEXPREF = "map";
    private const string BALLINDEXPREF = "ball";
    private const string DATAPREF = "data";

    private const string MAP_PROP_KEY = "m";

    private int failedAttempts = 0;
    [HideInInspector] public bool inGame = false;
    //private bool gameStart = false;
    private bool firstTimeDisconnect = true;

    #region Singleton
    private static PhotonNetworkingMain instance;
    public static PhotonNetworkingMain Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    private void Start()
    {
        Debug.Log("Connecting to Photon Network Master.");
        PhotonNetwork.GameVersion = "0.0.1";
        try
        {
            MenuCommonObjects.Instance.connectingToInternetPanelInStart.SetActive(true);
            PhotonNetwork.ConnectUsingSettings();
        }
        catch (System.Exception)
        {
            return;
        }
    }
    //TODO After connecting to database
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected Photon Network Master. Connecting to Photon Network Lobby.");
        if (MenuCommonObjects.Instance.connectingToInternetPanelInStart != null)
            MenuCommonObjects.Instance.connectingToInternetPanelInStart.SetActive(false);
        PhotonNetwork.JoinLobby(new TypedLobby("0", LobbyType.Default));
    }

    //TODO Info for player before game start: Check connection and try again
    //TODO In game if player disconnect goes after login screen
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Photon Disconnected!");
        if (!inGame)
        {
            Debug.Log("Loading Menu Scene.");
            SceneManager.LoadScene(0);
        }
        else if (firstTimeDisconnect)
        {
            //Debug.Log("Trying to reconnect.");
            //Debug.Log("Reconnecting returned : " + PhotonNetwork.ReconnectAndRejoin());
            GameObjectsData.Instance.reconnectPanel.SetActive(true);
            firstTimeDisconnect = false;
            StartCoroutine(WaitAndGoMenu());
        }
        //else if (!firstTimeDisconnect)
        //{
        //    Debug.Log("Second time disconnect!");
        //    firstTimeDisconnect = true;
        //    GameObjectsData.Instance.reconnectInfo.text = "Reconnection failed. Menu is loading...";
        //    StartCoroutine(WaitAndGoMenu());
        //}
    }

    IEnumerator WaitAndGoMenu()
    {
        yield return new WaitForSeconds(3f);
        GameObjectsData.Instance.reconnectInfo.text = "Reconnection failed. Menu is loading...";
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }

    //Callback when player try to reconnect and failed
    //public override void OnJoinRoomFailed(short returnCode, string message)
    //{
    //    GameObjectsData.Instance.reconnectInfo.text = "Reconnection failed. Menu is loading...";
    //    inGame = false;
    //    SceneManager.LoadScene(1);
    //}

    public override void OnJoinedLobby()
    {
        Debug.Log("Connected Photon Network Lobby.");
        if (MenuCommonObjects.Instance.loadingSlider != null) MenuUIController.Instance.SetSliderWithTweening(0.5f, 1f);
        StartCoroutine(SetLoadingPanel(1f));
    }

    IEnumerator SetLoadingPanel(float _delayTime)
    {
        yield return new WaitForSeconds(_delayTime);
        if (MenuCommonObjects.Instance.loadingPanel != null) LocalDatas.Instance.SetLoadingPanelWithTweening();
    }

    //Join room with Play button
    public void OnClick_JoinRandomRoom()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            MenuCommonObjects.Instance.loadingPanel.SetActive(true);

            PlayerPrefs.SetString(PLAYERNICKPREF, Settings.User.nickName);
            PlayerPrefs.SetInt(PLAYERLVLPREF, Settings.User.level);
            PlayerPrefs.SetInt(CHARACTERINDEXPREF, LocalDatas.Instance.currentCharacterIndex);
            PlayerPrefs.SetInt(RUNNERSKILLPREF, LocalDatas.Instance.currentRunnerSkill);
            PlayerPrefs.SetInt(RUNNERSKILLLVLPREF, LocalDatas.Instance.runnerSkillsLevels[LocalDatas.Instance.currentRunnerSkill]);
            PlayerPrefs.SetInt(CATCHERSKILLPREF, LocalDatas.Instance.currentCatcherSkill);
            PlayerPrefs.SetInt(CATCHERSKILLLVLPREF, LocalDatas.Instance.catcherSkillsLevels[LocalDatas.Instance.currentCatcherSkill]);
            PlayerPrefs.SetInt(MAPINDEXPREF, LocalDatas.Instance.currentMapIndex);
            PlayerPrefs.SetInt(BALLINDEXPREF, LocalDatas.Instance.currentBallSkinIndex);
            PlayerPrefs.SetString(DATAPREF, LocalDatas.Instance.GetDataString());

            if (failedAttempts > 3)
            {
                failedAttempts = 0;
                SceneManager.LoadScene(0);
            }
            if (PhotonNetwork.InLobby)
            {
                ///MAIN CODES*********************************
                ///
                ExitGames.Client.Photon.Hashtable hash = new ExitGames.Client.Photon.Hashtable { { MAP_PROP_KEY, LocalDatas.Instance.currentMapIndex } };
                if (!PhotonNetwork.JoinRandomRoom(hash, 8))
                {
                    Debug.Log("Join random room return false!!!");
                }
                ///**********************************
                ///
            }
            inGame = true;
            PhotonNetwork.LoadLevel(1);
        }
        else SceneManager.LoadScene(0);
    }

    //There is no room to join so player create new room
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        //Debug.Log(message);
        RoomOptions roomOptions = new RoomOptions
        {
            MaxPlayers = 8,
            EmptyRoomTtl = 5000, // 5 seconds to destroy empty rooms
            PlayerTtl = 5000 // 12 seconds to remove player after disconnected 
        };
        ExitGames.Client.Photon.Hashtable hash = new ExitGames.Client.Photon.Hashtable { { MAP_PROP_KEY, LocalDatas.Instance.currentMapIndex } };
        roomOptions.CustomRoomPropertiesForLobby = new string[] { MAP_PROP_KEY };
        roomOptions.CustomRoomProperties = hash;
        if (!PhotonNetwork.CreateRoom(null, roomOptions, TypedLobby.Default))
        {
            Debug.Log("Create room return false!!! Loading Menu Scene");
            SceneManager.LoadScene(0);
        }
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Create Room Failed. Joining Room again!");
        failedAttempts++;
        OnClick_JoinRandomRoom();
    }
}