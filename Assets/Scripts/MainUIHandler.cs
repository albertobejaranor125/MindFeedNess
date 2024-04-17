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
    // This go to Option Menu
    public void GoToOptionMenu()
    {
        SceneManager.LoadScene(2);
    }
    // This go to Credit Menu
    public void GoToCreditMenu()
    {
        SceneManager.LoadScene(1);
    }
    // This go to Exit Game
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
