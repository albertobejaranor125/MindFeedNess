using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Net.Sockets;
using System;

public class ScriptManager : MonoBehaviour
{
    public Button exitButton;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
}
