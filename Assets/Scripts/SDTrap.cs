using UnityEngine;

public class SDTrap : MonoBehaviour
{
    [HideInInspector] public byte ownerActNum;
    [HideInInspector] public float timeToDestroy;

    private void FixedUpdate()
    {
        timeToDestroy -= Time.fixedDeltaTime;
    }
}