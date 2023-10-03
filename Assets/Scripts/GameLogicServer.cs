///Server Base like Logic Code On Client
///I am MasterClient
///No UI components must be here

using UnityEngine;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;

public class GameLogicServer : MonoBehaviour
{
    private const byte EndFirstRoundEventCode = 4;
    private const byte GameStartEventCode = 5;

    private const int CHARACTERCOUNT = 14;

    [SerializeField] Transform rIPBOT;
    [SerializeField] Light directionalLight;

    //TODO maxPLayers
    readonly int maxPlayers = 8;

    float startWithBotTime;
    //float gameStartTime;      //Photon.Time
    bool allJoinCheck = false;
    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        startWithBotTime = Time.time + 20f;
    }

    void Update()
    {
        // Teaming calculating and time connection start when all joins
        if (PhotonNetwork.IsMasterClient && !allJoinCheck && (PhotonNetwork.PlayerList.Length == maxPlayers || Time.time > startWithBotTime))
        {
            allJoinCheck = true;
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;
            StartCoroutine(StartGame());
        }
    }

    public void GameStarted()//for clients
    {
        allJoinCheck = true;
    }

    private void RandomBotInitializing()
    {
        int playerCount = PhotonNetwork.PlayerList.Length;
        int botCounter = maxPlayers - PhotonNetwork.PlayerList.Length;
        byte randByte;
        System.Random random = new System.Random();
        for (int i = 0; i < botCounter; i++)
        {
            randByte = (byte)random.Next(CHARACTERCOUNT);
            GameObject bot = PhotonNetwork.InstantiateRoomObject("BOT", new Vector3(rIPBOT.position.x + i * 4, 2, rIPBOT.position.z), Quaternion.identity);
            bot.GetComponent<PhotonView>().RPC("SetCharacterBOT", RpcTarget.AllBuffered, (byte)((i + playerCount) % 2 == 0 ? 1 : 2), //team
                    (byte)((i + playerCount) / 2), //place
                    (byte)(100 + i),
                    randByte);
            GameObjectsData.Instance.bots.Add(bot);
        }
    }

    public IEnumerator StartGame() // Master client starts games
    {
        yield return new WaitForSeconds(.5f);
        RandomBotInitializing();
        object[] content = { (float)PhotonNetwork.Time, (byte)new System.Random().Next(4)};
        RaiseEventOptions rEO = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        PhotonNetwork.RaiseEvent(GameStartEventCode, content, rEO, SendOptions.SendReliable);
    }

    // Only called on MasterClient
    // Sent second round start time
    public void EndFirstRound()
    {
        object[] content = { (float)PhotonNetwork.Time, (byte)new System.Random().Next(4)};
        RaiseEventOptions rEO = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        PhotonNetwork.RaiseEvent(EndFirstRoundEventCode, content, rEO, SendOptions.SendReliable);
    }
}