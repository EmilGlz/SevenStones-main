using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using UnityEngine.Networking;



public class FirebaseController : MonoBehaviour
{
    DatabaseReference reference;
    [SerializeField] TMP_InputField username;
    [SerializeField] TMP_InputField email;
    [SerializeField] TMP_InputField nametoread;
    //[SerializeField] TMP_Text data;

    public GameObject CreateNickNamePanel;
    // [SerializeField] GameObject loadingPanel;

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
    //public bool readingFinished = false;

    [SerializeField] TMP_Text[] characterNamesInCharacterPanel;

    public int prizeVFXIndex = -1;
    public int prizeCharacterIndex = -1;
    public int prizeSkillIndex = -1;

    public GameObject noInternetImage;

    //[SerializeField] GameObject

    const string profilePicIndex = "ppi";
    const string characterIndex = "ci";
    const string vfxIndex = "vfxi";
    const string mapIndex = "mi";



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


    // Start is called before the first frame update
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void TestHundredSave()
    {
        for (int i = 0; i < 1000; i++)
        {
            user.userId = i.ToString();
            SaveData();
        }
    }

    public void SetLocalDatasToUserObject()
    {
        user.userId = LocalDatas.Instance.userID;
        user.nickName = LocalDatas.Instance.nickName;
        user.level = LocalDatas.Instance.level;
        user.xp = LocalDatas.Instance.xp;
        user.ssCoin = LocalDatas.Instance.ssCoin;
        user.starCoin = LocalDatas.Instance.crystalCoin;


        user.gs.generalWin = LocalDatas.Instance.generalWin;
        user.gs.generalLose = LocalDatas.Instance.generalLose;
        user.gs.generalMVP = LocalDatas.Instance.generalMVPCount;
        user.gs.generalStone = LocalDatas.Instance.generalStone;
        user.gs.generalKill = LocalDatas.Instance.generalKill;
        user.gs.generalShot = LocalDatas.Instance.generalShot;
        user.gs.generalEndurance = LocalDatas.Instance.generalEndurance;

        user.rs.rSpeedLevel = LocalDatas.Instance.runnerSpeedLevel;
        user.rs.rShieldLevel = LocalDatas.Instance.runnerShieldLevel;
        user.rs.rInvisibilityLevel = LocalDatas.Instance.runnerInvisibilityLevel;
        user.rs.rAddHealth = LocalDatas.Instance.runnerAddHealth;
        user.rs.rTrapLevel = LocalDatas.Instance.runnerTrapLevel;
        user.rs.rSDTLevel = LocalDatas.Instance.runnerSlowdownTrapLevel;
        user.rs.rTopViewLevel = LocalDatas.Instance.runnerTopViewLevel;
        user.rs.rWallLevel = LocalDatas.Instance.runnerWallLevel;
        user.rs.rHookLevel = LocalDatas.Instance.runnerHookLevel;
        user.rs.rBCLevel = LocalDatas.Instance.runnerBCLevel;

        user.cs.cSpeedLevel = LocalDatas.Instance.catcherSpeedLevel;
        //user.cs.cShieldLevel = LocalDatas.Instance.catcherShieldLevel;
        user.cs.cInvisibilityLevel = LocalDatas.Instance.catcherInvisibilityLevel;
        user.cs.cBallLevel = LocalDatas.Instance.catcherBallLevel;
        user.cs.cSDTlevel = LocalDatas.Instance.catcherSlowdownTrapLevel;
        user.cs.cTopViewLevel = LocalDatas.Instance.catcherTopViewLevel;
        user.cs.cWallLevel = LocalDatas.Instance.catcherWallLevel;
        user.cs.cHookLevel = LocalDatas.Instance.catcherHookLevel;
        user.cs.cDHLevel = LocalDatas.Instance.catcherDeadlyHitLevel;
        user.cs.cBCLevel = LocalDatas.Instance.catcherBCLevel;



        user.characters = "";
        for (int i = 0; i < LocalDatas.Instance.characters.Length; i++)
        {
            user.characters += LocalDatas.Instance.characters[i];
        }

        user.vfxs = "";
        for (int i = 0; i < LocalDatas.Instance.ballSkins.Length; i++)
        {
            user.vfxs += LocalDatas.Instance.ballSkins[i];
        }

        user.arenas = "";
        for (int i = 0; i < LocalDatas.Instance.arenas.Length; i++)
        {
            user.arenas += LocalDatas.Instance.arenas[i];
        }


    }

    //public void Save()
    //{
    //    string json = JsonUtility.ToJson(v);

    //    reference.Child("Version").SetRawJsonValueAsync(json).ContinueWithOnMainThread(task =>
    //    {
    //        if (task.IsCompleted)
    //        {
    //            Debug.Log("successfully added data to firebase");
    //        }
    //        else
    //        {
    //            Debug.Log("Failed to add to firebase");
    //        }
    //    });
    //}


    public void SaveData()
    {

        SetLocalDatasToUserObject();

        if (user.userId.Equals(null) || user.userId.Equals(""))
        {
            user.userId = "VirtualIllusions";
        }

        string json = JsonUtility.ToJson(user);



        reference.Child("Users").Child(user.userId).SetRawJsonValueAsync(json).ContinueWithOnMainThread(task =>
        {
          if (task.IsCompleted)
          {
              Debug.Log("successfully added data to firebase");

              // if it is firstNickNamePanel, then diable it
              if (CreateNickNamePanel.activeInHierarchy)
              {
                  StartCoroutine(SetFirstNickNamePanel(false));
              }
              StartCoroutine(SetToUI()); // wait for one frame, then add to UI
              SpecialData.Instance.user = user;
              Debug.Log("successfully added to UI");
          }
          else
          {
              Debug.Log("not successfull");

          }
      });
    }


    public void ReadData(string playerID)
    {

        //StartCoroutine(ReadVersion());

        StartCoroutine(CheckInternetConnection());


        Debug.Log("ReadData()");
        reference.Child("Version").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("Reading");
                DataSnapshot snapshot = task.Result;
                gameVersionMustBe = int.Parse(snapshot.Child("version").Value.ToString());
                Debug.Log("Version: " + gameVersionMustBe);


                // if game version is good
                if (LocalDatas.Instance.currentVersion == gameVersionMustBe)
                {
                    Debug.Log("reading user datas line 238");
                    ReadUserDatas(playerID);
                }
                else
                {
                    // Update Panel
                    Debug.Log("Needs update");
                    MenuUIController.Instance.OpenUpdatePanel();
                }

            }
            else
            {
                Debug.Log("ERROR");
            }
        });



    }

    private void ReadUserDatas(string playerID)
    {
        Debug.Log("ReadUserDatas()");
        reference.Child("Users").Child(playerID).GetValueAsync().ContinueWithOnMainThread(task =>
        {

            if (task.IsCompleted)
            {
                Debug.Log("Reading datas...");

                DataSnapshot snapshot = task.Result;




                if (!snapshot.Exists)
                {
                    // TODO Tuto panel ...
                    //StartCoroutine(SetFirstNickNamePanel(true));
                    MenuUIController.Instance.OpenTutorialPanel();
                    LocalDatas.Instance.currentCharacterIndex = 0;
                    LocalDatas.Instance.ResetLocalDatas();
                    StartCoroutine(SetLoadingPanel(1f));
                    Debug.Log("Does not exist");
                }
                else
                {

                    #region setting db datas to datas

                    string _nick = snapshot.Child("nickName").Value.ToString();
                    Debug.Log("nick done!");
                    int _lvl = int.Parse(snapshot.Child("level").Value.ToString());
                    int _xp = int.Parse(snapshot.Child("xp").Value.ToString());
                    int _ssCoin = int.Parse(snapshot.Child("ssCoin").Value.ToString());
                    int _starCoin = int.Parse(snapshot.Child("starCoin").Value.ToString());
                    Debug.Log("nick zad done!");

                    int[] generals = new int[7];
                    generals[0] = int.Parse(snapshot.Child("gs").Child("generalWin").Value.ToString());
                    generals[1] = int.Parse(snapshot.Child("gs").Child("generalLose").Value.ToString());
                    generals[2] = int.Parse(snapshot.Child("gs").Child("generalMVP").Value.ToString());
                    generals[3] = int.Parse(snapshot.Child("gs").Child("generalStone").Value.ToString());
                    generals[4] = int.Parse(snapshot.Child("gs").Child("generalKill").Value.ToString());
                    generals[5] = int.Parse(snapshot.Child("gs").Child("generalShot").Value.ToString());
                    generals[6] = int.Parse(snapshot.Child("gs").Child("generalEndurance").Value.ToString());
                    Debug.Log("generals done!");

                    int[] runnerSkills = new int[10];
                    runnerSkills[0] = int.Parse(snapshot.Child("rs").Child("rSpeedLevel").Value.ToString());
                    runnerSkills[2] = int.Parse(snapshot.Child("rs").Child("rShieldLevel").Value.ToString());
                    runnerSkills[4] = int.Parse(snapshot.Child("rs").Child("rInvisibilityLevel").Value.ToString());
                    runnerSkills[1] = int.Parse(snapshot.Child("rs").Child("rAddHealth").Value.ToString());
                    runnerSkills[3] = int.Parse(snapshot.Child("rs").Child("rTrapLevel").Value.ToString());
                    runnerSkills[5] = int.Parse(snapshot.Child("rs").Child("rSDTLevel").Value.ToString());
                    runnerSkills[6] = int.Parse(snapshot.Child("rs").Child("rTopViewLevel").Value.ToString());
                    runnerSkills[7] = int.Parse(snapshot.Child("rs").Child("rWallLevel").Value.ToString());
                    runnerSkills[8] = int.Parse(snapshot.Child("rs").Child("rHookLevel").Value.ToString());
                    runnerSkills[9] = int.Parse(snapshot.Child("rs").Child("rBCLevel").Value.ToString());
                    Debug.Log("runner skills done!");

                    int[] catcherSkills = new int[10];
                    catcherSkills[0] = int.Parse(snapshot.Child("cs").Child("cSpeedLevel").Value.ToString());
                    //catcherSkills[1] = int.Parse(snapshot.Child("cs").Child("cShieldLevel").Value.ToString());
                    catcherSkills[2] = int.Parse(snapshot.Child("cs").Child("cInvisibilityLevel").Value.ToString());
                    catcherSkills[3] = int.Parse(snapshot.Child("cs").Child("cBallLevel").Value.ToString());
                    catcherSkills[4] = int.Parse(snapshot.Child("cs").Child("cSDTlevel").Value.ToString());
                    catcherSkills[5] = int.Parse(snapshot.Child("cs").Child("cTopViewLevel").Value.ToString());
                    catcherSkills[6] = int.Parse(snapshot.Child("cs").Child("cWallLevel").Value.ToString());
                    catcherSkills[7] = int.Parse(snapshot.Child("cs").Child("cHookLevel").Value.ToString());
                    catcherSkills[8] = int.Parse(snapshot.Child("cs").Child("cDHLevel").Value.ToString());
                    catcherSkills[9] = int.Parse(snapshot.Child("cs").Child("cBCLevel").Value.ToString());
                    Debug.Log("catcher skills done!");


                    string _chs = snapshot.Child("characters").Value.ToString();
                    string _vfxs = snapshot.Child("vfxs").Value.ToString();
                    string _maps = snapshot.Child("arenas").Value.ToString();
                    Debug.Log("all skills done!");
                    #endregion
                    MenuUIController.Instance.CloseTutorialPanel();
                    // StartCoroutine(SetFirstNickNamePanel(false));
                    SetToUserObject(playerID, _nick, _lvl, _xp, _ssCoin, _starCoin, generals, runnerSkills, catcherSkills, _chs, _vfxs, _maps);

                    LocalDatas.Instance.SetDatasToLocalDatas(playerID, _nick, _lvl, _xp, _ssCoin, _starCoin, generals, runnerSkills, catcherSkills, _chs, _vfxs, _maps);

                    if (LocalDatas.Instance.xp >= SomeDatas.Instance.xpPerLevel[LocalDatas.Instance.level - 1])
                    {
                        //TODO LevelUp sound
                        Debug.Log("Level up");

                        StartCoroutine(ShowCongratsPanel());

                        AudioManager.Instance.Play(0);

                        return;
                    }
                    
                    SpecialData.Instance.user = user;
                    //SpecialData.Instance.firstTime = false;

                    StartCoroutine(SetToUI()); // wait for one frame, then add to UI

                    if (MenuCommonObjects.Instance.loadingSlider != null) MenuUIController.Instance.SetSliderWithTweening(0.3f, 0.5f);

                }

                Debug.Log("Reading done!");
                AudioManager.Instance.Play(0);
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
                //// If Version is good
                //if (int.Parse(snapshot.Child("version").Value.ToString()) == gameVersionMustBe)
                //{
                //    if (!PhotonNetwork.IsConnectedAndReady)
                //    {
                //        Debug.Log("Connecting to Photon Network Master.");
                //        PhotonNetwork.GameVersion = "0.0.1";
                //        PhotonNetwork.ConnectUsingSettings();
                //    }
                //    else
                //    {
                //        Debug.Log("Already in lobby");
                //        if (MenuCommonObjects.Instance.loadingSlider != null) MenuUIController.Instance.SetSliderWithTweening(0.5f, 1f);
                //        StartCoroutine(SetLoadingPanel(false, 1f));
                //    }
                //}
                //// If it must be updated
                //else
                //{
                //    Debug.Log("Must be updated");
                //    StartCoroutine(SetLoadingPanel(false, 1f));
                //    MenuUIController.Instance.OpenUpdatePanel();
                //    LocalDatas.Instance.canRotateObject = false;
                //}
            }
            else
            {
                Debug.Log("not successfull");
                SceneManager.LoadScene(1);
            }
        });
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

    public void AddXPTest(int addingXP)
    {
        LocalDatas.Instance.xp += addingXP;
        if (LocalDatas.Instance.xp >= SomeDatas.Instance.xpPerLevel[LocalDatas.Instance.level - 1])
        {
            //_xp = _xp - SomeDatas.Instance.xpPerLevel[LocalDatas.Instance.currentLevelIntervalIndex];
            //_lvl++;
            LocalDatas.Instance.xp -= SomeDatas.Instance.xpPerLevel[LocalDatas.Instance.level - 1];
            LocalDatas.Instance.level++;
        }
        SaveData();
    }
    private void SetToUserObject(string _id, string _nick, int _lvl, int _xp, int _ssCoin, int _starCoin, int[] generals, int[] runnerSkills, int[] catcherSkills, string _chs, string _vfxs, string _arenas)
    {
        user.userId = _id;
        user.nickName = _nick;
        user.level = _lvl;
        user.xp = _xp;
        user.ssCoin = _ssCoin;
        user.starCoin = _starCoin;

        user.gs.generalWin = generals[0];
        user.gs.generalLose = generals[1];
        user.gs.generalMVP = generals[2];
        user.gs.generalStone = generals[3];
        user.gs.generalKill = generals[4];
        user.gs.generalShot = generals[5];
        user.gs.generalEndurance = generals[6];

        user.rs.rSpeedLevel = runnerSkills[0];
        user.rs.rAddHealth = runnerSkills[1];
        user.rs.rShieldLevel = runnerSkills[2];
        user.rs.rTrapLevel = runnerSkills[3];
        user.rs.rInvisibilityLevel = runnerSkills[4];
        user.rs.rSDTLevel = runnerSkills[5];
        user.rs.rTopViewLevel = runnerSkills[6];
        user.rs.rWallLevel = runnerSkills[7];
        user.rs.rHookLevel = runnerSkills[8];
        user.rs.rBCLevel = runnerSkills[9];

        user.cs.cSpeedLevel = catcherSkills[0];
        //user.cs.cShieldLevel = catcherSkills[1];
        user.cs.cInvisibilityLevel = catcherSkills[2];
        user.cs.cBallLevel = catcherSkills[3];
        user.cs.cSDTlevel = catcherSkills[4];
        user.cs.cTopViewLevel = catcherSkills[5];
        user.cs.cWallLevel = catcherSkills[6];
        user.cs.cHookLevel = catcherSkills[7];
        user.cs.cDHLevel = catcherSkills[8];
        user.cs.cBCLevel = catcherSkills[9];

        user.characters = _chs;
        user.vfxs = _vfxs;
        user.arenas = _arenas;
    }

    public IEnumerator SetFirstNickNamePanel(bool setActive)
    {
        yield return null;
        Debug.Log("Setting firstNickPanel: " + setActive);
        MenuUIController.Instance.CheckIfInMenu();

        if (LocalDatas.Instance.isInMainMenu)
        {
            LocalDatas.Instance.Sed3dObjectParent(!setActive);
        }
        else
        {
            LocalDatas.Instance.Sed3dObjectParent(false);
        }

        CreateNickNamePanel.SetActive(setActive);
        MenuCommonObjects.Instance.loadingPanel.SetActive(false);

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

    //IEnumerator SetToUIBeforeReading()
    //{
    //    yield return null;
    //    SetNotificationIconsInMenu(-1);
    //    SetOrangeIconsInVFXPanel(-1);
    //    SetOrangeIconsInCharactersPanel(-1);
    //}

    IEnumerator SetToUI()
    {
        yield return null;
        Debug.Log("Starting Setting To UI");
        LocalDatas.Instance.currentCharacterIndex = PlayerPrefs.GetInt(characterIndex);
        LocalDatas.Instance.currentBallSkinIndex = PlayerPrefs.GetInt(vfxIndex);
        LocalDatas.Instance.currentMapIndex = (byte)PlayerPrefs.GetInt(mapIndex);

        for (int i = 0; i < SomeDatas.Instance.characterNames.Length; i++)
        {
            characterNamesInCharacterPanel[i].text = SomeDatas.Instance.characterNames[i];
        }


        if (LocalDatas.Instance.characters[LocalDatas.Instance.currentCharacterIndex] == 0)
        {
            // changing character to index 0
            PlayerPrefs.SetInt(characterIndex, 0);
            LocalDatas.Instance.currentCharacterIndex = 0;
        }

        if (LocalDatas.Instance.ballSkins[LocalDatas.Instance.currentBallSkinIndex] == 0)
        {
            PlayerPrefs.SetInt(vfxIndex, 0);
            LocalDatas.Instance.currentBallSkinIndex = 0;
        }

        if (LocalDatas.Instance.arenas[LocalDatas.Instance.currentMapIndex] == 0)
        {
            PlayerPrefs.SetInt(mapIndex, 0);
            LocalDatas.Instance.currentMapIndex = 0;
        }

        LocalDatas.Instance.ChangeAllPPs(PlayerPrefs.GetInt(profilePicIndex));
        LocalDatas.Instance.SetSkillLevelsToArray();
        MenuUIController.Instance.CheckIfInMenu();
        if (LocalDatas.Instance.isInMainMenu)
        {
            LocalDatas.Instance.Sed3dObjectParent(true);
            LocalDatas.Instance.SetCharacterObject(PlayerPrefs.GetInt(characterIndex));
            MenuUIController.Instance.characterNameInPlayPanel.text = SomeDatas.Instance.characterNames[LocalDatas.Instance.currentCharacterIndex].ToString();
        }
        else
        {
            LocalDatas.Instance.SetCharacterObject(PlayerPrefs.GetInt(characterIndex));
            MenuUIController.Instance.characterNameInPlayPanel.text = SomeDatas.Instance.characterNames[LocalDatas.Instance.currentCharacterIndex].ToString();
        }
        SetArenaDatasToUI();
        MenuUIController.Instance.SetCoinsPrices();
        LocalDatas.Instance.SetAllLocalDatasToUI();
        //MenuCommonObjects.Instance.loadingPanel.SetActive(false);
        StartCoroutine(LocalDatas.Instance.SetSkillButtonsPlayPanelCatcher() );
        StartCoroutine(LocalDatas.Instance.SetSkillButtonsPlayPanelRunner() );
        Debug.Log("Setting to UI finished");
    }

    private void SetArenaDatasToUI()
    {
        for (int i = 0; i < arenaPriceTexts.Length; i++)
        {
            arenaPriceTexts[i].text = SomeDatas.Instance.arenaPrices[i].ToString();
            // if arena[i] = 0, arenaPriceTextPanels.setFalse.
            if (LocalDatas.Instance.arenas[i] == 0)
            {
                arenaPriceTextPanels[i].SetActive(true);
                selectTextsInArenaButtons[i].gameObject.SetActive(false);
            }
            else
            {
                arenaPriceTextPanels[i].SetActive(false);
                selectTextsInArenaButtons[i].gameObject.SetActive(true);
                if (LocalDatas.Instance.currentMapIndex == i)
                {
                    selectTextsInArenaButtons[i].text = "Selected";
                }
                else
                {
                    selectTextsInArenaButtons[i].text = "Select";
                }

            }
        }
    }

    IEnumerator ShowCongratsPanel()
    {
        yield return null;
        Debug.Log("Startting congrats panel ... ");
        AudioManager.Instance.Play(4);
        OpenCongratsPanel();

        SetNotificationIconsInMenu(-1);
        SetOrangeIconsInVFXPanel(-1);
        SetOrangeIconsInCharactersPanel(-1);

        //SScoin
        prize1Text.text = SomeDatas.Instance.ssCoinPerLevel[LocalDatas.Instance.level - 1].ToString("n0");
        LocalDatas.Instance.ssCoin += SomeDatas.Instance.ssCoinPerLevel[LocalDatas.Instance.level - 1];

        // Diamond coin
        prize2Text.text = LocalDatas.Instance.level.ToString();
        LocalDatas.Instance.crystalCoin += LocalDatas.Instance.level;

        // Character, vfx, skill opened
        if ((LocalDatas.Instance.level + 1) % 5 == 0)
        {
            // TODO NEW VFX, CHARACTER, SKILL
            if ( CheckWhatIsPrize() ==  0) // character prize
            {
                prize3Text.text = "New Character!!!";
                Debug.Log("New ch: " + WhatIsCharacterPrize());
                SetNotificationIconsInMenu(0);
                SetOrangeIconsInCharactersPanel( WhatIsCharacterPrize() );
                prizeCharacterIndex = WhatIsCharacterPrize();
                LocalDatas.Instance.characters[prizeCharacterIndex] = 1;
            }
            else if (CheckWhatIsPrize() == 1) // VFX prize
            {
                prize3Text.text = "New VFX!!!";
                SetNotificationIconsInMenu(1);
                SetOrangeIconsInVFXPanel(WhatIsVFXPrize());
                prizeVFXIndex = WhatIsVFXPrize();
                LocalDatas.Instance.ballSkins[prizeVFXIndex] = 1;
            }
            prize3Object.gameObject.SetActive(true);
        }
        else
        {
            prize3Object.gameObject.SetActive(false);
        }

        congratsLevelText.text = (LocalDatas.Instance.level + 1).ToString();

        LocalDatas.Instance.xp -= SomeDatas.Instance.xpPerLevel[LocalDatas.Instance.level - 1];
        LocalDatas.Instance.level++;
        LocalDatas.Instance.currentLevelIntervalIndex = LocalDatas.Instance.SetLevelIntervalIndex();
        LocalDatas.Instance.SetLevelIntervalIndexForCharacter();


        SaveData();

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
            if (SomeDatas.Instance.prizes[(LocalDatas.Instance.level + 1) / 5 - 1, i] == 1)
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
            if (LocalDatas.Instance.characters[i] == 0)
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
            if (LocalDatas.Instance.ballSkins[i] == 0)
            {
                res = i;
                return res;
            }
        }
        return res;

    }

    public void SetFirstNickName(TMP_InputField nickNameInputfield)
    {
        LocalDatas.Instance.nickName = nickNameInputfield.text;
        SaveData();
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

    //public void SetOrangeIconsInSkillsPanelRunner(int index, bool setActive)
    //{
    //    if (index != -1)
    //    {
    //        orangeImagesInSkillPanelRunner[index].SetActive(setActive);
    //    }
    //    else
    //    {
    //        for (int i = 0; i < orangeImagesInSkillPanelRunner.Length; i++)
    //        {
    //            orangeImagesInSkillPanelRunner[i].SetActive(setActive);
    //        }
    //    }
    //}

    //public void SetOrangeIconsInSkillsPanelCatcher(int index, bool setActive)
    //{
    //    if (index != -1)
    //    {
    //        orangeImagesInSkillPanelCatcher[index].SetActive(setActive);
    //    }
    //    else
    //    {
    //        for (int i = 0; i < orangeImagesInSkillPanelCatcher.Length; i++)
    //        {
    //            orangeImagesInSkillPanelCatcher[i].SetActive(setActive);
    //        }
    //    }
    //}

    //public void SetOrangeIconsInSkillsCatcherRunner(int index, bool setActive) // 0-runner , 1-catcher
    //{
    //    if (index == 0)
    //    {
    //        orangeIconsInRunnerCatcherButtonsSkills[0].SetActive(setActive);
    //    }
    //    else if (index == 1)
    //    {
    //        orangeIconsInRunnerCatcherButtonsSkills[1].SetActive(setActive);
    //    }
    //    else
    //    {
    //        orangeIconsInRunnerCatcherButtonsSkills[0].SetActive(setActive);
    //        orangeIconsInRunnerCatcherButtonsSkills[1].SetActive(setActive);
    //    }
    //}

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

    public void RandomTest()
    {
        user.nickName = "Player" + Random.Range(0,100);
        user.level = Random.Range(0,25);
        user.xp = Random.Range(0,250);
        user.ssCoin = Random.Range(0,250);
        user.starCoin = Random.Range(0,250);
    }
}
