using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIStartMenu : MonoBehaviour
{
    public string playerName;
    public Text BestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        BestScoreText.text = "Best Score: " + DataManager.Instance.dataLoaded.topPlayerName + ": " + DataManager.Instance.dataLoaded.topScore;
        //playerName = DataManager.Instance.dataLoaded.lastPlayer;
    }

    public void StartNew()
    {
        if (playerName == "") return;
        else
        {
            Debug.Log("playerName: " + playerName);
            DataManager.Instance.dataLoaded.lastPlayer = playerName;
            SceneManager.LoadScene(1);
        }

    }

    public void Exit()
    {
        DataManager.Instance.SaveData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // only works in the built application
#endif
    }

    public void InputEdit(InputField inpF)
    {
        playerName = inpF.text;
        Debug.Log(playerName);
    }
}
