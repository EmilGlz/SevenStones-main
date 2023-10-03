using Photon.Pun;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MapFollow : MonoBehaviour
{
    [SerializeField] GameObject mapPlayerIcon;
    [SerializeField] Sprite[] mapIconsRes;
    RectTransform iconTransfrom;

    int catcherValue = 1;
    bool localPlayer;
    private void Start()
    {
        localPlayer = GetComponent<PhotonView>().IsMine;
        iconTransfrom = mapPlayerIcon.GetComponent<RectTransform>();
    }

    [PunRPC]
    public void SetMapIcon()
    {
        if (GetComponent<LocalPlayer>().teamMembers.Contains((byte)PhotonNetwork.LocalPlayer.ActorNumber) || localPlayer)
        {
            mapPlayerIcon.GetComponent<Image>().sprite = mapIconsRes[GetComponent<LocalPlayer>().place];
            mapPlayerIcon.SetActive(true);
        }
    }

    public void MapShowSkill(float time)
    {
        mapPlayerIcon.SetActive(true);
        IEnumerator coroutine = HideMapIcon(time);
        StartCoroutine(coroutine);
    }

    private IEnumerator HideMapIcon(float time)
    {
        yield return new WaitForSeconds(time);
        mapPlayerIcon.SetActive(false);
    }

    void LateUpdate()
    {
        iconTransfrom.anchoredPosition = new Vector3(transform.position.x * 2 * catcherValue, transform.position.z * 2 * catcherValue, 0);
    }
}
