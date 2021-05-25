using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class MainMenuController : MonoBehaviour
{

   


    
    void Start()
    {


        
    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Lvl1");

    }

    public void ExitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();

    }
}
