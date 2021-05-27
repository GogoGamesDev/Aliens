using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class MainMenuController : MonoBehaviour
{
    public GameObject loadingObject;

    
    public void StartGameButton()
    {
        StartCoroutine(StartGame());

       

    }
    public void ExitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();

    }

        IEnumerator StartGame()
        { 
          loadingObject.SetActive(true);

          yield return new WaitForSeconds(2);


          loadingObject.SetActive(false);
          SceneManager.LoadScene("Lvl1");




        }


    
}
