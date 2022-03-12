using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; //required for JsonUtility

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Save Data")]
    public string m_playername;
    public int m_highScore;

    [Header("Current Game")]
    public string m_cPlayerName; //Hidden until high score.
    public int m_cScore; //current game score

    private bool _reset = false;

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
        public string m_playername;
        public int m_highScore;
    }

    //Saving to Json
    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        //Reset
        if (_reset)
        {
            data.m_playername = "Player";
            data.m_highScore = 0;
        }
        else
        {
            data.m_playername = m_playername;
            data.m_highScore = m_highScore;
        }

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

            if (_reset)
            {
                m_playername = "Player";
                m_highScore = 0;
            }
            else
            {
                m_playername = data.m_playername;
                m_highScore = data.m_highScore;
            }
        }
    }
}
