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
    [SerializeField]private string _playerName = "";
    public TMP_InputField _inputField;

    // Start is called before the first frame update
    void Start()
    {
        _inputField = GameObject.Find("PlayerNameInputField").GetComponent<TMP_InputField>();
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

    public void InputPlayerName() //Save Player Name
    {
        Debug.Log(_inputField.text);
        _playerName = _inputField.text;
       
        GameManager.Instance.SaveHighScore();
    }

    void SaveScore()
    {

    }
}
