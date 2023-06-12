using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// the data to serialize
[System.Serializable]
public class SavedData
{
    public string lastPlayer;
    public string topPlayerName;
    public int topScore;
}

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public SavedData dataLoaded;

    private string path;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;

            path = Application.persistentDataPath + "/savedata.json";
            DontDestroyOnLoad(gameObject);
            LoadData();
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }


    public void LoadData()
    {
        Debug.Log("Path: " + path);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            dataLoaded = JsonUtility.FromJson<SavedData>(json);
        }
    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(dataLoaded);
        File.WriteAllText(path, json);
    }
}
