using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acidController : MonoBehaviour
{
   public int damageAmount;
   public float cooldownTime = 1f; //Cada [esto] tiempo en segundos, hace daño
   public bool canDamage; //Solo para verificar si puede hacer daño o no

 void OnTriggerStay2D(Collider2D col)
 {
    if(col.tag == "Player" && canDamage) 
    { //Si el collider es el jugador Y puede hacer daño
      StartCoroutine(DoDamage()); //Empieza la corroutina
    }
 }

   IEnumerator DoDamage()
   {
      canDamage = false; //No puedes hacer daño
      PlayerController.instance.TakeDamage(damageAmount); //Haz que el jugador reciba daño
      yield return new WaitForSeconds(cooldownTime); //Espera este tiempo
      AudioController.instance.PlayPlayerHurt();
      canDamage = true; //Ahora sí podemos hacer daño
   }
    
}
