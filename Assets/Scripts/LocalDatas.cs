using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class LocalDatas : MonoBehaviour
{
    //public string[] datas = new string[11];
    [HideInInspector] public string datas;
    [HideInInspector] public string[] datasArray;
    public Text debugtext;

    public PlayGamesServices pgs;
    //public FirebaseController fc;



    public string userID;
    public string nickName;
    public int level = 1;
    public int xp = 0;
    public int ssCoin = 0;
    public int crystalCoin = 0;
    [Space(10)]
    public int generalWin = 0;
    public int generalLose = 0;
    public int generalMVPCount = 0;
    public int generalStone = 0;
    public int generalKill = 0;
    public int generalShot = 0;
    public int generalEndurance = 0;

    [Space(10)]

    public int runnerSpeedLevel=0;
    public int runnerShieldLevel=0;
    public int runnerInvisibilityLevel=0;
    public int runnerAddHealth=0;
    public int runnerTrapLevel=0;
    public int runnerSlowdownTrapLevel=0;
    public int runnerTopViewLevel=0;
    public int runnerWallLevel=0;
    public int runnerHookLevel=0;
    public int runnerBCLevel = 0;

    [Space(10)]
    public int catcherSpeedLevel=0;
    public int catcherShieldLevel=0;
    public int catcherInvisibilityLevel=0;
    public int catcherBallLevel=0;
    public int catcherSlowdownTrapLevel = 0;
    public int catcherTopViewLevel = 0;
    public int catcherWallLevel = 0;
    public int catcherHookLevel = 0;
    public int catcherBCLevel = 0;
    public int catcherDeadlyHitLevel = 0;

    [Space(10)]
    public int[] ballSkins;
    public int[] characters;
    public int[] arenas;

    public int[] runnerSkillsLevels;

    public int[] catcherSkillsLevels;

    //[Space(30)]
    [Header("Others")]
    //[Space(30)]

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
    // [SerializeField] Text levelText;
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
    [SerializeField] GameObject[] lockPanels;
    [SerializeField] GameObject[] characterPriceTextPanels;

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
    //private static LocalDatas instance;
    //public static LocalDatas Instance { get => instance; }

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

    // [SerializeField] GameObject[] ssCoinssInShop;
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
        //runnerSkillsLevels = new int[5];
        //catcherSkillsLevels = new int[4];
        //pgs.GetComponent<PlayGamesServices>();
    }

    #endregion

    private void Start()
    {
        canRotateObject = true;
    }

    public void ResetLocalDatas()
    {
        xp = 0;
        level = 1;
        ssCoin = 500;
        crystalCoin = 5;

        generalWin = 0;
        generalLose = 0;
        generalMVPCount = 0;
        generalStone = 0;
        generalKill = 0;
        generalShot = 0;
        generalEndurance = 0;

        runnerSpeedLevel = 1;
        runnerShieldLevel = 1;
        runnerInvisibilityLevel = 1;
        runnerAddHealth = 0;
        runnerTrapLevel = 0;
        runnerSlowdownTrapLevel = 1;
        runnerTopViewLevel = 1;
        runnerWallLevel = 0;
        runnerHookLevel = 0;
        runnerBCLevel = 0;

        catcherSpeedLevel = 1;
        //catcherShieldLevel = 1;
        catcherInvisibilityLevel = 1;
        catcherBallLevel = 0;
        catcherSlowdownTrapLevel = 1;
        catcherTopViewLevel = 1;
        catcherWallLevel = 0;
        catcherHookLevel = 0;
        catcherBCLevel = 0;
        catcherDeadlyHitLevel = 1;

        ballSkins = new int[15] { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        characters = new int[14] { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        arenas = new int[3] { 1, 0, 0};

    }

    public void SetLoadingPanelWithTweening()
    {
        MenuCommonObjects.Instance.loadingSliderImage.SetActive(false);
        LeanTween.value(gameObject, 1f, 0f, 0.5f)
            .setOnUpdate((float vol) => {
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
        runnerSkillsLevels[0] = runnerSpeedLevel;
        runnerSkillsLevels[1] = runnerAddHealth;
        runnerSkillsLevels[2] = runnerShieldLevel;
        runnerSkillsLevels[3] = runnerTrapLevel;
        runnerSkillsLevels[4] = runnerInvisibilityLevel;
        runnerSkillsLevels[5] = runnerSlowdownTrapLevel;
        runnerSkillsLevels[6] = runnerTopViewLevel;
        runnerSkillsLevels[7] = runnerWallLevel;
        runnerSkillsLevels[8] = runnerHookLevel;
        runnerSkillsLevels[9] = runnerBCLevel;

        catcherSkillsLevels[0] = catcherSpeedLevel;
        catcherSkillsLevels[1] = catcherShieldLevel;
        catcherSkillsLevels[2] = catcherInvisibilityLevel;
        catcherSkillsLevels[3] = catcherBallLevel;
        catcherSkillsLevels[4] = catcherSlowdownTrapLevel;
        catcherSkillsLevels[5] = catcherTopViewLevel;
        catcherSkillsLevels[6] = catcherWallLevel;
        catcherSkillsLevels[7] = catcherHookLevel;
        catcherSkillsLevels[8] = catcherDeadlyHitLevel;
        catcherSkillsLevels[9] = catcherBCLevel;

    }

    public void SetCharacterBuyButton( int b )
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
        else if (b == 2 ) // SELECTED
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
            ssCoinText[i].text = "" + ssCoin.ToString("n0");
            crystalCoinText[i].text = "" + crystalCoin.ToString("n0");

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

    //public void DebugToUI(string a)
    //{
    //    debugtext.text += a + "\n";
    //}

    public void ShowDatas()
    {
        debugtext.text += "\nnickname: " + nickName + "\n";
        debugtext.text += "\nlevel: " + level + "\n";
        debugtext.text += "\nxp: " + xp + "\n";
        debugtext.text += "\nscoin: " + ssCoin + "\n";
        debugtext.text += "\nstarcoin: " + crystalCoin + "\n";
        
        debugtext.text += "\ngeneralWin: " + generalWin + "\n";
        debugtext.text += "\ngeneralLose: " + generalLose + "\n";
        debugtext.text += "\ngeneralMVPCount: " + generalMVPCount + "\n";
        debugtext.text += "\ngeneralStone: " + generalStone + "\n";
        debugtext.text += "\ngeneralKill: " + generalKill + "\n";
        debugtext.text += "\ngeneralShot: " + generalShot + "\n";
        debugtext.text += "\ngeneralEndurance: " + generalEndurance + "\n";

        debugtext.text += "\n\nrunnerSpeedLevel: " + runnerSpeedLevel + "\n";
        debugtext.text += "\nrunnerShieldLevel: " + runnerShieldLevel + "\n";
        debugtext.text += "\nrunnerInvisibilityLevel: " + runnerInvisibilityLevel + "\n";
        debugtext.text += "\nrunnerAddHealth: " + runnerAddHealth + "\n";
        debugtext.text += "\nrunnerTrapLevel: " + runnerTrapLevel + "\n";

        debugtext.text += "\n\ncatcherSpeedLevel: " + catcherSpeedLevel + "\n";
        debugtext.text += "\ncatcherShieldLevel: " + catcherShieldLevel + "\n";
        debugtext.text += "\ncatcherInvisibilityLevel: " + catcherInvisibilityLevel + "\n";
        debugtext.text += "\ncatcherMapShowLevel: " + catcherBallLevel + "\n";

        for (int i = 0; i < characters.Length; i++)
        {
            debugtext.text += "\ncharacters[" + i + "] = " + characters[i] + "\n";
        }

        for (int i = 0; i < ballSkins.Length; i++)
        {
            debugtext.text += "\nBallskins[" + i + "] = " + ballSkins[i] + "\n";
        }


    }


    public void DebugDatas()
    {
        Debug.Log("nickname: " + nickName);
        Debug.Log("level: " + level);
        Debug.Log("xp: " + xp);
        Debug.Log("sscoin: " + ssCoin);
        Debug.Log("starcoin: " + crystalCoin);

        Debug.Log( "generalWin: " + generalWin);
        Debug.Log( "generalLose: " + generalLose);
        Debug.Log( "generalMVPCount: " + generalMVPCount);
        Debug.Log( "generalStone: " + generalStone);
        Debug.Log(" generalKill: " + generalKill);
        Debug.Log(" generalShot: " + generalShot);
        Debug.Log(" generalEndurance: " + generalEndurance);
        
        Debug.Log( "runnerSpeedLevel: " + runnerSpeedLevel);
        Debug.Log( "runnerShieldLevel: " + runnerShieldLevel);
        Debug.Log( "runnerInvisibilityLevel: " + runnerInvisibilityLevel);
        Debug.Log( "runnerAddHealth: " + runnerAddHealth);
        Debug.Log( "runnerTrapLevel: " + runnerTrapLevel);
        
        Debug.Log( "catcherSpeedLevel: " + catcherSpeedLevel);
        Debug.Log( "catcherShieldLevel: " + catcherShieldLevel);
        Debug.Log( "catcherInvisibilityLevel: " + catcherInvisibilityLevel);
        Debug.Log( "catcherMapShowLevel: " + catcherBallLevel);

        for (int i = 0; i < characters.Length; i++)
        {
            Debug.Log("characters[" + i + "] = " + characters[i]);

        }

        for (int i = 0; i < ballSkins.Length; i++)
        {
            Debug.Log("Ballskins[" + i + "] = " + ballSkins[i]);
        }


    }

    public int SetLevelIntervalIndex()
    {
        int res;
        if (level < 5) // 0-5
        {
            res = 0;
        }
        else if (level < 10) // 5-10
        {
            res = 1;
        }
        else if (level < 15) // 10-15
        {
            res = 2;
        }
        else if (level < 20) // 15-20
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
        if (level <= SomeDatas.Instance.levelIntervalForCharacters[0])
        {
            currentLevelIntervalIndexForCharacters = 0;
        }
        else if (level >= SomeDatas.Instance.levelIntervalForCharacters[0] && level <= SomeDatas.Instance.levelIntervalForCharacters[1])
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
        if (level < SomeDatas.Instance.levelIntervalForVFX[0])
        {
            currentLevelIntervalIndexForVFX = 0;
        }
        else if (level >= SomeDatas.Instance.levelIntervalForVFX[0] && level <= SomeDatas.Instance.levelIntervalForVFX[1])
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
            xpSliders[i].value = (float)xp / (float)(SomeDatas.Instance.xpPerLevel[level - 1]);

        }
    }

    public void SetNickNameTexts()
    {
        for (int i = 0; i < nickNameTexts.Length; i++)
        {
            nickNameTexts[i].text = nickName;
        }
    }




    public void SetDatasToLocalDatas(string _userId, string _nickname, int _level, int _xp, int _ssCoin, int _starCoin, int[] _generals, int[] _runnerSkills , int[] _catcherSkill, string _characters, string _vfxs, string _maps)
    {

        if (!PlayerPrefs.HasKey(savedMusicVolume)) // if it is first time in this phone
        {
            PlayerPrefs.SetInt(savedMusicVolume, 1);
        }
        if (!PlayerPrefs.HasKey(savedSoundVolume)) // if it is first time in this phone
        {
            PlayerPrefs.SetInt(savedSoundVolume, 1);
        }

        soundOn = PlayerPrefs.GetInt(savedSoundVolume);
        musicOn = PlayerPrefs.GetInt(savedMusicVolume);

        userID = _userId;
        level = _level;
        nickName = _nickname;
        xp = _xp;
        ssCoin = _ssCoin;
        crystalCoin = _starCoin;


        generalWin = _generals[0];
        generalLose = _generals[1];
        generalMVPCount = _generals[2];
        generalStone = _generals[3];
        generalKill= _generals[4];
        generalShot = _generals[5];
        generalEndurance = _generals[6];

        runnerSpeedLevel = _runnerSkills[0];
        runnerAddHealth = _runnerSkills[1];
        runnerShieldLevel = _runnerSkills[2];
        runnerTrapLevel = _runnerSkills[3];
        runnerInvisibilityLevel = _runnerSkills[4];
        runnerSlowdownTrapLevel= _runnerSkills[5];
        runnerTopViewLevel = _runnerSkills[6];
        runnerWallLevel= _runnerSkills[7];
        runnerHookLevel = _runnerSkills[8];
        runnerBCLevel = _runnerSkills[9];
        for (int i = 0; i < runnerSkillsLevels.Length; i++)
        {
            runnerSkillsLevels[i] = _runnerSkills[i];
        }


        catcherSpeedLevel = _catcherSkill[0];
        catcherShieldLevel = _catcherSkill[1];
        catcherInvisibilityLevel = _catcherSkill[2];
        catcherBallLevel = _catcherSkill[3];
        catcherSlowdownTrapLevel = _catcherSkill[4];
        catcherTopViewLevel= _catcherSkill[5];
        catcherWallLevel= _catcherSkill[6];
        catcherHookLevel = _catcherSkill[7];
        catcherDeadlyHitLevel = _catcherSkill[8];
        catcherBCLevel = _catcherSkill[9];
        for (int i = 0; i < catcherSkillsLevels.Length; i++)
        {
            catcherSkillsLevels[i] = _catcherSkill[i];
        }

        characters = new int[14];
        for (int i = 0; i < 14; i++)
        {
            characters[i] = _characters[i] - '0';
        }

        ballSkins = new int[15];
        for (int i = 0; i < 15; i++)
        {
            ballSkins[i] = _vfxs[i] - '0';
        }

        arenas = new int[3];
        for (int i = 0; i < 3; i++)
        {
            arenas[i] = _maps[i] - '0';
        }

        currentLevelIntervalIndex = SetLevelIntervalIndex();
        SetLevelIntervalIndexForCharacter();
        SetLevelIntervalIndexForVFX();


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
        generalWinText.text = "" + generalWin.ToString("n0");
        generalLoseText.text = "" + generalLose.ToString("n0");
        generalMVPCountText.text = "" + generalMVPCount.ToString("n0");
        generalStoneText.text = "" + generalStone.ToString("n0");
        generalKillText.text = "" + generalKill.ToString("n0");
        if (generalShot == 0)
        {
            generalAccuracyText.text = "0 %";
        }
        else
        {
            generalAccuracyText.text = ( ( (float) generalKill / (float)generalShot )  * 100 ).ToString("0.00") + " %";
        }

        if (generalWin + generalLose == 0)
        {
            generalEnduranceText.text = "0 seconds";

        }
        else
        {
            generalEnduranceText.text = ( (float)generalEndurance / (float)(generalWin + generalLose) ).ToString("0.0") + " seconds";

        }
    }

    public void SetCharactersLocks()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i] == 0)
            {
                lockPanels[i].SetActive(true);
                characterPriceTextPanels[i].SetActive(true);
            }
            else
            {
                lockPanels[i].SetActive(false);
                characterPriceTextPanels[i].SetActive(false);
            }
        }
    
    }

    public void CheckXPLevel()
    {
        if (xp >= SomeDatas.Instance.xpPerLevel[level - 1]) // Next level achieved
        {
            // Next Level
            xp -= SomeDatas.Instance.xpPerLevel[level - 1];
            level++;
            SetXPSlider();
            for (int i = 0; i < xpTexts.Length; i++)
            {
                xpTexts[i].text = "XP: " + xp  + "/ " +  SomeDatas.Instance.xpPerLevel[level - 1];
                levelTexts[i].text = "" + level;
            }
            if (!SpecialData.Instance.firstTime)
            {
                playerCharacterObjects[currentCharacterIndex].SetActive(false);
                OpenPanel1();

            }

            SetLevelIntervalIndex();
            // TODO Some prizes
            FirebaseController.Instance.SaveData();

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
        //print("712:" + nickName);
        //print("713:" + level);
        //levelText.text = "hhh";
        //print("714.5:" + levelTexts[0].gameObject.name);
        //print("714" + nickNameTexts[1].gameObject.name);
        //print("714.5:" + levelTexts[2].gameObject.name);
        for (int i = 0; i < 2; i++)
        {
            //print("715:" + level);
            nickNameTexts[i].text = nickName.ToString();
            //print("714");
            levelTexts[i].text = level.ToString();
        }

        //print("xpTexts.Length: " + xpTexts.Length);
        for (int i = 0; i < xpTexts.Length; i++)
        {
            //print("722:" + xp);
            //print("723:" + level);
            if (level >= 1)
            {
                xpTexts[i].text = "XP: " + xp.ToString("n0") + "/" + SomeDatas.Instance.xpPerLevel[level - 1].ToString("n0");
            }
        }

        
        SetXPSlider();
        SetUICoins();
        SetGeneralStatsToUI();

        SetCharacterDatasToUI();

        SetVFXDatasToUI();



        MenuUIController.Instance.SetArenaButton();



        MenuUIController.Instance.SetMusicOnOffButtonOptions(Convert.ToBoolean( PlayerPrefs.GetInt(savedMusicVolume) ) );
        MenuUIController.Instance.SetSoundOnOffButtonOptions(Convert.ToBoolean( PlayerPrefs.GetInt(savedSoundVolume) ) );

    }



    private void SetVFXDatasToUI()
    {
        for (int i = 0; i < vfxPriceTexts.Length; i++)
        {
            // if we havent bought vfx
            if (ballSkins[i] == 0)
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

    private void SetCharacterDatasToUI()
    {
        for (int i = 0; i < 14; i++)
        {
            characterPriceTexts[i].text = SomeDatas.Instance.characterPrices[i].ToString("n0");
            if (characters[i] == 0) // not bought
            {
                // if we can buy it by level
                if (i <= SomeDatas.Instance.lastIndexPerLevelInterval[currentLevelIntervalIndexForCharacters])
                {
                    //print("We can buy it");
                    lockPanels[i].SetActive(false);
                    characterPriceTextPanels[i].SetActive(true);
                }
                // if our level is not enough to buy
                else
                {
                    lockPanels[i].SetActive(true);
                    characterPriceTextPanels[i].SetActive(true);
                }
            }
            else
            {
                lockPanels[i].SetActive(false);
                characterPriceTextPanels[i].SetActive(false);
            }
        }
    }


    public void AddTestXP(int xpCount)
    {
        xp += xpCount;

        for (int i = 0; i < xpTexts.Length; i++)
        {
            xpTexts[i].text = "XP: " + xp + "/ " + SomeDatas.Instance.xpPerLevel[level - 1];
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
        data += nickName + "|";
        data += level + "|";
        data += xp+ "|";
        data += ssCoin+ "|";
        data += crystalCoin+ "|";

        data += generalWin + ",";
        data += generalLose + ",";
        data += generalMVPCount + ",";
        data += generalStone+ ",";
        data += generalKill + ",";
        data += generalShot + ",";
        data += generalEndurance+ ",";

        data += "|";
        
        data += runnerSpeedLevel + ",";
        data += runnerShieldLevel + ",";
        data += runnerInvisibilityLevel + ",";
        data += runnerAddHealth + ",";
        data += runnerTrapLevel + ",";
        
        data += "|";

        data += catcherSpeedLevel + ",";
        data += catcherShieldLevel + ",";
        data += catcherInvisibilityLevel + ",";
        data += catcherBallLevel + ",";
        
        data += "|";

        for (int i = 0; i < characters.Length; i++)
        {
            data += characters[i].ToString();
        }

        data += "|";

        for (int i = 0; i < ballSkins.Length; i++)
        {
            data += ballSkins[i].ToString();
        }

        data += "|";

        data += "0000";
        
        data += "|";
        //for (int i = 0; i < datasArray.Length; i++)
        //{
        //    data += datasArray[i];
        //    data += "|";
        //}
        print("Datas in playerprefs: " + data);
        return data;
    }

    //public void EditLocalDatas(string _data)
    //{
    //    datasArray = _data.Split('|');

    //    nickName = datasArray[0];
    //    level = int.Parse(datasArray[1]);
    //    xp = int.Parse(datasArray[2]);
    //    ssCoin = int.Parse(datasArray[3]);
    //    crystalCoin = int.Parse(datasArray[4]);
    //    DebugToUI("\n272\n");
    //    SetLevelIntervalIndex();

    //    for (int i = 0; i < nickNameTexts.Length; i++)
    //    {
    //        nickNameTexts[i].text = "" + nickName;
    //        levelTexts[i].text = "" + level;
    //    }



    //    for (int i = 0; i < xpTexts.Length; i++)
    //    {
    //        if (level >= 1)
    //        {
    //            xpTexts[i].text = "XP: " + xp + "/" + SomeDatas.Instance.xpPerLevel[level - 1];
    //        }


    //    }
    //    DebugToUI("\n287\n");




    //    for (int i = 0; i < ssCoinText.Length; i++)
    //    {
    //        ssCoinText[i].text = "" + ssCoin;
    //        crystalCoinText[i].text = "" + crystalCoin;

    //    }




    //    debugtext.text += "\n-------------------------------\n";
    //    debugtext.text += "\n-------------------------------\n";
    //    debugtext.text += "generals: " + datasArray[5] + "\n";

    //    string[] generalStats = datasArray[5].Split(',');
    //    generalWin = int.Parse(generalStats[0]);
    //    generalLose = int.Parse(generalStats[1]);
    //    generalMVPCount = int.Parse(generalStats[2]);
    //    debugtext.text += "line 96";
    //    generalStone = int.Parse(generalStats[3]);
    //    generalKill = int.Parse(generalStats[4]);
    //    generalShot = int.Parse(generalStats[5]);
    //    generalEndurance = int.Parse(generalStats[6]);

    //    SetGeneralStatsToUI();

    //    debugtext.text += "\n-------------------------------\n";
    //    runnerSkillsLevels = new int[5];
    //    string[] runnerStats = datasArray[6].Split(',');
    //    if (runnerStats.Length != 0)
    //    {
    //        runnerSpeedLevel = int.Parse(runnerStats[0]);
    //        runnerShieldLevel = int.Parse(runnerStats[1]);
    //        runnerInvisibilityLevel = int.Parse(runnerStats[2]);
    //        runnerAddHealth = int.Parse(runnerStats[3]);
    //        runnerTrapLevel = int.Parse(runnerStats[4]);
    //        runnerSkillsLevels[0] = runnerSpeedLevel;
    //        runnerSkillsLevels[1] = runnerAddHealth;
    //        runnerSkillsLevels[2] = runnerShieldLevel;
    //        runnerSkillsLevels[3] = runnerTrapLevel;
    //        runnerSkillsLevels[4] = runnerInvisibilityLevel;

    //    }
    //    debugtext.text += "\n-------------------------------\n";
    //    catcherSkillsLevels = new int[4];
    //    string[] catcherStats = datasArray[7].Split(',');
    //    if (catcherStats.Length != 0)
    //    {
    //        catcherSpeedLevel = int.Parse(catcherStats[0]);
    //        catcherShieldLevel = int.Parse(catcherStats[1]);
    //        catcherInvisibilityLevel = int.Parse(catcherStats[2]);
    //        catcherBallLevel = int.Parse(catcherStats[3]);

    //        catcherSkillsLevels[0] = catcherSpeedLevel;
    //        catcherSkillsLevels[0] = catcherShieldLevel;
    //        catcherSkillsLevels[0] = catcherInvisibilityLevel;
    //        catcherSkillsLevels[0] = catcherBallLevel;

    //    }
    //    debugtext.text += "\n-------------------------------\n";
    //    debugtext.text += "datasarray length: " + datasArray.Length + "\n";
    //    debugtext.text += "datasArray[8]: " + datasArray[8] + "\n";
    //    string charactersString = datasArray[8];
    //    characters = new int[14];
    //    for (int i = 0; i < 14; i++)
    //    {
    //        characters[i] = charactersString[i] - '0';
    //        characterPriceTexts[i].text = "" + SomeDatas.Instance.characterPrices[i];
    //        if (characters[i] == 0)
    //        {
    //            lockPanels[i].SetActive(true);
    //            characterPriceTextPanels[i].SetActive(true);
    //        }
    //        else
    //        {
    //            lockPanels[i].SetActive(false);
    //            characterPriceTextPanels[i].SetActive(false);
    //        }
    //    }




    //    string balls = datasArray[9];
    //    DebugToUI("Balls: " + balls);
    //    ballSkins = new int[15];
    //    for (int i = 0; i < 15; i++)
    //    {
    //        ballSkins[i] = balls[i] - '0';
    //        if (ballSkins[i] == 0)
    //        {
    //            vfxPriceTexts[i].text = SomeDatas.Instance.ballPrices[i].ToString();
    //            vfxPriceTextPanels[i].SetActive(true);
    //        }
    //        else
    //        {
    //            vfxPriceTextPanels[i].SetActive(false);
    //        }
    //        debugtext.text += "ballSkins[" + i + "]= " + ballSkins[i] + " \n";

    //    }


    //    for (int i = 0; i < datasArray.Length - 1; i++)
    //    {
    //        debugtext.text += "_" + datasArray[i] + "_";
    //    }
    //    debugtext.text += "\n_-472-_: " + PlayerPrefs.GetInt(profilePicIndex) + "\n";
    //    ChangeAllPPs(PlayerPrefs.GetInt(profilePicIndex));

    //    //for (int i = 0; i < datasArray.Length - 1; i++)
    //    //{ 

    //    debugtext.text += "\n_-478-_\n";
    //    //}

    //    debugtext.text += "\n_-482-_\n";


    //    //if (!PlayerPrefs.HasKey(characterIndex))
    //    //{
    //    //    PlayerPrefs.SetInt(characterIndex, 0);
    //    //}

    //    currentCharacterIndex = PlayerPrefs.GetInt(characterIndex);
    //    currentBallSkinIndex = PlayerPrefs.GetInt(vfxIndex);
    //    currentBallSkinIndex = PlayerPrefs.GetInt(mapIndex);


    //    for (int i = 0; i < SomeDatas.Instance.characterNames.Length; i++)
    //    {
    //        characterNamesInCharacterPanel[i].text = SomeDatas.Instance.characterNames[i];
    //    }

    //    DebugToUI("\n current ch i : " + currentCharacterIndex);
    //    DebugToUI("\n current vfx i : " + currentBallSkinIndex);
    //    SetCharacterObject(currentCharacterIndex);

    //    CheckXPLevel();

    //    SetCoinsPrices();


    //    SetXPSlider();
    //    SpecialData.Instance.firstTime = false;

    //}

    //public void SetNewUserLocalDatas()
    //{
    //    level = 1;
    //    xp = 0;
    //    ssCoin = 0;
    //    crystalCoin = 0;

    //    generalWin = 0;
    //    generalLose = 0;
    //    generalMVPCount = 0;
    //    generalKill = 0;
    //    generalShot = 0;
    //    generalEndurance = 0;

    //    runnerSpeedLevel = 0;
    //    runnerShieldLevel = 0;
    //    runnerInvisibilityLevel = 0;
    //    runnerAddHealth = 0;
    //    runnerTrapLevel = 0;

    //    catcherSpeedLevel = 0;
    //    catcherShieldLevel = 0;
    //    catcherInvisibilityLevel = 0;
    //    catcherBallLevel = 0;

    //    for (int i = 0; i < characters.Length; i++)
    //    {
    //        if (i <= 4)
    //        {
    //            characters[i] = 1;
    //        }
    //        else
    //        {
    //            characters[i] = 0;
    //        }
    //    }

    //    for (int i = 0; i < ballSkins.Length; i++)
    //    {
    //        if (i <= 2)
    //        {
    //            ballSkins[i] = 1;
    //        }
    //        else
    //        {
    //            ballSkins[i] = 0;
    //        }
    //    }


    //}

}

