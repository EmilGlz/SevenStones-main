using System.Collections.Generic;
using UnityEngine;

public class GameLogicData : MonoBehaviour
{
    #region Singleton
    private static GameLogicData _instance;
    public static GameLogicData Instance { get { return _instance; } }
    private void Awake()
    {
        _instance = this;
    }
    #endregion

    #region Dynamic variables
    [HideInInspector] public Dictionary<int, byte> playerLvls;
    [HideInInspector] public List<int> myTeamActNums;
    [HideInInspector] public Vector3 myStartPoint;
    [HideInInspector] public byte myTeamID = 0;
    [HideInInspector] public int placedStonesCounter = 0;
    [HideInInspector] public int alivePlayers = 4;
    [HideInInspector] public int shootCounter = 0;
    [HideInInspector] public int enduranceTime = 0;
    [HideInInspector] public string dataString;
    [HideInInspector] public byte[] collectedStones;
    [HideInInspector] public bool skillCancel = false;
    [HideInInspector] public bool hookMove = false;
    #endregion

    #region Static datas
    public readonly Vector3[] mapsCatcherStartPositions = { new Vector3(15, 2, 2),
                                                            new Vector3(-7,2,2),
                                                            new Vector3(5,2,13),
                                                            new Vector3(5,2,-7)};
    public readonly Vector3[,,] mapsRunnerStartPositions = {{ {new Vector3(73, 2, 67), new Vector3(83,2,67), new Vector3(78,2,72), new Vector3(78,2,62) },
                                                            {new Vector3(-81, 2, -65), new Vector3(-75,2,-62), new Vector3(-72,2,-67), new Vector3(-80,2,-58) },
                                                            {new Vector3(-74, 2, 72), new Vector3(-74,2,62), new Vector3(-79,2,67), new Vector3(-69,2,67) },
                                                            {new Vector3(73, 2, -73), new Vector3(73,2,-65), new Vector3(78,2,-69), new Vector3(68,2,-69) }},
                                                            
                                                            { {new Vector3(81, 2, -83), new Vector3(73,2,-83), new Vector3(73,2,-76), new Vector3(81,2,-76) },
                                                            {new Vector3(76, 2, 77), new Vector3(84,2,77), new Vector3(84,2,70), new Vector3(76,2,70) },
                                                            {new Vector3(-77, 2, 74), new Vector3(-67,2,74), new Vector3(-67,2,67), new Vector3(-77,2,67) },
                                                            {new Vector3(-70, 2, -81), new Vector3(-60,2,-81), new Vector3(-60,2,-74), new Vector3(-70,2,-74) }},
                                                            
                                                            { {new Vector3(71, 2, 75), new Vector3(77, 2, 75), new Vector3(77, 2, 70), new Vector3(71, 2, 70) },
                                                            {new Vector3(-81, 2, 75), new Vector3(-72, 2, 75), new Vector3(-72,2,69), new Vector3(-81,2,69) },
                                                            {new Vector3(-74, 2, -64), new Vector3(-74,2,-71), new Vector3(-79,2,-69), new Vector3(-70,2,-69) },
                                                            {new Vector3(75, 2, -70), new Vector3(80,2,-70), new Vector3(80,2,-66), new Vector3(75,2,-66) }} };
    
    public readonly Vector3[,,] mapsStonesRandomPoss = {{ { new Vector3(4.4f, 1.2f, 48.55f), new Vector3(-48.9f, 1.2f, 30f), new Vector3(-60.1f, 1.2f, -8.5f), new Vector3(-40.5f, 1.2f, -40.8f), new Vector3(6.1f, 1.2f, -47.5f), new Vector3(68.8f, 1.2f, 32.4f), new Vector3(55.9f, 1.2f, -39.1f) },
                                                        { new Vector3(72f, 1.2f, -29.3f), new Vector3(66.9f, 1.2f, 31.9f), new Vector3(60.9f, 1.2f, 52.9f), new Vector3(4.9f, 1.2f, 64.9f), new Vector3(-59.1f, 1.2f, 58.9f), new Vector3(-67.1f, 1.2f, -39.1f), new Vector3(-32.1f, 1.2f, -66.1f) },
                                                        { new Vector3(59.9f, 1.2f, -7.1f), new Vector3(48.9f, 1.2f, 31.9f), new Vector3(-27.1f, 1.2f, 22.9f), new Vector3(-39.1f, 1.2f, -9.1f), new Vector3(-77.1f, 1.2f, 19.9f), new Vector3(-37.1f, 1.2f, 56.9f), new Vector3(39.9f, 1.2f, -69.1f) },
                                                        { new Vector3(40.9f, 1.2f, -18.1f), new Vector3(46.9f, 1.2f, 56.9f), new Vector3(21.9f, 1.2f, 33.9f), new Vector3(-61.1f, 1.2f, 24.9f), new Vector3(-74.1f, 1.2f, -8.1f), new Vector3(-46.1f, 1.2f, -24.1f), new Vector3(-51.1f, 1.2f, -54.1f) },
                                                        { new Vector3(28.9f, 1.2f, -48.1f), new Vector3(42.9f, 1.2f, 34.9f), new Vector3(3.9f, 1.2f, 22.9f), new Vector3(4.9f, 1.2f, 71.9f), new Vector3(-79.1f, 1.2f, 49.9f), new Vector3(-42.1f, 1.2f, -13.1f), new Vector3(58.9f, 1.2f, -8.1f) },
                                                        { new Vector3(-60.89f, 1.2f, -14.2f), new Vector3(-19.9f, 1.2f, -9.1f), new Vector3(24.8f, 1.2f, 17.64f), new Vector3(76f, 1.2f, 55.5f), new Vector3(37.2f, 1.2f, 54.1f), new Vector3(-24.2f, 1.2f, 39.3f), new Vector3(-34.1f, 1.2f, -55.78f) },
                                                        { new Vector3(21.9f, 1.2f, -67.1f), new Vector3(18f, 1.2f, -23.1f), new Vector3(-11.2f, 1.2f, 16.1f), new Vector3(-51.8f, 1.2f, 65f), new Vector3(-48.25f, 1.2f, 26.4f), new Vector3(-30.1f, 1.2f, -34.1f), new Vector3(65.4f, 1.2f, -38.6f) },
                                                        { new Vector3(66.9f, 1.2f, -33.1f), new Vector3(39.9f, 1.2f, -16.1f), new Vector3(53.9f, 1.2f, 19.9f), new Vector3(74.9f, 1.2f, 57.9f), new Vector3(-72.1f, 1.2f, 23.9f), new Vector3(-73.1f, 1.2f, -23.1f), new Vector3(-46.1f, 1.2f, -44.1f) },
                                                        { new Vector3(-72.7f, 1.2f, 35.9f), new Vector3(-42.5f, 1.2f, 19.9f), new Vector3(-47.5f, 1.2f, -18.4f), new Vector3(-58.8f, 1.2f, -60.3f), new Vector3(72.9f, 1.2f, 7.9f), new Vector3(65.6f, 1.2f, 53.7f), new Vector3(31.9f, 1.2f, 67.6f) },
                                                        { new Vector3(71.9f, 1.2f, -1.1f), new Vector3(39.9f, 1.2f, 38.9f), new Vector3(21.9f, 1.2f, 64.9f), new Vector3(-7.1f, 1.2f, -53.1f), new Vector3(-39.1f, 1.2f, -9.1f), new Vector3(-57.1f, 1.2f, 16.9f), new Vector3(-46.1f, 1.2f, 55.9f) },
                                                        { new Vector3(21.2f, 1.2f, -59.1f), new Vector3(49f, 1.2f, -14.5f), new Vector3(68.9f, 1.2f, 9.9f), new Vector3(-53.15f, 1.2f, 1f), new Vector3(-21.55f, 1.2f, 45.25f), new Vector3(-2.6f, 1.2f, 70.6f), new Vector3(37.9f, 1.2f, 72.5f) },
                                                        { new Vector3(4.9f, 1.2f, 29.9f), new Vector3(-35.1f, 1.2f, 1.9f), new Vector3(-28.1f, 1.2f, -30.1f), new Vector3(35.9f, 1.2f, -30.1f), new Vector3(35.9f, 1.2f, 1.9f), new Vector3(38.9f, 1.2f, 38.9f), new Vector3(-32.1f, 1.2f, 28.9f) },
                                                        { new Vector3(-43.1f, 1.2f, 18.9f), new Vector3(-16.1f, 1.2f, 49.9f), new Vector3(-77.1f, 1.2f, 48.9f), new Vector3(-77.1f, 1.2f, -26.1f), new Vector3(-21.1f, 1.2f, 70.9f), new Vector3(21.9f, 1.2f, 69.9f), new Vector3(73.9f, 1.2f, 57.9f) },
                                                        { new Vector3(32.9f, 1.2f, 14.9f), new Vector3(47.9f, 1.2f, -49.1f), new Vector3(64.7f, 1.2f, -22.4f), new Vector3(81.9f, 1.2f, 50.1f), new Vector3(4.9f, 1.2f, -29.5f), new Vector3(-32.1f, 1.2f, -17.6f), new Vector3(-80.1f, 1.2f, 7.25f) },
                                                        { new Vector3(4.9f, 1.2f, -53.1f), new Vector3(37.9f, 1.2f, -27.1f), new Vector3(54.9f, 1.2f, 1.9f), new Vector3(29.9f, 1.2f, 45.9f), new Vector3(-21.1f, 1.2f, 61.9f), new Vector3(-54.1f, 1.2f, 17.9f), new Vector3(-40.1f, 1.2f, -24.1f) }},

                                                        { { new Vector3(-12f, 1.2f, 32.3f), new Vector3(-65.25f, 1.2f, 14.8f), new Vector3(-76.45f, 1.2f, -23.7f), new Vector3(-56.85f, 1.2f, -56f), new Vector3(-10.25f, 1.2f, -62.7f), new Vector3(52.4f, 1.2f, 17.2f), new Vector3(39.5f, 1.2f, -49.7f) },
                                                        { new Vector3(51f, 1.2f, -21.4f), new Vector3(47.45f, 1.2f, 39.8f), new Vector3(41.45f, 1.2f, 60.8f), new Vector3(-14.5f, 1.2f, 72.8f), new Vector3(-73f, 1.2f, 59.3f), new Vector3(-77f, 1.2f, -23.7f), new Vector3(-51.5f, 1.2f, -52.7f) },
                                                        { new Vector3(48f, 1.2f, 3.3f), new Vector3(40.5f, 1.2f, 42.3f), new Vector3(-35.5f, 1.2f, 33.3f), new Vector3(-47.5f, 1.2f, 1.3f), new Vector3(-80f, 1.2f, 34.3f), new Vector3(-45.5f, 1.2f, 67.3f), new Vector3(29f, 1.2f, -58.7f) },
                                                        { new Vector3(72f, 1.2f, -40.2f), new Vector3(76.5f, 1.2f, 34.8f), new Vector3(51.5f, 1.2f, 11.8f), new Vector3(-31.5f, 1.2f, 2.8f), new Vector3(-44.5f, 1.2f, -30.2f), new Vector3(-16.5f, 1.2f, -46.2f), new Vector3(-21.5f, 1.2f, -76.2f) },
                                                        { new Vector3(57f, 1.2f, -54.7f), new Vector3(71f, 1.2f, 28.3f), new Vector3(32f, 1.2f, 16.3f), new Vector3(33f, 1.2f, 61.3f), new Vector3(-51f, 1.2f, 43.3f), new Vector3(-14f, 1.2f, -19.7f), new Vector3(87f, 1.2f, -14.7f)},
                                                        { new Vector3(-78f, 1.2f, 13.3f), new Vector3(-40f, 1.2f, 16.35f), new Vector3(6.2f, 1.2f, 43.1f), new Vector3(57.4f, 1.2f, 80.9f), new Vector3(18.6f, 1.2f, 79.5f), new Vector3(-42.8f, 1.2f, 64.8f), new Vector3(-52.65f, 1.2f, -30.3f)},
                                                        { new Vector3(39.1f, 1.2f, -47.8f), new Vector3(35.2f, 1.2f, -3.8f), new Vector3(6f, 1.2f, 35.4f), new Vector3(-34.6f, 1.2f, 82.3f), new Vector3(-37f, 1.2f, 43.3f), new Vector3(-29f, 1.2f, -14.8f), new Vector3(82.6f, 1.2f, -19.3f) },
                                                        { new Vector3(-38f, 1.2f, -54.7f), new Vector3(-65f, 1.2f, -33.7f), new Vector3(-64f, 1.2f, 13.3f), new Vector3(83f, 1.2f, 47.3f), new Vector3(62f, 1.2f, 9.3f), new Vector3(48f, 1.2f, -26.7f), new Vector3(75f, 1.2f, -43.7f) },
                                                        { new Vector3(-63.8f, 1.2f, 19.5f), new Vector3(-33.5f, 1.2f, 3.5f), new Vector3(-38.5f, 1.2f, -34.75f), new Vector3(-49.85f, 1.2f, -76.7f), new Vector3(81.8f, 1.2f, -8.5f), new Vector3(74.5f, 1.2f, 37.3f), new Vector3(40.8f, 1.2f, 54.3f) },
                                                        { new Vector3(64.5f, 1.2f, -14.7f), new Vector3(32.5f, 1.2f, 25.3f), new Vector3(14.5f, 1.2f, 51.3f), new Vector3(-14.5f, 1.2f, -62.7f), new Vector3(-46.5f, 1.2f, -22.7f), new Vector3(-64.5f, 1.2f, 3.3f), new Vector3(-53.5f, 1.2f, 40.3f) },
                                                        { new Vector3(16.3f, 1.2f, -79.5f), new Vector3(44.1f, 1.2f, -34.9f), new Vector3(64f, 1.2f, -10.5f), new Vector3(-58f, 1.2f, -25.7f), new Vector3(-26.4f, 1.2f, 24.7f), new Vector3(-7.5f, 1.2f, 50.2f), new Vector3(33f, 1.2f, 52.1f) },
                                                        { new Vector3(12f, 1.2f, 28.8f), new Vector3(-28f, 1.2f, 0.8f), new Vector3(-18f, 1.2f, -31.2f), new Vector3(43f, 1.2f, -31.2f), new Vector3(43f, 1.2f, 0.8f), new Vector3(46f, 1.2f, 37.8f), new Vector3(-25f, 1.2f, 27.8f) },
                                                        { new Vector3(-32.5f, 1.2f, 25.3f), new Vector3(-5.5f, 1.2f, 54.8f), new Vector3(-66.5f, 1.2f, 53.8f), new Vector3(-66.5f, 1.2f, -23.7f), new Vector3(-10.5f, 1.2f, 75.8f), new Vector3(32.5f, 1.2f, 74.8f), new Vector3(84.5f, 1.2f, 62.8f) },
                                                        { new Vector3(38f, 1.2f, 6.7f), new Vector3(53f, 1.2f, -57.3f), new Vector3(69.8f, 1.2f, -30.6f), new Vector3(87f, 1.2f, 41.9f), new Vector3(10f, 1.2f, -37.7f), new Vector3(-30f, 1.2f, -25.8f), new Vector3(-70f, 1.2f, -2.7f) },
                                                        { new Vector3(11.5f, 1.2f, -57.2f), new Vector3(44.5f, 1.2f, -31.2f), new Vector3(61.5f, 1.2f, -2.2f), new Vector3(36.5f, 1.2f, 41.8f), new Vector3(-14.5f, 1.2f, 57.8f), new Vector3(-47.5f, 1.2f, 13.8f), new Vector3(-33.5f, 1.2f, -28.2f)}},

                                                        { { new Vector3(-18.2f, 1.2f, 57.5f), new Vector3(-63.2f, 1.2f, 37f), new Vector3(-73.7f, 1.2f, 0f), new Vector3(-54.1f, 1.2f, -30.8f), new Vector3(-7.5f, 1.2f, -37.5f), new Vector3(55.2f, 1.2f, 42.4f), new Vector3(42.3f, 1.2f, -24.5f) },
                                                        { new Vector3(58.75f, 1.2f, -32.45f), new Vector3(56.75f, 1.2f, 28f), new Vector3(55.75f, 1.2f, 49.7f), new Vector3(-1.2f, 1.2f, 61.7f), new Vector3(-61.2f, 1.2f, 48.2f), new Vector3(-63.2f, 1.2f, -34.75f), new Vector3(-39.8f, 1.2f, -63.75f) },
                                                        { new Vector3(75.75f, 1.2f, -6f), new Vector3(68.25f, 1.2f, 37f), new Vector3(-7.7f, 1.2f, 26f), new Vector3(-24.2f, 1.2f, -6f), new Vector3(-48.2f, 1.2f, 28f), new Vector3(-17.7f, 1.2f, 60f), new Vector3(41.75f, 1.2f, -66f) },
                                                        { new Vector3(53.75f, 1.2f, -23f), new Vector3(62.25f, 1.2f, 54.5f), new Vector3(37.25f, 1.2f, 31.5f), new Vector3(-45.7f, 1.2f, 22.5f), new Vector3(-57.2f, 1.2f, -6f), new Vector3(-30.7f, 1.2f, -26.5f), new Vector3(-35.7f, 1.2f, -56.5f) },
                                                        { new Vector3(40.75f, 1.2f, -59f), new Vector3(49.75f, 1.2f, 28f), new Vector3(25.75f, 1.2f, 17f), new Vector3(18.75f, 1.2f, 60f), new Vector3(-67.2f, 1.2f, 39f), new Vector3(-30.2f, 1.2f, -24f), new Vector3(70.75f, 1.2f, -19f) },
                                                        { new Vector3(-68.2f, 1.2f, 8f), new Vector3(-34f, 1.2f, 11.05f), new Vector3(12.3f, 1.2f, 37.8f), new Vector3(64.75f, 1.2f, 40f), new Vector3(24.7f, 1.2f, 74.2f), new Vector3(-35.2f, 1.2f, 59.5f), new Vector3(-46.7f, 1.2f, -35.6f) },
                                                        { new Vector3(4f, 1.2f, -62f), new Vector3(0.2f, 1.2f, -18f), new Vector3(-29.05f, 1.2f, 18f), new Vector3(-69.7f, 1.2f, 68f), new Vector3(-72.1f, 1.2f, 29f), new Vector3(-64.1f, 1.2f, -29f), new Vector3(47.6f, 1.2f, -33.55f) },
                                                        { new Vector3(69.75f, 1.2f, -41f), new Vector3(43.75f, 1.2f, -24f), new Vector3(58.75f, 1.2f, 12f), new Vector3(77.75f, 1.2f, 50f), new Vector3(-67.2f, 1.2f, 11f), new Vector3(-66.2f, 1.2f, -32f), new Vector3(-43.2f, 1.2f, -52f) },
                                                        { new Vector3(-66.2f, 1.2f, 30f), new Vector3(-41.2f, 1.2f, 18f), new Vector3(-44.75f, 1.2f, -22.6f), new Vector3(-58.2f, 1.2f, -59f), new Vector3(73.75f, 1.2f, 9f), new Vector3(69.75f, 1.2f, 48f), new Vector3(37.75f, 1.2f, 66.5f) },
                                                        { new Vector3(68.25f, 1.2f, 1f), new Vector3(36.25f, 1.2f, 41f), new Vector3(18.75f, 1.2f, 59f), new Vector3(-10.7f, 1.2f, -47f), new Vector3(-42.7f, 1.2f, -7f), new Vector3(-60.7f, 1.2f, 19f), new Vector3(-52.2f, 1.2f, 61f) },
                                                        { new Vector3(20.1f, 1.2f, -62.8f), new Vector3(47.9f, 1.2f, -15f), new Vector3(67.8f, 1.2f, 6.2f), new Vector3(-54.3f, 1.2f, -5f), new Vector3(-25.2f, 1.2f, 41.55f), new Vector3(-1.2f, 1.2f, 69f), new Vector3(36.75f, 1.2f, 68.8f) },
                                                        { new Vector3(7.75f, 1.2f, 39f), new Vector3(-30.2f, 1.2f, 10f), new Vector3(-22.2f, 1.2f, -22.5f), new Vector3(38.75f, 1.2f, -24f), new Vector3(38.75f, 1.2f, 9.5f), new Vector3(39.75f, 1.2f, 46.5f), new Vector3(-29.2f, 1.2f, 39f) },
                                                        { new Vector3(-49.7f, 1.2f, 14.2f), new Vector3(-26.2f, 1.2f, 43.7f), new Vector3(-83.7f, 1.2f, 42.7f), new Vector3(-75.2f, 1.2f, -24f), new Vector3(-27.7f, 1.2f, 64.7f), new Vector3(15.25f, 1.2f, 61f), new Vector3(67.25f, 1.2f, 51.7f) },
                                                        { new Vector3(29.2f, 1.2f, 14.4f), new Vector3(44.25f, 1.2f, -49.6f), new Vector3(61f, 1.2f, -23f), new Vector3(78.25f, 1.2f, 49.6f), new Vector3(1.3f, 1.2f, -30f), new Vector3(-38.7f, 1.2f, -13f), new Vector3(-81.2f, 1.2f, 5f) },
                                                        { new Vector3(-37.7f, 1.2f, -26f), new Vector3(-51.7f, 1.2f, 14.5f), new Vector3(-18.7f, 1.2f, 58.5f), new Vector3(32.25f, 1.2f, 42.5f), new Vector3(57.25f, 1.2f, -1.5f), new Vector3(40.25f, 1.2f, -30.5f), new Vector3(5.75f, 1.2f, -61f) } } };




    public readonly float[,] runnerSkillLevels = {  {3f, 3.2f, 3.5f, 3.7f, 4f, 4.2f, 4.5f, 4.7f, 5f, 5.5f, 6f},//0. Speed
                                                    {2f, 3f, 3f, 3f, 3f, 3f, 3f, 3f, 3f, 3f, 3f},              //1. Life
                                                    {3f, 3.3f, 4f, 4.2f, 4.6f, 5f, 5.5f, 6f, 6.5f, 7f, 6f},    //2. Shield
                                                    {3f, 3.2f, 3.6f, 4f, 4.2f, 4.6f, 5f, 6f, 6.5f, 7f, 8f},    //3. Trap
                                                    {5f, 5.3f, 6f, 6.2f, 6.4f, 6.6f, 6.8f, 7f, 7.3f, 7.5f, 8f},//4. Invisibility
                                                    {4f, 4.4f, 4.8f, 5.2f, 5.6f, 6f, 6.4f, 6.8f, 7.2f, 7.6f, 8f},    //5. Slow down trap
                                                    {2f, 2.4f, 2.8f, 3.2f, 3.6f, 4f, 4.4f, 4.8f, 5.2f, 5.6f, 6f},    //6. Top view
                                                    {4f, 4.4f, 4.8f, 5.2f, 5.6f, 6f, 6.4f, 6.8f, 7.2f, 7.6f, 8f},//7. Wall
                                                    {30f, 29f, 28f, 27f, 26f, 25f, 24f, 23f, 22f, 21f, 20f},    //8. Hook
                                                    {4f, 4.4f, 4.8f, 5.2f, 5.6f, 6f, 6.4f, 6.8f, 7.2f, 7.6f, 8f}};   //9. BotClone
    public readonly float[,] catcherSkillLevels = { {3f, 3.2f, 3.5f, 3.7f, 4f, 4.2f, 4.5f, 4.7f, 5f, 5.5f, 6f},//0. Speed
                                                    {3f, 3.3f, 4f, 4.2f, 4.6f, 5f, 5.5f, 6f, 6.5f, 7f, 6f},    //1. Shield
                                                    {5f, 5.3f, 6f, 6.2f, 6.4f, 6.6f, 6.8f, 7f, 7.3f, 7.5f, 8f},//2. Invisibility
                                                    {2f, 3f, 3f, 3f, 3f, 3f, 3f, 3f, 3f, 3f, 3f},              //3. Extra ball
                                                    {4f, 4.4f, 4.8f, 5.2f, 5.6f, 6f, 6.4f, 6.8f, 7.2f, 7.6f, 8f},//4. Slow down trap
                                                    {2f, 2.4f, 2.8f, 3.2f, 3.6f, 4f, 4.4f, 4.8f, 5.2f, 5.6f, 6f},    //5. Top view
                                                    {4f, 4.4f, 4.8f, 5.2f, 5.6f, 6f, 6.4f, 6.8f, 7.2f, 7.6f, 8f},//6. Wall
                                                    {30f, 29f, 28f, 27f, 26f, 25f, 24f, 23f, 22f, 21f, 20f},//7. Hook
                                                    {30f, 29f, 28f, 27f, 26f, 25f, 24f, 23f, 22f, 21f, 20f},//8. Deadly hit
                                                    {4f, 4.4f, 4.8f, 5.2f, 5.6f, 6f, 6.4f, 6.8f, 7.2f, 7.6f, 8f}};   //9. Bot Clone
    public readonly float[,] characterDSLevels = { {5f,1f },                                                    
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
    public readonly string[] botNames = {"Gregoria","Guy","Nikole","Andria","Kyra","Cody","Miquel","Argentina","Rico","Sook","Anastacia","Anton","Milly","Jacelyn","Ailene","Olympia","Daysi",
                                         "Tristan","Daryl","Edmond","August","Cinthia","Mona","Aretha","Roxie","Angelo","Dusty","Ayako","Bernetta","Jerrod","Felicia","Kacey","Debora","Meghann",
                                         "Katherin","Dedra","Sharilyn","Juliana","Eusebio","Gustavo","Isobel","Carlita","Shaquana","Ken","Darleen","Pura","Tambra","Teodoro","Fiona","Shelly","Soila",
                                         "Aura","Keren","Torrie","Christy","Elenore","Vernell","Marjory","Jackqueline","Solomon","Leanna","Elaina","Lawrence","Miss","Ebony","Desmond","Claribel",
                                         "Arnette","Saturnina","Maragaret","Adriane","Summer","Walter","Vennie","Kari","Lyn","Max","Roxanne","Aleen","Booker","Gricelda","Nicolas","Kristy","Dwain",
                                         "Jay","Jonah","Kina","Marvel","Ricardo","Phyllis","Cliff","Ngan","Alejandrina","Faith","Tiesha","Amanda","Nia","Raquel","Annie","Elane" };

    #endregion

    private void Start()
    {
        collectedStones = new byte[8];
        playerLvls = new Dictionary<int, byte>();
    }
}