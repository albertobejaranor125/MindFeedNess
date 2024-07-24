using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainUIHandlerDefinitive : MonoBehaviour
{
    public GameObject RequestMainMenu;
    public GameObject MainMenu;
    public GameObject CreditMenu;
    public GameObject OptionMenu;
    public GameObject PlayMenu;
    // Start is called before the first frame update
    void Start()
    {
        RequestMainMenu.SetActive(true);
        MainMenu.SetActive(false);
        CreditMenu.SetActive(false);
        OptionMenu.SetActive(false);
        PlayMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartMenu()
    {
        MainMenu.SetActive(true);
        RequestMainMenu.SetActive(false);
        OptionMenu.SetActive(false);
        CreditMenu.SetActive(false);
        PlayMenu.SetActive(false);
    }
    public void StartCreditMenu()
    {
        RequestMainMenu.SetActive(false);
        MainMenu.SetActive(false);
        CreditMenu.SetActive(true);
        OptionMenu.SetActive(false);
        PlayMenu.SetActive(false);
    }
    public void CloseCreditMenu()
    {
        RequestMainMenu.SetActive(false);
        MainMenu.SetActive(true);
        CreditMenu.SetActive(false);
        OptionMenu.SetActive(false);
        PlayMenu.SetActive(false);
    }
    public void StartOptionMenu()
    {
        RequestMainMenu.SetActive(false);
        MainMenu.SetActive(false);
        CreditMenu.SetActive(false);
        OptionMenu.SetActive(true);
        PlayMenu.SetActive(false);
    }
    public void CloseOptionMenu()
    {
        RequestMainMenu.SetActive(false);
        MainMenu.SetActive(true);
        CreditMenu.SetActive(false);
        OptionMenu.SetActive(false);
        PlayMenu.SetActive(false);
    }
    public void OpenPlayMenu()
    {
        RequestMainMenu.SetActive(false);
        MainMenu.SetActive(false);
        OptionMenu.SetActive(false);
        PlayMenu.SetActive(true);
        CreditMenu.SetActive(false);
    }
    public void ClosePlayMenu()
    {
        RequestMainMenu.SetActive(false);
        MainMenu.SetActive(true);
        CreditMenu.SetActive(false);
        OptionMenu.SetActive(false);
        PlayMenu.SetActive(false);
    }
    public void PlayEnergyLevel()
    {
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
