using UnityEngine;

public class SpecialData : MonoBehaviour
{

    #region singleton

    private static SpecialData instance;

    public static SpecialData Instance { get => instance; }

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }
    #endregion

    [HideInInspector] public bool firstTime = true;

    //public User user;
}
