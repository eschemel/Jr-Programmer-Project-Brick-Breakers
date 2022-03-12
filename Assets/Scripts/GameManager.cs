using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; //required for JsonUtility

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Save Data")]
    public string playername;
    public int highScore;

    [Header("Current Game")]
    public string cPlayerName;

    //Allows access to the MainManager GameObject between scenes
    private void Awake()
    {
        //Ensure only a single instance exists
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable] //required for JsonUtility
    class SaveData
    {
        public string playername;
        public int highScore;
    }

    //Saving to Json
    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.playername = playername;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    //Loading from Json
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playername = data.playername;
            highScore = data.highScore;
        }
    }
}
