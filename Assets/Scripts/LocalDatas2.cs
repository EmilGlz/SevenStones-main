//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using TMPro;
//using GooglePlayGames;
//using GooglePlayGames.BasicApi;
//using GooglePlayGames.BasicApi.SavedGame;
//public class LocalDatas2 : MonoBehaviour
//{
//    private string SAVE_NAME = "savegames";
//    [SerializeField] TMP_Text debugtext;

//    public void opensavetocloud(bool saving)
//    {
//        // debugtext.text = "hello";
//        if (Social.localUser.authenticated)
//        {
//            //  debugtext.text = "hello2";
//            //issaving = saving;
//            ((PlayGamesPlatform)Social.Active).SavedGame.OpenWithAutomaticConflictResolution
//                (SAVE_NAME, GooglePlayGames.BasicApi.DataSource.ReadCacheOrNetwork,
//                ConflictResolutionStrategy.UseLongestPlaytime, savedgameopen);
//        }
//    }


//    private void savedgameopen(SavedGameRequestStatus status, ISavedGameMetadata meta)
//    {
//        if (status == SavedGameRequestStatus.Success)
//        {
//            byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(GetDataToStoreinCloud());
//            SavedGameMetadataUpdate update = new SavedGameMetadataUpdate.Builder().Build();
//            ((PlayGamesPlatform)Social.Active).SavedGame.CommitUpdate(meta, update, data, saveupdate);
//        }
//    }


//    private string GetDataToStoreinCloud()//  we seting the value that we are going to store the data in cloud
//    {
//        string Data = "";
//        ////data [0]
//        //for (int i = 0; i < datas.Length; i++)
//        //{
//        //    Data += datas[i];
//        //    Data += "|";
//        //}
//        debugtext.text += "\nData to store in the cloud: " + Data + "\n";
//        //LocalDatas.Instance.datas = Data;
//        return Data;
//    }

//    private void saveupdate(SavedGameRequestStatus status, ISavedGameMetadata meta)
//    {
//        //use this to debug whether the game is uploaded to cloud
//        //debugtext.text += "\nsuccessfully add data to cloud";
//        //CreateNickNamePanel.SetActive(false);
//    }
//}
