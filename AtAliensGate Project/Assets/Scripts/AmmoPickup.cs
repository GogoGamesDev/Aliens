using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
   public int ammoAmount = 25;
    void Start()
    {
        
    }

   
    void Update() 
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            AudioController.instance.PlayAmmoPickup(); 
            
            PlayerController.instance.currentAmmo += ammoAmount;
            PlayerController.instance.UpdateAMMO();


            Destroy(gameObject);
        }
        
    }
}
