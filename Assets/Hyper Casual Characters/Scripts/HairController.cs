using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairController : MonoBehaviour
{
    [SerializeField]
    private Transform head;
    [SerializeField]
    private GameObject hair;
    [SerializeField]
    private GameObject face;


    public void ChangeFace()
    {
        if (face != null)
            DestroyImmediate(face);
        Instantiate(face, head);
    }

    public void ChangeHair()
    {
        if (hair != null)
            DestroyImmediate(hair);
        Instantiate(hair, head);
    }
}
