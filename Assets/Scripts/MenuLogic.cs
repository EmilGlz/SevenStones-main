using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class MenuLogic : MonoBehaviour
{
    [SerializeField] Button playButton;

    private void Start()
    {
        playButton.onClick.AddListener(PhotonNetworkingMain.Instance.OnClick_JoinRandomRoom);
    }
}
