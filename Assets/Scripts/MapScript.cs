using UnityEngine;

public class MapScript : MonoBehaviour
{
    #region Singleton
    private static MapScript _instance;
    public static MapScript Instance { get => _instance;}
    private void Awake()
    {
        _instance = this;
    }
    #endregion

    [SerializeField] GameObject stonePrefab;
    [HideInInspector] public GameObject[] randomPoss;
    [HideInInspector] public int currentMap;
    private GameObject currentSet;

    private int changeCounter;
    private readonly byte[] sets = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14};

    private void Start()
    {
        changeCounter = 0;
        randomPoss = new GameObject[7];
        for (int i = 0; i < 7; i++)
        {
            randomPoss[i] = new GameObject();
        }
    }

    public byte[] ChangeZonesRandom(int placedStones)
    {
        byte[] result = new byte[8];
        int rand = new System.Random().Next(15-changeCounter);
        result[7] = sets[rand];

        byte temp = sets[rand];
        sets[rand] = sets[14 - changeCounter];
        sets[14 - changeCounter] = temp;

        for (int i = 0; i < placedStones; i++)
        {
            result[i] = 1;
        }

        changeCounter++;
        return ShuffleZones(result);
    }

    private byte[] ShuffleZones(byte[] arr) // Dont use this method another place
    {
        byte[] result = arr;
        int counter = 0;
        int rand;
        byte temp;
        for(int i = 0; i < 7; i++)
        {
            rand = new System.Random().Next(7 - counter);
            temp = result[rand];
            result[rand] = result[6 - counter];
            result[6 - counter] = temp;
            counter++;
        }
        return result;
    }

    public void ChangeZonesManually(byte[] zoneActivesANDSet) //8 length array: first 7 elements-> which stone is green, 8th element-> which set is active
    {
        if(!(currentSet == null)) currentSet.SetActive(false);
        GameObject randomSet = new GameObject("RandomSet");
        //Creating new zones
        for(int i = 0; i < 7; i++)
        {
            GameObject stoneZone = Instantiate(stonePrefab, GameLogicData.Instance.mapsStonesRandomPoss[currentMap, zoneActivesANDSet[7], i], Quaternion.identity, randomSet.transform);
            stoneZone.name = i.ToString();
            if (zoneActivesANDSet[i] == 1)
            {
                ParticleSystem.MainModule main = stoneZone.GetComponent<ParticleSystem>().main;
                main.startColor = Color.green;
            }
            else
            {
                ParticleSystem.MainModule main = stoneZone.GetComponent<ParticleSystem>().main;
                main.startColor = Color.red;
            }
            randomPoss[i] = stoneZone;
        }
        currentSet = randomSet;
        GameLogicData.Instance.collectedStones = zoneActivesANDSet;
    }
}