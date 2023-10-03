using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuToInventoryController : MonoBehaviour
{
    [SerializeField] GameObject shopPanel;
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] GameObject ballPanelInInventory;
    [SerializeField] GameObject characterPanelInInventory;

    public InventoryMenuUIController inventoryMenuUIController;

    //public enum ButtonTypeIndex { characters, balls };


    public void InventoryButtonChosen(int buttonType)
    {
        shopPanel.SetActive(false);
        inventoryPanel.SetActive(true);
        if (buttonType == 1) // 1
        {
            characterPanelInInventory.SetActive(false);
            ballPanelInInventory.SetActive(true);
            inventoryMenuUIController.GetComponent<InventoryMenuUIController>().BallInventoryButtonPressed();
        }
        if (buttonType == 0) // 0
        {
            ballPanelInInventory.SetActive(false);
            characterPanelInInventory.SetActive(true);
            inventoryMenuUIController.GetComponent<InventoryMenuUIController>().CharacterInventoryButtonPressed();
        }

    }

}
