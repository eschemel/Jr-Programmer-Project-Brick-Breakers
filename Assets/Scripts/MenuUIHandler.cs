using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    [Header("Player Name")]
    [SerializeField]private string playerName = "";
    public GameObject inputField;

    // Start is called before the first frame update
    void Start()
    {
        string newPlayerName = inputField.GetComponent<TMP_InputField>().text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
            Application.Quit(); // original code to quit Unity player
#endif
    }

    public void OnString_PlayerName(string value) //Save Player Name
    {
        Debug.Log(value);
        playerName = value;
        GameManager.Instance.SaveHighScore();
    }

    void SaveHighScore()
    {

    }
}
