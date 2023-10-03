using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

#pragma warning disable IDE0051
public class BotClone : MonoBehaviour, IPunInstantiateMagicCallback
{
    [SerializeField] GameObject characterVisual;
    [SerializeField] TMP_Text nameTag;
    [SerializeField] SpriteRenderer teamShadow;
    Transform selectedPlayer;
    bool catcherActive = false;

    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        // byte index,  float time
        object[] data = info.photonView.InstantiationData;
        GameObject clone = Instantiate(GameObjectsData.Instance.characterPrefabs[(byte)data[0]], characterVisual.transform);
        clone.GetComponent<Animator>().SetBool("IsMoving", true);
        nameTag.text = GetComponent<PhotonView>().Owner.NickName;
        if(GetComponent<PhotonView>().IsMine)
        {
            teamShadow.material.color = Color.cyan;
            nameTag.color = Color.cyan;
        }
        else 
        {
            Color color = GameLogicData.Instance.myTeamActNums.Contains(GetComponent<PhotonView>().OwnerActorNr) ? Color.green : Color.red;
            teamShadow.material.color = color;
            nameTag.color = color;
        }
        Destroy(gameObject, (float) data[1]);
    }

    public void CloneCommand(bool isCatcher, int seed)
    {
        GetComponent<NavMeshAgent>().enabled = true;
        if (isCatcher)
        {
            selectedPlayer = GameObjectsData.Instance.RandomPlayer(seed);
            catcherActive = true;
        }
        else
        {
            GetComponent<NavMeshAgent>().SetDestination(GameObjectsData.Instance.RandomStoneZone(seed));
        }
    }

    private void Update()
    {
        if (catcherActive)
        {
            GetComponent<NavMeshAgent>().SetDestination(selectedPlayer.position);
        }
    }
}
