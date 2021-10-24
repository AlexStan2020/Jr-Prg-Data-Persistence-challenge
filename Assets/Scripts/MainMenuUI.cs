using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public HighScoreManager instance;
    public InputField nameText;

    public void StartGame()
    {
        instance.currentName = nameText.text;
        //Debug.Log(instance.currentName + "input: " + nameText.text);
        nameText.gameObject.SetActive(false);
        GameObject.Find("TextName").SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
    Application.Quit();
#endif
    }
}
