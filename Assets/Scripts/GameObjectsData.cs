using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameObjectsData : MonoBehaviour
{
    #region Singleton
    private static GameObjectsData _instance;
    public static GameObjectsData Instance { get { return _instance; } }
    private void Awake()
    {
        _instance = this;
    }
    #endregion

    public Transform zeroPosition;
    public List<Transform> ballZones;
    public GameObject[] characterPrefabs;
    public Sprite[] avatarsRes;
    public GameObject reconnectPanel;
    public TMP_Text reconnectInfo;
    public GameObject[] lives;
    public GameObject skillFrame;

    [HideInInspector] public List<GameObject> stoneZones;

    private static System.Random random;

    [HideInInspector] public Transform localPlayer;
    [HideInInspector] public List<Transform> team1Players = new List<Transform>();
    [HideInInspector] public List<Transform> team2Players = new List<Transform>();
    [HideInInspector] public List<GameObject> bots = new List<GameObject>();
    [HideInInspector] public List<GameObject> endGameChars = new List<GameObject>();

    private void Start()
    {   
        random = new System.Random();
    }

    public Vector3 RandomStoneZone(int seed = 0)
    {
        int greenStoneZones = 0;
        if (GameLogicData.Instance.placedStonesCounter == 7)
        {
            return Vector3.zero;
        }
        int rand = (seed == 0) ? random.Next(7 - GameLogicData.Instance.placedStonesCounter) : new System.Random(seed).Next(7 - GameLogicData.Instance.placedStonesCounter);

        for (int i = 0; i < 7; i++) {
            if(GameLogicData.Instance.collectedStones[i] == 0)
            {
                if (rand == 0)
                {
                    return MapScript.Instance.randomPoss[i].transform.position;
                }
                else rand--;
            }
            else
            {
                greenStoneZones++;
            }
        }
        if(greenStoneZones == 7)
        {
            return Vector3.zero;
        }
        else
        {
            return RandomStoneZone();
        }
    }

    public Transform RandomPlayer(int seed)
    {
        int alivePlayers = GameLogicData.Instance.alivePlayers;
        if (alivePlayers <= 0)
        {
            return Instance.zeroPosition;
        }
        int rand = new System.Random(seed).Next(alivePlayers);
        foreach (Transform player in GameLogicData.Instance.myTeamID == 1 ? Instance.team2Players : Instance.team1Players)
        {
            if (player.GetComponent<LocalPlayer>().lives >= 1)
            {
                if (rand == 0)
                {
                    return player;
                }
                else rand--;
            }
        }

        return zeroPosition;
    }

    public void SkillFrameActivate(float time)
    {
        skillFrame.SetActive(true);
        StartCoroutine(DeactivateSkillFrame(time));
    }

    IEnumerator DeactivateSkillFrame(float time)
    {
        LeanTween.value(skillFrame,2f, 0f, 1f).setOnUpdate((float value) => {
            Color color = skillFrame.GetComponent<Image>().color;
            color.a = (1 - value) > 0 ? 1 - value : value - 1;
            skillFrame.GetComponent<Image>().color = color;
        }).setRepeat(8);
        yield return new WaitForSeconds(time);
        skillFrame.SetActive(false);
        LeanTween.cancel(skillFrame);
    }
}