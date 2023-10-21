using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveLoadManager
{
    public static void Save(User userData)
    {
        if (userData == null)
            return;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/userData.dat");
        bf.Serialize(file, userData);
        file.Close();
    }

    public static User Load()
    {
        if (File.Exists(Application.persistentDataPath + "/userData.dat"))
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/userData.dat", FileMode.Open);
                User userData = (User)bf.Deserialize(file);
                file.Close(); // Move the file stream closing here, after deserialization
                return userData;
            }
            catch (Exception)
            {
                return null;
            }
        }
        return null;
    }


    public static void DeleteData()
    {
        string dataPath = Application.persistentDataPath + "/userData.dat";

        if (File.Exists(dataPath))
        {
            File.Delete(dataPath);
            Debug.Log("UserData deleted.");
        }
        else
        {
            Debug.LogWarning("UserData file does not exist. Nothing to delete.");
        }
    }
}