using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopRUSureController : MonoBehaviour
{
    public void BuyButtonChosen(GameObject imageLocation)
    {
        imageLocation.GetComponent<Image>().sprite = gameObject.GetComponentInChildren<Image>().sprite;
    }

}
