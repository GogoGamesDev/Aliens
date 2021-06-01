using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public Animator anim;
    public SpriteRenderer spriteRenderer;
    public float speed = 0.5f;
    private float waitTime;
    public float startWaitTime = 2;
    private int i = 0;
    private Vector2 actualPose;
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

    public Transform[] moveSpots;

    public bool iShoot = false;
    public bool followingPlayer = false;

    void Start()
    {
        waitTime = startWaitTime;
        
    }

    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position,speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, moveSpots[i].transform.position) < 0.1f)
        {

            if(waitTime <= 0)
            {
                if(moveSpots[i] != moveSpots[moveSpots.Length -1])
                {
                    i++;
                }else
                {
                    i = 0;
                }

                waitTime = startWaitTime;

            }else
            {
                waitTime -= Time.deltaTime;
            }

        }




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


     public void TakeDamage() 
     {
        health--;
        if(health <= 0) 
        {
            Instantiate(explosion, transform.position, transform.rotation);
            AudioController.instance.PlayEnemyDie();

            Destroy(gameObject);
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
