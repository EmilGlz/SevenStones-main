using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuDefaultMaker : MonoBehaviour
{
     public GameObject characterMagazine;
     public GameObject BallMagazine;
     public GameObject moneyMagazine;
     
     public GameObject characterShopButton;
     public GameObject BallShopButton;
     public GameObject moneyMagazineButton;
     
     public Sprite characterChosen;
     
     public Sprite moneyNotChosen;
     public Sprite ballNotChosen;
     
     public GameObject CharacterInventory;
     public GameObject BallInventory;
     
     public GameObject CharacterInventoryButton;
     public GameObject BallInventoryButton;

     public UIObjectsRotator uiObjectsRotator;

    public GameObject[] pageTwos;
    public GameObject[] pageOnes;

    public RectTransform[] contentPanelsInInventory;
    public void MakeShopDefault()
    {
        characterMagazine.SetActive(true);
        BallMagazine.SetActive(false);
        moneyMagazine.SetActive(false);
        //clothesMagazine.SetActive(false);
        characterShopButton.GetComponent<Image>().sprite = characterChosen;
        moneyMagazineButton.GetComponent<Image>().sprite = moneyNotChosen;
        BallShopButton.GetComponent<Image>().sprite = ballNotChosen;
        //clothesMagazineButton.GetComponent<Image>().sprite = clothesMagazineNotChosen;
        for (int i = 0; i < 4; i++)
        {
            pageOnes[i].SetActive(true);
            pageTwos[i].SetActive(false);
        }
    }

    public void MakeInventoryDefault()
    {
        CharacterInventory.SetActive(true);
        BallInventory.SetActive(false);
        //ClothesInventory.SetActive(false);
        CharacterInventoryButton.GetComponent<Image>().sprite = characterChosen;
        //ClothesInventoryButton.GetComponent<Image>().sprite = ClothesInventoryNotChosen;
        BallInventoryButton.GetComponent<Image>().sprite = ballNotChosen;
        for (int i = 0; i < 3; i++)
        {
            contentPanelsInInventory[i].anchoredPosition = new Vector3(-6.78f, -1267.17f, 0f);
        }
    }

}
