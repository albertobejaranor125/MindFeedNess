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
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Button exitButton;
    private int score;
    private int highScore;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        highScore = 0;
        UpdateScore(0);
    }

    private void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Puntos: "+score;
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
