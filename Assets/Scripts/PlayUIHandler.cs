using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayUIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //This goes to Main Menu
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    //This goes to Energy Level User
    public void GoToEnergyLeverUser()
    {
        SceneManager.LoadScene(4);
    }
}
