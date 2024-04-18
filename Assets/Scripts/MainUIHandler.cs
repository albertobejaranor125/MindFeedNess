using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainUIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // This goes to Play Menu
    public void GoToPlayMenu()
    {
        SceneManager.LoadScene(3);
    }
    // This goes to Option Menu
    public void GoToOptionMenu()
    {
        SceneManager.LoadScene(2);
    }
    // This goes to Credit Menu
    public void GoToCreditMenu()
    {
        SceneManager.LoadScene(1);
    }
    // This goes to Exit Game
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
