using UnityEditor;
using UnityEngine;
internal static class EditorScripts
{
    //[MenuItem("Editor Buttons/Delete User From Local Storage")]
    private static void DeleteUserDatasFromLocal()
    {
        SaveLoadManager.DeleteData();
    }
}
