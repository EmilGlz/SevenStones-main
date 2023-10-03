using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomeDatas : MonoBehaviour
{
    #region Singleton

    private static SomeDatas instance;

    public static SomeDatas Instance { get => instance; }

    private void Awake()
    {
        instance = this;
    }

    #endregion

    #region Level datas

    public int[] xpPerLevel = {
        600,
        800,
        1000,
        1200,
        1400,
        1600,
        1800,
        2000,
        2200,
        2400,
        2600,
        2800,
        3000,
        3200,
        3400,
        3600,
        3800,
        4000
    };


    // Sprint-Life-Shield-Trap-Invisibility-STD-TopView-Wall-Hook-BC
    public int[,] maxRunnerSkillLevelPerLevel = {
        { 2,  0,  2,  0,  2,  2,   2,  0,  0,  0},  // 0-4
        { 4,  1,  4,  4,  4,  4,   4,  4,  4,  4},  // 5-9
        { 6,  1,  6,  6,  6,  6,   6,  6,  6,  6},  // 10-14
        { 8,  1,  8,  8,  8,  8,   8,  8,  8,  8},  // 15-19
        { 11, 2,  11, 11, 11, 11,  11, 11, 11, 11}  // 20+
    };

    // Sprint-Shield-Invisibility-Ball-STD-TopView-Wall-Hook-DeadlyHit-BC
    public int[,] maxCatcherSkillLevelPerLevel = {
        { 2,  2,   2,   0,  2,  2,  0,  0,  2,  0}, // 0-4
        { 4,  4,   4,   1,  4,  4,  4,  4,  4,  4}, // 5-9
        { 6,  6,   6,   1,  6,  6,  6,  6,  6,  6}, // 10-14
        { 8,  8,   8,   1,  8,  8,  8,  8,  8,  8}, // 15-19
        { 11, 11,  11,  2,  11, 11, 11, 11, 11, 11} // 20+
    };

    #endregion

    [Space(20)]

    #region character datas

    public int[] characterPrices = {
        100,
        150,
        200,
        250,
        300,
        350,
        400,
        450,
        500,
        550,
        600,
        700,
        750,
        800
    };

    public string[] characterNames = { };

    public int[] characterSprintLevels = {
        0,
        1,
        2,
        2,
        3,
        3,
        4,
        4,
        5,
        5,
        6,
        7,
        7,
        8
    };


    public int[] characterDashLevels = {
        0,
        1,
        2,
        2,
        3,
        3,
        4,
        4,
        5,
        5,
        6,
        7,
        7,
        8
    };

    public int[] lastIndexPerLevelInterval = { 6, 10, 13};
    public int[] levelIntervalForCharacters = { 10, 15};

    public readonly float[,] characterDSLevels = { {5f,1f},
                                                   {5f,1f },
                                                   {4.95f,1.01f },
                                                   {4.9f,1.02f },
                                                   {4.85f,1.03f },
                                                   {4.8f,1.04f },
                                                   {4.75f,1.05f },
                                                   {4.7f,1.06f },
                                                   {4.65f,1.07f },
                                                   {4.6f,1.08f },
                                                   {4.55f,1.09f },
                                                   {4.5f,1.1f },
                                                   {4.45f,1.11f },
                                                   {4.3f,1.13f }};

    #endregion

    [Space(20)]

    #region Shop datas



    public int[] ssCoinPrices = {
        10,
        15,
        20,
        25,
        30,
        35,
        40,
        45,
        50,
        55,
    };


    public int[] ssCoinValues = {
        1,
        2,
        3,
        4,
        5,
        6,
        7,
        8,
        9,
        10,
    };

    #endregion

    [Space(20)]

    #region skill prices
    public int[] runnerSpeedPrices;
    public int[] runnerShieldPrices;
    public int[] runnerInvisibilityPrices;
    public int[] runnerAddHealthPrices;
    public int[] runnerTrapPrices;
    public int[] runnerSTDPrices;
    public int[] runnerTopViewPrices;
    public int[] runnerWallPrices;
    public int[] runnerHookPrices;
    public int[] runnerBCPrices;

    [Space(5)]

    public int[] catcherSpeedPrices;
    public int[] catcherShieldPrices;
    public int[] catcherInvisibilityPrices;
    public int[] catcherBallPrices;
    public int[] catcherSTDPrices;
    public int[] catcherTopViewPrices;
    public int[] catcherWallPrices;
    public int[] catcherHookPrices;
    public int[] catcherBCPrices;
    public int[] catcherDHPrices;


    #endregion

    [Space(20)]

    #region level-up datas
    
    
    public int[] ssCoinPerLevel;



    #endregion

    [Space(20)]

    #region Arena Prices

    public int[] arenaPrices;

    #endregion

    [Space(20)]

    #region Prize datas
    // TODO length
    // only 8 arrays, means 40 levels. Needs to be increased
    public int[,] prizes = {
        { 0, 1}, // 5 level
        { 0, 1}, // 10 level
        { 1, 0}, // 15 level
        { 0, 1}, // 20 level
        { 0, 0}, // 25 level
        { 1, 0}, // 30 level
        { 1, 0}, // 35 level
        { 0, 1}, // 40 level
    };

    #endregion

    [Space(20)]

    #region VFX variables
    public int[] ballPrices = {
        100,
        150,
        200,
        250,
        300,
        350,
        400,
        450,
        500,
        550,
        560,
        570,
        580,
        590,
        600,
    };

    public int[] lastIndexPerLevelIntervalVFX = { 6, 11, 14 };
    public int[] levelIntervalForVFX = { 8, 15 };
    #endregion
}
