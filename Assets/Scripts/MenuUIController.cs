using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class MenuUIController : MonoBehaviour
{
    //[SerializeField] GameObject playerObjectParent;

    #region Singleton

    private static MenuUIController instance;

    public static MenuUIController Instance { get => instance; }

    private void Awake()
    {
        instance = this;
    }

    #endregion



    #region Overall variables

    public float time;
    [SerializeField] string helpSupportURL;
    [SerializeField] string privacyURL;
    [SerializeField] string sevenStonesPlayStoreURL;
    [SerializeField] RectTransform playerObjectParentPositionInPlayPanel;
    [SerializeField] Vector3 playerObjectParentPositionInMainMenu;
    [SerializeField] RectTransform playerObjectParentInMainMenu;
    [SerializeField] GameObject playerProfilePanel;
    [SerializeField] GameObject playerProfilePanelChild;

    [SerializeField] GameObject characterPanel;
    [SerializeField] GameObject characterPanelChild;

    [SerializeField] GameObject shopPanel;
    [SerializeField] GameObject shopPanelChild;

    [SerializeField] GameObject skillsPanel;
    [SerializeField] GameObject skillsPanelChild;

    [SerializeField] GameObject arenaPanel;
    [SerializeField] GameObject arenaPanelChild;

    [SerializeField] GameObject optionsPanel;
    public GameObject optionsPanelChild;

    [SerializeField] GameObject ChangePPPanel;
    [SerializeField] GameObject ChangePPPanelChild;

    [SerializeField] GameObject PlayPanel;
    [SerializeField] GameObject PlayPanelChild;

    [SerializeField] GameObject characterInsideMenu;
    [SerializeField] GameObject characterInsideMenuChild;

    [SerializeField] GameObject changeNickMenu;
    [SerializeField] GameObject changeNickMenuChild;

    [SerializeField] GameObject UpdatePanel;



    //[SerializeField] GameObject characterInsidePlayerObject;

    //[SerializeField] GameObject notEnoughMoneyImage;
    [SerializeField] TMP_Text notEnoughMoneyText;
    [SerializeField] GameObject notEnoughMoneyPanel;
    [SerializeField] float infoTextFadeTime;
    [SerializeField] float infoTextDelayTime;
    [SerializeField] Color notEnoughMoneyTextColor;

    [SerializeField] GameObject tryAgainPanel;

    #endregion

    [Space(20)]

    #region Play panel variables

    public TMP_Text characterNameInPlayPanel;


    [SerializeField] GameObject runnerPlayButton;
    [SerializeField] GameObject catcherPlayButton;

    [SerializeField] GameObject runnerPanel;
    [SerializeField] GameObject catcherPanel;

    [SerializeField] Sprite selectedSprite;
    [SerializeField] Sprite notSelectedSprite;



    //[SerializeField] GameObject LocalDatas.Instance.selectedRunnerSkillImage;
    //[SerializeField] GameObject LocalDatas.Instance.selectedCatcherSkillImage;

    //[SerializeField] TMP_Text LocalDatas.Instance.runnerSkillNameText;
    //[SerializeField] TMP_Text LocalDatas.Instance.catcherSkillNameText;

    #endregion

    [Space(20)]
    [Header("Shop variables")]
    #region Shop variables
    [Space(20)]

    [SerializeField] GameObject[] inShopButtons;
    [SerializeField] Sprite[] inShopButtonsSprites;

    [SerializeField] RectTransform shopScrollContent;

    //[SerializeField] GameObject RUSureObjectImage;

    [SerializeField] TMP_Text ruSureInShopPriceText;
    [SerializeField] TMP_Text ruSureInShopGainingCoinText;

    //[SerializeField] GameObject[] ballsInShop;
    //[SerializeField] TMP_Text[] ballPricesTexts;

    [SerializeField] GameObject[] ssCoinssInShop;
    [SerializeField] TMP_Text[] ssCoinPricesTexts;
    [SerializeField] TMP_Text[] ssCoinValuesTexts;

    [SerializeField] GameObject InShopBuyButton;

    [SerializeField] GameObject ruSureCoinImage;

    [SerializeField] Sprite coinSprite;
    [SerializeField] Sprite diamondSprite;

    //[SerializeField] GameObject ruSurePanel;

    [SerializeField] GameObject ruSureShopPanel;

    [SerializeField] TMP_Text changeNickPriceText;

    #endregion


    [Space(20)]
    [Header("Change Profile Picture variables")]
    #region Change PP variables


    //[SerializeField] RectTransform[] PPImagesPoss;
    [SerializeField] GameObject scrollBackgroundImage;
    [SerializeField] GameObject[] PPImages;
    [SerializeField] RectTransform changePPScrollContent;
    [SerializeField] RectTransform MiddleImage;
    [SerializeField] GameObject MiddlePImage;
    #endregion

    [Space(20)]
    [Header("Character Panel variables")]
    #region character panel variables

    [SerializeField] TMP_Text[] characterInsidePanelLevelInfoTexts;

    [SerializeField] TMP_Text characterInfoText;

    [SerializeField] GameObject[] lockPanels;
    //[SerializeField] GameObject[] lockPanels;

    [SerializeField] TMP_Text characterPriceText;

    [SerializeField] GameObject[] playerCharacterObjects;

    [SerializeField] GameObject characterInsidePricePanel;


    [SerializeField] GameObject[] sprintCharacterLevelImages;
    [SerializeField] GameObject[] dashCharacterLevelImages;

    [SerializeField] TMP_Text characterNameInCharacterInsidePanel;

    #endregion

    [Space(20)]

    #region PlayerProfile variables

    [SerializeField] GameObject ruSureChangeNickPanel;
    [SerializeField] TMP_InputField changeNickInputfield;

    #endregion

    [Space(20)]
    [Header("Skill variables")]
    #region Skill variables

    [SerializeField] GameObject[] runnerSkillBlackSquares;
    [SerializeField] GameObject[] catcherSkillBlackSquares;

    //[SerializeField] TMP_Text fullText;
    [SerializeField] Color32 skillInfoColorNotOpened;
    [SerializeField] Color32 skillInfoColorOpened;

    [SerializeField] Image miniSkillImageRunner;
    [SerializeField] Image miniSkillImageCatcher;

    [SerializeField] GameObject improveRunnerButton;
    [SerializeField] GameObject improveCatcherButton;

    [SerializeField] Sprite runnerButtonSelectedSprite;
    [SerializeField] Sprite runnerButtonNotSelectedSprite;

    [SerializeField] Sprite catcherButtonSelectedSprite;
    [SerializeField] Sprite catcherButtonNotSelectedSprite;

    [SerializeField] GameObject runnerSkillsPanel;
    [SerializeField] GameObject catcherSkillsPanel;

    [SerializeField] GameObject bigSkillImageRunner;
    [SerializeField] GameObject bigSkillImageCatcher;

    [SerializeField] TMP_Text skillNameTextRunner;
    [SerializeField] TMP_Text skillNameTextCatcher;


    //[SerializeField] GameObject firstSkillImageRunner;
    //[SerializeField] GameObject firstSkillImageCatcher;


    [SerializeField] GameObject runnerSkillsButton;
    [SerializeField] GameObject catcherSkillsButton;

    [SerializeField] GameObject[] runnerSkillsLevelImages;
    [SerializeField] GameObject[] catcherSkillsLevelImages;

    [SerializeField] GameObject[] runnerSkillsButtons;
    [SerializeField] GameObject[] catcherSkillsButtons;

    [SerializeField] Sprite[] runnerSkillsLevelSpritesBack;
    [SerializeField] Sprite[] catcherSkillsLevelSpritesBack;

    [SerializeField] GameObject runnerSkillLevelImageBack;
    [SerializeField] GameObject catcherSkillLevelImageBack;


    [SerializeField] TMP_Text runnerSkillInfoText;
    [SerializeField] TMP_Text catcherSkillInfoText;

    [SerializeField] TMP_Text runnerSkillPriceText;
    [SerializeField] TMP_Text catcherSkillPriceText;

    [SerializeField] Image rightImageRunnerCoinImage;
    [SerializeField] Image rightImageCatcherCoinImage;

    string currentRunnerSkillPressed;
    string currentCatcherSkillPressed;

    #endregion

    [Space(20)]
    [Header("Choose ball variables")]
    #region chooseBall variables
    [SerializeField] GameObject chooseBallPanel;
    [SerializeField] GameObject chooseBallPanelChild;
    #endregion

    [Space(20)]
    [Header("Congrats panel variables")]
    #region Congrats panel variables

    [SerializeField] GameObject panel1;
    [SerializeField] GameObject panel2;
    [SerializeField] GameObject panel3;

    [SerializeField] TMP_Text congratsText;

    [SerializeField] float panel1AnimTime;
    [SerializeField] float panel2AnimTime;
    [SerializeField] float panel3AnimTime;

    [SerializeField] float delayAfterPanelsToPrizes;

    [SerializeField] GameObject prize1;
    [SerializeField] GameObject prize2;
    [SerializeField] GameObject prize3;

    [SerializeField] GameObject nextButton;
    #endregion

    [Space(20)]
    [Header("Options variables")]
    #region Options variables



    [SerializeField] GameObject musicOnOffButton;
    [SerializeField] GameObject soundOnOffButton;

    [SerializeField] Sprite isOnButton;
    [SerializeField] Sprite isOffButton;

    [SerializeField] TMP_Text musicOnOffText;
    [SerializeField] TMP_Text soundOnOffText;

    #endregion

    [Space(20)]
    [Header("VFX variables")]
    #region VFX variables
    [SerializeField] float vfxButtonRotationTime;

    [SerializeField] GameObject vfxButtonBack;

    [SerializeField] GameObject[] gameobjectsThatAreNotTransparent;

    public TMP_Text[] vfxSelectSelectedText;
    [SerializeField] TMP_Text rightVFXText;


    [SerializeField] TMP_Text[] vfxProcesTexts;
    [SerializeField] GameObject[] vfxPricePanels;

    [SerializeField] Image rightVFXImage;

    [SerializeField] GameObject[] vfxButtonsImages;

    [SerializeField] GameObject buyOrSelectVFXButton;
    [SerializeField] TMP_Text buyOrSelectVFXText;

    [SerializeField] Sprite buyButtonSprite;
    [SerializeField] Sprite selectButtonSprite;
    [SerializeField] Sprite selectedButtonSprite;

    [SerializeField] TMP_Text vfxInfoText;


    #endregion

    [Space(20)]
    [Header("Arena variables")]
    #region Arena variables

    [SerializeField] GameObject ruSureArenaImage;
    [SerializeField] TMP_Text ruSureArenaQuestionText;
    [SerializeField] TMP_Text ruSureArenaPriceText;

    [SerializeField] GameObject ruSureArenaPanel;
    [SerializeField] GameObject arenaButtonInMainMenu;
    [SerializeField] Sprite[] arenaButtonSprites;
    #endregion

    [Space(20)]
    [Header("Tutorial variables")]
    #region Tutorial variables

    public GameObject tutoPanel;
    public GameObject[] tutoImages;

    [SerializeField] Image[] tutoPointImages;

    [SerializeField] Color32 selectedPoint;
    [SerializeField] Color32 unSelectedPoint;

    #endregion

    [Space(20)]
    [Header("Loading Variables")]
    #region Loading variables
    [SerializeField] Slider loadingSlider;
    #endregion

    #region Some Private variables

    const string profilePicIndex = "ppi";
    const string selectedCharacterIndex = "ci";
    const string vfxIndex = "vfxi";
    const string mapIndexPlayerPrefs = "mi";
    const string currentSavedRunnerSkill = "rs";
    const string currentSavedCatcherSkill = "cs";
    const string savedMusicVolume = "mv";
    const string savedSoundVolume = "sv";

    int pressedBallBUttonIndex = -1;
    int pressedssCoinBUttonIndex = -1;
    int selectedPPImage = -1;
    int openedCharacterIndex = -1;
    int pressedArenaIndex = -1;
    Color halfTransparentColor = new Color(0f, 0f, 0f, 0.5f);
    Color transparentColor = new Color(0f, 0f, 0f, 0f);
    int currentTutoIndex = 0;
    bool hasntTouchedVfxButton = false;
    #endregion

    public void AddDiamond(int value)
    {
        LocalDatas.Instance.crystalCoin += value;
        FirebaseController.Instance.SaveData();
        //LocalDatas.Instance.ShowDatas();

    }

    #region loading functions
    public void SetSliderWithTweening(float from, float to)
    {
        //float from = 0f;
        //float to = 0.8f;
        LeanTween.value(gameObject, from, to, 1f)
            .setEaseOutBack()
            .setOnUpdate(SetSliderValue);
    }

    void SetSliderValue(float _value)
    {
        loadingSlider.value = _value;
    
    }

    #endregion


    #region Some overall functions

    public void OpenTryAgainPanel()
    {
        LeanTween.scale(tryAgainPanel, Vector3.one, 0.5f).setOnComplete(() => {

            LeanTween.scale(tryAgainPanel, Vector3.one * 1.1f, 0.5f).setEasePunch();
        });
    }



    public void TryAgainInMenu()
    {
        LeanTween.scale(tryAgainPanel, Vector3.zero, 0.5f).setOnComplete(() => {
            SceneManager.LoadScene(1);
        });
    }

    public void ShowNotEnoughMoneyImage()
    {
        notEnoughMoneyPanel.SetActive(true);

        LeanTween.alpha(notEnoughMoneyPanel.GetComponent<RectTransform>(), 1f, time).setEase(LeanTweenType.pingPong).setOnComplete(FadeOutInfoText);

        notEnoughMoneyText.gameObject.SetActive(true);

        //LeanTween.colorText(notEnoughMoneyText.GetComponent<RectTransform>(), notEnoughMoneyTextColor, infoTextFadeTime).setOnComplete(FadeOutInfoText);
        //if (notEnoughMoneyText.GetComponent<Text>().color.a == 0f)
        //{
        //}
    }

    void SetNoFundsText()
    {
        notEnoughMoneyText.gameObject.SetActive(false);
        notEnoughMoneyPanel.gameObject.SetActive(false);

    }

    void FadeOutInfoText()
    {
        LeanTween.alpha(notEnoughMoneyPanel.GetComponent<RectTransform>(), 0f, time).setDelay(0.7f).setEase(LeanTweenType.pingPong).setOnComplete(SetNoFundsText);
        //notEnoughMoneyText.gameObject.SetActive(false);
        //LeanTween.colorText(notEnoughMoneyText.GetComponent<RectTransform>(), Color.clear, infoTextFadeTime).setDelay(infoTextDelayTime);
    }


    public void ButtonClickTweeningDown()
    {
        LeanTween.scale(EventSystem.current.currentSelectedGameObject, 1f * Vector3.one, 0.1f);
    }

    public void ButtonClickTweeningUp()
    {
        LeanTween.scale(EventSystem.current.currentSelectedGameObject, 0.95f * Vector3.one, 0.1f);
    }

    public void PPTweeningDown()
    {
        LeanTween.scale(EventSystem.current.currentSelectedGameObject, 1f * Vector3.one, 0.1f);
    }

    public void PPTweeningUp()
    {
        LeanTween.scale(EventSystem.current.currentSelectedGameObject, 0.95f * Vector3.one, 0.1f);
    }

    public void CheckIfInMenu()
    {
        if (playerProfilePanelChild.activeInHierarchy || ChangePPPanelChild.activeInHierarchy || shopPanelChild.activeInHierarchy || arenaPanelChild.activeInHierarchy || PlayPanelChild.activeInHierarchy || skillsPanelChild.activeInHierarchy || optionsPanelChild.activeInHierarchy || MenuCommonObjects.Instance.loadingPanel.activeInHierarchy || tutoPanel.activeInHierarchy || characterInsideMenuChild.activeInHierarchy || characterPanelChild.activeInHierarchy || FirebaseController.Instance.CreateNickNamePanel.activeInHierarchy)
        {
            LocalDatas.Instance.isInMainMenu = false;
        }
        else
        {
            LocalDatas.Instance.isInMainMenu = true;
        }
    }

    public void ClearDebug()
    {
        LocalDatas.Instance.debugtext.text = "";
    }

    #endregion


    #region Tutorial functions


    public void NextTutoPressed()
    {
        currentTutoIndex++;

        if (currentTutoIndex >= tutoImages.Length)
        {
            // Tutorial finished
            FirebaseController.Instance.SetFirstNickPanel_void(true);
            tutoPanel.SetActive(false);
        }
        SetTutoImage(currentTutoIndex);
    }

    public void BackTutoPressed()
    {
        if (currentTutoIndex != 0)
        {
            currentTutoIndex--;
            SetTutoImage(currentTutoIndex);
        }
    }


    public void OpenTutorialPanel()
    {
        //tutoPointImages[0].color = selectedPoint;
        //tutoPointImages[0].color = unSelectedPoint;

        SetTutoImage(0);
        LocalDatas.Instance.Sed3dObjectParent(false);
        tutoPanel.SetActive(true);
        //currentTutoIndex = 1; // gets equal to 1
    }


    public void CloseTutorialPanel()
    {
        SetTutoImage(0);
        tutoPanel.SetActive(false);
    }



    private void SetTutoImage(int tutoIndex)
    {
        for (int i = 0; i < tutoImages.Length; i++)
        {
            if (i == tutoIndex)
            {
                tutoPointImages[i].color = selectedPoint;
                tutoImages[i].SetActive(true);
            }
            else
            {
                tutoPointImages[i].color = unSelectedPoint;
                tutoImages[i].SetActive(false);
            }
        }
    }


    #endregion

    #region shop functions

    public void OpenRUSurePanelInShop()
    {
        ruSureShopPanel.GetComponent<Image>().color = transparentColor;
        ruSureShopPanel.SetActive(true);
    }

    public void CloseRUSurePanelInShop()
    {
        pressedBallBUttonIndex = -1;
        pressedssCoinBUttonIndex = -1;
        ruSureShopPanel.SetActive(false);
    }

    public void BuySSCoin() // diamond -> sscoin
    {
        if (pressedssCoinBUttonIndex >= 0)
        {
            if (LocalDatas.Instance.crystalCoin >= SomeDatas.Instance.ssCoinPrices[pressedssCoinBUttonIndex])
            {
                // Buying
                AudioManager.Instance.Play(2);
                LocalDatas.Instance.crystalCoin -= SomeDatas.Instance.ssCoinPrices[pressedssCoinBUttonIndex];
                LocalDatas.Instance.ssCoin += SomeDatas.Instance.ssCoinValues[pressedssCoinBUttonIndex];
                FirebaseController.Instance.SaveData();
                LocalDatas.Instance.ShowDatas();
                LocalDatas.Instance.SetUICoins();
            }
            else
            {
                ShowNotEnoughMoneyImage();
            }

            CloseRUSurePanelInShop();

        }
    }


    public void SSCoinPressed(int buttonIndex)
    {
        OpenRUSurePanelInShop();
        ruSureCoinImage.GetComponent<Image>().sprite = diamondSprite;
        pressedssCoinBUttonIndex = buttonIndex;
        pressedBallBUttonIndex = -1;
        ruSureInShopGainingCoinText.text = SomeDatas.Instance.ssCoinValues[buttonIndex].ToString("n0");
        InShopBuyButton.SetActive(true);
        ruSureInShopPriceText.text = "" + SomeDatas.Instance.ssCoinPrices[pressedssCoinBUttonIndex];
    }

    public void SetCoinsPrices()
    {
        //string ballDatas = LocalDatas.Instance.datasArray[9];
        for (int i = 0; i < ssCoinssInShop.Length; i++)
        {
            ssCoinPricesTexts[i].text = "" + SomeDatas.Instance.ssCoinPrices[i];
            ssCoinValuesTexts[i].text = "" + SomeDatas.Instance.ssCoinValues[i];
        }
    }

   
    public void InShopchvfxPressed()
    {
        shopScrollContent.GetComponent<RectTransform>().localPosition = new Vector3(0f, shopScrollContent.GetComponent<RectTransform>().localPosition.y, shopScrollContent.GetComponent<RectTransform>().localPosition.z);
        inShopButtons[0].GetComponent<Image>().sprite = inShopButtonsSprites[0];
        inShopButtons[1].GetComponent<Image>().sprite = inShopButtonsSprites[1];
        inShopButtons[2].GetComponent<Image>().sprite = inShopButtonsSprites[2];
    }


    public void InShopCoinsPressed()
    {
        shopScrollContent.GetComponent<RectTransform>().localPosition = new Vector3(-575f, shopScrollContent.GetComponent<RectTransform>().localPosition.y, shopScrollContent.GetComponent<RectTransform>().localPosition.z);
        inShopButtons[1].GetComponent<Image>().sprite = inShopButtonsSprites[0];
        inShopButtons[0].GetComponent<Image>().sprite = inShopButtonsSprites[1];
        inShopButtons[2].GetComponent<Image>().sprite = inShopButtonsSprites[2];
    }

    public void InShopDiamondsPressed()
    {
        shopScrollContent.GetComponent<RectTransform>().localPosition = new Vector3(-650f, shopScrollContent.GetComponent<RectTransform>().localPosition.y, shopScrollContent.GetComponent<RectTransform>().localPosition.z);
        inShopButtons[2].GetComponent<Image>().sprite = inShopButtonsSprites[0];
        inShopButtons[1].GetComponent<Image>().sprite = inShopButtonsSprites[1];
        inShopButtons[0].GetComponent<Image>().sprite = inShopButtonsSprites[2];
    }

    public void OnShopScrollViewScrolled()
    {
        //Sprite temp;
        if (shopScrollContent.GetComponent<RectTransform>().localPosition.x > -340f)
        {
            inShopButtons[0].GetComponent<Image>().sprite = inShopButtonsSprites[0];
            inShopButtons[1].GetComponent<Image>().sprite = inShopButtonsSprites[1];
            inShopButtons[2].GetComponent<Image>().sprite = inShopButtonsSprites[2];
        }
        else if (shopScrollContent.GetComponent<RectTransform>().localPosition.x <= -340f && shopScrollContent.GetComponent<RectTransform>().localPosition.x >= -580f)
        {
            inShopButtons[1].GetComponent<Image>().sprite = inShopButtonsSprites[0];
            inShopButtons[0].GetComponent<Image>().sprite = inShopButtonsSprites[1];
            inShopButtons[2].GetComponent<Image>().sprite = inShopButtonsSprites[2];
        }
        else
        {
            inShopButtons[2].GetComponent<Image>().sprite = inShopButtonsSprites[0];
            inShopButtons[1].GetComponent<Image>().sprite = inShopButtonsSprites[1];
            inShopButtons[0].GetComponent<Image>().sprite = inShopButtonsSprites[2];
        }
        //Debug.Log("content pos: " + content.GetComponent<RectTransform>().localPosition);
    }

    public void OpenShopPanel()
    {
        LeanTween.alpha(shopPanel.GetComponent<RectTransform>(), 1f, time).setEase(LeanTweenType.pingPong);
        shopPanel.GetComponent<Image>().raycastTarget = true;
        shopPanelChild.SetActive(true);
        ruSureShopPanel.SetActive(false);
        //LeanTween.alpha(ruSurePanel.GetComponent<RectTransform>(), 0f, 0.1f).setEase(LeanTweenType.pingPong);

        //for (int i = 0; i < shopPanelChildren.Length; i++)
        //{
        //    shopPanelChildren[i].SetActive(true);
        //}
        LocalDatas.Instance.Sed3dObjectParent(false);
        MakePlayerObjectDefaultRotation(LocalDatas.Instance.playerCharacterObjects[LocalDatas.Instance.currentCharacterIndex]);
        LocalDatas.Instance.isInMainMenu = false;
    }

    public void CloseShopPanel()
    {

        LeanTween.alpha(shopPanel.GetComponent<RectTransform>(), 0f, time).setEase(LeanTweenType.pingPong);
        shopPanel.GetComponent<Image>().raycastTarget = false;
        shopPanelChild.SetActive(false);
        ruSureShopPanel.SetActive(false);

        //for (int i = 0; i < shopPanelChildren.Length; i++)
        //{
        //    shopPanelChildren[i].SetActive(false);
        //}
        LocalDatas.Instance.Sed3dObjectParent(true);
        LocalDatas.Instance.isInMainMenu = true;

    }

    #endregion

    #region skills functions

    public void ImproveRunnerSkill()
    {
        if (currentRunnerSkillPressed == "Sprint")
        {
            if (LocalDatas.Instance.runnerSpeedLevel < SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 0]) // if skill level is not max for this level
            {
                improveRunnerButton.GetComponent<Button>().interactable = true;
                // If we are buying with sscoin
                if (LocalDatas.Instance.runnerSpeedLevel != SomeDatas.Instance.runnerSpeedPrices.Length - 1)
                {
                    if (LocalDatas.Instance.ssCoin >= SomeDatas.Instance.runnerSpeedPrices[LocalDatas.Instance.runnerSpeedLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.ssCoin -= SomeDatas.Instance.runnerSpeedPrices[LocalDatas.Instance.runnerSpeedLevel];
                        LocalDatas.Instance.runnerSpeedLevel += 1;
                        SetRunnerSkillLevels(LocalDatas.Instance.runnerSpeedLevel);
                        SkillButtonPressedRunner(runnerSkillsButtons[0]);
                        FirebaseController.Instance.SaveData();

                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
                // If we are buying with diamond coins
                else
                {
                    if (LocalDatas.Instance.crystalCoin >= SomeDatas.Instance.runnerSpeedPrices[LocalDatas.Instance.runnerSpeedLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.crystalCoin -= SomeDatas.Instance.runnerSpeedPrices[LocalDatas.Instance.runnerSpeedLevel];
                        LocalDatas.Instance.runnerSpeedLevel += 1;
                        SetRunnerSkillLevels(LocalDatas.Instance.runnerSpeedLevel);
                        SkillButtonPressedRunner(runnerSkillsButtons[0]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
            }
            else // if skill level is max for this level
            {
                runnerSkillInfoText.text = "Sprint skill is maximum for your level";
                improveRunnerButton.GetComponent<Button>().interactable = false;
            }
        }
        else if (currentRunnerSkillPressed == "Shield")
        {
            if (LocalDatas.Instance.runnerShieldLevel < SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 2]) // if skill level is not max for this level
            {
                improveRunnerButton.GetComponent<Button>().interactable = true;
                if (LocalDatas.Instance.runnerShieldLevel != SomeDatas.Instance.runnerShieldPrices.Length - 1)
                { 
                    if (LocalDatas.Instance.ssCoin >= SomeDatas.Instance.runnerShieldPrices[LocalDatas.Instance.runnerShieldLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);

                        LocalDatas.Instance.ssCoin -= SomeDatas.Instance.runnerShieldPrices[LocalDatas.Instance.runnerShieldLevel];
                        LocalDatas.Instance.runnerShieldLevel += 1;
                        SetRunnerSkillLevels(LocalDatas.Instance.runnerShieldLevel);
                        SkillButtonPressedRunner(runnerSkillsButtons[1]);
                        FirebaseController.Instance.SaveData();

                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }                
                }
                else
                {
                    if (LocalDatas.Instance.crystalCoin >= SomeDatas.Instance.runnerShieldPrices[LocalDatas.Instance.runnerShieldLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.crystalCoin -= SomeDatas.Instance.runnerShieldPrices[LocalDatas.Instance.runnerShieldLevel];
                        LocalDatas.Instance.runnerShieldLevel += 1;
                        SetRunnerSkillLevels(LocalDatas.Instance.runnerShieldLevel);
                        SkillButtonPressedRunner(runnerSkillsButtons[1]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
            }
            else // if skill level is max for this level
            {
                runnerSkillInfoText.text = "Shield skill is maximum for your level";
                improveRunnerButton.GetComponent<Button>().interactable = false;
            }
        }
        else if (currentRunnerSkillPressed == "Invisibility")
        {
            if (LocalDatas.Instance.runnerInvisibilityLevel < SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 4]) // if skill level is not max for this level
            {
                improveRunnerButton.GetComponent<Button>().interactable = true;
                if (LocalDatas.Instance.runnerInvisibilityLevel != SomeDatas.Instance.runnerInvisibilityPrices.Length - 1)
                {
                    if (LocalDatas.Instance.ssCoin >= SomeDatas.Instance.runnerInvisibilityPrices[LocalDatas.Instance.runnerInvisibilityLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);

                        LocalDatas.Instance.ssCoin -= SomeDatas.Instance.runnerInvisibilityPrices[LocalDatas.Instance.runnerInvisibilityLevel];
                        LocalDatas.Instance.runnerInvisibilityLevel += 1;
                        SetRunnerSkillLevels(LocalDatas.Instance.runnerInvisibilityLevel);
                        SkillButtonPressedRunner(runnerSkillsButtons[2]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
                else
                {
                    if (LocalDatas.Instance.crystalCoin >= SomeDatas.Instance.runnerInvisibilityPrices[LocalDatas.Instance.runnerInvisibilityLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.crystalCoin -= SomeDatas.Instance.runnerInvisibilityPrices[LocalDatas.Instance.runnerInvisibilityLevel];
                        LocalDatas.Instance.runnerInvisibilityLevel += 1;
                        SetRunnerSkillLevels(LocalDatas.Instance.runnerInvisibilityLevel);
                        SkillButtonPressedRunner(runnerSkillsButtons[2]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
            }
            else // if skill level is max for this level
            {
                runnerSkillInfoText.text = "Invisibility skill is maximum for your level";
                improveRunnerButton.GetComponent<Button>().interactable = false;
            }
        }
        else if (currentRunnerSkillPressed == "Life")
        {
            if (LocalDatas.Instance.runnerAddHealth < SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 1]) // if skill level is not max for this level
            {
                improveRunnerButton.GetComponent<Button>().interactable = true;
                if (LocalDatas.Instance.runnerAddHealth != SomeDatas.Instance.runnerAddHealthPrices.Length - 1)
                {
                    if (LocalDatas.Instance.ssCoin >= SomeDatas.Instance.runnerAddHealthPrices[LocalDatas.Instance.runnerAddHealth])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.ssCoin -= SomeDatas.Instance.runnerAddHealthPrices[LocalDatas.Instance.runnerAddHealth];
                        LocalDatas.Instance.runnerAddHealth += 1;
                        SetRunnerSkillLevels(LocalDatas.Instance.runnerAddHealth);
                        SkillButtonPressedRunner(runnerSkillsButtons[3]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
                else
                {
                    if (LocalDatas.Instance.crystalCoin >= SomeDatas.Instance.runnerAddHealthPrices[LocalDatas.Instance.runnerAddHealth])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.crystalCoin -= SomeDatas.Instance.runnerAddHealthPrices[LocalDatas.Instance.runnerAddHealth];
                        LocalDatas.Instance.runnerAddHealth += 1;
                        SetRunnerSkillLevels(LocalDatas.Instance.runnerAddHealth);
                        SkillButtonPressedRunner(runnerSkillsButtons[3]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
            }
            else // if skill level is max for this level
            {
                runnerSkillInfoText.text = "Life skill is maximum for your level";
                improveRunnerButton.GetComponent<Button>().interactable = false;
            }
        }
        else if (currentRunnerSkillPressed == "Trap")
        {
            if (LocalDatas.Instance.runnerTrapLevel < SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 3]) // if skill level is not max for this level
            {
                improveRunnerButton.GetComponent<Button>().interactable = true;
                if (LocalDatas.Instance.runnerTrapLevel != SomeDatas.Instance.runnerTrapPrices.Length - 1)
                {
                    if (LocalDatas.Instance.ssCoin >= SomeDatas.Instance.runnerTrapPrices[LocalDatas.Instance.runnerTrapLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.ssCoin -= SomeDatas.Instance.runnerTrapPrices[LocalDatas.Instance.runnerTrapLevel];
                        LocalDatas.Instance.runnerTrapLevel += 1;
                        SetRunnerSkillLevels(LocalDatas.Instance.runnerTrapLevel);
                        SkillButtonPressedRunner(runnerSkillsButtons[4]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
                else
                {
                    if (LocalDatas.Instance.crystalCoin >= SomeDatas.Instance.runnerTrapPrices[LocalDatas.Instance.runnerTrapLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.crystalCoin -= SomeDatas.Instance.runnerTrapPrices[LocalDatas.Instance.runnerTrapLevel];
                        LocalDatas.Instance.runnerTrapLevel += 1;
                        SetRunnerSkillLevels(LocalDatas.Instance.runnerTrapLevel);
                        SkillButtonPressedRunner(runnerSkillsButtons[4]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
            }
            else // if skill level is max for this level
            {
                runnerSkillInfoText.text = "Trap skill is maximum for your level";
                improveRunnerButton.GetComponent<Button>().interactable = false;
            }
        }
        else if (currentRunnerSkillPressed == "SlowDownTrap")
        {
            if (LocalDatas.Instance.runnerSlowdownTrapLevel < SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 5]) // if skill level is not max for this level
            {
                improveRunnerButton.GetComponent<Button>().interactable = true;
                if (LocalDatas.Instance.runnerSlowdownTrapLevel != SomeDatas.Instance.runnerSTDPrices.Length - 1)
                {
                    if (LocalDatas.Instance.ssCoin >= SomeDatas.Instance.runnerSTDPrices[LocalDatas.Instance.runnerSlowdownTrapLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.ssCoin -= SomeDatas.Instance.runnerSTDPrices[LocalDatas.Instance.runnerSlowdownTrapLevel];
                        LocalDatas.Instance.runnerSlowdownTrapLevel += 1;
                        SetRunnerSkillLevels(LocalDatas.Instance.runnerSlowdownTrapLevel);
                        SkillButtonPressedRunner(runnerSkillsButtons[5]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
                else
                {
                    if (LocalDatas.Instance.crystalCoin >= SomeDatas.Instance.runnerSTDPrices[LocalDatas.Instance.runnerSlowdownTrapLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.crystalCoin -= SomeDatas.Instance.runnerSTDPrices[LocalDatas.Instance.runnerSlowdownTrapLevel];
                        LocalDatas.Instance.runnerSlowdownTrapLevel += 1;
                        SetRunnerSkillLevels(LocalDatas.Instance.runnerSlowdownTrapLevel);
                        SkillButtonPressedRunner(runnerSkillsButtons[5]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
            }
            else // if skill level is max for this level
            {
                runnerSkillInfoText.text = "SlowDownTrap skill is maximum for your level";
                improveRunnerButton.GetComponent<Button>().interactable = false;
            }
        }
        else if (currentRunnerSkillPressed == "TopView")
        {
            if (LocalDatas.Instance.runnerTopViewLevel < SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 6]) // if skill level is not max for this level
            {
                improveRunnerButton.GetComponent<Button>().interactable = true;
                if (LocalDatas.Instance.runnerTopViewLevel != SomeDatas.Instance.runnerTopViewPrices.Length - 1)
                {
                    if (LocalDatas.Instance.ssCoin >= SomeDatas.Instance.runnerTopViewPrices[LocalDatas.Instance.runnerTopViewLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.ssCoin -= SomeDatas.Instance.runnerTopViewPrices[LocalDatas.Instance.runnerTopViewLevel];
                        LocalDatas.Instance.runnerTopViewLevel += 1;
                        SetRunnerSkillLevels(LocalDatas.Instance.runnerTopViewLevel);
                        SkillButtonPressedRunner(runnerSkillsButtons[6]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
                else
                {
                    if (LocalDatas.Instance.crystalCoin >= SomeDatas.Instance.runnerTopViewPrices[LocalDatas.Instance.runnerTopViewLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.crystalCoin -= SomeDatas.Instance.runnerTopViewPrices[LocalDatas.Instance.runnerTopViewLevel];
                        LocalDatas.Instance.runnerTopViewLevel += 1;
                        SetRunnerSkillLevels(LocalDatas.Instance.runnerTopViewLevel);
                        SkillButtonPressedRunner(runnerSkillsButtons[6]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
            }
            else // if skill level is max for this level
            {
                runnerSkillInfoText.text = "TopView skill is maximum for your level";
                improveRunnerButton.GetComponent<Button>().interactable = false;
            }
        }
        else if (currentRunnerSkillPressed == "Wall")
        {
            if (LocalDatas.Instance.runnerWallLevel < SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 7]) // if skill level is not max for this level
            {
                improveRunnerButton.GetComponent<Button>().interactable = true;
                if (LocalDatas.Instance.runnerWallLevel != SomeDatas.Instance.runnerWallPrices.Length - 1)
                {
                    if (LocalDatas.Instance.ssCoin >= SomeDatas.Instance.runnerWallPrices[LocalDatas.Instance.runnerWallLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.ssCoin -= SomeDatas.Instance.runnerWallPrices[LocalDatas.Instance.runnerWallLevel];
                        LocalDatas.Instance.runnerWallLevel += 1;
                        SetRunnerSkillLevels(LocalDatas.Instance.runnerWallLevel);
                        SkillButtonPressedRunner(runnerSkillsButtons[7]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
                else
                {
                    if (LocalDatas.Instance.crystalCoin >= SomeDatas.Instance.runnerWallPrices[LocalDatas.Instance.runnerWallLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.crystalCoin -= SomeDatas.Instance.runnerWallPrices[LocalDatas.Instance.runnerWallLevel];
                        LocalDatas.Instance.runnerWallLevel += 1;
                        SetRunnerSkillLevels(LocalDatas.Instance.runnerWallLevel);
                        SkillButtonPressedRunner(runnerSkillsButtons[7]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
            }
            else // if skill level is max for this level
            {
                runnerSkillInfoText.text = "Wall skill is maximum for your level";
                improveRunnerButton.GetComponent<Button>().interactable = false;
            }
        }
        else if (currentRunnerSkillPressed == "Hook")
        {
            if (LocalDatas.Instance.runnerHookLevel < SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 8]) // if skill level is not max for this level
            {
                improveRunnerButton.GetComponent<Button>().interactable = true;
                if (LocalDatas.Instance.runnerHookLevel != SomeDatas.Instance.runnerHookPrices.Length - 1)
                {
                    if (LocalDatas.Instance.ssCoin >= SomeDatas.Instance.runnerHookPrices[LocalDatas.Instance.runnerHookLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.ssCoin -= SomeDatas.Instance.runnerHookPrices[LocalDatas.Instance.runnerHookLevel];
                        LocalDatas.Instance.runnerHookLevel += 1;
                        SetRunnerSkillLevels(LocalDatas.Instance.runnerHookLevel);
                        SkillButtonPressedRunner(runnerSkillsButtons[8]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
                else
                {
                    if (LocalDatas.Instance.crystalCoin >= SomeDatas.Instance.runnerHookPrices[LocalDatas.Instance.runnerHookLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.crystalCoin -= SomeDatas.Instance.runnerHookPrices[LocalDatas.Instance.runnerHookLevel];
                        LocalDatas.Instance.runnerHookLevel += 1;
                        SetRunnerSkillLevels(LocalDatas.Instance.runnerHookLevel);
                        SkillButtonPressedRunner(runnerSkillsButtons[8]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
            }
            else // if skill level is max for this level
            {
                runnerSkillInfoText.text = "Hook skill is maximum for your level";
                improveRunnerButton.GetComponent<Button>().interactable = false;
            }
        }
        else if (currentRunnerSkillPressed == "Bot Clone")
        {
            if (LocalDatas.Instance.runnerBCLevel < SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 9]) // if skill level is not max for this level
            {
                improveRunnerButton.GetComponent<Button>().interactable = true;
                if (LocalDatas.Instance.runnerBCLevel != SomeDatas.Instance.runnerBCPrices.Length - 1)
                {
                    if (LocalDatas.Instance.ssCoin >= SomeDatas.Instance.runnerBCPrices[LocalDatas.Instance.runnerBCLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.ssCoin -= SomeDatas.Instance.runnerBCPrices[LocalDatas.Instance.runnerBCLevel];
                        LocalDatas.Instance.runnerBCLevel += 1;
                        SetRunnerSkillLevels(LocalDatas.Instance.runnerBCLevel);
                        SkillButtonPressedRunner(runnerSkillsButtons[9]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
                else
                {
                    if (LocalDatas.Instance.crystalCoin >= SomeDatas.Instance.runnerBCPrices[LocalDatas.Instance.runnerBCLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.crystalCoin -= SomeDatas.Instance.runnerBCPrices[LocalDatas.Instance.runnerBCLevel];
                        LocalDatas.Instance.runnerBCLevel += 1;
                        SetRunnerSkillLevels(LocalDatas.Instance.runnerBCLevel);
                        SkillButtonPressedRunner(runnerSkillsButtons[9]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
            }
            else // if skill level is max for this level
            {
                runnerSkillInfoText.text = "Bot Clone skill is maximum for your level";
                improveRunnerButton.GetComponent<Button>().interactable = false;
            }
        }
    }

    public void ImproveCatcherSkill()
    {
        if (currentCatcherSkillPressed == "Sprint")
        {
            if (LocalDatas.Instance.catcherSpeedLevel < SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 0]) // if skill level is not max for this level
            {
                improveCatcherButton.GetComponent<Button>().interactable = true;
                if (LocalDatas.Instance.catcherSpeedLevel != SomeDatas.Instance.catcherSpeedPrices.Length - 1)
                {
                    if (LocalDatas.Instance.ssCoin >= SomeDatas.Instance.catcherSpeedPrices[LocalDatas.Instance.catcherSpeedLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.ssCoin -= SomeDatas.Instance.catcherSpeedPrices[LocalDatas.Instance.catcherSpeedLevel];
                        LocalDatas.Instance.catcherSpeedLevel += 1;
                        SetCatcherSkillLevels(LocalDatas.Instance.catcherSpeedLevel);
                        SkillButtonPressedCatcher(catcherSkillsButtons[0]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
                else
                {
                    if (LocalDatas.Instance.crystalCoin >= SomeDatas.Instance.catcherSpeedPrices[LocalDatas.Instance.catcherSpeedLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.crystalCoin -= SomeDatas.Instance.catcherSpeedPrices[LocalDatas.Instance.catcherSpeedLevel];
                        LocalDatas.Instance.catcherSpeedLevel += 1;
                        SetCatcherSkillLevels(LocalDatas.Instance.catcherSpeedLevel);
                        SkillButtonPressedCatcher(catcherSkillsButtons[0]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
            }
            else // if skill level is max for this level
            {
                catcherSkillInfoText.text = "Sprint skill is maximum for your level";
                improveCatcherButton.GetComponent<Button>().interactable = false;
            }
        }
        else if (currentCatcherSkillPressed == "Shield")
        {
            if (LocalDatas.Instance.catcherShieldLevel < SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 1]) // if skill level is not max for this level
            {
                improveCatcherButton.GetComponent<Button>().interactable = true;
                if (LocalDatas.Instance.catcherShieldLevel != SomeDatas.Instance.catcherShieldPrices.Length - 1)
                {
                    if (LocalDatas.Instance.ssCoin >= SomeDatas.Instance.catcherShieldPrices[LocalDatas.Instance.catcherShieldLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.ssCoin -= SomeDatas.Instance.catcherShieldPrices[LocalDatas.Instance.catcherShieldLevel];
                        LocalDatas.Instance.catcherShieldLevel += 1;
                        SetCatcherSkillLevels(LocalDatas.Instance.catcherShieldLevel);
                        SkillButtonPressedCatcher(catcherSkillsButtons[1]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
                else
                {
                    if (LocalDatas.Instance.crystalCoin >= SomeDatas.Instance.catcherShieldPrices[LocalDatas.Instance.catcherShieldLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.crystalCoin -= SomeDatas.Instance.catcherShieldPrices[LocalDatas.Instance.catcherShieldLevel];
                        LocalDatas.Instance.catcherShieldLevel += 1;
                        SetCatcherSkillLevels(LocalDatas.Instance.catcherShieldLevel);
                        SkillButtonPressedCatcher(catcherSkillsButtons[1]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
            }
            else // if skill level is max for this level
            {
                catcherSkillInfoText.text = "Shield skill is maximum for your level";
                improveCatcherButton.GetComponent<Button>().interactable = false;
            }

        }
        else if (currentCatcherSkillPressed == "Invisibility")
        {
            if (LocalDatas.Instance.catcherInvisibilityLevel < SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 2]) // if skill level is not max for this level
            {
                improveCatcherButton.GetComponent<Button>().interactable = true;
                if (LocalDatas.Instance.catcherInvisibilityLevel != SomeDatas.Instance.catcherInvisibilityPrices.Length - 1)
                {
                    if (LocalDatas.Instance.ssCoin >= SomeDatas.Instance.catcherInvisibilityPrices[LocalDatas.Instance.catcherInvisibilityLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.ssCoin -= SomeDatas.Instance.catcherInvisibilityPrices[LocalDatas.Instance.catcherInvisibilityLevel];
                        LocalDatas.Instance.catcherInvisibilityLevel += 1;
                        SetCatcherSkillLevels(LocalDatas.Instance.catcherInvisibilityLevel);
                        SkillButtonPressedCatcher(catcherSkillsButtons[2]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
                else
                {
                    if (LocalDatas.Instance.crystalCoin >= SomeDatas.Instance.catcherInvisibilityPrices[LocalDatas.Instance.catcherInvisibilityLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.crystalCoin -= SomeDatas.Instance.catcherInvisibilityPrices[LocalDatas.Instance.catcherInvisibilityLevel];
                        LocalDatas.Instance.catcherInvisibilityLevel += 1;
                        SetCatcherSkillLevels(LocalDatas.Instance.catcherInvisibilityLevel);
                        SkillButtonPressedCatcher(catcherSkillsButtons[2]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
            }
            else // if skill level is max for this level
            {
                catcherSkillInfoText.text = "Invisibility skill is maximum for your level";
                improveCatcherButton.GetComponent<Button>().interactable = false;
            }
        }
        else if (currentCatcherSkillPressed == "ExtraBall")
        {
            if (LocalDatas.Instance.catcherBallLevel < SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 3]) // if skill level is not max for this level
            {
                improveCatcherButton.GetComponent<Button>().interactable = true;
                if (LocalDatas.Instance.catcherBallLevel != SomeDatas.Instance.catcherBallPrices.Length - 1)
                {
                    if (LocalDatas.Instance.ssCoin >= SomeDatas.Instance.catcherBallPrices[LocalDatas.Instance.catcherBallLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.ssCoin -= SomeDatas.Instance.catcherBallPrices[LocalDatas.Instance.catcherBallLevel];
                        LocalDatas.Instance.catcherBallLevel += 1;
                        SetCatcherSkillLevels(LocalDatas.Instance.catcherBallLevel);
                        SkillButtonPressedCatcher(catcherSkillsButtons[3]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
                else
                {
                    if (LocalDatas.Instance.crystalCoin >= SomeDatas.Instance.catcherBallPrices[LocalDatas.Instance.catcherBallLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.crystalCoin -= SomeDatas.Instance.catcherBallPrices[LocalDatas.Instance.catcherBallLevel];
                        LocalDatas.Instance.catcherBallLevel += 1;
                        SetCatcherSkillLevels(LocalDatas.Instance.catcherBallLevel);
                        SkillButtonPressedCatcher(catcherSkillsButtons[3]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
            }
            else // if skill level is max for this level
            {
                catcherSkillInfoText.text = "ExtraBall skill is maximum for your level";
                improveCatcherButton.GetComponent<Button>().interactable = false;
            }
        }
        else if (currentCatcherSkillPressed == "SlowDownTrap")
        {
            if (LocalDatas.Instance.catcherSlowdownTrapLevel < SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 4]) // if skill level is not max for this level
            {
                improveCatcherButton.GetComponent<Button>().interactable = true;
                if (LocalDatas.Instance.catcherSlowdownTrapLevel != SomeDatas.Instance.catcherSTDPrices.Length - 1)
                {
                    if (LocalDatas.Instance.ssCoin >= SomeDatas.Instance.catcherSTDPrices[LocalDatas.Instance.catcherSlowdownTrapLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.ssCoin -= SomeDatas.Instance.catcherSTDPrices[LocalDatas.Instance.catcherSlowdownTrapLevel];
                        LocalDatas.Instance.catcherSlowdownTrapLevel += 1;
                        SetCatcherSkillLevels(LocalDatas.Instance.catcherSlowdownTrapLevel);
                        SkillButtonPressedCatcher(catcherSkillsButtons[4]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
                else
                {
                    if (LocalDatas.Instance.crystalCoin >= SomeDatas.Instance.catcherSTDPrices[LocalDatas.Instance.catcherSlowdownTrapLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.crystalCoin -= SomeDatas.Instance.catcherSTDPrices[LocalDatas.Instance.catcherSlowdownTrapLevel];
                        LocalDatas.Instance.catcherSlowdownTrapLevel += 1;
                        SetCatcherSkillLevels(LocalDatas.Instance.catcherSlowdownTrapLevel);
                        SkillButtonPressedCatcher(catcherSkillsButtons[4]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
            }
            else // if skill level is max for this level
            {
                catcherSkillInfoText.text = "SlowDownTrap skill is maximum for your level";
                improveCatcherButton.GetComponent<Button>().interactable = false;
            }
        }
        else if (currentCatcherSkillPressed == "TopView")
        {
            if (LocalDatas.Instance.catcherTopViewLevel < SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 5]) // if skill level is not max for this level
            {
                improveCatcherButton.GetComponent<Button>().interactable = true;
                if (LocalDatas.Instance.catcherTopViewLevel != SomeDatas.Instance.catcherTopViewPrices.Length - 1)
                {
                    if (LocalDatas.Instance.ssCoin >= SomeDatas.Instance.catcherTopViewPrices[LocalDatas.Instance.catcherTopViewLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.ssCoin -= SomeDatas.Instance.catcherTopViewPrices[LocalDatas.Instance.catcherTopViewLevel];
                        LocalDatas.Instance.catcherTopViewLevel += 1;
                        SetCatcherSkillLevels(LocalDatas.Instance.catcherTopViewLevel);
                        SkillButtonPressedCatcher(catcherSkillsButtons[5]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
                else
                {
                    if (LocalDatas.Instance.crystalCoin >= SomeDatas.Instance.catcherTopViewPrices[LocalDatas.Instance.catcherTopViewLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.crystalCoin -= SomeDatas.Instance.catcherTopViewPrices[LocalDatas.Instance.catcherTopViewLevel];
                        LocalDatas.Instance.catcherTopViewLevel += 1;
                        SetCatcherSkillLevels(LocalDatas.Instance.catcherTopViewLevel);
                        SkillButtonPressedCatcher(catcherSkillsButtons[5]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
            }
            else // if skill level is max for this level
            {
                catcherSkillInfoText.text = "TopView skill is maximum for your level";
                improveCatcherButton.GetComponent<Button>().interactable = false;
            }
        }
        else if (currentCatcherSkillPressed == "Wall")
        {
            if (LocalDatas.Instance.catcherWallLevel < SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 6]) // if skill level is not max for this level
            {
                improveCatcherButton.GetComponent<Button>().interactable = true;
                if (LocalDatas.Instance.catcherWallLevel != SomeDatas.Instance.catcherWallPrices.Length - 1)
                {
                    if (LocalDatas.Instance.ssCoin >= SomeDatas.Instance.catcherWallPrices[LocalDatas.Instance.catcherWallLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.ssCoin -= SomeDatas.Instance.catcherWallPrices[LocalDatas.Instance.catcherWallLevel];
                        LocalDatas.Instance.catcherWallLevel += 1;
                        SetCatcherSkillLevels(LocalDatas.Instance.catcherWallLevel);
                        SkillButtonPressedCatcher(catcherSkillsButtons[6]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
                else
                {
                    if (LocalDatas.Instance.crystalCoin >= SomeDatas.Instance.catcherWallPrices[LocalDatas.Instance.catcherWallLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.crystalCoin -= SomeDatas.Instance.catcherWallPrices[LocalDatas.Instance.catcherWallLevel];
                        LocalDatas.Instance.catcherWallLevel += 1;
                        SetCatcherSkillLevels(LocalDatas.Instance.catcherWallLevel);
                        SkillButtonPressedCatcher(catcherSkillsButtons[6]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
            }
            else // if skill level is max for this level
            {
                catcherSkillInfoText.text = "Wall skill is maximum for your level";
                improveCatcherButton.GetComponent<Button>().interactable = false;
            }
        }
        else if (currentCatcherSkillPressed == "Hook")
        {
            if (LocalDatas.Instance.catcherHookLevel < SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 7]) // if skill level is not max for this level
            {
                improveCatcherButton.GetComponent<Button>().interactable = true;
                if (LocalDatas.Instance.catcherHookLevel != SomeDatas.Instance.catcherHookPrices.Length - 1)
                {
                    if (LocalDatas.Instance.ssCoin >= SomeDatas.Instance.catcherHookPrices[LocalDatas.Instance.catcherHookLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.ssCoin -= SomeDatas.Instance.catcherHookPrices[LocalDatas.Instance.catcherHookLevel];
                        LocalDatas.Instance.catcherHookLevel += 1;
                        SetCatcherSkillLevels(LocalDatas.Instance.catcherHookLevel);
                        SkillButtonPressedCatcher(catcherSkillsButtons[7]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
                else
                {
                    if (LocalDatas.Instance.crystalCoin >= SomeDatas.Instance.catcherHookPrices[LocalDatas.Instance.catcherHookLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.crystalCoin -= SomeDatas.Instance.catcherHookPrices[LocalDatas.Instance.catcherHookLevel];
                        LocalDatas.Instance.catcherHookLevel += 1;
                        SetCatcherSkillLevels(LocalDatas.Instance.catcherHookLevel);
                        SkillButtonPressedCatcher(catcherSkillsButtons[7]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
            }
            else // if skill level is max for this level
            {
                catcherSkillInfoText.text = "Hook skill is maximum for your level";
                improveCatcherButton.GetComponent<Button>().interactable = false;
            }
        }
        else if (currentCatcherSkillPressed == "Deadly Hit")
        {
            if (LocalDatas.Instance.catcherDeadlyHitLevel < SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 8]) // if skill level is not max for this level
            {
                improveCatcherButton.GetComponent<Button>().interactable = true;
                if (LocalDatas.Instance.catcherDeadlyHitLevel != SomeDatas.Instance.catcherDHPrices.Length - 1)
                {
                    if (LocalDatas.Instance.ssCoin >= SomeDatas.Instance.catcherDHPrices[LocalDatas.Instance.catcherDeadlyHitLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.ssCoin -= SomeDatas.Instance.catcherDHPrices[LocalDatas.Instance.catcherDeadlyHitLevel];
                        LocalDatas.Instance.catcherDeadlyHitLevel += 1;
                        SetCatcherSkillLevels(LocalDatas.Instance.catcherDeadlyHitLevel);
                        SkillButtonPressedCatcher(catcherSkillsButtons[8]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
                else
                {
                    if (LocalDatas.Instance.crystalCoin >= SomeDatas.Instance.catcherDHPrices[LocalDatas.Instance.catcherDeadlyHitLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.crystalCoin -= SomeDatas.Instance.catcherDHPrices[LocalDatas.Instance.catcherDeadlyHitLevel];
                        LocalDatas.Instance.catcherDeadlyHitLevel += 1;
                        SetCatcherSkillLevels(LocalDatas.Instance.catcherDeadlyHitLevel);
                        SkillButtonPressedCatcher(catcherSkillsButtons[8]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
            }
            else // if skill level is max for this level
            {
                catcherSkillInfoText.text = "Deadly Hit skill is maximum for your level";
                improveCatcherButton.GetComponent<Button>().interactable = false;
            }
        }
        else if (currentCatcherSkillPressed == "Bot Clone")
        {
            if (LocalDatas.Instance.catcherBCLevel < SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 9]) // if skill level is not max for this level
            {
                improveCatcherButton.GetComponent<Button>().interactable = true;
                if (LocalDatas.Instance.catcherBCLevel != SomeDatas.Instance.catcherBCPrices.Length - 1)
                {
                    if (LocalDatas.Instance.ssCoin >= SomeDatas.Instance.catcherBCPrices[LocalDatas.Instance.catcherBCLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.ssCoin -= SomeDatas.Instance.catcherBCPrices[LocalDatas.Instance.catcherBCLevel];
                        LocalDatas.Instance.catcherBCLevel += 1;
                        SetCatcherSkillLevels(LocalDatas.Instance.catcherBCLevel);
                        SkillButtonPressedCatcher(catcherSkillsButtons[9]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
                else
                {
                    if (LocalDatas.Instance.crystalCoin >= SomeDatas.Instance.catcherBCPrices[LocalDatas.Instance.catcherBCLevel])
                    {
                        // Improving
                        AudioManager.Instance.Play(3);
                        LocalDatas.Instance.crystalCoin -= SomeDatas.Instance.catcherBCPrices[LocalDatas.Instance.catcherBCLevel];
                        LocalDatas.Instance.catcherBCLevel += 1;
                        SetCatcherSkillLevels(LocalDatas.Instance.catcherBCLevel);
                        SkillButtonPressedCatcher(catcherSkillsButtons[9]);
                        FirebaseController.Instance.SaveData();
                    }
                    else
                    {
                        ShowNotEnoughMoneyImage();
                    }
                }
            }
            else // if skill level is max for this level
            {
                catcherSkillInfoText.text = "Bot Clone skill is maximum for your level";
                improveCatcherButton.GetComponent<Button>().interactable = false;
            }
        }
    }

    void SetRunnerSkillLevels(int _level)
    {
        for (int i = 0; i < runnerSkillsLevelImages.Length; i++)
        {
            if (i < _level)
            {
                runnerSkillsLevelImages[i].SetActive(true);
                //LocalDatas.Instance.Debug("\nLine 228\n");
            }
            else
            {
                runnerSkillsLevelImages[i].SetActive(false);
            }
        }
    }

    void SetCatcherSkillLevels(int _level)
    {
        for (int i = 0; i < catcherSkillsLevelImages.Length; i++)
        {
            if (i < _level)
            {
                catcherSkillsLevelImages[i].SetActive(true);

            }
            else
            {
                catcherSkillsLevelImages[i].SetActive(false);
            }
        }
    }

    int WhenRunnerSkillWillOpen(int _skillIndex, int _levelIntervalIndex)
    {
        int res = -1;

        for (int i = _levelIntervalIndex; i < 5; i++)
        {
            if (SomeDatas.Instance.maxRunnerSkillLevelPerLevel[i, _skillIndex] > SomeDatas.Instance.maxRunnerSkillLevelPerLevel[_levelIntervalIndex, _skillIndex])
            {
                res = i;
                print("Res: " + res);
                break;
            }
        }

        return FromLevelIntervalToLevel(res);
    }


    int WhenCatcherSkillWillOpen(int _skillIndex, int _levelIntervalIndex)
    {
        int res = -1;

        for (int i = _levelIntervalIndex; i < 5; i++)
        {
            if (SomeDatas.Instance.maxCatcherSkillLevelPerLevel[i, _skillIndex] > SomeDatas.Instance.maxCatcherSkillLevelPerLevel[_levelIntervalIndex, _skillIndex])
            {
                res = i;
                break;
            }
        }

        return FromLevelIntervalToLevel(res);
    }
    int FromLevelIntervalToLevel(int levelInterval)
    {
        int res = 0;
        if (levelInterval == 0)
        {
            res = 0;
        }
        else if (levelInterval == 1)
        {
            res = 5;
        }
        else if (levelInterval == 2)
        {
            res = 10;
        }
        else if (levelInterval == 3)
        {
            res = 15;
        }
        else if (levelInterval == 4)
        {
            res = 20;
        }

        return res;
    }


    public void SkillButtonPressedRunner(GameObject button)
    {
        bigSkillImageRunner.GetComponent<Image>().sprite = button.GetComponent<Image>().sprite;
        skillNameTextRunner.text = "" + button.name;
        miniSkillImageRunner.sprite = button.GetComponent<Image>().sprite;
        SetNumberOfBlackSquaresInRunnerSkillRightPanel(11);
        runnerSkillInfoText.color = skillInfoColorOpened;
        improveRunnerButton.SetActive(true);
        rightImageRunnerCoinImage.gameObject.SetActive(true);
        if (button.name == "Sprint")
        {
            runnerSkillLevelImageBack.GetComponent<Image>().sprite = runnerSkillsLevelSpritesBack[0];
            currentRunnerSkillPressed = "Sprint";
            SetRunnerSkillLevels(LocalDatas.Instance.runnerSpeedLevel);

            if (LocalDatas.Instance.runnerSpeedLevel == SomeDatas.Instance.runnerSpeedPrices.Length - 1) // 10 level
            {
                rightImageRunnerCoinImage.sprite = diamondSprite;

            }
            else if (LocalDatas.Instance.runnerSpeedLevel <= SomeDatas.Instance.runnerSpeedPrices.Length - 1) // 0 - 9 level
            {
                rightImageRunnerCoinImage.sprite = coinSprite;

            }
            else if (LocalDatas.Instance.runnerSpeedLevel >= SomeDatas.Instance.runnerSpeedPrices.Length) // 11 level
            {
                runnerSkillPriceText.text = "FULL";
                improveRunnerButton.SetActive(false);
                rightImageRunnerCoinImage.gameObject.SetActive(false);
                runnerSkillInfoText.text = "Sprint is the ability to move temporarily quickly around the map. It takes 30 seconds to regenerate the Sprint ability. Sprint effect time depends on the level of the ability. There are total of 11 levels.";
                return;
            }


            if (SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 0] != 0 && LocalDatas.Instance.runnerSpeedLevel < SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 0]) // Sprint is opened
            {
                runnerSkillInfoText.text = "Sprint is the ability to move temporarily quickly around the map. It takes 30 seconds to regenerate the Sprint ability. Sprint effect time depends on the level of the ability. There are total of 11 levels.";
                if (LocalDatas.Instance.runnerSpeedLevel < SomeDatas.Instance.runnerSpeedPrices.Length)
                {
                    improveRunnerButton.GetComponent<Button>().interactable = true;
                    improveRunnerButton.SetActive(true);

                    runnerSkillPriceText.text = SomeDatas.Instance.runnerSpeedPrices[LocalDatas.Instance.runnerSpeedLevel].ToString("n0");
                }
                else
                {
                    improveRunnerButton.SetActive(false);
                    runnerSkillPriceText.text = "FULL";
                }

            }
            else if (LocalDatas.Instance.runnerSpeedLevel >= SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 0] && SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 0] != 0) // if skill level is not max for this level
            {

                runnerSkillInfoText.text = "Required activation level - " + WhenRunnerSkillWillOpen(0, LocalDatas.Instance.currentLevelIntervalIndex);
                improveRunnerButton.GetComponent<Button>().interactable = false;
            }
            else // Sprint skill is not opened yet
            {
                runnerSkillPriceText.text = SomeDatas.Instance.runnerSpeedPrices[LocalDatas.Instance.runnerSpeedLevel].ToString("n0");
                runnerSkillInfoText.color = skillInfoColorNotOpened;
                runnerSkillInfoText.text = "The skill is not active. Required activation level - " + WhenRunnerSkillWillOpen(0, LocalDatas.Instance.currentLevelIntervalIndex);
                improveRunnerButton.GetComponent<Button>().interactable = false;
            }
        }
        else if (button.name == "Shield")
        {
            runnerSkillLevelImageBack.GetComponent<Image>().sprite = runnerSkillsLevelSpritesBack[2];
            currentRunnerSkillPressed = "Shield";
            SetRunnerSkillLevels(LocalDatas.Instance.runnerShieldLevel);
            if (LocalDatas.Instance.runnerShieldLevel == SomeDatas.Instance.runnerShieldPrices.Length - 1) // 10 lvl
            {
                rightImageRunnerCoinImage.sprite = diamondSprite;
            }
            if (LocalDatas.Instance.runnerShieldLevel < SomeDatas.Instance.runnerShieldPrices.Length - 1) // 0-9 level
            {
                rightImageRunnerCoinImage.sprite = coinSprite;
            }
            else if (LocalDatas.Instance.runnerShieldLevel >= SomeDatas.Instance.runnerShieldPrices.Length) // 11 level
            {
                runnerSkillPriceText.text = "FULL";
                improveRunnerButton.SetActive(false);
                rightImageRunnerCoinImage.gameObject.SetActive(false);
                runnerSkillInfoText.text = "SHIELD Shields the Hero(character) for certain seconds depending on level of the ability. It takes 30 seconds to regenerate the Shield ability. There are total of 11 levels.";
                return;
            }
            runnerSkillPriceText.text = SomeDatas.Instance.runnerShieldPrices[LocalDatas.Instance.runnerShieldLevel].ToString("n0");
            if (SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 2] != 0 && LocalDatas.Instance.runnerShieldLevel < SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 2]) // Shield is opened
            {
                runnerSkillInfoText.text = "SHIELD Shields the Hero(character) for certain seconds depending on level of the ability. It takes 30 seconds to regenerate the Shield ability. There are total of 11 levels.";
                if (LocalDatas.Instance.runnerShieldLevel < SomeDatas.Instance.runnerShieldPrices.Length)
                {
                    improveRunnerButton.GetComponent<Button>().interactable = true;
                    improveRunnerButton.SetActive(true);

                    runnerSkillPriceText.text = SomeDatas.Instance.runnerShieldPrices[LocalDatas.Instance.runnerShieldLevel].ToString("n0");
                }
                else
                {
                    improveRunnerButton.SetActive(false);

                    runnerSkillPriceText.text = "FULL";
                }
            }
            else if (LocalDatas.Instance.runnerShieldLevel >= SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 2] && SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 2] != 0) // if skill level is not max for this level
            {
                runnerSkillInfoText.text = "Required activation level - " + WhenRunnerSkillWillOpen(2, LocalDatas.Instance.currentLevelIntervalIndex);
                improveRunnerButton.GetComponent<Button>().interactable = false;
            }
            else // shield skill is not opened yet
            {
                runnerSkillPriceText.text = SomeDatas.Instance.runnerShieldPrices[LocalDatas.Instance.runnerShieldLevel].ToString("n0");
                runnerSkillInfoText.color = skillInfoColorNotOpened;

                runnerSkillInfoText.text = "The skill is not active. Required activation level - " + WhenRunnerSkillWillOpen(2, LocalDatas.Instance.currentLevelIntervalIndex);
                improveRunnerButton.GetComponent<Button>().interactable = false;
            }

        }
        else if (button.name == "Invisibility")
        {
            runnerSkillLevelImageBack.GetComponent<Image>().sprite = runnerSkillsLevelSpritesBack[4];
            currentRunnerSkillPressed = "Invisibility";
            SetRunnerSkillLevels(LocalDatas.Instance.runnerInvisibilityLevel);
            if (LocalDatas.Instance.runnerInvisibilityLevel == SomeDatas.Instance.runnerInvisibilityPrices.Length - 1) // 10 lvl
            {
                rightImageRunnerCoinImage.sprite = diamondSprite;
            }
            else if (LocalDatas.Instance.runnerInvisibilityLevel < SomeDatas.Instance.runnerInvisibilityPrices.Length - 1) // 0-9 lvl
            {
                rightImageRunnerCoinImage.sprite = coinSprite;
            }
            else if (LocalDatas.Instance.runnerInvisibilityLevel >= SomeDatas.Instance.runnerInvisibilityPrices.Length) // 11 level
            {
                runnerSkillPriceText.text = "FULL";
                improveRunnerButton.SetActive(false);
                rightImageRunnerCoinImage.gameObject.SetActive(false);
                runnerSkillInfoText.text = "Invisibility is the phenomenon of becoming invisible to the eye. It takes 30 seconds to regenerate the Invisibility ability. Invisibility effect time depends on the level of the ability. There are total of 11 levels.";
                return;
            }

            runnerSkillPriceText.text = SomeDatas.Instance.runnerInvisibilityPrices[LocalDatas.Instance.runnerInvisibilityLevel].ToString("n0");

            if (SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 4] != 0 && LocalDatas.Instance.runnerInvisibilityLevel < SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 4]) // Invisibility is opened
            {

                runnerSkillInfoText.text = "Invisibility is the phenomenon of becoming invisible to the eye. It takes 30 seconds to regenerate the Invisibility ability. Invisibility effect time depends on the level of the ability. There are total of 11 levels.";
                //runnerSkillsPrices = Skill.Instance.runnerInvisibility.Split('|');
                //LocalDatas.Instance.Debug("\nrunnerSkillsPrices[0]" + runnerSkillsPrices[0]);
                if (LocalDatas.Instance.runnerInvisibilityLevel < SomeDatas.Instance.runnerInvisibilityPrices.Length)
                {
                    improveRunnerButton.GetComponent<Button>().interactable = true;

                    improveRunnerButton.SetActive(true);

                    runnerSkillPriceText.text = SomeDatas.Instance.runnerInvisibilityPrices[LocalDatas.Instance.runnerInvisibilityLevel].ToString("n0");
                }
                else
                {
                    improveRunnerButton.SetActive(false);

                    runnerSkillPriceText.text = "FULL";
                }
            }
            else if (LocalDatas.Instance.runnerInvisibilityLevel >= SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 4] && SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 4] != 0) // if skill level is not max for this level
            {
                runnerSkillInfoText.text = "Required activation level - " + WhenRunnerSkillWillOpen(4, LocalDatas.Instance.currentLevelIntervalIndex); ;
                improveRunnerButton.GetComponent<Button>().interactable = false;
            }
            else // Invisibility skill is not opened yet
            {
                runnerSkillPriceText.text = SomeDatas.Instance.runnerInvisibilityPrices[LocalDatas.Instance.runnerInvisibilityLevel].ToString("n0");
                runnerSkillInfoText.color = skillInfoColorNotOpened;

                runnerSkillInfoText.text = "The skill is not active. Required activation level - " + WhenRunnerSkillWillOpen(4, LocalDatas.Instance.currentLevelIntervalIndex);
                improveRunnerButton.GetComponent<Button>().interactable = false;
            }

        }
        else if (button.name == "Life")
        {
            SetNumberOfBlackSquaresInRunnerSkillRightPanel(2);
            runnerSkillLevelImageBack.GetComponent<Image>().sprite = runnerSkillsLevelSpritesBack[1];
            currentRunnerSkillPressed = "Life";
            SetRunnerSkillLevels(LocalDatas.Instance.runnerAddHealth);
            if (LocalDatas.Instance.runnerAddHealth == SomeDatas.Instance.runnerAddHealthPrices.Length - 1) // 10 lvl
            {
                rightImageRunnerCoinImage.sprite = diamondSprite;
            }
            else if (LocalDatas.Instance.runnerAddHealth < SomeDatas.Instance.runnerAddHealthPrices.Length - 1) // 0-9 lvl
            {
                rightImageRunnerCoinImage.sprite = coinSprite;
            }
            else if (LocalDatas.Instance.runnerAddHealth >= SomeDatas.Instance.runnerAddHealthPrices.Length) // 11 level
            {
                runnerSkillPriceText.text = "FULL";
                improveRunnerButton.SetActive(false);
                rightImageRunnerCoinImage.gameObject.SetActive(false);
                runnerSkillInfoText.text = "The \"Health\" ability adds additional health, which is selected before entering the game. There are only 3 levels, so depending on the level health is added.";
                return;
            }

            runnerSkillPriceText.text = SomeDatas.Instance.runnerAddHealthPrices[LocalDatas.Instance.runnerAddHealth].ToString("n0");

            if (SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 1] != 0 && LocalDatas.Instance.runnerAddHealth < SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 1]) // Life is opened
            {
                //runnerSkillsPrices = Skill.Instance.runnerAddHealth.Split('|');
                runnerSkillInfoText.text = "The \"Health\" ability adds additional health, which is selected before entering the game. There are only 3 levels, so depending on the level health is added.";
                //LocalDatas.Instance.Debug("\nrunnerSkillsPrices[0]" + runnerSkillsPrices[0]);

                if (LocalDatas.Instance.runnerAddHealth < SomeDatas.Instance.runnerAddHealthPrices.Length)
                {
                    improveRunnerButton.GetComponent<Button>().interactable = true;

                    improveRunnerButton.SetActive(true);

                    runnerSkillPriceText.text = SomeDatas.Instance.runnerAddHealthPrices[LocalDatas.Instance.runnerAddHealth].ToString("n0");
                }
                else
                {
                    improveRunnerButton.SetActive(false);

                    runnerSkillPriceText.text = "FULL";
                }
            }
            else if (LocalDatas.Instance.runnerAddHealth >= SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 1] && SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 1] != 0) // if skill level is not max for this level
            {
                runnerSkillInfoText.text = "Required activation level - " + WhenRunnerSkillWillOpen(1, LocalDatas.Instance.currentLevelIntervalIndex);
                improveRunnerButton.GetComponent<Button>().interactable = false;
            }
            else // Life skill is not opened yet
            {
                runnerSkillPriceText.text = SomeDatas.Instance.runnerAddHealthPrices[LocalDatas.Instance.runnerAddHealth].ToString("n0");
                runnerSkillInfoText.color = skillInfoColorNotOpened;
                runnerSkillInfoText.text = "The skill is not active. Required activation level - " + WhenRunnerSkillWillOpen(1, LocalDatas.Instance.currentLevelIntervalIndex);
                improveRunnerButton.GetComponent<Button>().interactable = false;
            }
        }
        else if (button.name == "Trap")
        {
            runnerSkillLevelImageBack.GetComponent<Image>().sprite = runnerSkillsLevelSpritesBack[3];
            currentRunnerSkillPressed = "Trap";
            SetRunnerSkillLevels(LocalDatas.Instance.runnerTrapLevel);
            if (LocalDatas.Instance.runnerTrapLevel == SomeDatas.Instance.runnerTrapPrices.Length - 1) // 10 lvl
            {
                rightImageRunnerCoinImage.sprite = diamondSprite;
            }
            else if (LocalDatas.Instance.runnerTrapLevel < SomeDatas.Instance.runnerTrapPrices.Length - 1) // 0-9 lvl
            {
                rightImageRunnerCoinImage.sprite = coinSprite;
            }
            else if (LocalDatas.Instance.runnerTrapLevel >= SomeDatas.Instance.runnerTrapPrices.Length) // 11 level
            {
                runnerSkillPriceText.text = "FULL";
                improveRunnerButton.SetActive(false);
                rightImageRunnerCoinImage.gameObject.SetActive(false);
                runnerSkillInfoText.text = "TRAP Character throws a trap under himself, immobilizing the affected enemies for a certain amount of time. It takes 30 seconds to regenerate the Trap ability. There are total of 11 levels.";
                return;
            }
            runnerSkillPriceText.text = SomeDatas.Instance.runnerTrapPrices[LocalDatas.Instance.runnerTrapLevel].ToString("n0");

            if (SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 3] != 0 && LocalDatas.Instance.runnerTrapLevel < SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 3]) // Trap is opened
            {
                //runnerSkillsPrices = Skill.Instance.runnerTrap.Split('|');
                runnerSkillInfoText.text = "TRAP Character throws a trap under himself, immobilizing the affected enemies for a certain amount of time. It takes 30 seconds to regenerate the Trap ability. There are total of 11 levels.";
                //LocalDatas.Instance.Debug("\nrunnerSkillsPrices[0]" + runnerSkillsPrices[0]);
                //TODO length of array ..
                if (LocalDatas.Instance.runnerTrapLevel < SomeDatas.Instance.runnerTrapPrices.Length)
                {
                    improveRunnerButton.GetComponent<Button>().interactable = true;

                    improveRunnerButton.SetActive(true);

                    runnerSkillPriceText.text = SomeDatas.Instance.runnerTrapPrices[LocalDatas.Instance.runnerTrapLevel].ToString("n0");

                    //runnerSkillPriceText.text = SomeDatas.Instance.runnerAddHealthPrices[LocalDatas.Instance.runnerAddHealth].ToString();
                }
                else
                {
                    improveRunnerButton.SetActive(false);
                    runnerSkillPriceText.text = "FULL";
                }
            }
            else if (LocalDatas.Instance.runnerTrapLevel >= SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 3] && SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 3] != 0) // if skill level is not max for this level
            {
                runnerSkillInfoText.text = "Required activation level - " + WhenRunnerSkillWillOpen(3, LocalDatas.Instance.currentLevelIntervalIndex);
                improveRunnerButton.GetComponent<Button>().interactable = false;
            }
            else // Trap skill is not opened yet
            {
                runnerSkillPriceText.text = SomeDatas.Instance.runnerTrapPrices[LocalDatas.Instance.runnerTrapLevel].ToString("n0");
                runnerSkillInfoText.color = skillInfoColorNotOpened;

                runnerSkillInfoText.text = "The skill is not active. Required activation level - " + WhenRunnerSkillWillOpen(3, LocalDatas.Instance.currentLevelIntervalIndex);
                improveRunnerButton.GetComponent<Button>().interactable = false;
            }
        }
        else if (button.name == "SlowDownTrap")
        {
            runnerSkillLevelImageBack.GetComponent<Image>().sprite = runnerSkillsLevelSpritesBack[3];
            currentRunnerSkillPressed = "SlowDownTrap";
            SetRunnerSkillLevels(LocalDatas.Instance.runnerSlowdownTrapLevel);
            if (LocalDatas.Instance.runnerSlowdownTrapLevel == SomeDatas.Instance.runnerSTDPrices.Length - 1) // 10 lvl
            {
                rightImageRunnerCoinImage.sprite = diamondSprite;
            }
            else if (LocalDatas.Instance.runnerSlowdownTrapLevel < SomeDatas.Instance.runnerSTDPrices.Length - 1) // 0-9 lvl
            {
                rightImageRunnerCoinImage.sprite = coinSprite;
            }
            else if (LocalDatas.Instance.runnerSlowdownTrapLevel >= SomeDatas.Instance.runnerSTDPrices.Length) // 11 level
            {
                runnerSkillPriceText.text = "FULL";
                improveRunnerButton.SetActive(false);
                rightImageRunnerCoinImage.gameObject.SetActive(false);
                runnerSkillInfoText.text = "Slowing Down Trap - the ability to throw a circular field in a certain direction in order to slow down opponents for a defined amount of time within the range of the field. It takes 30 seconds to regenerate the Slowing Down Trap. Slowing Down Trap effect time depends on the level of the ability.";
                return;
            }
            runnerSkillPriceText.text = SomeDatas.Instance.runnerSTDPrices[LocalDatas.Instance.runnerSlowdownTrapLevel].ToString("n0");

            if (SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 5] != 0 && LocalDatas.Instance.runnerSlowdownTrapLevel < SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 5]) // Trap is opened
            {
                //runnerSkillsPrices = Skill.Instance.runnerTrap.Split('|');
                runnerSkillInfoText.text = "Slowing Down Trap - the ability to throw a circular field in a certain direction in order to slow down opponents for a defined amount of time within the range of the field. It takes 30 seconds to regenerate the Slowing Down Trap. Slowing Down Trap effect time depends on the level of the ability.";
                //LocalDatas.Instance.Debug("\nrunnerSkillsPrices[0]" + runnerSkillsPrices[0]);
                //TODO length of array ..
                if (LocalDatas.Instance.runnerSlowdownTrapLevel < SomeDatas.Instance.runnerSTDPrices.Length)
                {
                    improveRunnerButton.GetComponent<Button>().interactable = true;

                    improveRunnerButton.SetActive(true);

                    runnerSkillPriceText.text = SomeDatas.Instance.runnerSTDPrices[LocalDatas.Instance.runnerSlowdownTrapLevel].ToString("n0");

                    //runnerSkillPriceText.text = SomeDatas.Instance.runnerAddHealthPrices[LocalDatas.Instance.runnerAddHealth].ToString();
                }
                else
                {
                    improveRunnerButton.SetActive(false);
                    runnerSkillPriceText.text = "FULL";
                }
            }
            else if (LocalDatas.Instance.runnerSlowdownTrapLevel >= SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 5] && SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 5] != 0) // if skill level is not max for this level
            {
                runnerSkillInfoText.text = "Required activation level - " + WhenRunnerSkillWillOpen(5, LocalDatas.Instance.currentLevelIntervalIndex);
                improveRunnerButton.GetComponent<Button>().interactable = false;
            }
            else // Trap skill is not opened yet
            {
                runnerSkillPriceText.text = SomeDatas.Instance.runnerSTDPrices[LocalDatas.Instance.runnerSlowdownTrapLevel].ToString("n0");
                runnerSkillInfoText.color = skillInfoColorNotOpened;

                runnerSkillInfoText.text = "The skill is not active. Required activation level - " + WhenRunnerSkillWillOpen(5, LocalDatas.Instance.currentLevelIntervalIndex);
                improveRunnerButton.GetComponent<Button>().interactable = false;
            }
        }
        else if (button.name == "TopView")
        {
            runnerSkillLevelImageBack.GetComponent<Image>().sprite = runnerSkillsLevelSpritesBack[3];
            currentRunnerSkillPressed = "TopView";
            SetRunnerSkillLevels(LocalDatas.Instance.runnerTopViewLevel);
            if (LocalDatas.Instance.runnerTopViewLevel == SomeDatas.Instance.runnerTopViewPrices.Length - 1) // 10 lvl
            {
                rightImageRunnerCoinImage.sprite = diamondSprite;
            }
            else if (LocalDatas.Instance.runnerTopViewLevel < SomeDatas.Instance.runnerTopViewPrices.Length - 1) // 0-9 lvl
            {
                rightImageRunnerCoinImage.sprite = coinSprite;
            }
            else if (LocalDatas.Instance.runnerTopViewLevel >= SomeDatas.Instance.runnerTopViewPrices.Length) // 11 level
            {
                runnerSkillPriceText.text = "FULL";
                improveRunnerButton.SetActive(false);
                rightImageRunnerCoinImage.gameObject.SetActive(false);
                runnerSkillInfoText.text = "Top View - the ability gives you the view of the arena from above. All opponents and their actions will be visible at a certain time. It takes 30 seconds to regenerate the Top View ability. Top View effect time depends on the level of the ability.";
                return;
            }
            runnerSkillPriceText.text = SomeDatas.Instance.runnerTopViewPrices[LocalDatas.Instance.runnerTopViewLevel].ToString("n0");

            if (SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 6] != 0 && LocalDatas.Instance.runnerTopViewLevel < SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 6]) // TopView is opened
            {
                //runnerSkillsPrices = Skill.Instance.runnerTrap.Split('|');
                runnerSkillInfoText.text = "Top View - the ability gives you the view of the arena from above. All opponents and their actions will be visible at a certain time. It takes 30 seconds to regenerate the Top View ability. Top View effect time depends on the level of the ability.";
                //LocalDatas.Instance.Debug("\nrunnerSkillsPrices[0]" + runnerSkillsPrices[0]);
                //TODO length of array ..
                if (LocalDatas.Instance.runnerTopViewLevel < SomeDatas.Instance.runnerTopViewPrices.Length)
                {
                    improveRunnerButton.GetComponent<Button>().interactable = true;

                    improveRunnerButton.SetActive(true);

                    runnerSkillPriceText.text = SomeDatas.Instance.runnerTopViewPrices[LocalDatas.Instance.runnerTopViewLevel].ToString("n0");

                    //runnerSkillPriceText.text = SomeDatas.Instance.runnerAddHealthPrices[LocalDatas.Instance.runnerAddHealth].ToString();
                }
                else
                {
                    improveRunnerButton.SetActive(false);
                    runnerSkillPriceText.text = "FULL";
                }
            }
            else if (LocalDatas.Instance.runnerTopViewLevel >= SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 6] && SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 6] != 0) // if skill level is not max for this level
            {
                runnerSkillInfoText.text = "Required activation level - " + WhenRunnerSkillWillOpen(6, LocalDatas.Instance.currentLevelIntervalIndex);
                improveRunnerButton.GetComponent<Button>().interactable = false;
            }
            else // Trap skill is not opened yet
            {
                runnerSkillPriceText.text = SomeDatas.Instance.runnerTopViewPrices[LocalDatas.Instance.runnerTopViewLevel].ToString("n0");
                runnerSkillInfoText.color = skillInfoColorNotOpened;

                runnerSkillInfoText.text = "The skill is not active. Required activation level -" + WhenRunnerSkillWillOpen(6, LocalDatas.Instance.currentLevelIntervalIndex);
                improveRunnerButton.GetComponent<Button>().interactable = false;
            }
        }
        else if (button.name == "Wall")
        {
            runnerSkillLevelImageBack.GetComponent<Image>().sprite = runnerSkillsLevelSpritesBack[3];
            currentRunnerSkillPressed = "Wall";
            SetRunnerSkillLevels(LocalDatas.Instance.runnerWallLevel);
            if (LocalDatas.Instance.runnerWallLevel == SomeDatas.Instance.runnerWallPrices.Length - 1)// 10 level
            {
                rightImageRunnerCoinImage.sprite = diamondSprite;
            }
            else if (LocalDatas.Instance.runnerWallLevel < SomeDatas.Instance.runnerWallPrices.Length - 1)// 0-9 level
            {
                rightImageRunnerCoinImage.sprite = coinSprite;
            }
            else if (LocalDatas.Instance.runnerWallLevel >= SomeDatas.Instance.runnerWallPrices.Length) // 11 level
            {
                runnerSkillPriceText.text = "FULL";
                improveRunnerButton.SetActive(false);
                rightImageRunnerCoinImage.gameObject.SetActive(false);
                runnerSkillInfoText.text = "Barrier - forms a circular barrier that keeps opponents inside for a certain amount of time. It takes 30 seconds to regenerate the Barrier ability. Barrier effect time depends on the level of the ability. There are total of 11 levels.";
                return;
            }
            runnerSkillPriceText.text = SomeDatas.Instance.runnerWallPrices[LocalDatas.Instance.runnerWallLevel].ToString("n0");

            if (SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 7] != 0 && LocalDatas.Instance.runnerWallLevel < SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 7]) // Wall is opened
            {
                //runnerSkillsPrices = Skill.Instance.runnerTrap.Split('|');
                runnerSkillInfoText.text = "Barrier - forms a circular barrier that keeps opponents inside for a certain amount of time. It takes 30 seconds to regenerate the Barrier ability. Barrier effect time depends on the level of the ability. There are total of 11 levels.";
                //LocalDatas.Instance.Debug("\nrunnerSkillsPrices[0]" + runnerSkillsPrices[0]);
                //TODO length of array ..
                if (LocalDatas.Instance.runnerWallLevel < SomeDatas.Instance.runnerWallPrices.Length)
                {
                    improveRunnerButton.GetComponent<Button>().interactable = true;

                    improveRunnerButton.SetActive(true);

                    runnerSkillPriceText.text = SomeDatas.Instance.runnerWallPrices[LocalDatas.Instance.runnerWallLevel].ToString("n0");

                    //runnerSkillPriceText.text = SomeDatas.Instance.runnerAddHealthPrices[LocalDatas.Instance.runnerAddHealth].ToString();
                }
                else
                {
                    improveRunnerButton.SetActive(false);
                    runnerSkillPriceText.text = "FULL";
                }
            }
            else if (LocalDatas.Instance.runnerWallLevel >= SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 7] && SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 7] != 0) // if skill level is not max for this level
            {
                runnerSkillInfoText.text = "Required activation level - " + WhenRunnerSkillWillOpen(7, LocalDatas.Instance.currentLevelIntervalIndex);
                improveRunnerButton.GetComponent<Button>().interactable = false;
            }
            else // Trap skill is not opened yet
            {
                runnerSkillPriceText.text = SomeDatas.Instance.runnerWallPrices[LocalDatas.Instance.runnerWallLevel].ToString("n0");
                runnerSkillInfoText.color = skillInfoColorNotOpened;

                runnerSkillInfoText.text = "The skill is not active. Required activation level -" + WhenRunnerSkillWillOpen(7, LocalDatas.Instance.currentLevelIntervalIndex);
                improveRunnerButton.GetComponent<Button>().interactable = false;
            }
        }
        else if (button.name == "Hook")
        {
            runnerSkillLevelImageBack.GetComponent<Image>().sprite = runnerSkillsLevelSpritesBack[3];
            currentRunnerSkillPressed = "Hook";
            SetRunnerSkillLevels(LocalDatas.Instance.runnerHookLevel);
            if (LocalDatas.Instance.runnerHookLevel == SomeDatas.Instance.runnerHookPrices.Length - 1) // 10 lvl
            {
                rightImageRunnerCoinImage.sprite = diamondSprite;
            }
            else if (LocalDatas.Instance.runnerHookLevel < SomeDatas.Instance.runnerHookPrices.Length - 1) // 0-9 lvl
            {
                rightImageRunnerCoinImage.sprite = coinSprite;
            }
            else if (LocalDatas.Instance.runnerHookLevel >= SomeDatas.Instance.runnerHookPrices.Length) // 11 level
            {
                runnerSkillPriceText.text = "FULL";
                improveRunnerButton.SetActive(false);
                rightImageRunnerCoinImage.gameObject.SetActive(false);
                runnerSkillInfoText.text = "Hook - the ability to move quickly in the direction of the thrown hook. The hook can be thrown in the desired direction toward solids. It takes 30 seconds to regenerate the Hook ability. Hook regeneration time depends on the level of the ability. There are total of 11 levels.";
                return;
            }
            runnerSkillPriceText.text = SomeDatas.Instance.runnerHookPrices[LocalDatas.Instance.runnerHookLevel].ToString("n0");

            if (SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 8] != 0 && LocalDatas.Instance.runnerHookLevel < SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 8]) // Hook is opened
            {
                //runnerSkillsPrices = Skill.Instance.runnerTrap.Split('|');
                runnerSkillInfoText.text = "Hook - the ability to move quickly in the direction of the thrown hook. The hook can be thrown in the desired direction toward solids. It takes 30 seconds to regenerate the Hook ability. Hook regeneration time depends on the level of the ability. There are total of 11 levels.";
                //LocalDatas.Instance.Debug("\nrunnerSkillsPrices[0]" + runnerSkillsPrices[0]);
                //TODO length of array ..
                if (LocalDatas.Instance.runnerHookLevel < SomeDatas.Instance.runnerHookPrices.Length)
                {
                    improveRunnerButton.GetComponent<Button>().interactable = true;

                    improveRunnerButton.SetActive(true);

                    runnerSkillPriceText.text = SomeDatas.Instance.runnerHookPrices[LocalDatas.Instance.runnerHookLevel].ToString("n0");

                    //runnerSkillPriceText.text = SomeDatas.Instance.runnerAddHealthPrices[LocalDatas.Instance.runnerAddHealth].ToString();
                }
                else
                {
                    improveRunnerButton.SetActive(false);
                    runnerSkillPriceText.text = "FULL";
                }
            }
            else if (LocalDatas.Instance.runnerHookLevel >= SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 8] && SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 8] != 0) // if skill level is not max for this level
            {

                runnerSkillInfoText.text = "Required activation level - " + WhenRunnerSkillWillOpen(8, LocalDatas.Instance.currentLevelIntervalIndex);
                improveRunnerButton.GetComponent<Button>().interactable = false;
            }
            else // Trap skill is not opened yet
            {
                runnerSkillPriceText.text = SomeDatas.Instance.runnerHookPrices[LocalDatas.Instance.runnerHookLevel].ToString("n0");
                runnerSkillInfoText.color = skillInfoColorNotOpened;
                runnerSkillInfoText.text = "The skill is not active. Required activation level - " + WhenRunnerSkillWillOpen(8, LocalDatas.Instance.currentLevelIntervalIndex);
                improveRunnerButton.GetComponent<Button>().interactable = false;
            }
        }
        else if (button.name == "Bot Clone")
        {
            runnerSkillLevelImageBack.GetComponent<Image>().sprite = runnerSkillsLevelSpritesBack[3];
            currentRunnerSkillPressed = "Bot Clone";
            SetRunnerSkillLevels(LocalDatas.Instance.runnerBCLevel);
            if (LocalDatas.Instance.runnerBCLevel == SomeDatas.Instance.runnerBCPrices.Length - 1) // 10 lvl
            {
                rightImageRunnerCoinImage.sprite = diamondSprite;
            }
            else if(LocalDatas.Instance.runnerBCLevel < SomeDatas.Instance.runnerBCPrices.Length - 1) // 0-9 lvl
            {
                rightImageRunnerCoinImage.sprite = coinSprite;
            }
            else if (LocalDatas.Instance.runnerBCLevel >= SomeDatas.Instance.runnerBCPrices.Length) // 11 level
            {
                runnerSkillPriceText.text = "FULL";
                improveRunnerButton.SetActive(false);
                rightImageRunnerCoinImage.gameObject.SetActive(false);
                runnerSkillInfoText.text = "Clone Bots - the ability to create two clone bots that will make your opponent confused. The bots will move around the arena for a certain amount of time. It takes 30 seconds to regenerate the Ñlone Bots ability. Clone Bots effect time depends on the level of the ability.";
                return;
            }
            runnerSkillPriceText.text = SomeDatas.Instance.runnerBCPrices[LocalDatas.Instance.runnerBCLevel].ToString("n0");

            if (SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 9] != 0 && LocalDatas.Instance.runnerBCLevel < SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 9]) // Bot Clone is opened
            {
                //runnerSkillsPrices = Skill.Instance.runnerTrap.Split('|');
                runnerSkillInfoText.text = "Clone Bots - the ability to create two clone bots that will make your opponent confused. The bots will move around the arena for a certain amount of time. It takes 30 seconds to regenerate the Ñlone Bots ability. Clone Bots effect time depends on the level of the ability.";
                //LocalDatas.Instance.Debug("\nrunnerSkillsPrices[0]" + runnerSkillsPrices[0]);
                //TODO length of array ..
                if (LocalDatas.Instance.runnerBCLevel < SomeDatas.Instance.runnerBCPrices.Length)
                {
                    improveRunnerButton.GetComponent<Button>().interactable = true;

                    improveRunnerButton.SetActive(true);

                    runnerSkillPriceText.text = SomeDatas.Instance.runnerBCPrices[LocalDatas.Instance.runnerBCLevel].ToString("n0");

                    //runnerSkillPriceText.text = SomeDatas.Instance.runnerAddHealthPrices[LocalDatas.Instance.runnerAddHealth].ToString();
                }
                else
                {
                    improveRunnerButton.SetActive(false);
                    runnerSkillPriceText.text = "FULL";
                }
            }
            else if (LocalDatas.Instance.runnerBCLevel >= SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 9] && SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 9] != 0) // if skill level is not max for this level
            {

                runnerSkillInfoText.text = "Required activation level - " + WhenRunnerSkillWillOpen(9, LocalDatas.Instance.currentLevelIntervalIndex);
                improveRunnerButton.GetComponent<Button>().interactable = false;
            }
            else // Trap skill is not opened yet
            {
                runnerSkillPriceText.text = SomeDatas.Instance.runnerBCPrices[LocalDatas.Instance.runnerBCLevel].ToString("n0");
                runnerSkillInfoText.color = skillInfoColorNotOpened;
                runnerSkillInfoText.text = "The skill is not active. Required activation level -" + WhenRunnerSkillWillOpen(9, LocalDatas.Instance.currentLevelIntervalIndex);
                improveRunnerButton.GetComponent<Button>().interactable = false;
            }
        }

    }

    public void SkillButtonPressedCatcher(GameObject button)
    {
        bigSkillImageCatcher.GetComponent<Image>().sprite = button.GetComponent<Image>().sprite;
        skillNameTextCatcher.text = "" + button.name;
        //string[] catcherStats = LocalDatas.Instance.datasArray[7].Split(',');
        //string[] catcherSkillsPrices;

        miniSkillImageCatcher.sprite = button.GetComponent<Image>().sprite;

        catcherSkillInfoText.color = skillInfoColorOpened;
        SetNumberOfBlackSquaresInCatcherSkillRightPanel(11);
        improveCatcherButton.SetActive(true);
        rightImageCatcherCoinImage.gameObject.SetActive(true);
        if (button.name == "Sprint")
        {
            catcherSkillLevelImageBack.GetComponent<Image>().sprite = catcherSkillsLevelSpritesBack[0];
            currentCatcherSkillPressed = "Sprint";
            SetCatcherSkillLevels(LocalDatas.Instance.catcherSpeedLevel);
            if (LocalDatas.Instance.catcherSpeedLevel == SomeDatas.Instance.catcherSpeedPrices.Length - 1) // 10 lvl
            {
                rightImageCatcherCoinImage.sprite = diamondSprite;
            }
            else if(LocalDatas.Instance.catcherSpeedLevel < SomeDatas.Instance.catcherSpeedPrices.Length - 1) // 0-9 lvl
            {
                rightImageCatcherCoinImage.sprite = coinSprite;
            }
            else if (LocalDatas.Instance.catcherSpeedLevel >= SomeDatas.Instance.catcherSpeedPrices.Length) // 11 level
            {
                catcherSkillPriceText.text = "FULL";
                improveCatcherButton.SetActive(false);
                rightImageCatcherCoinImage.gameObject.SetActive(false);
                catcherSkillInfoText.text = "Sprint is the ability to move temporarily quickly around the map. It takes 30 seconds to regenerate the Sprint ability. Sprint effect time depends on the level of the ability. There are total of 11 levels.";
                return;
            }
            catcherSkillPriceText.text = SomeDatas.Instance.catcherSpeedPrices[LocalDatas.Instance.catcherSpeedLevel].ToString("n0");

            if (SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 0] != 0 && LocalDatas.Instance.catcherSpeedLevel < SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 0]) // Sprint is opened
            {
                catcherSkillInfoText.text = "Sprint is the ability to move temporarily quickly around the map. It takes 30 seconds to regenerate the Sprint ability. Sprint effect time depends on the level of the ability. There are total of 11 levels.";
                if (LocalDatas.Instance.catcherSpeedLevel < SomeDatas.Instance.catcherSpeedPrices.Length)
                {
                    improveCatcherButton.GetComponent<Button>().interactable = true;

                    improveCatcherButton.SetActive(true);
                    catcherSkillPriceText.text = SomeDatas.Instance.catcherSpeedPrices[LocalDatas.Instance.catcherSpeedLevel].ToString("n0");
                }
                else
                {
                    improveCatcherButton.SetActive(false);

                    catcherSkillPriceText.text = "FULL";
                }
            }
            else if (LocalDatas.Instance.catcherSpeedLevel >= SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 0] && SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 0] != 0) // if skill level is not max for this level
            {
                catcherSkillInfoText.text = "Required activation level - " + WhenCatcherSkillWillOpen(0, LocalDatas.Instance.currentLevelIntervalIndex);
                improveCatcherButton.GetComponent<Button>().interactable = false;
            }
            else // Sprint skill is not opened yet
            {
                catcherSkillPriceText.text = SomeDatas.Instance.catcherSpeedPrices[LocalDatas.Instance.catcherSpeedLevel].ToString("n0");
                catcherSkillInfoText.color = skillInfoColorNotOpened;

                catcherSkillInfoText.text = "The skill is not active. Required activation level - " + WhenCatcherSkillWillOpen(0, LocalDatas.Instance.currentLevelIntervalIndex);
                improveCatcherButton.GetComponent<Button>().interactable = false;
            }
        }
        else if (button.name == "Shield")
        {
            catcherSkillLevelImageBack.GetComponent<Image>().sprite = catcherSkillsLevelSpritesBack[1];
            currentCatcherSkillPressed = "Shield";
            SetCatcherSkillLevels(LocalDatas.Instance.catcherShieldLevel);
            if (LocalDatas.Instance.catcherShieldLevel == SomeDatas.Instance.catcherShieldPrices.Length - 1) // 10 lvl
            {
                rightImageCatcherCoinImage.sprite = diamondSprite;
            }
            else if (LocalDatas.Instance.catcherShieldLevel < SomeDatas.Instance.catcherShieldPrices.Length - 1) // 0-9 lvl
            {
                rightImageCatcherCoinImage.sprite = coinSprite;
            }
            else if (LocalDatas.Instance.catcherShieldLevel >= SomeDatas.Instance.catcherShieldPrices.Length) // 11 level
            {
                catcherSkillPriceText.text = "FULL";
                improveCatcherButton.SetActive(false);
                rightImageCatcherCoinImage.gameObject.SetActive(false);
                catcherSkillInfoText.text = "SHIELD Shields the Hero(character) for certain seconds depending on level of the ability. It takes 30 seconds to regenerate the Shield ability. There are total of 11 levels.";
                return;
            }
            catcherSkillPriceText.text = SomeDatas.Instance.catcherShieldPrices[LocalDatas.Instance.catcherShieldLevel].ToString("n0");

            if (SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 1] != 0 && LocalDatas.Instance.catcherShieldLevel < SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 1]) // Shield is opened
            {
                catcherSkillInfoText.text = "SHIELD Shields the Hero(character) for certain seconds depending on level of the ability. It takes 30 seconds to regenerate the Shield ability. There are total of 11 levels.";

                //LocalDatas.Instance.Debug("\ncatcherSkillsPrices[0]" + catcherSkillsPrices[0]);

                //catcherSkillsPrices = Skill.Instance.catcherShield.Split('|');
                if (LocalDatas.Instance.catcherShieldLevel < SomeDatas.Instance.catcherShieldPrices.Length)
                {
                    improveCatcherButton.GetComponent<Button>().interactable = true;

                    improveCatcherButton.SetActive(true);


                    catcherSkillPriceText.text = SomeDatas.Instance.catcherShieldPrices[LocalDatas.Instance.catcherShieldLevel].ToString("n0");
                }
                else
                {
                    improveCatcherButton.SetActive(false);

                    catcherSkillPriceText.text = "FULL";
                }
            }
            else if (LocalDatas.Instance.catcherShieldLevel >= SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 1] && SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 1] != 0) // if skill level is not max for this level
            {
                catcherSkillInfoText.text = "Required activation level - " + WhenCatcherSkillWillOpen(1, LocalDatas.Instance.currentLevelIntervalIndex);
                improveCatcherButton.GetComponent<Button>().interactable = false;
            }
            else // Shield skill is not opened yet
            {
                catcherSkillPriceText.text = SomeDatas.Instance.catcherShieldPrices[LocalDatas.Instance.catcherShieldLevel].ToString("n0");
                catcherSkillInfoText.color = skillInfoColorNotOpened;

                catcherSkillInfoText.text = "The skill is not active. Required activation level - " + WhenCatcherSkillWillOpen(1, LocalDatas.Instance.currentLevelIntervalIndex);
                improveCatcherButton.GetComponent<Button>().interactable = false;
            }

        }
        else if (button.name == "Invisibility")
        {
            catcherSkillLevelImageBack.GetComponent<Image>().sprite = catcherSkillsLevelSpritesBack[2];

            currentCatcherSkillPressed = "Invisibility";
            SetCatcherSkillLevels(LocalDatas.Instance.catcherInvisibilityLevel);
            if (LocalDatas.Instance.catcherInvisibilityLevel == SomeDatas.Instance.catcherInvisibilityPrices.Length - 1) // 10 lvl
            {
                rightImageCatcherCoinImage.sprite = diamondSprite;
            }
            else if (LocalDatas.Instance.catcherInvisibilityLevel < SomeDatas.Instance.catcherInvisibilityPrices.Length - 1) // 0-9 lvl
            {
                rightImageCatcherCoinImage.sprite = coinSprite;
            }
            else if (LocalDatas.Instance.catcherInvisibilityLevel >= SomeDatas.Instance.catcherInvisibilityPrices.Length) // 11 level
            {
                catcherSkillPriceText.text = "FULL";
                improveCatcherButton.SetActive(false);
                rightImageCatcherCoinImage.gameObject.SetActive(false);
                catcherSkillInfoText.text = "Invisibility is the phenomenon of becoming invisible to the eye. It takes 30 seconds to regenerate the Invisibility ability. Invisibility effect time depends on the level of the ability. There are total of 11 levels.";
                return;
            }

            catcherSkillPriceText.text = SomeDatas.Instance.catcherInvisibilityPrices[LocalDatas.Instance.catcherInvisibilityLevel].ToString("n0");

            if (SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 2] != 0 && LocalDatas.Instance.catcherInvisibilityLevel < SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 2]) // Invisibility is opened
            {
                catcherSkillInfoText.text = "Invisibility is the phenomenon of becoming invisible to the eye. It takes 30 seconds to regenerate the Invisibility ability. Invisibility effect time depends on the level of the ability. There are total of 11 levels.";
                //LocalDatas.Instance.Debug("\ncatcherSkillsPrices[0]" + catcherSkillsPrices[0]);
                //catcherSkillsPrices = Skill.Instance.catcherInvisibility.Split('|');
                if (LocalDatas.Instance.catcherInvisibilityLevel < SomeDatas.Instance.catcherInvisibilityPrices.Length)
                {
                    improveCatcherButton.GetComponent<Button>().interactable = true;

                    improveCatcherButton.SetActive(true);

                    catcherSkillPriceText.text = SomeDatas.Instance.catcherInvisibilityPrices[LocalDatas.Instance.catcherInvisibilityLevel].ToString("n0");
                }
                else
                {
                    improveCatcherButton.SetActive(false);

                    catcherSkillPriceText.text = "FULL";
                }
            }
            else if (LocalDatas.Instance.catcherInvisibilityLevel >= SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 2] && SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 2] != 0) // if skill level is not max for this level
            {
                catcherSkillInfoText.text = "Required activation level - " + WhenCatcherSkillWillOpen(2, LocalDatas.Instance.currentLevelIntervalIndex);
                improveCatcherButton.GetComponent<Button>().interactable = false;
            }
            else // Invisibility skill is not opened yet
            {
                catcherSkillPriceText.text = SomeDatas.Instance.catcherInvisibilityPrices[LocalDatas.Instance.catcherInvisibilityLevel].ToString("n0");
                catcherSkillInfoText.color = skillInfoColorNotOpened;

                catcherSkillInfoText.text = "The skill is not active. Required activation level - " + WhenCatcherSkillWillOpen(2, LocalDatas.Instance.currentLevelIntervalIndex);
                improveCatcherButton.GetComponent<Button>().interactable = false;
            }
        }
        else if (button.name == "Extra Projectile")
        {
            SetNumberOfBlackSquaresInCatcherSkillRightPanel(2);
            catcherSkillLevelImageBack.GetComponent<Image>().sprite = catcherSkillsLevelSpritesBack[3];

            currentCatcherSkillPressed = "ExtraBall";
            SetCatcherSkillLevels(LocalDatas.Instance.catcherBallLevel);
            if (LocalDatas.Instance.catcherBallLevel == SomeDatas.Instance.catcherBallPrices.Length - 1) // 10 lvl
            {
                rightImageCatcherCoinImage.sprite = diamondSprite;
            }
            else if (LocalDatas.Instance.catcherBallLevel < SomeDatas.Instance.catcherBallPrices.Length - 1) // 0-9 lvl
            {
                rightImageCatcherCoinImage.sprite = coinSprite;
            }
            else if (LocalDatas.Instance.catcherBallLevel >= SomeDatas.Instance.catcherBallPrices.Length) // 11 level
            {
                catcherSkillPriceText.text = "FULL";
                improveCatcherButton.SetActive(false);
                rightImageCatcherCoinImage.gameObject.SetActive(false);
                catcherSkillInfoText.text = "The \"Balls\" ability adds additional balls that are selected before entering the game. There are a total of 3 levels, therefore balls are added depending on the level.";
                return;
            }
            catcherSkillPriceText.text = SomeDatas.Instance.catcherBallPrices[LocalDatas.Instance.catcherBallLevel].ToString("n0");

            if (SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 3] != 0 && LocalDatas.Instance.catcherBallLevel < SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 3]) // ExtraBall is opened
            {
                catcherSkillInfoText.text = "The \"Balls\" ability adds additional balls that are selected before entering the game. There are a total of 3 levels, therefore balls are added depending on the level.";
                //LocalDatas.Instance.Debug("\ncatcherSkillsPrices[0]" + catcherSkillsPrices[0]);
                //catcherSkillsPrices = Skill.Instance.catcherMapShow.Split('|');
                if (LocalDatas.Instance.catcherBallLevel < SomeDatas.Instance.catcherBallPrices.Length)
                {
                    improveCatcherButton.GetComponent<Button>().interactable = true;

                    improveCatcherButton.SetActive(true);

                    catcherSkillPriceText.text = SomeDatas.Instance.catcherBallPrices[LocalDatas.Instance.catcherBallLevel].ToString("n0");
                }
                else
                {
                    improveCatcherButton.SetActive(false);

                    catcherSkillPriceText.text = "FULL";
                }

            }
            else if (LocalDatas.Instance.catcherBallLevel >= SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 3] && SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 3] != 0) // if skill level is not max for this level
            {
                catcherSkillInfoText.text = "Required activation level - " + WhenCatcherSkillWillOpen(3, LocalDatas.Instance.currentLevelIntervalIndex);
                improveCatcherButton.GetComponent<Button>().interactable = false;
            }
            else // ExtraBall skill is not opened yet
            {
                catcherSkillPriceText.text = SomeDatas.Instance.catcherBallPrices[LocalDatas.Instance.catcherBallLevel].ToString("n0");
                catcherSkillInfoText.color = skillInfoColorNotOpened;

                catcherSkillInfoText.text = "The skill is not active. Required activation level - " + WhenCatcherSkillWillOpen(3, LocalDatas.Instance.currentLevelIntervalIndex);
                improveCatcherButton.GetComponent<Button>().interactable = false;
            }
        }
        else if (button.name == "SlowDownTrap")
        {
            catcherSkillLevelImageBack.GetComponent<Image>().sprite = catcherSkillsLevelSpritesBack[3];

            currentCatcherSkillPressed = "SlowDownTrap";
            SetCatcherSkillLevels(LocalDatas.Instance.catcherSlowdownTrapLevel);
            if (LocalDatas.Instance.catcherSlowdownTrapLevel == SomeDatas.Instance.catcherSTDPrices.Length - 1) // 10 lvl
            {
                rightImageCatcherCoinImage.sprite = diamondSprite;
            }
            else if (LocalDatas.Instance.catcherSlowdownTrapLevel < SomeDatas.Instance.catcherSTDPrices.Length - 1) // 0-9 lvl
            {
                rightImageCatcherCoinImage.sprite = coinSprite;
            }
            else if (LocalDatas.Instance.catcherSlowdownTrapLevel >= SomeDatas.Instance.catcherSTDPrices.Length) // 11 level
            {
                catcherSkillPriceText.text = "FULL";
                improveCatcherButton.SetActive(false);
                rightImageCatcherCoinImage.gameObject.SetActive(false);
                catcherSkillInfoText.text = "Slowing Down Trap - the ability to throw a circular field in a certain direction in order to slow down opponents for a defined amount of time within the range of the field. It takes 30 seconds to regenerate the Slowing Down Trap. Slowing Down Trap effect time depends on the level of the ability.";
                return;
            }
            catcherSkillPriceText.text = SomeDatas.Instance.catcherSTDPrices[LocalDatas.Instance.catcherSlowdownTrapLevel].ToString("n0");

            if (SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 4] != 0 && LocalDatas.Instance.catcherSlowdownTrapLevel < SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 4]) // SlowDownTrap is opened
            {
                catcherSkillInfoText.text = "Slowing Down Trap - the ability to throw a circular field in a certain direction in order to slow down opponents for a defined amount of time within the range of the field. It takes 30 seconds to regenerate the Slowing Down Trap. Slowing Down Trap effect time depends on the level of the ability.";
                //LocalDatas.Instance.Debug("\ncatcherSkillsPrices[0]" + catcherSkillsPrices[0]);
                //catcherSkillsPrices = Skill.Instance.catcherMapShow.Split('|');
                if (LocalDatas.Instance.catcherSlowdownTrapLevel < SomeDatas.Instance.catcherSTDPrices.Length)
                {
                    improveCatcherButton.GetComponent<Button>().interactable = true;

                    improveCatcherButton.SetActive(true);

                    catcherSkillPriceText.text = SomeDatas.Instance.catcherSTDPrices[LocalDatas.Instance.catcherSlowdownTrapLevel].ToString("n0");
                }
                else
                {
                    improveCatcherButton.SetActive(false);

                    catcherSkillPriceText.text = "FULL";
                }

            }
            else if (LocalDatas.Instance.catcherSlowdownTrapLevel >= SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 4] && SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 4] != 0) // if skill level is not max for this level
            {
                catcherSkillInfoText.text = "Required activation level - " + WhenCatcherSkillWillOpen(4, LocalDatas.Instance.currentLevelIntervalIndex);
                improveCatcherButton.GetComponent<Button>().interactable = false;
            }
            else // ExtraBall skill is not opened yet
            {
                catcherSkillPriceText.text = SomeDatas.Instance.catcherSTDPrices[LocalDatas.Instance.catcherBallLevel].ToString("n0");
                catcherSkillInfoText.color = skillInfoColorNotOpened;

                catcherSkillInfoText.text = "The skill is not active. Required activation level - " + WhenCatcherSkillWillOpen(4, LocalDatas.Instance.currentLevelIntervalIndex);
                improveCatcherButton.GetComponent<Button>().interactable = false;
            }
        }
        else if (button.name == "TopView")
        {
            catcherSkillLevelImageBack.GetComponent<Image>().sprite = catcherSkillsLevelSpritesBack[3];

            currentCatcherSkillPressed = "TopView";
            SetCatcherSkillLevels(LocalDatas.Instance.catcherTopViewLevel);
            if (LocalDatas.Instance.catcherTopViewLevel == SomeDatas.Instance.catcherTopViewPrices.Length - 1) // 10 lvl
            {
                rightImageCatcherCoinImage.sprite = diamondSprite;
            }
            else if (LocalDatas.Instance.catcherTopViewLevel < SomeDatas.Instance.catcherTopViewPrices.Length - 1) // 0-9 lvl
            {
                rightImageCatcherCoinImage.sprite = coinSprite;
            }
            else if (LocalDatas.Instance.catcherTopViewLevel >= SomeDatas.Instance.catcherTopViewPrices.Length) // 11 level
            {
                catcherSkillPriceText.text = "FULL";
                improveCatcherButton.SetActive(false);
                rightImageCatcherCoinImage.gameObject.SetActive(false);
                catcherSkillInfoText.text = "Top View - the ability gives you the view of the arena from above. All opponents and their actions will be visible at a certain time. It takes 30 seconds to regenerate the Top View ability. Top View effect time depends on the level of the ability.";
                return;
            }
            catcherSkillPriceText.text = SomeDatas.Instance.catcherTopViewPrices[LocalDatas.Instance.catcherTopViewLevel].ToString("n0");

            if (SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 5] != 0 && LocalDatas.Instance.catcherTopViewLevel < SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 5]) // TopView is opened
            {
                catcherSkillInfoText.text = "Top View - the ability gives you the view of the arena from above. All opponents and their actions will be visible at a certain time. It takes 30 seconds to regenerate the Top View ability. Top View effect time depends on the level of the ability.";
                //LocalDatas.Instance.Debug("\ncatcherSkillsPrices[0]" + catcherSkillsPrices[0]);
                //catcherSkillsPrices = Skill.Instance.catcherMapShow.Split('|');
                if (LocalDatas.Instance.catcherTopViewLevel < SomeDatas.Instance.catcherTopViewPrices.Length)
                {
                    improveCatcherButton.GetComponent<Button>().interactable = true;

                    improveCatcherButton.SetActive(true);

                    catcherSkillPriceText.text = SomeDatas.Instance.catcherTopViewPrices[LocalDatas.Instance.catcherTopViewLevel].ToString("n0");
                }
                else
                {
                    improveCatcherButton.SetActive(false);

                    catcherSkillPriceText.text = "FULL";
                }

            }
            else if (LocalDatas.Instance.catcherTopViewLevel >= SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 5] && SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 5] != 0) // if skill level is not max for this level
            {
                catcherSkillInfoText.text = "Required activation level - " + WhenCatcherSkillWillOpen(5, LocalDatas.Instance.currentLevelIntervalIndex);
                improveCatcherButton.GetComponent<Button>().interactable = false;
            }
            else // ExtraBall skill is not opened yet
            {
                catcherSkillPriceText.text = SomeDatas.Instance.catcherTopViewPrices[LocalDatas.Instance.catcherBallLevel].ToString("n0");
                catcherSkillInfoText.color = skillInfoColorNotOpened;

                catcherSkillInfoText.text = "The skill is not active. Required activation level - " + WhenCatcherSkillWillOpen(5, LocalDatas.Instance.currentLevelIntervalIndex);
                improveCatcherButton.GetComponent<Button>().interactable = false;
            }
        }
        else if (button.name == "Wall")
        {
            catcherSkillLevelImageBack.GetComponent<Image>().sprite = catcherSkillsLevelSpritesBack[3];

            currentCatcherSkillPressed = "Wall";
            SetCatcherSkillLevels(LocalDatas.Instance.catcherWallLevel);
            if (LocalDatas.Instance.catcherWallLevel == SomeDatas.Instance.catcherWallPrices.Length - 1) // 10 lvl
            {
                rightImageCatcherCoinImage.sprite = diamondSprite;
            }
            else if (LocalDatas.Instance.catcherWallLevel < SomeDatas.Instance.catcherWallPrices.Length - 1) // 0-9 lvl
            {
                rightImageCatcherCoinImage.sprite = coinSprite;
            }
            else if (LocalDatas.Instance.catcherWallLevel >= SomeDatas.Instance.catcherWallPrices.Length) // 11 level
            {
                catcherSkillPriceText.text = "FULL";
                improveCatcherButton.SetActive(false);
                rightImageCatcherCoinImage.gameObject.SetActive(false);
                catcherSkillInfoText.text = "Barrier - forms a circular barrier that keeps opponents inside for a certain amount of time. It takes 30 seconds to regenerate the Barrier ability. Barrier effect time depends on the level of the ability. There are total of 11 levels.";
                return;
            }
            catcherSkillPriceText.text = SomeDatas.Instance.catcherWallPrices[LocalDatas.Instance.catcherWallLevel].ToString("n0");

            if (SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 6] != 0 && LocalDatas.Instance.catcherWallLevel < SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 6]) // Wall is opened
            {
                catcherSkillInfoText.text = "Barrier - forms a circular barrier that keeps opponents inside for a certain amount of time. It takes 30 seconds to regenerate the Barrier ability. Barrier effect time depends on the level of the ability. There are total of 11 levels.";
                //LocalDatas.Instance.Debug("\ncatcherSkillsPrices[0]" + catcherSkillsPrices[0]);
                //catcherSkillsPrices = Skill.Instance.catcherMapShow.Split('|');
                if (LocalDatas.Instance.catcherWallLevel < SomeDatas.Instance.catcherWallPrices.Length)
                {
                    improveCatcherButton.GetComponent<Button>().interactable = true;

                    improveCatcherButton.SetActive(true);

                    catcherSkillPriceText.text = SomeDatas.Instance.catcherWallPrices[LocalDatas.Instance.catcherWallLevel].ToString("n0");
                }
                else
                {
                    improveCatcherButton.SetActive(false);

                    catcherSkillPriceText.text = "FULL";
                }

            }
            else if (LocalDatas.Instance.catcherWallLevel >= SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 6] && SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 6] != 0) // if skill level is not max for this level
            {
                catcherSkillInfoText.text = "Required activation level - " + WhenCatcherSkillWillOpen(6, LocalDatas.Instance.currentLevelIntervalIndex);
                improveCatcherButton.GetComponent<Button>().interactable = false;
            }
            else // ExtraBall skill is not opened yet
            {
                catcherSkillPriceText.text = SomeDatas.Instance.catcherWallPrices[LocalDatas.Instance.catcherBallLevel].ToString("n0");
                catcherSkillInfoText.color = skillInfoColorNotOpened;

                catcherSkillInfoText.text = "The skill is not active. Required activation level - " + WhenCatcherSkillWillOpen(6, LocalDatas.Instance.currentLevelIntervalIndex);
                improveCatcherButton.GetComponent<Button>().interactable = false;
            }
        }
        else if (button.name == "Hook")
        {
            catcherSkillLevelImageBack.GetComponent<Image>().sprite = catcherSkillsLevelSpritesBack[3];

            currentCatcherSkillPressed = "Hook";
            SetCatcherSkillLevels(LocalDatas.Instance.catcherHookLevel);
            if (LocalDatas.Instance.catcherHookLevel == SomeDatas.Instance.catcherHookPrices.Length - 1) // 10 lvl
            {
                rightImageCatcherCoinImage.sprite = diamondSprite;
            }
            else if (LocalDatas.Instance.catcherHookLevel < SomeDatas.Instance.catcherHookPrices.Length - 1) // 0-9 lvl
            {
                rightImageCatcherCoinImage.sprite = coinSprite;
            }
            else if (LocalDatas.Instance.catcherHookLevel >= SomeDatas.Instance.catcherHookPrices.Length) // 11 level
            {
                catcherSkillPriceText.text = "FULL";
                improveCatcherButton.SetActive(false);
                rightImageCatcherCoinImage.gameObject.SetActive(false);
                catcherSkillInfoText.text = "Hook - the ability to move quickly in the direction of the thrown hook. The hook can be thrown in the desired direction toward solids. It takes 30 seconds to regenerate the Hook ability. Hook regeneration time depends on the level of the ability. There are total of 11 levels.";
                return;
            }
            catcherSkillPriceText.text = SomeDatas.Instance.catcherHookPrices[LocalDatas.Instance.catcherHookLevel].ToString("n0");

            if (SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 7] != 0 && LocalDatas.Instance.catcherHookLevel < SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 7]) // Hook is opened
            {
                catcherSkillInfoText.text = "Hook - the ability to move quickly in the direction of the thrown hook. The hook can be thrown in the desired direction toward solids. It takes 30 seconds to regenerate the Hook ability. Hook regeneration time depends on the level of the ability. There are total of 11 levels.";
                //LocalDatas.Instance.Debug("\ncatcherSkillsPrices[0]" + catcherSkillsPrices[0]);
                //catcherSkillsPrices = Skill.Instance.catcherMapShow.Split('|');
                if (LocalDatas.Instance.catcherHookLevel < SomeDatas.Instance.catcherHookPrices.Length)
                {
                    improveCatcherButton.GetComponent<Button>().interactable = true;

                    improveCatcherButton.SetActive(true);

                    catcherSkillPriceText.text = SomeDatas.Instance.catcherHookPrices[LocalDatas.Instance.catcherHookLevel].ToString("n0");
                }
                else
                {
                    improveCatcherButton.SetActive(false);

                    catcherSkillPriceText.text = "FULL";
                }

            }
            else if (LocalDatas.Instance.catcherHookLevel >= SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 7] && SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 7] != 0) // if skill level is not max for this level
            {
                catcherSkillInfoText.text = "Required activation level - " + WhenCatcherSkillWillOpen(7, LocalDatas.Instance.currentLevelIntervalIndex);
                improveCatcherButton.GetComponent<Button>().interactable = false;
            }
            else // ExtraBall skill is not opened yet
            {
                catcherSkillPriceText.text = SomeDatas.Instance.catcherHookPrices[LocalDatas.Instance.catcherBallLevel].ToString("n0");
                catcherSkillInfoText.color = skillInfoColorNotOpened;

                catcherSkillInfoText.text = "The skill is not active. Required activation level - " + WhenCatcherSkillWillOpen(7, LocalDatas.Instance.currentLevelIntervalIndex);
                improveCatcherButton.GetComponent<Button>().interactable = false;
            }
        }
        else if (button.name == "Death Shot")
        {
            catcherSkillLevelImageBack.GetComponent<Image>().sprite = catcherSkillsLevelSpritesBack[3];

            currentCatcherSkillPressed = "Deadly Hit";
            SetCatcherSkillLevels(LocalDatas.Instance.catcherDeadlyHitLevel);
            if (LocalDatas.Instance.catcherDeadlyHitLevel == SomeDatas.Instance.catcherDHPrices.Length - 1) // 10 lvl
            {
                rightImageCatcherCoinImage.sprite = diamondSprite;
            }
            else if (LocalDatas.Instance.catcherDeadlyHitLevel < SomeDatas.Instance.catcherDHPrices.Length - 1) // 0-9 lvl
            {
                rightImageCatcherCoinImage.sprite = coinSprite;
            }
            else if (LocalDatas.Instance.catcherDeadlyHitLevel >= SomeDatas.Instance.catcherDHPrices.Length) // 11 level
            {
                catcherSkillPriceText.text = "FULL";
                improveCatcherButton.SetActive(false);
                rightImageCatcherCoinImage.gameObject.SetActive(false);
                catcherSkillInfoText.text = "Death Shot - the ability to shoot in a chosen direction. The beams can go through walls or rocks. It takes 30 seconds to regenerate the Death Shot ability. Death Shot regeneration time depends on the level of the ability.";
                return;
            }
            catcherSkillPriceText.text = SomeDatas.Instance.catcherDHPrices[LocalDatas.Instance.catcherDeadlyHitLevel].ToString("n0");

            if (SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 8] != 0 && LocalDatas.Instance.catcherDeadlyHitLevel < SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 8]) // Deadly Hit is opened
            {
                catcherSkillInfoText.text = "Death Shot - the ability to shoot in a chosen direction. The beams can go through walls or rocks. It takes 30 seconds to regenerate the Death Shot ability. Death Shot regeneration time depends on the level of the ability.";
                //LocalDatas.Instance.Debug("\ncatcherSkillsPrices[0]" + catcherSkillsPrices[0]);
                //catcherSkillsPrices = Skill.Instance.catcherMapShow.Split('|');
                if (LocalDatas.Instance.catcherDeadlyHitLevel < SomeDatas.Instance.catcherDHPrices.Length)
                {
                    improveCatcherButton.GetComponent<Button>().interactable = true;

                    improveCatcherButton.SetActive(true);

                    catcherSkillPriceText.text = SomeDatas.Instance.catcherDHPrices[LocalDatas.Instance.catcherDeadlyHitLevel].ToString("n0");
                }
                else
                {
                    improveCatcherButton.SetActive(false);

                    catcherSkillPriceText.text = "FULL";
                }

            }
            else if (LocalDatas.Instance.catcherDeadlyHitLevel >= SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 8] && SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 8] != 0) // if skill level is not max for this level
            {
                catcherSkillInfoText.text = "Required activation level - " + WhenCatcherSkillWillOpen(8, LocalDatas.Instance.currentLevelIntervalIndex);
                improveCatcherButton.GetComponent<Button>().interactable = false;
            }
            else // Deadly Hit skill is not opened yet
            {
                catcherSkillPriceText.text = SomeDatas.Instance.catcherDHPrices[LocalDatas.Instance.catcherDeadlyHitLevel].ToString("n0");
                catcherSkillInfoText.color = skillInfoColorNotOpened;

                catcherSkillInfoText.text = "The skill is not active. Required activation level - " + WhenCatcherSkillWillOpen(8, LocalDatas.Instance.currentLevelIntervalIndex);
                improveCatcherButton.GetComponent<Button>().interactable = false;
            }
        }
        else if (button.name == "Bot Clone")
        {
            catcherSkillLevelImageBack.GetComponent<Image>().sprite = catcherSkillsLevelSpritesBack[3];

            currentCatcherSkillPressed = "Bot Clone";
            SetCatcherSkillLevels(LocalDatas.Instance.catcherBCLevel);
            if (LocalDatas.Instance.catcherBCLevel == SomeDatas.Instance.catcherBCPrices.Length - 1) // 10 lvl
            {
                rightImageCatcherCoinImage.sprite = diamondSprite;
            }
            else if (LocalDatas.Instance.catcherBCLevel < SomeDatas.Instance.catcherBCPrices.Length - 1) // 0-9 lvl
            {
                rightImageCatcherCoinImage.sprite = coinSprite;
            }
            else if (LocalDatas.Instance.catcherBCLevel >= SomeDatas.Instance.catcherBCPrices.Length) // 11 level
            {
                catcherSkillPriceText.text = "FULL";
                improveCatcherButton.SetActive(false);
                rightImageCatcherCoinImage.gameObject.SetActive(false);
                catcherSkillInfoText.text = "Clone Bots - the ability to create two clone bots that will make your opponent confused. The bots will move around the arena for a certain amount of time. It takes 30 seconds to regenerate the Ñlone Bots ability. Clone Bots effect time depends on the level of the ability.";
                return;
            }
            catcherSkillPriceText.text = SomeDatas.Instance.catcherBCPrices[LocalDatas.Instance.catcherBCLevel].ToString("n0");

            if (SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 9] != 0 && LocalDatas.Instance.catcherBCLevel < SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 9]) // Bot Clone is opened
            {
                catcherSkillInfoText.text = "Clone Bots - the ability to create two clone bots that will make your opponent confused. The bots will move around the arena for a certain amount of time. It takes 30 seconds to regenerate the Ñlone Bots ability. Clone Bots effect time depends on the level of the ability.";
                //LocalDatas.Instance.Debug("\ncatcherSkillsPrices[0]" + catcherSkillsPrices[0]);
                //catcherSkillsPrices = Skill.Instance.catcherMapShow.Split('|');
                if (LocalDatas.Instance.catcherBCLevel < SomeDatas.Instance.catcherBCPrices.Length)
                {
                    improveCatcherButton.GetComponent<Button>().interactable = true;

                    improveCatcherButton.SetActive(true);

                    catcherSkillPriceText.text = SomeDatas.Instance.catcherBCPrices[LocalDatas.Instance.catcherBCLevel].ToString("n0");
                }
                else
                {
                    improveCatcherButton.SetActive(false);

                    catcherSkillPriceText.text = "FULL";
                }

            }
            else if (LocalDatas.Instance.catcherBCLevel >= SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 9] && SomeDatas.Instance.maxCatcherSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, 9] != 0) // if skill level is not max for this level
            {
                catcherSkillInfoText.text = "Required activation level - " + WhenCatcherSkillWillOpen(9, LocalDatas.Instance.currentLevelIntervalIndex);
                improveCatcherButton.GetComponent<Button>().interactable = false;
            }
            else // ExtraBall skill is not opened yet
            {
                catcherSkillPriceText.text = SomeDatas.Instance.catcherBCPrices[LocalDatas.Instance.catcherBCLevel].ToString("n0");
                catcherSkillInfoText.color = skillInfoColorNotOpened;

                catcherSkillInfoText.text = "The skill is not active. Required activation level - " + WhenCatcherSkillWillOpen(9, LocalDatas.Instance.currentLevelIntervalIndex);
                improveCatcherButton.GetComponent<Button>().interactable = false;
            }
        }

    }

    public void MakeSkillsPanelDefault()
    {
        bigSkillImageRunner.GetComponent<Image>().sprite = runnerSkillsButtons[0].GetComponent<Image>().sprite;
        skillNameTextRunner.text = "" + runnerSkillsButtons[0].name;

        bigSkillImageCatcher.GetComponent<Image>().sprite = runnerSkillsButtons[0].GetComponent<Image>().sprite;
        skillNameTextCatcher.text = "" + runnerSkillsButtons[0].name;
    }

    public void OpenSkillsPanel()
    {
        LeanTween.alpha(skillsPanel.GetComponent<RectTransform>(), 0.5f, time).setEase(LeanTweenType.pingPong);
        skillsPanel.GetComponent<Image>().raycastTarget = true;
        skillsPanelChild.SetActive(true);
        LeanTween.alpha(skillsPanelChild.GetComponent<RectTransform>(), 1f, time).setEase(LeanTweenType.pingPong);
        LocalDatas.Instance.Sed3dObjectParent(false);
        MakePlayerObjectDefaultRotation(LocalDatas.Instance.playerCharacterObjects[LocalDatas.Instance.currentCharacterIndex]);
        SkillButtonPressedRunner(runnerSkillsButtons[0]);
        LocalDatas.Instance.isInMainMenu = false;
        SetRunnerSkillOpenedOrNot();



    }

    public void SetRunnerSkillOpenedOrNot()
    {
        for (int i = 0; i < runnerSkillsButtons.Length; i++)
        {
            if (LocalDatas.Instance.runnerSkillsLevels[i] <= SomeDatas.Instance.maxRunnerSkillLevelPerLevel[LocalDatas.Instance.currentLevelIntervalIndex, i] && LocalDatas.Instance.runnerSkillsLevels[i] == 0)
            {
                runnerSkillsButtons[i].GetComponent<Image>().color = unSelectedPoint;
            }
            else
            {
                runnerSkillsButtons[i].GetComponent<Image>().color = selectedPoint;
            }
        }
    }

    public void CloseSkillsPanel()
    {
        //RotateVFXButtonBack();
        LeanTween.alpha(skillsPanel.GetComponent<RectTransform>(), 0f, time).setEase(LeanTweenType.pingPong);
        skillsPanel.GetComponent<Image>().raycastTarget = false;
        skillsPanelChild.SetActive(false);
        LocalDatas.Instance.Sed3dObjectParent(true);
        catcherSkillsPanel.SetActive(false);
        runnerSkillsPanel.SetActive(true);
        LocalDatas.Instance.isInMainMenu = true;

    }

    public void RunnerSkillsButtonPressed()
    {
        runnerSkillsButton.GetComponent<Image>().sprite = runnerButtonSelectedSprite;
        catcherSkillsButton.GetComponent<Image>().sprite = catcherButtonNotSelectedSprite;
        runnerSkillsPanel.SetActive(true);
        catcherSkillsPanel.SetActive(false);
    }

    public void CatcherSkillsButtonPressed()
    {
        catcherSkillsButton.GetComponent<Image>().sprite = catcherButtonSelectedSprite;
        runnerSkillsButton.GetComponent<Image>().sprite = runnerButtonNotSelectedSprite;
        catcherSkillsPanel.SetActive(true);
        runnerSkillsPanel.SetActive(false);
    }

    void SetNumberOfBlackSquaresInRunnerSkillRightPanel(int n)
    {
        for (int i = 0; i < runnerSkillBlackSquares.Length; i++)
        {
            if (i < n)
            {
                runnerSkillBlackSquares[i].SetActive(true);
            }
            else
            {

                runnerSkillBlackSquares[i].SetActive(false);
            }
        }
    }

    void SetNumberOfBlackSquaresInCatcherSkillRightPanel(int n)
    {
        for (int i = 0; i < runnerSkillBlackSquares.Length; i++)
        {
            if (i < n)
            {
                catcherSkillBlackSquares[i].SetActive(true);
            }
            else
            {

                catcherSkillBlackSquares[i].SetActive(false);
            }
        }
    }

    #endregion

    #region PlayerProfile functions

    public void OpenRUSureChangeNickPanel()
    {
        changeNickPriceText.text = "Changing nickname will cost " + LocalDatas.Instance.changeNickPrice + " diamonds. Are you sure?";
        ruSureChangeNickPanel.SetActive(true);
    }

    public void CloseRUSureChangeNickPanel()
    {
        ruSureChangeNickPanel.SetActive(false);
    }

    public void CheckIfCanChangeNick()
    {
        if (LocalDatas.Instance.crystalCoin >= LocalDatas.Instance.changeNickPrice)
        {
            OpenChangeNickPanel();
        }
        else
        {
            ShowNotEnoughMoneyImage();
        }
    }


    public void OpenChangeNickPanel()
    {
        LeanTween.alpha(changeNickMenu.GetComponent<RectTransform>(), 1f, time).setEase(LeanTweenType.pingPong);
        changeNickMenu.GetComponent<Image>().raycastTarget = true;
        changeNickMenuChild.SetActive(true);
    }


    public void CloseChangeNickPanel()
    {
        changeNickInputfield.text = "";
        LeanTween.alpha(changeNickMenu.GetComponent<RectTransform>(), 0f, time).setEase(LeanTweenType.pingPong);
        changeNickMenu.GetComponent<Image>().raycastTarget = false;
        changeNickMenuChild.SetActive(false);
    }

    public void SaveChangedNickname()
    {
        LocalDatas.Instance.crystalCoin -= LocalDatas.Instance.changeNickPrice;
        LocalDatas.Instance.nickName = changeNickInputfield.text;
        changeNickInputfield.text = "";
        LocalDatas.Instance.SetNickNameTexts();
        FirebaseController.Instance.SaveData();
        CloseChangeNickPanel();
    }

    public void OpenPlayerProfilePanel()
    {
        LeanTween.alpha(playerProfilePanel.GetComponent<RectTransform>(), 1f, time).setEase(LeanTweenType.pingPong);
        playerProfilePanel.GetComponent<Image>().raycastTarget = true;
        playerProfilePanelChild.SetActive(true);
        LocalDatas.Instance.Sed3dObjectParent(false);
        MakePlayerObjectDefaultRotation(LocalDatas.Instance.playerCharacterObjects[LocalDatas.Instance.currentCharacterIndex]);
        LocalDatas.Instance.isInMainMenu = false;
    }

    public void ClosePlayerProfilePanel()
    {
        //RotateVFXButtonBack();
        LeanTween.alpha(playerProfilePanel.GetComponent<RectTransform>(), 0f, time).setEase(LeanTweenType.pingPong);
        playerProfilePanel.GetComponent<Image>().raycastTarget = false;
        playerProfilePanelChild.SetActive(false);
        LocalDatas.Instance.Sed3dObjectParent(true);
        LocalDatas.Instance.isInMainMenu = true;
    }

    #endregion

    #region CharacterPanel functions



    public void OpenCharacterPanel()
    {
        //vfxButtonCanRotate = false;
        LeanTween.alpha(characterPanel.GetComponent<RectTransform>(), 1f, time).setEase(LeanTweenType.pingPong);
        for (int i = 0; i < lockPanels.Length; i++)
        {
            LeanTween.alpha(lockPanels[i].GetComponent<RectTransform>(), 0.5f, time + 0.01f);
        }
        //LeanTween.alpha(characterPanelChild.GetComponent<RectTransform>(), 1f, time).setEase(LeanTweenType.pingPong);
        characterPanel.GetComponent<Image>().raycastTarget = true;
        characterPanelChild.SetActive(true);
        LocalDatas.Instance.Sed3dObjectParent(false);
        MakePlayerObjectDefaultRotation(LocalDatas.Instance.playerCharacterObjects[LocalDatas.Instance.currentCharacterIndex]);
        LocalDatas.Instance.isInMainMenu = false;



        //for (int i = 0; i < characterPanelChildren.Length; i++)
        //{
        //    characterPanelChildren[i].SetActive(true);
        //}

    }

    public void CloseCharacterPanel()
    {
        //vfxButtonCanRotate = true;
        //RotateVFXButtonBack();

        LeanTween.alpha(characterPanel.GetComponent<RectTransform>(), 0f, time).setEase(LeanTweenType.pingPong);
        //LeanTween.alpha(characterPanelChild.GetComponent<RectTransform>(), 0f, time).setEase(LeanTweenType.pingPong);
        characterPanel.GetComponent<Image>().raycastTarget = false;
        characterPanelChild.SetActive(false);
        LocalDatas.Instance.Sed3dObjectParent(true);

        LocalDatas.Instance.isInMainMenu = true;

        //for (int i = 0; i < characterPanelChildren.Length; i++)
        //{
        //    characterPanelChildren[i].SetActive(false);
        //}
    }
    #endregion

    #region characterInsideMenu functions
    int WhenCharacterWillOpen(int characterIndex)
    {
        int res = 0;
        if (characterIndex > SomeDatas.Instance.lastIndexPerLevelInterval[0] && characterIndex <= SomeDatas.Instance.lastIndexPerLevelInterval[1])
        {
            // 6-10
            res = SomeDatas.Instance.levelIntervalForCharacters[0] + 1;
        }
        else if (characterIndex > SomeDatas.Instance.lastIndexPerLevelInterval[1] && characterIndex <= SomeDatas.Instance.lastIndexPerLevelInterval[2])
        {
            res = SomeDatas.Instance.levelIntervalForCharacters[1] + 1;
        }
        return res;

    }
    void SetCharacterSprintLevel(int _level)
    {
        for (int i = 0; i < sprintCharacterLevelImages.Length; i++)
        {
            if (i < _level)
            {
                sprintCharacterLevelImages[i].SetActive(true);
                //LocalDatas.Instance.Debug("\nLine 228\n");
            }
            else
            {
                sprintCharacterLevelImages[i].SetActive(false);
            }
        }
    }

    void SetCharacterDashLevel(int _level)
    {
        for (int i = 0; i < dashCharacterLevelImages.Length; i++)
        {
            if (i < _level)
            {
                dashCharacterLevelImages[i].SetActive(true);
                //LocalDatas.Instance.Debug("\nLine 228\n");
            }
            else
            {
                dashCharacterLevelImages[i].SetActive(false);
            }
        }
    }

    public void MakePlayerObjectDefaultRotation(GameObject _playerObject)
    {
        _playerObject.transform.localRotation = Quaternion.Euler(-14.193f, 321.689f, 1.747f);
    }

    public void BuyCharacter()
    {
        // If character must be bought
        if (LocalDatas.Instance.characters[openedCharacterIndex] == 0)
        {
            if (openedCharacterIndex >= 0)
            {
                if (LocalDatas.Instance.ssCoin >= SomeDatas.Instance.characterPrices[openedCharacterIndex])
                {
                    // Buying
                    // TODO save delay
                    //LocalDatas.Instance.AllButtonsOff();


                    LocalDatas.Instance.SetCharacterBuyButton(1);
                    LocalDatas.Instance.ssCoin -= SomeDatas.Instance.characterPrices[openedCharacterIndex];
                    LocalDatas.Instance.characters[openedCharacterIndex] = 1;
                    LocalDatas.Instance.ShowDatas();
                    lockPanels[openedCharacterIndex].GetComponent<Image>().color = Color.black;
                    LocalDatas.Instance.SetUICoins();
                    LocalDatas.Instance.SetCharactersLocks();
                    characterInsidePricePanel.SetActive(false);
                    FirebaseController.Instance.SaveData();
                    AudioManager.Instance.Play(2);
                }
                else // if we dont have enough money 
                {
                    ShowNotEnoughMoneyImage();
                }
            }
        }
        // Here, character must be selected
        else
        {
            AudioManager.Instance.Play(5);
            PlayerPrefs.SetInt(selectedCharacterIndex, openedCharacterIndex);
            LocalDatas.Instance.SetCharacterBuyButton(2);
            LocalDatas.Instance.currentCharacterIndex = openedCharacterIndex;
            LocalDatas.Instance.SetCharacterObject(openedCharacterIndex);
            characterNameInPlayPanel.text = SomeDatas.Instance.characterNames[openedCharacterIndex];

        }
    }

    public void OpenCharacterInsidePanel(int _openedCharacterIndex)
    {

        openedCharacterIndex = _openedCharacterIndex;

        characterInsidePanelLevelInfoTexts[0].text = SomeDatas.Instance.characterDSLevels[openedCharacterIndex, 0].ToString("0.00") + " secs";
        characterInsidePanelLevelInfoTexts[1].text = SomeDatas.Instance.characterDSLevels[openedCharacterIndex, 1].ToString("0.00") + " %";

        characterNameInCharacterInsidePanel.text = SomeDatas.Instance.characterNames[openedCharacterIndex];
        characterPriceText.text = "" + SomeDatas.Instance.characterPrices[openedCharacterIndex];
        LeanTween.alpha(characterInsideMenu.GetComponent<RectTransform>(), 1f, time).setEase(LeanTweenType.pingPong);
        characterInsideMenu.GetComponent<Image>().raycastTarget = true;
        characterInsideMenuChild.SetActive(true);
        //LocalDatas.Instance.DebugToUI("\n1013: " + LocalDatas.Instance.characters[_openedCharacterIndex]);
        SetCharacterSprintLevel(SomeDatas.Instance.characterSprintLevels[_openedCharacterIndex]);
        SetCharacterDashLevel(SomeDatas.Instance.characterDashLevels[_openedCharacterIndex]);
        if (LocalDatas.Instance.characters[_openedCharacterIndex] == 0)
        {
            // If we can buy character
            if (_openedCharacterIndex <= SomeDatas.Instance.lastIndexPerLevelInterval[LocalDatas.Instance.currentLevelIntervalIndexForCharacters])
            {
                LocalDatas.Instance.SetCharacterBuyButton(0);
                characterInfoText.gameObject.SetActive(false);
                characterInsidePricePanel.SetActive(true);
            }
            // If we cannot buy character
            else
            {
                LocalDatas.Instance.SetCharacterBuyButton(-1);
                //characterInsidePricePanel.SetActive(false);
                characterInfoText.text = "The character is not active. Required activation level - " + WhenCharacterWillOpen(_openedCharacterIndex);
                characterInfoText.gameObject.SetActive(true);
            }
        }
        else
        {
            characterInfoText.gameObject.SetActive(false);
            // IF it is already selected object
            if (openedCharacterIndex == LocalDatas.Instance.currentCharacterIndex)
            {
                LocalDatas.Instance.SetCharacterBuyButton(2);
            }
            else // If it is opened character, but not selected
            {
                LocalDatas.Instance.SetCharacterBuyButton(1);
            }
            characterInsidePricePanel.SetActive(false);
            // TODO button turn into select button
            //LocalDatas.Instance.selectButton.GetComponent<Image>().sprite = LocalDatas.Instance.selectButtonSprite;
        }
        //characterInsidePlayerObject.SetActive(true);
        playerCharacterObjects[openedCharacterIndex].SetActive(true);
        //playerCharacterObjectsParent.SetActive(true);
        LocalDatas.Instance.isInMainMenu = false;

        if (FirebaseController.Instance.prizeCharacterIndex != -1)
        {
            FirebaseController.Instance.SetOrangeIconsInCharactersPanel(-1);
            FirebaseController.Instance.SetNotificationIconsInMenu(-1);

        }
    }

    public void CloseCharacterInsidePanel()
    {
        playerCharacterObjects[openedCharacterIndex].SetActive(false);
        MakePlayerObjectDefaultRotation(playerCharacterObjects[openedCharacterIndex]);
        LeanTween.alpha(characterInsideMenu.GetComponent<RectTransform>(), 0f, time).setEase(LeanTweenType.pingPong);
        characterInsideMenu.GetComponent<Image>().raycastTarget = false;
        characterInsideMenuChild.SetActive(false);
        //characterInsidePlayerObject.SetActive(false);
        LocalDatas.Instance.isInMainMenu = false;

    }

    #endregion

    #region Options functions


    public void MusicOnOff()
    {
        if (LocalDatas.Instance.musicOn == 0) // if music is off, we turn on it
        {
            // TODO music on
            LocalDatas.Instance.musicOn = 1;
            PlayerPrefs.SetInt(savedMusicVolume, 1);

            AudioManager.Instance.Play(0);
            SetMusicOnOffButtonOptions(true);

        }
        else // if music is on, we turn off it
        {
            // TODO music off
            LocalDatas.Instance.musicOn = 0;
            PlayerPrefs.SetInt(savedMusicVolume, 0);
            AudioManager.Instance.Stop(0);
            SetMusicOnOffButtonOptions(false);

        }
    }
    public void SetMusicOnOffButtonOptions(bool isOn)
    {
        if (isOn)
        {
            musicOnOffText.text = "On";
            musicOnOffButton.GetComponent<Image>().sprite = isOnButton;
        }
        else
        {
            musicOnOffText.text = "Off";
            musicOnOffButton.GetComponent<Image>().sprite = isOffButton;
        }
    }

    public void SetSoundOnOffButtonOptions(bool isOn)
    {
        if (isOn)
        {
            soundOnOffText.text = "On";
            soundOnOffButton.GetComponent<Image>().sprite = isOnButton;
        }
        else
        {
            soundOnOffText.text = "Off";
            soundOnOffButton.GetComponent<Image>().sprite = isOffButton;
        }
    }


    public void SoundOnOff()
    {
        if (LocalDatas.Instance.soundOn == 0) // if sound is off, we turn on it
        {
            SetSoundOnOffButtonOptions(true);
            LocalDatas.Instance.soundOn = 1;
            PlayerPrefs.SetInt(savedSoundVolume, 1);
        }
        else // if sound is on, we turn off it
        {
            SetSoundOnOffButtonOptions(false);
            LocalDatas.Instance.soundOn = 0;
            PlayerPrefs.SetInt(savedSoundVolume, 0);

        }
    }

    public void OpenHelpSupport()
    {
        Application.OpenURL(helpSupportURL);
    }

    public void OpenPrivacy()
    {
        Application.OpenURL(privacyURL);
    }

    public void OpenOptionsPanel()
    {
        LeanTween.alpha(optionsPanel.GetComponent<RectTransform>(), 1f, time).setEase(LeanTweenType.pingPong);
        optionsPanel.GetComponent<Image>().raycastTarget = true;
        optionsPanelChild.SetActive(true);
        LocalDatas.Instance.Sed3dObjectParent(false);
        MakePlayerObjectDefaultRotation(LocalDatas.Instance.playerCharacterObjects[LocalDatas.Instance.currentCharacterIndex]);
        LocalDatas.Instance.isInMainMenu = false;
    }

    public void CloseOptionsPanel()
    {
        //RotateVFXButtonBack();

        LeanTween.alpha(optionsPanel.GetComponent<RectTransform>(), 0f, time).setEase(LeanTweenType.pingPong);
        optionsPanel.GetComponent<Image>().raycastTarget = false;
        optionsPanelChild.SetActive(false);
        LocalDatas.Instance.Sed3dObjectParent(true);
        LocalDatas.Instance.isInMainMenu = true;

    }
    #endregion

    #region Arena functions

    public void CloseRUSUreArenaPanel()
    {
        ruSureArenaPanel.SetActive(false);
    }

    public void ArenaButtonPressed(int mapIndex)
    {
        pressedArenaIndex = mapIndex;
        if (LocalDatas.Instance.arenas[mapIndex] == 0) // we havent bought it, ruSure to buy opens
        {
            // rusure achilir
            ruSureArenaPanel.GetComponent<Image>().color = transparentColor;
            ruSureArenaImage.GetComponent<Image>().sprite = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;
            ruSureArenaQuestionText.text = "Are you sure to pay " + SomeDatas.Instance.arenaPrices[mapIndex] + " star coins ?";
            ruSureArenaPriceText.text = SomeDatas.Instance.arenaPrices[mapIndex].ToString();
            ruSureArenaPanel.SetActive(true);
        }
        else // we are selecting arena
        {
            LocalDatas.Instance.currentMapIndex = (byte)mapIndex;
            PlayerPrefs.SetInt(mapIndexPlayerPrefs, mapIndex);
            arenaButtonInMainMenu.GetComponent<Image>().sprite = arenaButtonSprites[mapIndex];
            for (int i = 0; i < FirebaseController.Instance.selectTextsInArenaButtons.Length; i++)
            {
                if (LocalDatas.Instance.arenas[mapIndex] != 0)
                {
                    if (i == mapIndex)
                    {
                        FirebaseController.Instance.selectTextsInArenaButtons[i].text = "Selected";
                    }
                    else
                    {
                        FirebaseController.Instance.selectTextsInArenaButtons[i].text = "Select";
                    }
                }
            }
            // Arena button changes to arena color

        }
    }

    public void SetArenaButton()
    {
        arenaButtonInMainMenu.GetComponent<Image>().sprite = arenaButtonSprites[PlayerPrefs.GetInt(mapIndexPlayerPrefs)];
    }
    public void BuyArena()
    {
        if (LocalDatas.Instance.crystalCoin >= SomeDatas.Instance.arenaPrices[pressedArenaIndex])
        {
            // Buying
            AudioManager.Instance.Play(1);
            LocalDatas.Instance.crystalCoin -= SomeDatas.Instance.arenaPrices[pressedArenaIndex];
            LocalDatas.Instance.arenas[pressedArenaIndex] = 1;
            FirebaseController.Instance.SaveData();
            ruSureArenaPanel.SetActive(false);
        }
        else
        {
            ShowNotEnoughMoneyImage();
        }

    }


    public void OpenArenaPanel()
    {
        //vfxButtonCanRotate = false;

        LeanTween.alpha(arenaPanel.GetComponent<RectTransform>(), 1f, time).setEase(LeanTweenType.pingPong);
        arenaPanel.GetComponent<Image>().raycastTarget = true;
        arenaPanelChild.SetActive(true);
        LocalDatas.Instance.Sed3dObjectParent(false);
        MakePlayerObjectDefaultRotation(LocalDatas.Instance.playerCharacterObjects[LocalDatas.Instance.currentCharacterIndex]);
        LocalDatas.Instance.isInMainMenu = false;


        //for (int i = 0; i < optionsPanelChildren.Length; i++)
        //{
        //}

    }

    public void CloseArenaPanel()
    {
        //vfxButtonCanRotate = true;
        //RotateVFXButtonBack();

        LeanTween.alpha(arenaPanel.GetComponent<RectTransform>(), 0f, time).setEase(LeanTweenType.pingPong);
        arenaPanel.GetComponent<Image>().raycastTarget = false;
        arenaPanelChild.SetActive(false);
        LocalDatas.Instance.Sed3dObjectParent(true);
        LocalDatas.Instance.isInMainMenu = true;


        //for (int i = 0; i < optionsPanelChildren.Length; i++)
        //{
        //    optionsPanelChildren[i].SetActive(false);
        //}
    }

    #endregion

    #region Change PP functions


    public void PPSubmitted()
    {
        if (selectedPPImage >= 0)
        {
            //TODO neyese gore 9 sechdi ?!
            PlayerPrefs.SetInt(profilePicIndex, selectedPPImage);
            LocalDatas.Instance.ChangeAllPPs(selectedPPImage);
        }
    }

    int tempPPIndex = 0;
    public void OnPPScrollChanged()
    {

        if (changePPScrollContent.GetComponent<RectTransform>().anchoredPosition.x >= 470f)
        {
            selectedPPImage = 0;
            MiddlePImage.GetComponent<Image>().sprite = PPImages[0].GetComponent<Image>().sprite;
        }
        else if (changePPScrollContent.GetComponent<RectTransform>().anchoredPosition.x >= 340f)
        {
            selectedPPImage = 1;

            MiddlePImage.GetComponent<Image>().sprite = PPImages[1].GetComponent<Image>().sprite;
        }
        else if (changePPScrollContent.GetComponent<RectTransform>().anchoredPosition.x >= 211f)
        {
            selectedPPImage = 2;
            MiddlePImage.GetComponent<Image>().sprite = PPImages[2].GetComponent<Image>().sprite;
        }
        else if (changePPScrollContent.GetComponent<RectTransform>().anchoredPosition.x >= 73f)
        {
            selectedPPImage = 3;
            MiddlePImage.GetComponent<Image>().sprite = PPImages[3].GetComponent<Image>().sprite;
        }
        else if (changePPScrollContent.GetComponent<RectTransform>().anchoredPosition.x >= -55f)
        {
            selectedPPImage = 4;
            MiddlePImage.GetComponent<Image>().sprite = PPImages[4].GetComponent<Image>().sprite;
        }
        else if (changePPScrollContent.GetComponent<RectTransform>().anchoredPosition.x >= -187f)
        {
            selectedPPImage = 5;
            MiddlePImage.GetComponent<Image>().sprite = PPImages[5].GetComponent<Image>().sprite;
        }
        else if (changePPScrollContent.GetComponent<RectTransform>().anchoredPosition.x >= -320f)
        {
            selectedPPImage = 6;
            MiddlePImage.GetComponent<Image>().sprite = PPImages[6].GetComponent<Image>().sprite;
        }
        else if (changePPScrollContent.GetComponent<RectTransform>().anchoredPosition.x >= -451f)
        {
            selectedPPImage = 7;
            MiddlePImage.GetComponent<Image>().sprite = PPImages[7].GetComponent<Image>().sprite;
        }
        else
        {
            selectedPPImage = 8;
            MiddlePImage.GetComponent<Image>().sprite = PPImages[8].GetComponent<Image>().sprite;
        }

        if (tempPPIndex != selectedPPImage)
        {
            // Play sound
            AudioManager.Instance.Play(25);
            tempPPIndex = selectedPPImage;
        }

    }

    public void OpenChangePPPanel()
    {
        changePPScrollContent.GetComponent<RectTransform>().anchoredPosition = new Vector2(1390f, changePPScrollContent.GetComponent<RectTransform>().anchoredPosition.y);
        LeanTween.alpha(ChangePPPanel.GetComponent<RectTransform>(), 1f, time).setEase(LeanTweenType.pingPong);
        ChangePPPanel.GetComponent<Image>().raycastTarget = true;
        LeanTween.alpha(MiddleImage.GetComponent<RectTransform>(), 0.5f, 0.1f).setEase(LeanTweenType.pingPong);
        LeanTween.alpha(scrollBackgroundImage.GetComponent<RectTransform>(), 0.5f, 0.1f).setEase(LeanTweenType.pingPong);
        for (int i = 0; i < PPImages.Length; i++)
        {
            LeanTween.alpha(PPImages[i].GetComponent<RectTransform>(), 1f, 0.1f).setEase(LeanTweenType.pingPong);
        }
        ChangePPPanelChild.SetActive(true);
        LocalDatas.Instance.isInMainMenu = false;
    }

    public void CloseChangePPPanel()
    {
        LeanTween.alpha(ChangePPPanel.GetComponent<RectTransform>(), 0f, time).setEase(LeanTweenType.pingPong);
        ChangePPPanel.GetComponent<Image>().raycastTarget = false;
        ChangePPPanelChild.SetActive(false);
        LocalDatas.Instance.isInMainMenu = false;

        //playerObject.SetActive(true);
        //for (int i = 0; i < optionsPanelChildren.Length; i++)
        //{
        //    optionsPanelChildren[i].SetActive(false);
        //}
    }

    #endregion

    #region PlayPanel functions

    public void RunnerPlaySkillPressed()
    {

        runnerPanel.SetActive(true);
        catcherPanel.SetActive(false);
        runnerPlayButton.GetComponent<Image>().sprite = selectedSprite;
        catcherPlayButton.GetComponent<Image>().sprite = notSelectedSprite;
    }

    public void CatcherPlaySkillPressed()
    {
        catcherPanel.SetActive(true);
        runnerPanel.SetActive(false);
        runnerPlayButton.GetComponent<Image>().sprite = notSelectedSprite;
        catcherPlayButton.GetComponent<Image>().sprite = selectedSprite;
    }


    public void SetRunnerSkill(int rSkillIndex)
    {
        LocalDatas.Instance.selectedRunnerSkillImage.GetComponent<Image>().sprite = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;
        LocalDatas.Instance.currentRunnerSkill = rSkillIndex;
        LocalDatas.Instance.runnerSkillNameText.text = EventSystem.current.currentSelectedGameObject.name;
        PlayerPrefs.SetInt(currentSavedRunnerSkill, rSkillIndex);
        //rSkillDebugText.text = "Runner skill index: " + LocalDatas.Instance.currentRunnerSkill;
    }

    public void SetCatcherSkill(int cSkillIndex)
    {
        LocalDatas.Instance.selectedCatcherSkillImage.GetComponent<Image>().sprite = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;
        LocalDatas.Instance.currentCatcherSkill = cSkillIndex;
        LocalDatas.Instance.catcherSkillNameText.text = EventSystem.current.currentSelectedGameObject.name;
        PlayerPrefs.SetInt(currentSavedCatcherSkill, cSkillIndex);
        //cSkillDebugText.text = "Catcher skill index: " + LocalDatas.Instance.currentCatcherSkill;
    }

    //public void SetBallSkin(int ballSkin)
    //{
    //    LocalDatas.Instance.currentBallSkinIndex= ballSkin;
    //    //ballSkinDebugText.text = "BallSkin index: " + ballSkin;
    //}

    public void OpenPlayPanel()
    {
        //vfxButtonCanRotate = false;
        LocalDatas.Instance.canRotateObject = false;
        playerObjectParentInMainMenu.GetComponent<RectTransform>().anchoredPosition = playerObjectParentPositionInPlayPanel.anchoredPosition;
        LeanTween.alpha(PlayPanel.GetComponent<RectTransform>(), 1f, time).setEase(LeanTweenType.pingPong);
        PlayPanel.GetComponent<Image>().raycastTarget = true;
        PlayPanelChild.SetActive(true);
        //playerMainMenuObjects[LocalDatas.Instance.currentCharacterIndex].SetActive(false);
        MakePlayerObjectDefaultRotation(LocalDatas.Instance.playerCharacterObjects[LocalDatas.Instance.currentCharacterIndex]);
        LocalDatas.Instance.isInMainMenu = false;


    }

    public void ClosePlayPanel()
    {
        LocalDatas.Instance.canRotateObject = true;

        //vfxButtonCanRotate = true;
        //RotateVFXButtonBack();

        playerObjectParentInMainMenu.GetComponent<RectTransform>().anchoredPosition = playerObjectParentPositionInMainMenu;
        LeanTween.alpha(PlayPanel.GetComponent<RectTransform>(), 0f, time).setEase(LeanTweenType.pingPong);
        PlayPanel.GetComponent<Image>().raycastTarget = false;
        PlayPanelChild.SetActive(false);
        MakePlayerObjectDefaultRotation(LocalDatas.Instance.playerCharacterObjects[LocalDatas.Instance.currentCharacterIndex]);
        LocalDatas.Instance.isInMainMenu = true;
        RunnerPlaySkillPressed();
        //playerMainMenuObjects[LocalDatas.Instance.currentCharacterIndex].SetActive(true);


    }

    #endregion

    #region VFX functions

    public void SetVFXSelectOrBuyButton(int b) // 0 buy, 1 select, 2 selected
    {
        if (b == 0) // BUY
        {
            buyOrSelectVFXButton.GetComponent<Image>().sprite = buyButtonSprite;
            buyOrSelectVFXText.text = "Buy";
        }
        else if (b == 1) // SELECT
        {
            buyOrSelectVFXButton.GetComponent<Image>().sprite = selectButtonSprite;
            buyOrSelectVFXText.text = "Select";

        }
        else // SELECTED
        {
            buyOrSelectVFXButton.GetComponent<Image>().sprite = selectedButtonSprite;
            buyOrSelectVFXText.text = "Selected";

        }
    }

    public void BuyOrSelectVFX()
    {
        if (LocalDatas.Instance.ballSkins[pressedBallBUttonIndex] == 0)
        {
            // Buying
            if (LocalDatas.Instance.ssCoin >= SomeDatas.Instance.ballPrices[pressedBallBUttonIndex])
            {
                // If we have money to buy
                // TODO buying
                AudioManager.Instance.Play(2);
                SetVFXSelectOrBuyButton(1); // set button from buy, to select
                rightVFXText.gameObject.SetActive(false);
                LocalDatas.Instance.ssCoin -= SomeDatas.Instance.ballPrices[pressedBallBUttonIndex];
                LocalDatas.Instance.ballSkins[pressedBallBUttonIndex] = 1;
                LocalDatas.Instance.SetUICoins();
                LocalDatas.Instance.vfxPriceTextPanels[pressedBallBUttonIndex].SetActive(false);
                FirebaseController.Instance.SaveData();
            }
            else
            {
                // not enough money
                ShowNotEnoughMoneyImage();
            }
        }
        else
        {
            //Selecting
            PlayerPrefs.SetInt(vfxIndex, pressedBallBUttonIndex);
            SetVFXSelectOrBuyButton(2); //  from select, to selected
            LocalDatas.Instance.currentBallSkinIndex = pressedBallBUttonIndex;
            for (int i = 0; i < SomeDatas.Instance.ballPrices.Length; i++)
            {
                if (LocalDatas.Instance.ballSkins[i] == 1)
                {
                    if (i == pressedBallBUttonIndex)
                    {
                        LocalDatas.Instance.vfxSelectSelectedTexts[i].text = "Selected";
                    }
                    else
                    {
                        LocalDatas.Instance.vfxSelectSelectedTexts[i].text = "Select";
                    }
                }

            }
            AudioManager.Instance.Play(5);

        }



    }



    public void SelectParticleBall(int ballIndex)
    {
        pressedBallBUttonIndex = ballIndex;
        rightVFXImage.sprite = vfxButtonsImages[ballIndex].GetComponent<Image>().sprite;
        if (LocalDatas.Instance.ballSkins[ballIndex] == 0) // buy chixmalidir
        {
            // if we can buy it
            //if (LocalDatas.Instance.level >= WhenVFXWillOpen(ballIndex))
            if (ballIndex <= SomeDatas.Instance.lastIndexPerLevelIntervalVFX[LocalDatas.Instance.currentLevelIntervalIndexForVFX])
            {

                // Buy button
                buyOrSelectVFXButton.SetActive(true);
                vfxInfoText.gameObject.SetActive(false);
                rightVFXText.gameObject.SetActive(true);
                rightVFXText.text = SomeDatas.Instance.ballPrices[ballIndex].ToString("n0");
                SetVFXSelectOrBuyButton(0);
            }
            // if we cannot buy it
            else
            {
                buyOrSelectVFXButton.SetActive(false);
                vfxInfoText.gameObject.SetActive(true);
                vfxInfoText.text = "Particle is not active. Required activation level - " + WhenVFXWillOpen(ballIndex);
                rightVFXText.gameObject.SetActive(true);
                rightVFXText.text = SomeDatas.Instance.ballPrices[ballIndex].ToString("n0");

            }

        }   
        else // select chixmalidir
        {
            // Select button
            rightVFXText.gameObject.SetActive(false);
            buyOrSelectVFXButton.SetActive(true);
            vfxInfoText.gameObject.SetActive(false);
            //vfxSelectSelectedText[ballIndex].gameObject.SetActive(true);
            if (LocalDatas.Instance.currentBallSkinIndex == ballIndex) // if it is selected vfx
            {
                SetVFXSelectOrBuyButton(2);

            }
            else // if it is not selected yet
            {
                SetVFXSelectOrBuyButton(1);
            }

        }


        if (hasntTouchedVfxButton == true)
        {
            if (FirebaseController.Instance.prizeVFXIndex != -1)
            {
                FirebaseController.Instance.SetOrangeIconsInVFXPanel(-1);
                FirebaseController.Instance.SetNotificationIconsInMenu(-1);
            }

        }

    }

    int WhenVFXWillOpen(int vfxIndex)
    {
        int res = 0;
        if ( vfxIndex > SomeDatas.Instance.lastIndexPerLevelIntervalVFX[0] && vfxIndex <= SomeDatas.Instance.lastIndexPerLevelIntervalVFX[1]) 
        {
            // 6-10
            res = SomeDatas.Instance.levelIntervalForVFX[0] + 1;
        }
        else if (vfxIndex > SomeDatas.Instance.lastIndexPerLevelIntervalVFX[1] && vfxIndex <= SomeDatas.Instance.lastIndexPerLevelIntervalVFX[2])
        {
            res = SomeDatas.Instance.levelIntervalForVFX[1] + 1;
        }
        return res;
    
    }
    public void OpenVFXPanel()
    {
        //vfxButtonCanRotate = false;
        SelectParticleBall(LocalDatas.Instance.currentBallSkinIndex);
        hasntTouchedVfxButton = true;
        chooseBallPanelChild.SetActive(true);
        LeanTween.alpha(chooseBallPanelChild.GetComponent<RectTransform>(), 1f, time).setEase(LeanTweenType.pingPong).setOnComplete(SetVFXLockPanelHalfTransparent);
        chooseBallPanel.GetComponent<Image>().color = halfTransparentColor;
        //LeanTween.alpha(chooseBallPanelChild.GetComponent<RectTransform>(), 1f, 0.01f).setEase(LeanTweenType.pingPong);
        chooseBallPanel.GetComponent<Image>().raycastTarget = true;
        MakePlayerObjectDefaultRotation(LocalDatas.Instance.playerCharacterObjects[LocalDatas.Instance.currentCharacterIndex]);
        //LocalDatas.Instance.playerCharacterObjects[LocalDatas.Instance.currentCharacterIndex].SetActive(false);
        LocalDatas.Instance.Sed3dObjectParent(false);

    }

    void SetVFXLockPanelHalfTransparent()
    {
        for (int i = 0; i < SomeDatas.Instance.ballPrices.Length; i++)
        {
            if (LocalDatas.Instance.lockPanelsInVFX[i].activeInHierarchy)
            {
                LeanTween.alpha(LocalDatas.Instance.lockPanelsInVFX[i].GetComponent<RectTransform>(), 0.5f, 0.2f).setEase(LeanTweenType.pingPong);
            }
            else
            {
                //LeanTween.alpha(LocalDatas.Instance.lockPanelsInVFX[i].GetComponent<RectTransform>(), 0f, 0.2f).setEase(LeanTweenType.pingPong);
                LocalDatas.Instance.lockPanelsInVFX[i].GetComponent<Image>().color = new Color(0, 0, 0, 0.5f);
            }

        }
    }

    public void CloseVFXPanel()
    {
        hasntTouchedVfxButton = false;
       // vfxButtonCanRotate = true;
        //RotateVFXButtonBack();
        LeanTween.alpha(chooseBallPanelChild.GetComponent<RectTransform>(), 0f, time).setEase(LeanTweenType.pingPong);
        chooseBallPanelChild.SetActive(false);
        chooseBallPanel.GetComponent<Image>().raycastTarget = false;
        chooseBallPanel.GetComponent<Image>().color = transparentColor;
        LocalDatas.Instance.Sed3dObjectParent(true);


    }



    #endregion

    #region Update Funcrtions

    public void GoToSSPlayStore()
    { 
        Application.OpenURL(sevenStonesPlayStoreURL);
    }

    public void OpenUpdatePanel()
    {
        UpdatePanel.SetActive(true);
    }

    public void CloseUpdatePanel()
    {
        UpdatePanel.SetActive(false);
    }



    #endregion


    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (ChangePPPanelChild.activeInHierarchy)
            {
                CloseChangePPPanel();
            }
            else if (playerProfilePanelChild.activeInHierarchy)
            {
                ClosePlayerProfilePanel();
            }
            else if (optionsPanelChild.activeInHierarchy)
            {
                CloseOptionsPanel();
            }
            else if (shopPanelChild.activeInHierarchy)
            {
                CloseShopPanel();
            }
            else if (skillsPanelChild.activeInHierarchy)
            {
                CloseSkillsPanel();
            }
            else if (arenaPanelChild.activeInHierarchy)
            {
                CloseArenaPanel();
            }
            else if (characterInsideMenuChild.activeInHierarchy)
            {
                CloseCharacterInsidePanel();
            }
            else if (characterPanelChild.activeInHierarchy)
            {
                CloseCharacterPanel();
            }
            else if (PlayPanelChild.activeInHierarchy)
            {
                ClosePlayPanel();
            }

            AudioManager.Instance.Play(6);
        }
    }



}