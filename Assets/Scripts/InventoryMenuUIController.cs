using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenuUIController : MonoBehaviour
{
    public GameObject CharacterInventory;
    public GameObject BallInventory;
    public GameObject ClothesInventory;

    public GameObject CharacterButton;
    public GameObject BallButton;
    public GameObject ClothesButton;

    public Sprite characterInventoryChosen;
    public Sprite ClothesInventoryChosen;
    public Sprite ballInventoryChosen;

    public Sprite characterInventoryNotChosen;
    public Sprite ClothesInventoryNotChosen;
    public Sprite ballInventoryNotChosen;


    public void CharacterInventoryButtonPressed()
    {
        CharacterInventory.SetActive(true);
        BallInventory.SetActive(false);
        ClothesInventory.SetActive(false);
        CharacterButton.GetComponent<Image>().sprite = characterInventoryChosen;
        ClothesButton.GetComponent<Image>().sprite = ClothesInventoryNotChosen;
        BallButton.GetComponent<Image>().sprite = ballInventoryNotChosen;
    }

    public void ClothesInventoryButtonPressed()
    {
        ClothesInventory.SetActive(true);
        CharacterInventory.SetActive(false);
        BallInventory.SetActive(false);
        ClothesButton.GetComponent<Image>().sprite = ClothesInventoryChosen;
        CharacterButton.GetComponent<Image>().sprite = characterInventoryNotChosen;
        BallButton.GetComponent<Image>().sprite = ballInventoryNotChosen;
    }


    public void BallInventoryButtonPressed()
    {
        BallInventory.SetActive(true);
        CharacterInventory.SetActive(false);
        ClothesInventory.SetActive(false);
        BallButton.GetComponent<Image>().sprite = ballInventoryChosen;
        CharacterButton.GetComponent<Image>().sprite = characterInventoryNotChosen;
        ClothesButton.GetComponent<Image>().sprite = ClothesInventoryNotChosen;
    }




    public void ShopButtonPressed(Image buttonImage)
    {
        buttonImage.color = Color.red;
    }
}
