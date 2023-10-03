using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenuUIController : MonoBehaviour
{
    public GameObject characterMagazine;
    public GameObject BallMagazine;
    public GameObject moneyMagazine;
    public GameObject clothesMagazine;

    public GameObject CharacterButton;
    public GameObject BallButton;
    public GameObject moneyMagazineButton;
    public GameObject clothesMagazineButton;

    public Sprite characterMagazineChosen;
    public Sprite moneyMagazineChosen;
    public Sprite ballMagazineChosen;
    public Sprite clothesMagazineChosen;

    public Sprite characterMagazineNotChosen;
    public Sprite moneyMagazineNotChosen;
    public Sprite ballMagazineNotChosen;
    public Sprite clothesMagazineNotChosen;


    public void CharacterShopButtonPressed()
    {
        characterMagazine.SetActive(true);
        BallMagazine.SetActive(false);
        moneyMagazine.SetActive(false);
        clothesMagazine.SetActive(false);
        CharacterButton.GetComponent<Image>().sprite = characterMagazineChosen;
        moneyMagazineButton.GetComponent<Image>().sprite = moneyMagazineNotChosen;
        BallButton.GetComponent<Image>().sprite = ballMagazineNotChosen;
        clothesMagazineButton.GetComponent<Image>().sprite = clothesMagazineNotChosen;
    }

    public void MoneyShopButtonPressed()
    {
        moneyMagazine.SetActive(true);
        characterMagazine.SetActive(false);
        BallMagazine.SetActive(false);
        clothesMagazine.SetActive(false);
        moneyMagazineButton.GetComponent<Image>().sprite = moneyMagazineChosen;
        CharacterButton.GetComponent<Image>().sprite = characterMagazineNotChosen;
        BallButton.GetComponent<Image>().sprite = ballMagazineNotChosen;
        clothesMagazineButton.GetComponent<Image>().sprite = clothesMagazineNotChosen;
    }


    public void BallShopButtonPressed()
    {
        BallMagazine.SetActive(true);
        characterMagazine.SetActive(false);
        moneyMagazine.SetActive(false);
        clothesMagazine.SetActive(false);
        BallButton.GetComponent<Image>().sprite = ballMagazineChosen;
        CharacterButton.GetComponent<Image>().sprite = characterMagazineNotChosen;
        moneyMagazineButton.GetComponent<Image>().sprite = moneyMagazineNotChosen;
        clothesMagazineButton.GetComponent<Image>().sprite = clothesMagazineNotChosen;
    }

    public void ClothesShopButtonPressed()
    {
        clothesMagazine.SetActive(true);
        BallMagazine.SetActive(false);
        characterMagazine.SetActive(false);
        moneyMagazine.SetActive(false);
        clothesMagazineButton.GetComponent<Image>().sprite = clothesMagazineChosen;
        moneyMagazineButton.GetComponent<Image>().sprite = moneyMagazineNotChosen;
        BallButton.GetComponent<Image>().sprite = ballMagazineNotChosen;
        CharacterButton.GetComponent<Image>().sprite = characterMagazineNotChosen;
    }




}
