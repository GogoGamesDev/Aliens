using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmetUpgrade : MonoBehaviour
{
    public GameObject ActualUI;
    public GameObject NewUI;

    public bool ActualUIOff = false;

    public AudioSource getNewUI;
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
         
            PlayUpgradePickup();
            ActualUI.SetActive(false);
            NewUI.SetActive(true);
            
            Destroy(gameObject);

        }
        
    }


    public void PlayUpgradePickup()
    {
        getNewUI.Stop();
        getNewUI.Play();
    }
}
