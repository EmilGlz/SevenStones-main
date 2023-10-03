using Photon.Pun;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

#pragma warning disable IDE0051

public class LocalPlayer : MonoBehaviour
{
    [SerializeField] SpriteRenderer myTeamShadow;
    public TMP_Text nameTag;

    [HideInInspector] public byte actNum;
    [HideInInspector] public bool isBOT = false;
    [HideInInspector] public byte teamID = 0;
    [HideInInspector] public byte place = 0;
    [HideInInspector] public byte lives = 1;
    [HideInInspector] public bool isCatcher; // offline bool
    [HideInInspector] public bool hasShield;
    [HideInInspector] public byte lvl;

    [HideInInspector] public List<byte> teamMembers; //Photon player actor numbers of my teammates

    //Only Bot Data  
    [HideInInspector] public string nickName;
    [HideInInspector] public byte charIndex;
    [HideInInspector] public Pair<byte, byte> IdAndPlace;
    [HideInInspector] public Sprite avatar;
    //

    [PunRPC]
    private void SetTeamInfo(byte teamID, byte place, byte[] teamMembers,byte lives, byte lvl)
    {
        this.teamID = teamID;
        this.place = place;
        this.teamMembers = new List<byte>(teamMembers);
        this.lives = lives;
        this.lvl = lvl;
        actNum = (byte)GetComponent<PhotonView>().OwnerActorNr;
        GameLogicData.Instance.playerLvls.Add(GetComponent<PhotonView>().OwnerActorNr, lvl);
        AddGameObjectToData();
    }

    [PunRPC]
    void SetBotInfo(byte[] teamMembers)
    {
        this.teamMembers = new List<byte>(teamMembers);
        if (PhotonNetwork.IsMasterClient && teamID == 1)
        {
            this.teamMembers.Add((byte)PhotonNetwork.LocalPlayer.ActorNumber);
        }
        AddGameObjectToDataBot();
    }

    [PunRPC]
    void SetCharacterBOT(byte teamID, byte place, byte actorNumber, byte charIndex)
    {
        this.teamID = teamID;
        this.place = place;
        IdAndPlace = new Pair<byte, byte>(teamID, place);
        actNum = actorNumber;
        GetComponent<LocalPlayer>().actNum = actorNumber;
        this.charIndex = charIndex;
        //nickName = string.Format("BOT{0}", actorNumber);
        nickName = GameLogicData.Instance.botNames[new System.Random(actorNumber).Next(100)];
        gameObject.name = actorNumber.ToString();
        GameLogicData.Instance.playerLvls.Add(actorNumber, 1);

        GameObject character = Instantiate(GameObjectsData.Instance.characterPrefabs[charIndex], GetComponent<PlayerScript>().characterVisual.transform);
        GetComponent<PlayerScript>().Animator = character.GetComponent<Animator>();
        GetComponent<PlayerScript>().ballCloneRemote = character.GetComponent<CharacterData>().ballGO;
        avatar = GameObjectsData.Instance.avatarsRes[charIndex];
    }

    [PunRPC]
    private void ChangeColor()
    {
        if (GetComponent<PhotonView>().IsMine)
        {
            if (isBOT)
            {
                Color color = GetComponent<LocalPlayer>().teamMembers.Contains((byte)PhotonNetwork.LocalPlayer.ActorNumber) ? Color.green : Color.red;
                myTeamShadow.material.color = color; // For image
                nameTag.text = nickName;
                nameTag.color = color;
            }
            else
            {
                myTeamShadow.material.color = Color.cyan; //For image
                nameTag.text = PhotonNetwork.LocalPlayer.NickName;
                nameTag.color = Color.cyan;
            }
        }
        else
        {
            if (isBOT)
            {
                Color color = GetComponent<LocalPlayer>().teamMembers.Contains((byte)PhotonNetwork.LocalPlayer.ActorNumber) ? Color.green : Color.red;
                myTeamShadow.material.color = color; // For image
                nameTag.text = nickName;
                nameTag.color = color;
            }
            else
            {
                Color color = teamMembers.Contains((byte)PhotonNetwork.LocalPlayer.ActorNumber) ? Color.green : Color.red;
                myTeamShadow.material.color = color; // For image
                nameTag.text = GetComponent<PhotonView>().Owner.NickName;
                nameTag.color = color;
            }
        }

    }
    
    [PunRPC]
    private void SubHealth()
    {
        lives--;
    }

    private void AddGameObjectToData()
    {
        if (teamID == 1) GameObjectsData.Instance.team1Players.Add(gameObject.transform);
        else GameObjectsData.Instance.team2Players.Add(gameObject.transform);
    }

    private void AddGameObjectToDataBot()
    {
        if (!PhotonNetwork.IsMasterClient) GameObjectsData.Instance.bots.Add(gameObject);

        if (IdAndPlace.First == 1) GameObjectsData.Instance.team1Players.Add(gameObject.transform);
        else GameObjectsData.Instance.team2Players.Add(gameObject.transform);
    }
}