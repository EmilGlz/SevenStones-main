using UnityEngine;

public class CommonObjects : MonoBehaviour
{
    #region Singleton

    private static CommonObjects instance;

    public static CommonObjects Instance { get => instance; }

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject[] CharactersButtons;
}
