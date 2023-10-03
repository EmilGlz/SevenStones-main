using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCommonObjects : MonoBehaviour
{
    #region Singleton

    private static MenuCommonObjects instance;

    public static MenuCommonObjects Instance { get => instance; }

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject loadingPanel;
    public Slider loadingSlider;
    public GameObject loadingSliderImage;
}
