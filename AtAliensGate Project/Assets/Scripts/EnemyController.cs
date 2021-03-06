using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 3;
    public GameObject explosion;
    public float playerRange = 10f;

    public Rigidbody2D theRB;
    public float moveSpeed;

    public bool shouldShoot;
    public float fireRate = .5f;

    private float shotCounter;
    public GameObject bullet;
    public Transform firePoint;
    public bool iShoot = false;
    public bool followingPlayer = false;

    void Update()
    {

        if(Vector3.Distance(transform.position, PlayerController.instance.transform.position) < playerRange)
        {
            followingPlayer = true;
            Vector3 playerDirection = PlayerController.instance.transform.position - transform.position;

            theRB.velocity = playerDirection.normalized * moveSpeed;

            if(shouldShoot)
            {
                shotCounter -= Time.deltaTime;
                if(shotCounter <= 0)
                {
                    Instantiate(bullet, firePoint.position, firePoint.rotation);
                    shotCounter = fireRate; 

                    iShoot = true;   
                }
            }else
            {
                followingPlayer = false;
            }
            if(iShoot==true)
            {
              AudioController.instance.PlayEnemyShot();

              iShoot = false;

            }
        } else
        {
            theRB.velocity = Vector2.zero;
        }
    }
    public void TakeDamage(Transform currentPlayerPosition) 
    {
        health--;
        if(health <= 0) 
        { 
            Instantiate(explosion, transform.position, transform.rotation);
            AudioController.instance.PlayEnemyDie();
            Destroy(gameObject); //Hacer esto, destruirá al objeto y el codigo ya no se ejecutará, así que no instanciará ni rerpoducirá el enemigo
           
        }else 
        {
         AudioController.instance.PlayEnemyShot(); //Como estás destruyendo el objeto, no es necesario poner un "else" ya que el tener un Destroy hará que ya no se reproduzca código
        }
         if(followingPlayer) //Aquí es si *no* lo está siguiendo o atacando, entonces seguirlo 
         {
             //MoverseA(currentPlayerPosition); //No sé si "MoverseA" exista, aquí va la función que sea que uses para mover al enemigo y lo que sea que uses para pasarle la posición a la que va
         } 
    }

}
