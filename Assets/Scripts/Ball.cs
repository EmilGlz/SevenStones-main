using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //private const byte PLAYERLAYER = 7;
    //private const byte LOCALLAYER = 3;

    private const byte BallHitEventCode = 1;

    [HideInInspector] public bool isDeadly = false;
    [HideInInspector] public byte ownerActNum;
    [HideInInspector] public byte[] ownerTeamActNums;

    [SerializeField] ProjectileScript projectileScript;

    List<byte> myTeamActNums;
    void Start()
    {
        Destroy(gameObject, isDeadly ? 10f : 1f);
        myTeamActNums = new List<byte>(ownerTeamActNums);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Ball collide with player and not with player itself
        if ((other.gameObject.CompareTag("Bot") || other.gameObject.CompareTag("Player")) && ownerActNum != other.gameObject.GetComponent<LocalPlayer>().actNum)
        {
            bool secondLife = false;
            //Only local Player calculate and only for opp team members
            if (PhotonNetwork.LocalPlayer.ActorNumber == ownerActNum && !myTeamActNums.Contains(other.gameObject.GetComponent<LocalPlayer>().actNum))
            {
                if (other.gameObject.GetComponent<LocalPlayer>().lives > 1)
                {
                    secondLife = true;
                }
                else
                {
                    RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
                    object[] content = { ownerActNum, other.gameObject.GetComponent<LocalPlayer>().actNum, (float)PhotonNetwork.Time };
                    PhotonNetwork.RaiseEvent(BallHitEventCode, content, raiseEventOptions, SendOptions.SendReliable);
                }
                GameObject hit1 = Instantiate(projectileScript.hit, transform.position, Quaternion.identity);
                Destroy(hit1, 1f);
                Destroy(gameObject);
                other.gameObject.GetComponent<PhotonView>().RPC("BallHit", RpcTarget.All, secondLife);
            }
            //Calculating for bot
            else if (PhotonNetwork.IsMasterClient && ownerActNum >= 100 && !myTeamActNums.Contains(other.gameObject.GetComponent<LocalPlayer>().actNum))
            {
                if (other.gameObject.GetComponent<LocalPlayer>().lives > 1)
                {
                    secondLife = true;
                }
                else
                {
                    RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
                    object[] content = { ownerActNum, other.gameObject.GetComponent<LocalPlayer>().actNum, (float)PhotonNetwork.Time };
                    PhotonNetwork.RaiseEvent(BallHitEventCode, content, raiseEventOptions, SendOptions.SendReliable);
                }
                GameObject hit1 = Instantiate(projectileScript.hit, transform.position, Quaternion.identity);
                Destroy(hit1, 1f);
                Destroy(gameObject);
                other.gameObject.GetComponent<PhotonView>().RPC("BallHit", RpcTarget.All, secondLife);
            }
            else if (PhotonNetwork.LocalPlayer.ActorNumber == ownerActNum && myTeamActNums.Contains(other.gameObject.GetComponent<LocalPlayer>().actNum))
            {
                GameObject hit1 = Instantiate(projectileScript.hit, transform.position, Quaternion.identity);
                Destroy(hit1, 1f);
                Destroy(gameObject);
            }
        }
        else if (!other.gameObject.CompareTag("Bot") && !other.gameObject.CompareTag("Player") && !isDeadly)
        {
            GameObject hit1 = Instantiate(projectileScript.hit, transform.position, Quaternion.identity);
            Destroy(hit1, 1f);
            Destroy(gameObject);
        }
    }
}
