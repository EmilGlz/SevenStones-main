using UnityEngine;
using Photon.Pun;
using Cinemachine;
using TMPro;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class PhotonNetworkingInGame : MonoBehaviourPunCallbacks
{
    private const string PLAYERPREFABNAME = "Player";

    private const string PLAYERNICKPREF = "nick";
    private const string PLAYERLVLPREF = "lvl";
    private const string CHARACTERINDEXPREF = "ch";
    private const string RUNNERSKILLPREF = "rs";
    private const string RUNNERSKILLLVLPREF = "rslvl";
    private const string CATCHERSKILLPREF = "cs";
    private const string CATCHERSKILLLVLPREF = "cslvl";
    //private const string MAPINDEXPREF = "map";
    private const string BALLINDEXPREF = "ball";
    private const string DATAPREF = "data";

    [SerializeField] GameObject commonCanvas;
    [SerializeField] GameObject gameLogic;
    [SerializeField] GameObject movementJoystick;
    [SerializeField] GameObject attackJoystick;
    [SerializeField] Transform relatedInitializingPosition;
    [SerializeField] TMP_Text dashTimer;
    [SerializeField] CinemachineVirtualCamera cinemachine;

    private GameObject myGameObject;
    private readonly Vector3[] playerPositions = new Vector3[] { new Vector3(2, 2, -16),
                                                        new Vector3(-2, 2, -16),
                                                        new Vector3(6, 2, -16),
                                                        new Vector3(-6, 2, -16),
                                                        new Vector3(2, 2, 16),
                                                        new Vector3(-2, 2, 16),
                                                        new Vector3(-6, 2, 16),
                                                        new Vector3(6, 2, 16) };

    public override void OnJoinedRoom()
    {
        //Debug.Log("Joined Room. Lobby name: " + PhotonNetwork.CurrentLobby.Name);
        GameLogicData.Instance.dataString = PlayerPrefs.GetString(DATAPREF);

        commonCanvas.SetActive(true);

        //Instantiate player, set nickname, joystick assign
        PhotonNetwork.LocalPlayer.NickName = PlayerPrefs.GetString(PLAYERNICKPREF,"player");
        myGameObject = PhotonNetwork.Instantiate(PLAYERPREFABNAME,GetPlayerPosition(),Quaternion.identity);
        int characterIndex = PlayerPrefs.GetInt(CHARACTERINDEXPREF, 0);
        myGameObject.GetComponent<PlayerMovement>().SetStartInfo(movementJoystick, attackJoystick, dashTimer, PlayerPrefs.GetInt(BALLINDEXPREF), characterIndex);
        myGameObject.GetComponent<PhotonView>().RPC("SetCharacter", RpcTarget.AllBuffered, (byte)characterIndex);
        myGameObject.layer = 3; // Layer to Local
        GameObjectsData.Instance.localPlayer = myGameObject.transform;
        gameLogic.GetComponent<GameLogicPlayer>().SetMyGameObject(myGameObject);

        gameLogic.GetComponent<GameLogicPlayer>()
            .ManageSkills(PlayerPrefs.GetInt(RUNNERSKILLPREF), 
                          PlayerPrefs.GetInt(RUNNERSKILLLVLPREF), 
                          PlayerPrefs.GetInt(CATCHERSKILLPREF), 
                          PlayerPrefs.GetInt(CATCHERSKILLLVLPREF));

        Hashtable hash = new Hashtable { { "c", PlayerPrefs.GetInt(CHARACTERINDEXPREF, 0) } };
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);

        gameLogic.GetComponent<GameLogicPlayer>().SetJoysticks(movementJoystick, attackJoystick);
        //Cinemachine follow
        cinemachine.Follow = myGameObject.transform;
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        gameLogic.GetComponent<GameLogicPlayer>().PlayerLeftRoom(otherPlayer.ActorNumber);
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        if (PhotonNetwork.LocalPlayer.Equals(newMasterClient))
        {
            foreach (GameObject bot in GameObjectsData.Instance.bots)
            {
                bot.GetComponent<BotController>().enabled = true;
                bot.GetComponent<BotController>().StartRound(bot.GetComponent<PlayerScript>().isCatcher);
            }
        }
        else
        {
            foreach (GameObject bot in GameObjectsData.Instance.bots)
            {
                bot.GetComponent<BotController>().enabled = false;
            }
        }
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause && PhotonNetwork.IsMasterClient)
        {
            if(PhotonNetwork.PlayerListOthers.Length == 0)
            {
                PhotonNetwork.Disconnect();
            }
            else
            {
                PhotonNetwork.SetMasterClient(PhotonNetwork.PlayerListOthers[0]);
            }
        }
    }

    private Vector3 GetPlayerPosition()
    {
        int playerCount = PhotonNetwork.PlayerList.Length;
        if(playerCount == 0)
        {
            return Vector3.zero;
        }
        return (playerCount % 2 == 1) ? ( relatedInitializingPosition.position + playerPositions[(playerCount-1) / 2]) : ( relatedInitializingPosition.position + playerPositions[4 + (playerCount-1) / 2]);
    }
}