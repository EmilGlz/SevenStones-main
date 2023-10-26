using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Photon.Pun;



public class FirebaseController : MonoBehaviour
{
    [SerializeField] TMP_InputField username;
    [SerializeField] TMP_InputField email;
    [SerializeField] TMP_InputField nametoread;

    public GameObject CreateNickNamePanel;
    
    [SerializeField] GameObject xpScalingSlider;
    [SerializeField] float congratsSliderTime;

    public TMP_Text prize1Text;
    public TMP_Text prize2Text;
    public TMP_Text prize3Text;
    public TMP_Text congratsLevelText;

    [SerializeField] GameObject prize3Object;
    [SerializeField] GameObject congratsPanel;
    [SerializeField] GameObject congratsPanelChild;

    public GameObject[] notificationImagesInMenuButtons;

    public GameObject[] orangeImagesInVFXPanel;

    public GameObject[] orangeIconsInRunnerCatcherButtonsSkills;

    public GameObject[] orangeImagesInSkillPanelRunner;
    public GameObject[] orangeImagesInSkillPanelCatcher;

    public GameObject[] orangeImagesInCharacterPanel;

    public TMP_Text[] arenaPriceTexts;
    public GameObject[] arenaPriceTextPanels;

    public TMP_Text[] selectTextsInArenaButtons;

    [SerializeField] TMP_Text[] characterNamesInCharacterPanel;

    public int prizeVFXIndex = -1;
    public int prizeCharacterIndex = -1;
    public int prizeSkillIndex = -1;

    public GameObject noInternetImage;

    public User user = new User();
    public Version v = new Version();
    [HideInInspector] public int gameVersionMustBe;

    #region Singleton

    private static FirebaseController instance;

    public static FirebaseController Instance { get => instance; }

    private void Awake()
    {
        instance = this;
    }

    #endregion


    public void ReadData(string playerID)
    {

        //StartCoroutine(ReadVersion());

        StartCoroutine(CheckInternetConnection());


        Debug.Log("ReadData()");
        //reference.Child("Version").GetValueAsync().ContinueWithOnMainThread(task =>
        //{
        //    if (task.IsCompleted)
        //    {
        //        Debug.Log("Reading");
        //        DataSnapshot snapshot = task.Result;
        //        gameVersionMustBe = int.Parse(snapshot.Child("version").Value.ToString());
        //        Debug.Log("Version: " + gameVersionMustBe);


        //        // if game version is good
        //        if (LocalDatas.Instance.currentVersion == gameVersionMustBe)
        //        {
        //            Debug.Log("reading user datas line 238");
        //            ReadUserDatas(playerID);
        //        }
        //        else
        //        {
        //            // Update Panel
        //            Debug.Log("Needs update");
        //            MenuUIController.Instance.OpenUpdatePanel();
        //        }

        //    }
        //    else
        //    {
        //        Debug.Log("ERROR");
        //    }
        //});



    }

    private void ReadUserDatas(string playerID)
    {
        Debug.Log("ReadUserDatas()");
        //reference.Child("Users").Child(playerID).GetValueAsync().ContinueWithOnMainThread(task =>
        //{

        //    if (task.IsCompleted)
        //    {
        //        Debug.Log("Reading datas...");

        //        DataSnapshot snapshot = task.Result;




        //        if (!snapshot.Exists)
        //        {
        //            // TODO Tuto panel ...
        //            //StartCoroutine(SetFirstNickNamePanel(true));
        //            MenuUIController.Instance.OpenTutorialPanel();
        //            LocalDatas.Instance.currentCharacterIndex = 0;
        //            LocalDatas.Instance.ResetLocalDatas();
        //            StartCoroutine(SetLoadingPanel(1f));
        //            Debug.Log("Does not exist");
        //        }
        //        else
        //        {

        //            #region setting db datas to datas

        //            string _nick = snapshot.Child("nickName").Value.ToString();
        //            Debug.Log("nick done!");
        //            int _lvl = int.Parse(snapshot.Child("level").Value.ToString());
        //            int _xp = int.Parse(snapshot.Child("xp").Value.ToString());
        //            int _ssCoin = int.Parse(snapshot.Child("ssCoin").Value.ToString());
        //            int _starCoin = int.Parse(snapshot.Child("starCoin").Value.ToString());
        //            Debug.Log("nick zad done!");

        //            int[] generals = new int[7];
        //            generals[0] = int.Parse(snapshot.Child("gs").Child("generalWin").Value.ToString());
        //            generals[1] = int.Parse(snapshot.Child("gs").Child("generalLose").Value.ToString());
        //            generals[2] = int.Parse(snapshot.Child("gs").Child("generalMVP").Value.ToString());
        //            generals[3] = int.Parse(snapshot.Child("gs").Child("generalStone").Value.ToString());
        //            generals[4] = int.Parse(snapshot.Child("gs").Child("generalKill").Value.ToString());
        //            generals[5] = int.Parse(snapshot.Child("gs").Child("generalShot").Value.ToString());
        //            generals[6] = int.Parse(snapshot.Child("gs").Child("generalEndurance").Value.ToString());
        //            Debug.Log("generals done!");

        //            int[] runnerSkills = new int[10];
        //            runnerSkills[0] = int.Parse(snapshot.Child("rs").Child("rSpeedLevel").Value.ToString());
        //            runnerSkills[2] = int.Parse(snapshot.Child("rs").Child("rShieldLevel").Value.ToString());
        //            runnerSkills[4] = int.Parse(snapshot.Child("rs").Child("rInvisibilityLevel").Value.ToString());
        //            runnerSkills[1] = int.Parse(snapshot.Child("rs").Child("rAddHealth").Value.ToString());
        //            runnerSkills[3] = int.Parse(snapshot.Child("rs").Child("rTrapLevel").Value.ToString());
        //            runnerSkills[5] = int.Parse(snapshot.Child("rs").Child("rSDTLevel").Value.ToString());
        //            runnerSkills[6] = int.Parse(snapshot.Child("rs").Child("rTopViewLevel").Value.ToString());
        //            runnerSkills[7] = int.Parse(snapshot.Child("rs").Child("rWallLevel").Value.ToString());
        //            runnerSkills[8] = int.Parse(snapshot.Child("rs").Child("rHookLevel").Value.ToString());
        //            runnerSkills[9] = int.Parse(snapshot.Child("rs").Child("rBCLevel").Value.ToString());
        //            Debug.Log("runner skills done!");

        //            int[] catcherSkills = new int[10];
        //            catcherSkills[0] = int.Parse(snapshot.Child("cs").Child("cSpeedLevel").Value.ToString());
        //            //catcherSkills[1] = int.Parse(snapshot.Child("cs").Child("cShieldLevel").Value.ToString());
        //            catcherSkills[2] = int.Parse(snapshot.Child("cs").Child("cInvisibilityLevel").Value.ToString());
        //            catcherSkills[3] = int.Parse(snapshot.Child("cs").Child("cBallLevel").Value.ToString());
        //            catcherSkills[4] = int.Parse(snapshot.Child("cs").Child("cSDTlevel").Value.ToString());
        //            catcherSkills[5] = int.Parse(snapshot.Child("cs").Child("cTopViewLevel").Value.ToString());
        //            catcherSkills[6] = int.Parse(snapshot.Child("cs").Child("cWallLevel").Value.ToString());
        //            catcherSkills[7] = int.Parse(snapshot.Child("cs").Child("cHookLevel").Value.ToString());
        //            catcherSkills[8] = int.Parse(snapshot.Child("cs").Child("cDHLevel").Value.ToString());
        //            catcherSkills[9] = int.Parse(snapshot.Child("cs").Child("cBCLevel").Value.ToString());
        //            Debug.Log("catcher skills done!");


        //            string _chs = snapshot.Child("characters").Value.ToString();
        //            string _vfxs = snapshot.Child("vfxs").Value.ToString();
        //            string _maps = snapshot.Child("arenas").Value.ToString();
        //            Debug.Log("all skills done!");
        //            #endregion
        //            MenuUIController.Instance.CloseTutorialPanel();
        //            // StartCoroutine(SetFirstNickNamePanel(false));
        //            SetToUserObject(playerID, _nick, _lvl, _xp, _ssCoin, _starCoin, generals, runnerSkills, catcherSkills, _chs, _vfxs, _maps);

        //            LocalDatas.Instance.SetDatasToLocalDatas(playerID, _nick, _lvl, _xp, _ssCoin, _starCoin, generals, runnerSkills, catcherSkills, _chs, _vfxs, _maps);

        //            if (LocalDatas.Instance.xp >= SomeDatas.Instance.xpPerLevel[LocalDatas.Instance.level - 1])
        //            {
        //                //TODO LevelUp sound
        //                Debug.Log("Level up");

        //                StartCoroutine(ShowCongratsPanel());

        //                AudioManager.Instance.Play(0);

        //                return;
        //            }
                    
        //            SpecialData.Instance.user = user;
        //            //SpecialData.Instance.firstTime = false;

        //            StartCoroutine(SetToUI()); // wait for one frame, then add to UI

        //            if (MenuCommonObjects.Instance.loadingSlider != null) MenuUIController.Instance.SetSliderWithTweening(0.3f, 0.5f);

        //        }

        //        Debug.Log("Reading done!");
        //        AudioManager.Instance.Play(0);
        //        if (!PhotonNetwork.IsConnectedAndReady)
        //        {
        //            Debug.Log("Connecting to Photon Network Master.");
        //            PhotonNetwork.GameVersion = "0.0.1";
        //            PhotonNetwork.ConnectUsingSettings();
        //        }
        //        else
        //        {
        //            Debug.Log("Already in lobby");
        //            if (MenuCommonObjects.Instance.loadingSlider != null) MenuUIController.Instance.SetSliderWithTweening(0.5f, 1f);
        //            StartCoroutine(SetLoadingPanel(1f));
        //        }
        //        //// If Version is good
        //        //if (int.Parse(snapshot.Child("version").Value.ToString()) == gameVersionMustBe)
        //        //{
        //        //    if (!PhotonNetwork.IsConnectedAndReady)
        //        //    {
        //        //        Debug.Log("Connecting to Photon Network Master.");
        //        //        PhotonNetwork.GameVersion = "0.0.1";
        //        //        PhotonNetwork.ConnectUsingSettings();
        //        //    }
        //        //    else
        //        //    {
        //        //        Debug.Log("Already in lobby");
        //        //        if (MenuCommonObjects.Instance.loadingSlider != null) MenuUIController.Instance.SetSliderWithTweening(0.5f, 1f);
        //        //        StartCoroutine(SetLoadingPanel(false, 1f));
        //        //    }
        //        //}
        //        //// If it must be updated
        //        //else
        //        //{
        //        //    Debug.Log("Must be updated");
        //        //    StartCoroutine(SetLoadingPanel(false, 1f));
        //        //    MenuUIController.Instance.OpenUpdatePanel();
        //        //    LocalDatas.Instance.canRotateObject = false;
        //        //}
        //    }
        //    else
        //    {
        //        Debug.Log("not successfull");
        //        SceneManager.LoadScene(1);
        //    }
        //});
    }

    public IEnumerator CheckInternetConnection()
    {
        // UnityWebRequest request = new UnityWebRequest("http://google.com");
        // yield return request.SendWebRequest();

        WWW w = new WWW("http://google.com");
        yield return w;

        if (w.error != null) // there is no internet
        {
            MenuUIController.Instance.OpenTryAgainPanel();
        }
        //else // there is internet
        //{

        //}
    }

    IEnumerator SetLoadingPanel(float _delayTime)
    {
        yield return null;
        //yield return new WaitForSeconds(_delayTime);
        //if (!PhotonNetwork.IsConnected)
        //{
        //    //LocalDatas.Instance.DebugToUI("\n67\n");
        //    Debug.Log("Connecting to Photon Network Master.");
        //    PhotonNetwork.GameVersion = "0.0.1";
        //    PhotonNetwork.ConnectUsingSettings();
        //}

        yield return new WaitForSeconds(_delayTime);
        if (MenuCommonObjects.Instance.loadingPanel != null) LocalDatas.Instance.SetLoadingPanelWithTweening();

    }

    public void SetFirstNickPanel_void(bool setActive)
    {
        Debug.Log("Setting firstNickPanel: " + setActive);
        //LocalDatas.Instance.isInMainMenu = !setActive;
        MenuUIController.Instance.CheckIfInMenu();
        LocalDatas.Instance.Sed3dObjectParent(!setActive);

        CreateNickNamePanel.SetActive(setActive);
        MenuCommonObjects.Instance.loadingPanel.SetActive(false);

    }

    public IEnumerator ShowCongratsPanel()
    {
        yield return null;
        Debug.Log("Startting congrats panel ... ");
        AudioManager.Instance.Play(4);
        OpenCongratsPanel();

        SetNotificationIconsInMenu(-1);
        SetOrangeIconsInVFXPanel(-1);
        SetOrangeIconsInCharactersPanel(-1);

        //SScoin
        prize1Text.text = SomeDatas.Instance.ssCoinPerLevel[Settings.User.level - 1].ToString("n0");
        Settings.User.ssCoin += SomeDatas.Instance.ssCoinPerLevel[Settings.User.level - 1];

        // Diamond coin
        prize2Text.text = Settings.User.level.ToString();
        Settings.User.ssCoin += Settings.User.level;

        // Character, vfx, skill opened
        if ((Settings.User.level + 1) % 5 == 0)
        {
            // TODO NEW VFX, CHARACTER, SKILL
            if ( CheckWhatIsPrize() ==  0) // character prize
            {
                prize3Text.text = "New Character!!!";
                Debug.Log("New ch: " + WhatIsCharacterPrize());
                SetNotificationIconsInMenu(0);
                SetOrangeIconsInCharactersPanel( WhatIsCharacterPrize() );
                prizeCharacterIndex = WhatIsCharacterPrize();
                Utils.SetCharAtIndex(ref Settings.User.characters, prizeCharacterIndex, '1');
                MenuUIController.Instance.SetToUI();
            }
            else if (CheckWhatIsPrize() == 1) // VFX prize
            {
                prize3Text.text = "New VFX!!!";
                SetNotificationIconsInMenu(1);
                SetOrangeIconsInVFXPanel(WhatIsVFXPrize());
                prizeVFXIndex = WhatIsVFXPrize();
                Utils.SetCharAtIndex(ref Settings.User.vfxs, prizeVFXIndex, '1');
                MenuUIController.Instance.SetToUI();
            }
            prize3Object.gameObject.SetActive(true);
        }
        else
        {
            prize3Object.gameObject.SetActive(false);
        }

        congratsLevelText.text = (Settings.User.level + 1).ToString();

        Settings.User.xp -= SomeDatas.Instance.xpPerLevel[Settings.User.level - 1];
        Settings.User.level++;
        LocalDatas.Instance.currentLevelIntervalIndex = LocalDatas.Instance.SetLevelIntervalIndex();
        LocalDatas.Instance.SetLevelIntervalIndexForCharacter();

        MenuUIController.Instance.SetToUI();
        SaveLoadManager.Save(Settings.User);

        LocalDatas.Instance.OpenPanel1();

        if (!PhotonNetwork.IsConnectedAndReady)
        {
            Debug.Log("Connecting to Photon Network Master.");
            PhotonNetwork.GameVersion = "0.0.1";
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            Debug.Log("Already in lobby");
            if (MenuCommonObjects.Instance.loadingSlider != null) MenuUIController.Instance.SetSliderWithTweening(0.5f, 1f);
            StartCoroutine(SetLoadingPanel(1f));
        }

    }

    int CheckWhatIsPrize()
    {
        int res = -1;
        // TODO length , 8
        for (int i = 0; i < 2; i++)
        {
            if (SomeDatas.Instance.prizes[(Settings.User.level + 1) / 5 - 1, i] == 1)
            {
                res = i;
                return res;
            }
        }
        return res;
    }

    int WhatIsCharacterPrize()
    {
        int res = -1;
        for (int i = 0; i < SomeDatas.Instance.characterNames.Length; i++)
        {
            if (Settings.User.characters[i] == '0')
            {
                res = i;
                return res;
            }
        }
        return res;
    
    }

    int WhatIsVFXPrize()
    {
        int res = -1;
        for (int i = 0; i < SomeDatas.Instance.ballPrices.Length; i++)
        {
            if (Settings.User.vfxs[i] == '0')
            {
                res = i;
                return res;
            }
        }
        return res;

    }

    public void SetFirstNickName(TMP_InputField nickNameInputfield)
    {
        Settings.User.nickName = nickNameInputfield.text;
        SaveLoadManager.Save(Settings.User);
    }

    public void SetNotificationIconsInMenu(int index)
    {
        for (int i = 0; i < notificationImagesInMenuButtons.Length; i++)
        {
            if (i == index)
            {
                notificationImagesInMenuButtons[i].SetActive(true);
            }
            else
            {
                notificationImagesInMenuButtons[i].SetActive(false);
            }
        }
    }

    public void SetOrangeIconsInVFXPanel(int index)
    {
        for (int i = 0; i < orangeImagesInVFXPanel.Length; i++)
        {
            if (i == index)
            {
                orangeImagesInVFXPanel[i].SetActive(true);
            }
            else
            {
                orangeImagesInVFXPanel[i].SetActive(false);
            }
        }
        if (index == -1)
        {
            prizeVFXIndex = -1;
        }
    }

    public void SetOrangeIconsInCharactersPanel(int index)
    {
        for (int i = 0; i < orangeImagesInCharacterPanel.Length; i++)
        {
            if (i == index)
            {
                orangeImagesInCharacterPanel[i].SetActive(true);
            }
            else
            {
                orangeImagesInCharacterPanel[i].SetActive(false);
            }
        }
        if (index == -1)
        {
            prizeCharacterIndex = -1;
        }
    }

    public bool CheckIfAllOrangesOffSkillRunner()
    {
        int s = 0;
        for (int i = 0; i < 10; i++)
        {
            if (!orangeImagesInSkillPanelRunner[i].activeInHierarchy)
            {
                s++;
            }
        }
        if (s == 10)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CheckIfAllOrangesOffSkillCatcher()
    {
        int s = 0;
        for (int i = 0; i < 9; i++)
        {
            if (!orangeImagesInSkillPanelCatcher[i].activeInHierarchy)
            {
                s++;
            }
        }
        if (s == 9)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void OpenCongratsPanel()
    {
        LeanTween.alpha(congratsPanel.GetComponent<RectTransform>(), 1f, 0.1f).setEase(LeanTweenType.pingPong);
        congratsPanel.GetComponent<Image>().raycastTarget = true;
        congratsPanelChild.SetActive(true);
    }

    public void CloseCongratsPanel()
    {
        LeanTween.alpha(congratsPanel.GetComponent<RectTransform>(), 0f, 0.1f).setEase(LeanTweenType.pingPong);
        congratsPanel.GetComponent<Image>().raycastTarget = false;
        congratsPanelChild.SetActive(false);
    }
}
