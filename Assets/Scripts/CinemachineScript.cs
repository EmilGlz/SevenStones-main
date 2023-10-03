using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineScript : MonoBehaviour
{
    public void FollowPlayer(GameObject player)
    {
        CinemachineVirtualCamera cVC = GetComponent<CinemachineVirtualCamera>();
        cVC.Follow = player.transform;
    }
}
