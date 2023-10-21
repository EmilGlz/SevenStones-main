using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class LocalDatas : MonoBehaviour
{
    [HideInInspector] public string datas;
    [HideInInspector] public string[] datasArray;
    public Text debugtext;

    public int[] runnerSkillsLevels;

    public int[] catcherSkillsLevels;

    [Header("Others")]

    public int currentRunnerSkill;
    public int currentCatcherSkill;


    public int currentCharacterIndex = 0;
    public int currentBallSkinIndex = 0;
    public byte currentMapIndex = 0;

    public int soundOn;
    public int musicOn;

    [SerializeField] GameObject[] profilePics;
    [SerializeField] Sprite[] profilePicSprites;

    const string currentSavedRunnerSkill = "rs";
    const string currentSavedCatcherSkill = "cs";
    const string savedMusicVolume = "mv";
    const string savedSoundVolume = "sv";



    public int currentLevelIntervalIndex = 0;
    public int currentLevelIntervalIndexForCharacters = 0;
    public int currentLevelIntervalIndexForVFX = 0;

    public int currentVersion = 0;

    #region UI texts

    [SerializeField] TMP_Text[] nickNameTexts;
    [SerializeField] TMP_Text[] levelTexts;
    [SerializeField] TMP_Text[] xpTexts;
    [SerializeField] TMP_Text[] ssCoinText;
    [SerializeField] TMP_Text[] crystalCoinText;

    [SerializeField] TMP_Text generalWinText;
    [SerializeField] TMP_Text generalLoseText;
    [SerializeField] TMP_Text generalMVPCountText;
    [SerializeField] TMP_Text generalStoneText;
    [SerializeField] TMP_Text generalKillText;
    [SerializeField] TMP_Text generalAccuracyText;
    [SerializeField] TMP_Text generalEnduranceText;

    [SerializeField] TMP_Text[] characterPriceTexts;

    #endregion

    public GameObject[] lockPanelsInVFX;

    [SerializeField] Sprite buyButtonSprite;
    [SerializeField] Sprite selectButtonSprite;
    [SerializeField] Sprite selectedButtonSprite;

    public GameObject selectButton;
    [SerializeField] TMP_Text buyOrSelectText;

    [SerializeField] Slider[] xpSliders;

    [SerializeField] GameObject[] buttonsThatSave;

    public GameObject[] playerCharacterObjects;

    public GameObject playerCharacterObjectsParent;

    public GameObject[] vfxPriceTextPanels;
    public TMP_Text[] vfxPriceTexts;
    public TMP_Text[] vfxSelectSelectedTexts;

    public GameObject[] playPanelRunnerSkillButtons;
    public GameObject[] playPanelCatcherSkillButtons;


    public bool isInMainMenu = true;
    public bool canRotateObject = true;

    [SerializeField] TMP_Text[] characterNamesInCharacterPanel;


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


    public GameObject selectedRunnerSkillImage;
    public GameObject selectedCatcherSkillImage;

    public TMP_Text runnerSkillNameText;
    public TMP_Text catcherSkillNameText;

    [SerializeField] TMP_Text[] ssCoinPricesTexts;
    [SerializeField] TMP_Text[] ssCoinValuesTexts;

    Color tmp;

    public int changeNickPrice;

    #region Singleton

    private static LocalDatas instance;

    public static LocalDatas Instance { get => instance; }

    private void Awake()
    {
        instance = this;
    }

    #endregion

    private void Start()
    {
        canRotateObject = true;
        Settings.User = SaveLoadManager.Load();
        if (Settings.User == null)
        {
            Settings.User = Settings.ResettedUser();
            SaveLoadManager.Save(Settings.User);
        }
        MenuUIController.Instance.SetToUI();
    }

    public void SetLoadingPanelWithTweening()
    {
        MenuCommonObjects.Instance.loadingSliderImage.SetActive(false);
        LeanTween.value(gameObject, 1f, 0f, 0.5f)
            .setOnUpdate((float vol) =>
            {
                tmp.a = vol;
                MenuCommonObjects.Instance.loadingPanel.GetComponent<Image>().color = tmp;
            }).setOnComplete(() =>
            {
                MenuCommonObjects.Instance.loadingPanel.SetActive(false);
            });
    }

    public IEnumerator SetSkillButtonsPlayPanelRunner()
    {
        int s = 0;
        int firstSkillIndex = 0;
        currentRunnerSkill = PlayerPrefs.GetInt(currentSavedRunnerSkill);
        for (int i = 0; i < runnerSkillsLevels.Length; i++)
        {
            if (runnerSkillsLevels[i] == 0) // if it is closed
            {
                playPanelRunnerSkillButtons[i].SetActive(false);
            }
            else // if it is opened
            {
                playPanelRunnerSkillButtons[i].SetActive(true);
                s++;
                if (s == 1)
                {
                    firstSkillIndex = i;
                    Debug.Log("First Runner Skill Index: " + firstSkillIndex);
                }
            }
            yield return null;
        }

        // if current is 0, but our oth skill is not opened
        if (runnerSkillsLevels[currentRunnerSkill] == 0)
        {
            currentRunnerSkill = firstSkillIndex;
            PlayerPrefs.SetInt(currentSavedRunnerSkill, currentRunnerSkill);
        }

        if (s == 0)
        {
            selectedRunnerSkillImage.SetActive(false);
        }
        else
        {
            selectedRunnerSkillImage.GetComponent<Image>().sprite = playPanelRunnerSkillButtons[currentRunnerSkill].GetComponent<Image>().sprite;
            runnerSkillNameText.text = playPanelRunnerSkillButtons[currentRunnerSkill].name;
            selectedRunnerSkillImage.SetActive(true);
        }

    }

    public IEnumerator SetSkillButtonsPlayPanelCatcher()
    {
        int s = 0;
        int firstSkillIndex = 0;
        catcherSkillsLevels[1] = 0;

        currentCatcherSkill = PlayerPrefs.GetInt(currentSavedCatcherSkill);
        for (int i = 0; i < catcherSkillsLevels.Length; i++)
        {
            if (catcherSkillsLevels[i] == 0)
            {
                playPanelCatcherSkillButtons[i].SetActive(false);
            }
            else
            {
                playPanelCatcherSkillButtons[i].SetActive(true);
                s++;
                if (s == 1)
                {
                    firstSkillIndex = i;
                }
            }
            yield return null;
        }
        // if current is 0, but our oth skill is not opened
        if (catcherSkillsLevels[currentCatcherSkill] == 0)
        {
            currentCatcherSkill = firstSkillIndex;
            PlayerPrefs.SetInt(currentSavedCatcherSkill, currentCatcherSkill);
        }



        if (s == 0)
        {
            selectedCatcherSkillImage.SetActive(false);
        }
        else
        {
            selectedCatcherSkillImage.GetComponent<Image>().sprite = playPanelCatcherSkillButtons[currentCatcherSkill].GetComponent<Image>().sprite;
            catcherSkillNameText.text = playPanelCatcherSkillButtons[currentCatcherSkill].name;
            selectedCatcherSkillImage.SetActive(true);
        }

    }

    public void SetSkillLevelsToArray()
    {
        runnerSkillsLevels[0] = Settings.User.rs.rSpeedLevel;
        runnerSkillsLevels[1] = Settings.User.rs.rAddHealth;
        runnerSkillsLevels[2] = Settings.User.rs.rShieldLevel;
        runnerSkillsLevels[3] = Settings.User.rs.rTrapLevel;
        runnerSkillsLevels[4] = Settings.User.rs.rInvisibilityLevel;
        runnerSkillsLevels[5] = Settings.User.rs.rSDTLevel;
        runnerSkillsLevels[6] = Settings.User.rs.rTopViewLevel;
        runnerSkillsLevels[7] = Settings.User.rs.rWallLevel;
        runnerSkillsLevels[8] = Settings.User.rs.rHookLevel;
        runnerSkillsLevels[9] = Settings.User.rs.rBCLevel;

        catcherSkillsLevels[0] = Settings.User.cs.cSpeedLevel;
        catcherSkillsLevels[1] = Settings.User.cs.cShieldLevel;
        catcherSkillsLevels[2] = Settings.User.cs.cInvisibilityLevel;
        catcherSkillsLevels[3] = Settings.User.cs.cBallLevel;
        catcherSkillsLevels[4] = Settings.User.cs.cSDTlevel;
        catcherSkillsLevels[5] = Settings.User.cs.cTopViewLevel;
        catcherSkillsLevels[6] = Settings.User.cs.cWallLevel;
        catcherSkillsLevels[7] = Settings.User.cs.cHookLevel;
        catcherSkillsLevels[8] = Settings.User.cs.cDHLevel;
        catcherSkillsLevels[9] = Settings.User.cs.cBCLevel;

    }

    public void SetCharacterBuyButton(int b)
    {
        if (b == 0) // BUY
        {
            selectButton.GetComponent<Image>().sprite = buyButtonSprite;
            buyOrSelectText.text = "Buy";
            selectButton.SetActive(true);
        }
        else if (b == 1) // SELECT
        {
            selectButton.GetComponent<Image>().sprite = selectButtonSprite;
            buyOrSelectText.text = "Select";
            selectButton.SetActive(true);
        }
        else if (b == 2) // SELECTED
        {
            selectButton.GetComponent<Image>().sprite = selectedButtonSprite;
            buyOrSelectText.text = "Selected";
            selectButton.SetActive(true);
        }
        else if (b == -1)
        {
            selectButton.SetActive(false);
        }
    }
    public void ChangeAllPPs(int ppIndex)
    {
        Debug.Log("PP Index: " + ppIndex);
        // Prozapas
        if (ppIndex >= profilePicSprites.Length)
        {
            ppIndex = 0;
        }

        for (int i = 0; i < profilePics.Length; i++)
        {
            profilePics[i].GetComponent<Image>().sprite = profilePicSprites[ppIndex];
        }
    }

    public void SetUICoins()
    {
        for (int i = 0; i < ssCoinText.Length; i++)
        {
            ssCoinText[i].text = "" + Settings.User.ssCoin.ToString("n0");
            crystalCoinText[i].text = "" + Settings.User.starCoin.ToString("n0");

        }
    }

    public void SaveToCloudLocalDatas()
    {
        //string[] tempDatas = new string[11];
        //tempDatas[0] = nickName;
        //tempDatas[1] = "" + level;
        //tempDatas[2] = "" + xp;
        //tempDatas[3] = "" + ssCoin;
        //tempDatas[4] = "" + crystalCoin;

        //tempDatas[5] = "" + generalWin + "," + generalLose + "," + generalMVPCount + "," + generalStone + "," + generalKill + "," + generalShot + "," + generalEndurance + ",";
        //tempDatas[6] = "" + runnerSpeedLevel + "," + runnerShieldLevel + "," + runnerInvisibilityLevel + "," + runnerAddHealth + "," + runnerTrapLevel + ",";
        //tempDatas[7] = "" + catcherSpeedLevel + "," + catcherShieldLevel + "," + catcherInvisibilityLevel + "," + catcherBallLevel + ",";

        //for (int i = 0; i < characters.Length; i++)
        //{
        //    tempDatas[8] += "" + characters[i];
        //}

        //for (int i = 0; i < ballSkins.Length; i++)
        //{
        //    tempDatas[9] += "" + ballSkins[i];
        //}

        //tempDatas[10] = "0000";
        ////Debug("\n");
        //for (int i = 0; i < tempDatas.Length; i++)
        //{
        //    //Debug("Tempdatas: " + tempDatas[i]);
        //}
        ////Debug("\n");

        //datasArray = tempDatas;
        //DebugToUI("\nTempdatas:");
        //for (int i = 0; i < tempDatas.Length; i++)
        //{
        //    DebugToUI("_" + tempDatas[i] + "_");
        //}
        //DebugToUI("\n");
        //pgs.EditSaveVariables(tempDatas);
        //pgs.OpenSaveToCloud(true);
        //fc.SaveData();

    }

    public int SetLevelIntervalIndex()
    {
        int res;
        if (Settings.User.level < 5) // 0-5
        {
            res = 0;
        }
        else if (Settings.User.level < 10) // 5-10
        {
            res = 1;
        }
        else if (Settings.User.level < 15) // 10-15
        {
            res = 2;
        }
        else if (Settings.User.level < 20) // 15-20
        {
            res = 3;
        }
        else // 20+
        {
            res = 4;
        }
        currentLevelIntervalIndex = res;
        return res;
    }

    public void SetLevelIntervalIndexForCharacter()
    {
        if (Settings.User.level <= SomeDatas.Instance.levelIntervalForCharacters[0])
        {
            currentLevelIntervalIndexForCharacters = 0;
        }
        else if (Settings.User.level >= SomeDatas.Instance.levelIntervalForCharacters[0] && Settings.User.level <= SomeDatas.Instance.levelIntervalForCharacters[1])
        {
            currentLevelIntervalIndexForCharacters = 1;
        }
        else
        {
            currentLevelIntervalIndexForCharacters = 2;

        }

    }

    public void SetLevelIntervalIndexForVFX()
    {
        if (Settings.User.level < SomeDatas.Instance.levelIntervalForVFX[0])
        {
            currentLevelIntervalIndexForVFX = 0;
        }
        else if (Settings.User.level >= SomeDatas.Instance.levelIntervalForVFX[0] && Settings.User.level <= SomeDatas.Instance.levelIntervalForVFX[1])
        {
            currentLevelIntervalIndexForVFX = 1;
        }
        else
        {
            currentLevelIntervalIndexForVFX = 2;

        }

    }

    public void SetXPSlider()
    {
        for (int i = 0; i < xpSliders.Length; i++)
        {
            xpSliders[i].value = (float)Settings.User.xp / (float)(SomeDatas.Instance.xpPerLevel[Settings.User.level - 1]);

        }
    }

    public void SetNickNameTexts()
    {
        for (int i = 0; i < nickNameTexts.Length; i++)
        {
            nickNameTexts[i].text = Settings.User.nickName;
        }
    }

    public void SetCharacterObject(int currentIndex)
    {
        for (int i = 0; i < playerCharacterObjects.Length; i++)
        {
            if (i == currentIndex)
            {
                playerCharacterObjects[i].SetActive(true);
            }
            else
            {
                playerCharacterObjects[i].SetActive(false);
            }
        }
    }

    public void Sed3dObjectParent(bool setActive)
    {
        playerCharacterObjectsParent.SetActive(setActive);
    }

    private void SetGeneralStatsToUI()
    {
        generalWinText.text = "" + Settings.User.gs.generalWin.ToString("n0");
        generalLoseText.text = "" + Settings.User.gs.generalLose.ToString("n0");
        generalMVPCountText.text = "" + Settings.User.gs.generalMVP.ToString("n0");
        generalStoneText.text = "" + Settings.User.gs.generalStone.ToString("n0");
        generalKillText.text = "" + Settings.User.gs.generalKill.ToString("n0");
        if (Settings.User.gs.generalShot == 0)
        {
            generalAccuracyText.text = "0 %";
        }
        else
        {
            generalAccuracyText.text = (((float)Settings.User.gs.generalKill / (float)Settings.User.gs.generalShot) * 100).ToString("0.00") + " %";
        }

        if (Settings.User.gs.generalWin + Settings.User.gs.generalLose == 0)
        {
            generalEnduranceText.text = "0 seconds";

        }
        else
        {
            generalEnduranceText.text = ((float)Settings.User.gs.generalEndurance / (float)(Settings.User.gs.generalWin + Settings.User.gs.generalLose)).ToString("0.0") + " seconds";

        }
    }

    public void CheckXPLevel()
    {
        if (Settings.User.xp >= SomeDatas.Instance.xpPerLevel[Settings.User.level - 1]) // Next level achieved
        {
            // Next Level
            Settings.User.xp -= SomeDatas.Instance.xpPerLevel[Settings.User.level - 1];
            Settings.User.level++;
            SetXPSlider();
            for (int i = 0; i < xpTexts.Length; i++)
            {
                xpTexts[i].text = "XP: " + Settings.User.xp + "/ " + SomeDatas.Instance.xpPerLevel[Settings.User.level - 1];
                levelTexts[i].text = "" + Settings.User.level;
            }
            if (!SpecialData.Instance.firstTime)
            {
                playerCharacterObjects[currentCharacterIndex].SetActive(false);
                OpenPanel1();

            }

            SetLevelIntervalIndex();
            SaveLoadManager.Save(Settings.User);
        }

    }

    public void SetCoinsPrices()
    {
        //string ballDatas = LocalDatas.Instance.datasArray[9];
        for (int i = 0; i < ssCoinPricesTexts.Length; i++)
        {
            ssCoinPricesTexts[i].text = "" + SomeDatas.Instance.ssCoinPrices[i];
            ssCoinValuesTexts[i].text = "" + SomeDatas.Instance.ssCoinValues[i];
        }
    }

    public void SetAllLocalDatasToUI()
    {
        for (int i = 0; i < 2; i++)
        {
            nickNameTexts[i].text = Settings.User.nickName.ToString();
            levelTexts[i].text = Settings.User.level.ToString();
        }

        for (int i = 0; i < xpTexts.Length; i++)
        {
            if (Settings.User.level >= 1)
            {
                xpTexts[i].text = "XP: " + Settings.User.xp.ToString("n0") + "/" + SomeDatas.Instance.xpPerLevel[Settings.User.level - 1].ToString("n0");
            }
        }


        SetXPSlider();
        SetUICoins();
        SetGeneralStatsToUI();


        SetVFXDatasToUI();



        MenuUIController.Instance.SetArenaButton();



        MenuUIController.Instance.SetMusicOnOffButtonOptions(Convert.ToBoolean(PlayerPrefs.GetInt(savedMusicVolume)));
        MenuUIController.Instance.SetSoundOnOffButtonOptions(Convert.ToBoolean(PlayerPrefs.GetInt(savedSoundVolume)));

    }

    private void SetVFXDatasToUI()
    {
        for (int i = 0; i < vfxPriceTexts.Length; i++)
        {
            // if we havent bought vfx
            if (Settings.User.vfxs[i] == '0')
            {
                // if we can buy it
                if (i <= SomeDatas.Instance.lastIndexPerLevelIntervalVFX[currentLevelIntervalIndexForVFX])
                {
                    lockPanelsInVFX[i].SetActive(false);
                }
                // if our level is not enough to buy
                else
                {

                    lockPanelsInVFX[i].SetActive(true);
                }
                vfxPriceTexts[i].text = SomeDatas.Instance.ballPrices[i].ToString("n0");
                vfxPriceTextPanels[i].SetActive(true);
                vfxSelectSelectedTexts[i].gameObject.SetActive(false);
            }
            else
            {
                lockPanelsInVFX[i].SetActive(false);
                vfxPriceTextPanels[i].SetActive(false);
                vfxSelectSelectedTexts[i].gameObject.SetActive(true);
                if (LocalDatas.instance.currentBallSkinIndex == i)
                {
                    vfxSelectSelectedTexts[i].text = "Selected";
                }
                else
                {
                    vfxSelectSelectedTexts[i].text = "Select";
                }
            }
        }
    }

    public void AddTestXP(int xpCount)
    {
        Settings.User.xp += xpCount;

        for (int i = 0; i < xpTexts.Length; i++)
        {
            xpTexts[i].text = "XP: " + Settings.User.xp + "/ " + SomeDatas.Instance.xpPerLevel[Settings.User.level - 1];
        }
        SetXPSlider();
        CheckXPLevel();
    }

    #region Congrats panel functions

    public void OpenPanel1()
    {
        LeanTween.scale(panel1, Vector3.one * 1, panel1AnimTime).setOnComplete(OpenPanel2);
    }
    void OpenPanel2()
    {
        LeanTween.scale(panel2, Vector3.one * 1f, panel2AnimTime).setOnComplete(OpenPanel3);
    }

    void OpenPanel3()
    {
        LeanTween.scale(panel3, Vector3.one * 1f, panel3AnimTime).setEasePunch().setOnComplete(OpenPrizes);
    }

    public void OpenPrizes()
    {
        OpenPrize1();
        Panel3Step1();
    }

    void OpenPrize1()
    {
        LeanTween.scale(prize1, Vector3.one * 1f, panel2AnimTime).setDelay(delayAfterPanelsToPrizes).setOnComplete(OpenPrize2);
    }

    void OpenPrize2()
    {
        LeanTween.scale(prize2, Vector3.one * 1f, panel2AnimTime).setOnComplete(OpenPrize3);
    }

    void OpenPrize3()
    {
        LeanTween.scale(prize3, Vector3.one * 1f, panel2AnimTime).setOnComplete(SetNextButton);
    }

    void SetNextButton()
    {
        nextButton.GetComponent<Image>().enabled = true;
    }

    public void Panel3Step1()
    {
        LeanTween.scale(panel3, Vector3.one * 1.1f, 0.6f).setOnComplete(Panel3Step2);
    }

    public void Panel3Step2()
    {
        LeanTween.scale(panel3, Vector3.one * 1f, 0.6f).setOnComplete(Panel3Step1);
    }

    #endregion

    public string GetDataString()//  we seting the value that we are going to store the data in cloud
    {
        string data = "";
        data += Settings.User.nickName + "|";
        data += Settings.User.level + "|";
        data += Settings.User.xp + "|";
        data += Settings.User.ssCoin + "|";
        data += Settings.User.starCoin + "|";

        data += Settings.User.gs.generalWin + ",";
        data += Settings.User.gs.generalLose + ",";
        data += Settings.User.gs.generalMVP + ",";
        data += Settings.User.gs.generalStone + ",";
        data += Settings.User.gs.generalKill + ",";
        data += Settings.User.gs.generalShot + ",";
        data += Settings.User.gs.generalEndurance + ",";

        data += "|";

        data += Settings.User.rs.rSpeedLevel + ",";
        data += Settings.User.rs.rShieldLevel + ",";
        data += Settings.User.rs.rInvisibilityLevel + ",";
        data += Settings.User.rs.rAddHealth + ",";
        data += Settings.User.rs.rTrapLevel + ",";

        data += "|";

        data += Settings.User.cs.cSpeedLevel + ",";
        data += Settings.User.cs.cShieldLevel + ",";
        data += Settings.User.cs.cInvisibilityLevel + ",";
        data += Settings.User.cs.cBallLevel + ",";

        data += "|";

        for (int i = 0; i < Settings.User.characters.Length; i++)
        {
            data += Settings.User.characters[i].ToString();
        }

        data += "|";

        for (int i = 0; i < Settings.User.vfxs.Length; i++)
        {
            data += Settings.User.vfxs[i].ToString();
        }

        data += "|";

        data += "0000";

        data += "|";
        return data;
    }
}

