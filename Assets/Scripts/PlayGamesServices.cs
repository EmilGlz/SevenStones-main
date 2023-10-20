using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;
using TMPro;

//using Photon.Pun;

public class PlayGamesServices : MonoBehaviour
{
    [SerializeField] Text debugtext;

    [SerializeField] Sprite OnButtonSprite;
    [SerializeField] Sprite OffButtonSprite;
    [SerializeField] GameObject playGamesButton;
    [SerializeField] TMP_Text playGamesOnOffText;

    string currentID = "";

    const string profilePicIndex = "ppi";
    const string characterIndex = "ci";
    const string vfxIndex = "vfxi";
    const string mapIndex = "mi";



    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.Stop(8);

        StartCoroutine(CheckInternetConnection());

    }

    public IEnumerator CheckInternetConnection()
    {
        //UnityWebRequest request = new UnityWebRequest("http://google.com");
        //yield return request.SendWebRequest();
        
        WWW w = new WWW("http://google.com");
        yield return w;

        //if (request.error != null) // there is no internet
        if (w.error != null) // there is no internet
        {
            Debug.Log("No internet");
            MenuUIController.Instance.OpenTryAgainPanel();
        }
        else // there is internet
        {
            Debug.Log("Yes internet");
            
            //FirebaseController.Instance.noInternetImage.SetActive(false);

            if (SpecialData.Instance.firstTime)
            {
                Initialize();
                //SpecialData.Instance.firstTime = false;
            }
            else // FROM GAME TO MENU
            {
                Debug.Log("From game to menu");
                if (Social.localUser.authenticated)
                {
                    Debug.Log("Authenticated");
                    playGamesButton.GetComponent<Image>().sprite = OnButtonSprite;
                    playGamesOnOffText.text = "Connected";

                    LocalDatas.Instance.userID = Social.localUser.id;
                    // Debug.Log("Social  ID: " + Social.localUser.id);
                    // Debug.Log("Special ID: " + SpecialData.Instance.user.userId);
                    // Debug.Log("LocalDatas ID: " + LocalDatas.Instance.userID);
                    FirebaseController.Instance.ReadData(SpecialData.Instance.user.userId);
                }
                else
                {
                    playGamesButton.GetComponent<Image>().sprite = OffButtonSprite;
                    playGamesOnOffText.text = "Disconnected";
                    SignInWithPlayGames();
                }
            }


        }

    }

    public void SignInOutPressed()
    {
        if (Social.localUser.authenticated)
        {
            SignOut();
            playGamesButton.GetComponent<Image>().sprite = OffButtonSprite;
            playGamesOnOffText.text = "Disconnected";
            SignInWithPlayGames();
        }
        else
        {
            SignInWithPlayGames();
        }
    }

    public void SignOut()
    {
        currentID = Social.localUser.id;
        //PlayerPrefs.SetInt("IsLogged", 0);
        //PlayGamesPlatform.Instance.SignOut();
    }

    public void Initialize()
    {
        //PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
        //    .RequestServerAuthCode(false).
        //    Build();
        //PlayGamesPlatform.InitializeInstance(config);
        //PlayGamesPlatform.DebugLogEnabled = true;
        //PlayGamesPlatform.Activate();
        debugtext.text += "\nplaygames initialized";
        Debug.Log("playgames initialized");
        SignInWithPlayGames();
    }

    void SignInWithPlayGames()
    {
        //PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptAlways, (success) =>
        //{
        //    switch (success)
        //    {
        //        case SignInStatus.Success:
        //            if (currentID != "" && currentID != Social.localUser.id )
        //            {
        //                // signed in to different acc
        //                LocalDatas.Instance.currentBallSkinIndex = 0;
        //                LocalDatas.Instance.currentCharacterIndex = 0;
        //                LocalDatas.Instance.currentMapIndex = 0;

        //                PlayerPrefs.SetInt(characterIndex, 0);
        //                PlayerPrefs.SetInt(profilePicIndex, 0);
        //                PlayerPrefs.SetInt(vfxIndex, 0);
        //                PlayerPrefs.SetInt(mapIndex, 0);
        //            }

        //            playGamesButton.GetComponent<Image>().sprite = OnButtonSprite;

        //            LocalDatas.Instance.userID = Social.localUser.id;

        //            if (MenuCommonObjects.Instance.loadingSlider != null) MenuUIController.Instance.SetSliderWithTweening(0f, 0.3f);


        //            FirebaseController.Instance.ReadData(Social.localUser.id);


        //            break;
        //        default:
        //            // Not succesfull
        //            break;
        //    }
        //});
    }

    //public void RefreshTest()
    //{
    //    datas[0] = "";
    //    debugtext.text += "\n------------------------------------------------------------------------------";
    //    debugtext.text += "\ndata[0] =_" + datas[0].ToString() + "_";
    //    datas[5] = "0,0,0,0,0,0,0,"; // 7 times
    //    datas[6] = "0,0,0,0,0,"; // 5 times
    //    datas[7] = "0,0,0,0,"; // 4 times
    //    datas[8] = "11000000000000";
    //    datas[9] = "110000000000000";
    //    datas[10] = "0000";

    //    LocalDatas.Instance.nickName = "";
    //    LocalDatas.Instance.DebugToUI("\nLocaldatas Nickname: " + LocalDatas.Instance.nickName + "\n");
    //    LocalDatas.Instance.level = 1;
    //    LocalDatas.Instance.xp = 0;
    //    LocalDatas.Instance.ssCoin = 0;
    //    LocalDatas.Instance.crystalCoin = 0;

    //    LocalDatas.Instance.generalWin = 0;
    //    LocalDatas.Instance.generalLose = 0;
    //    LocalDatas.Instance.generalMVPCount = 0;
    //    LocalDatas.Instance.generalStone = 0;
    //    LocalDatas.Instance.generalKill= 0;
    //    LocalDatas.Instance.generalShot = 0;
    //    LocalDatas.Instance.generalEndurance = 0;

    //    LocalDatas.Instance.runnerSpeedLevel = 0;
    //    LocalDatas.Instance.runnerShieldLevel = 0;
    //    LocalDatas.Instance.runnerInvisibilityLevel = 0;
    //    LocalDatas.Instance.runnerAddHealth = 0;
    //    LocalDatas.Instance.runnerTrapLevel = 0;

    //    LocalDatas.Instance.catcherSpeedLevel = 0;
    //    LocalDatas.Instance.catcherShieldLevel = 0;
    //    LocalDatas.Instance.catcherInvisibilityLevel = 0;
    //    LocalDatas.Instance.catcherBallLevel = 0;

    //    for (int i = 0; i < LocalDatas.Instance.characters.Length; i++)
    //    {
    //        if (i < 2)
    //        {
    //           LocalDatas.Instance.characters[i] = 1;
    //        }
    //        else
    //        {
    //           LocalDatas.Instance.characters[i] = 0;

    //        }
    //    }


    //    for (int i = 0; i < LocalDatas.Instance.ballSkins.Length; i++)
    //    {
    //        if (i < 2)
    //        {
    //            LocalDatas.Instance.ballSkins[i] = 1;
    //        }
    //        else
    //        {
    //            LocalDatas.Instance.ballSkins[i] = 0;

    //        }
    //    }



    //    for (int i = 1; i <= 10; i++)
    //    {
    //        if (i < 5)
    //        {
    //            datas[i] = "0";
    //        }
    //        debugtext.text += "\ndata[" + i + "] =_" + datas[i].ToString() + "_";
    //    }
    //    datas[1] = "1";
    //    debugtext.text += "\n------------------------------------------------------------------------------";
    //}

    //public void RandomTest()
    //{
    //    datas[0] = "Player" + (int)Random.Range(0f, 100f);
    //    datas[1] = "" + Random.Range(1, 30); // level
    //    datas[2] = "" + Random.Range(0, 600); // xp
    //    datas[3] = "" + Random.Range(0, 600); // sscoin
    //    datas[4] = "" + Random.Range(0, 600); // diamond coin
    //    datas[5] = RandomWithVergul(7); // general stats
    //    datas[6] = RandomWithVergul(5); // runner skill levels
    //    datas[7] = RandomWithVergul(4); // catcher skill levels
    //    datas[8] = RandomWithoutVergul(14); // characters
    //    datas[9] = RandomWithoutVergul(15); // vfxs
    //    datas[10] = RandomWithoutVergul(10); // maps

    //    debugtext.text += "\n------------------------------------------------------------------------------";
    //    //debugtext.text += "\ndata[0] = " + datas[0].ToString();
    //    //for (int i = 1; i < datas.Length; i++)
    //    //{
    //    //    //if (i == 8)
    //    //    //{
    //    //    //    datas[i] = RandomSkills(14);

    //    //    //}
    //    //    //else if (i > 8) // 01010
    //    //    //{
    //    //    //    datas[i] = RandomSkills(10);
    //    //    //}
    //    //    //else if (i >= 5 && i <= 7) // 12,43,1,4,1,
    //    //    //{
    //    //    //    debugtext.text += "\ndata[" + i + "] = " + datas[i].ToString();
    //    //    //    continue;
    //    //    //}
    //    //    //else if (i == 1)
    //    //    //{
    //    //    //    datas[i] = "" + Random.Range(1, 30);
    //    //    //}
    //    //    else
    //    //    {
    //    //        datas[i] = "" + (int)Random.Range(0f, 600f);
    //    //    }
    //    //    debugtext.text += "\ndata[" + i + "] = " + datas[i].ToString();
    //    //}
    //    debugtext.text += "\n------------------------------------------------------------------------------";
    //}

    //public void EditSaveVariables(string[] _datas)
    //{
    //    debugtext.text += "///////////////////////\n";
    //    for (int i = 0; i < datas.Length; i++)
    //    {
    //        datas[i] = _datas[i];
    //        LocalDatas.Instance.DebugToUI("_" + datas[i] + "_");
    //    }
    //    debugtext.text += "///////////////////////\n";
    //}


    //public void SetFirstNickName(TMP_InputField nickNameInput)
    //{
    //    RefreshTest();
    //    datas[0] = nickNameInput.text;
    //    LocalDatas.Instance.nickName = nickNameInput.text;
    //    LocalDatas.Instance.SetAllLocalDatasToUI();
    //    //OpenSaveToCloud(true);
    //    CreateNickNamePanel.SetActive(false);
    //}

    //public void SetNickName(InputField nickNameInput)
    //{
    //    datas[0] = nickNameInput.text;
    //}



    //private bool issaving = false;
    //private string SAVE_NAME = "savegames";

    //public void OpenSaveToCloud(bool saving)
    //{
    //    // debugtext.text = "hello";
    //    if (Social.localUser.authenticated)
    //    {
    //        //  debugtext.text = "hello2";
    //        issaving = saving;
    //        ((PlayGamesPlatform)Social.Active).SavedGame.OpenWithAutomaticConflictResolution
    //            (SAVE_NAME, GooglePlayGames.BasicApi.DataSource.ReadCacheOrNetwork,
    //            ConflictResolutionStrategy.UseLongestPlaytime, SavedGameOpen);
    //    }
    //}

    //private void SavedGameOpen(SavedGameRequestStatus status, ISavedGameMetadata meta)
    //{
    //    if (status == SavedGameRequestStatus.Success)
    //    {
    //        LocalDatas.Instance.DebugToUI("\nIsSaving: " + issaving + "\n");
    //        if (issaving)//if is saving is true we are saving our data to cloud
    //        {
    //            byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(GetDataToStoreinCloud());
    //            SavedGameMetadataUpdate update = new SavedGameMetadataUpdate.Builder().Build();
    //            ((PlayGamesPlatform)Social.Active).SavedGame.CommitUpdate(meta, update, data, SavingFinishedCallback);
    //        }
    //        else//if is saving is false we are opening our saved data from cloud
    //        {
    //            ((PlayGamesPlatform)Social.Active).SavedGame.ReadBinaryData(meta, ReadDataFromCloud);
    //        }
    //    }
    //}

    //private void ReadDataFromCloud(SavedGameRequestStatus status, byte[] data)
    //{
    //    if (status == SavedGameRequestStatus.Success)
    //    {
    //        string savedata = System.Text.ASCIIEncoding.ASCII.GetString(data);
    //        LoadDataFromCloudToOurGame(savedata);
    //    }
    //}

    //private void LoadDataFromCloudToOurGame(string savedata)
    //{
    //    debugtext.text += "\nSavedData:\n_" + savedata +"_\n";
    //    string[] data = savedata.Split('|');
    //    debugtext.text += "dATA[0]:_" + data[0] + "_\n";
    //    if (data[0] == "")
    //    {
    //        PlayerPrefs.SetInt(profilePicIndex, 0);

    //        debugtext.text += "line 227\n";
    //        LocalDatas.Instance.playerCharacterObjects[PlayerPrefs.GetInt(characterIndex)].SetActive(false);
    //        CreateNickNamePanel.SetActive(true);
    //        LocalDatas.Instance.currentCharacterIndex = 0; // our character must be the first one
    //    }
    //    else
    //    {
    //        CreateNickNamePanel.SetActive(false);
    //    }
    //    LocalDatas.Instance.EditLocalDatas(savedata);
    //    debugtext.text += "\n------------------";
    //    debugtext.text += "\nline 206 Data length is: " + data.Length;

    //    for (int i = 0; i < 11; i++)
    //    {
    //        debugtext.text += "\ndata[" + i + "] =_" + data[i].ToString() + "_";
    //    }
    //    debugtext.text += "\n---------OPENED--GAME---------";

    //}

    //private void SavingFinishedCallback(SavedGameRequestStatus status, ISavedGameMetadata meta)
    //{
    //    debugtext.text += "\nsuccessfully add data to cloud";
    //}

    //string RandomWithoutVergul(int skillCount)
    //{
    //    string res = "";
    //    for (int i = 0; i < skillCount; i++)
    //    {
    //        res += Random.Range(0,3);
    //    }
    //    return res;

    //}

    //string RandomWithVergul(int skillCount)
    //{
    //    string res = "";
    //    for (int i = 0; i < skillCount; i++)
    //    {
    //        res += Random.Range(0, 11);
    //        res += ",";
    //    }
    //    debugtext.text +="randomStats: " + res;
    //    return res;

    //}

    //private string GetDataToStoreinCloud()//  we seting the value that we are going to store the data in cloud
    //{
    //    string Data = "";
    //    for (int i = 0; i < 11; i++)
    //    {
    //        Data += datas[i];
    //        Data += "|";
    //    }
    //    debugtext.text += "\nData to store in the cloud: " + Data + "\n";
    //    LocalDatas.Instance.datas = Data;
    //    return Data;
    //}

}
