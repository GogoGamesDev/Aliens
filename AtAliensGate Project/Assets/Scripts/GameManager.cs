using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        instance = this; 

        
    }



    void Start()
    {
        LockCursor();

        
    }

    void Update()
    {
        if(PauseManager.instance.isPaused == false)
        {
             if(PlayerController.instance.currentHealth > 0)
             {
               if(Input.GetKeyDown(KeyCode.Escape))
               {
                  UnlockCursor();

                }

               if(Input.GetMouseButton(0))
               {
                 LockCursor();
            
                }

            }
        }
       

        
        
    }

        

       
    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }
}
