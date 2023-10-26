using UnityEditor;
internal static class EditorScripts
{
#if UNITY_EDITOR

    [MenuItem("Editor Buttons/Delete User From Local Storage")]
    private static void DeleteUserDatasFromLocal()
    {
        SaveLoadManager.DeleteData();
    }


    [MenuItem("Editor Buttons/Make User Rich with SSCoin")]
    private static void MakeUserRichWithSSCoin()
    {
        Settings.User.ssCoin = 100000;
        SaveLoadManager.Save(Settings.User);
    }
#endif
}
