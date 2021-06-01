using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    public static PauseManager instance;
    public bool isPaused = false;
    public GameObject pauseCam;

    private bool m_isAxisInUse = false;


    private void Awake() 
    {
        instance = this;

        
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {             
            isPaused = true;
            pausePanel.SetActive(true);
            Time.timeScale = 0;


        }


        if( Input.GetAxisRaw("Cancel") != 0)
        {
            if(m_isAxisInUse == false)
            {
                  isPaused = true;
                  pausePanel.SetActive(true);
                  Time.timeScale = 0;              
                  m_isAxisInUse = true;
            }
        }

        if( Input.GetAxisRaw("Cancel") == 0)
        {
           m_isAxisInUse = false;
        }   

        if(isPaused == true)
        {
            PlayerController.instance.viewCam.enabled = false;
        }else
        {
            
            PlayerController.instance.viewCam.enabled = true;
            pauseCam.SetActive(false);
        }

        
    }

    public void playButton()
    {
        isPaused = false;
        LockCursor1();
        pausePanel.SetActive(false);
        Time.timeScale = 1;

    }

    public void Menu()
    {
      isPaused = false;
 
      SceneManager.LoadScene("MainMenu");

    }


     public void LockCursor1()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
}
