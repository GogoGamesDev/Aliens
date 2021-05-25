using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSystem : MonoBehaviour
{
    public GameObject Jugador;

  string nivel;
  public void Save()
  {
    GuardarVector ("Jugador", Jugador.transform.position); //Guardará el vector del jugador con nombre "Jugador"
  }

  public void Load()
  {
    var playerPosTemp = CargarVector("Jugador"); //Ejecuta la función para cargar el vector de "Jugador"
    Jugador.transform.position = playerPosTemp == new Vector3() ? Jugador.transform.position : playerPosTemp; //aquí estamos usando algo llamado "ternario"
    //los ternarios son como un "if" de una sola línea. condición ? if true : if false
    //Entonces, en este caso si la posición temporal que cargamos es un vector vacío, carga la posición actual (la que tiene al iniciar la partida)
    //pero en caso contrario, cargará la posición temporal
  }

  public Vector3 CargarVector(string nombre)
  {
    Vector3 valor = Vector3.zero; //Inicializa un vector en 0s
    valor.x = PlayerPrefs.GetFloat(nombre + "_x" + "_" + nivel, 0); //Carga lo que sea que esté guardado como el nombre_x (por ejemplo, Jugador_x)
    valor.y = PlayerPrefs.GetFloat(nombre + "_y" + "_" + nivel, 0); //Carga lo que sea que esté guardado como el nombre_y (por ejemplo, Jugador_y)
    valor.z = PlayerPrefs.GetFloat(nombre + "_z" + "_" + nivel, 0); //Carga lo que sea que esté guardado como el nombre_z (por ejemplo, Jugador_z)
    return valor;
  }

  public void GuardarVector(string nombre, Vector3 valores)
  {
    PlayerPrefs.SetFloat(nombre + "_x" + "_" + nivel, valores.x); //Guarda el valor de x en el nombre_x (por ejemplo, Jugador_x)
    PlayerPrefs.SetFloat(nombre + "_y" + "_" + nivel, valores.y); //Guarda el valor de y en el nombre_y (por ejemplo, Jugador_y)
    PlayerPrefs.SetFloat(nombre + "_z" + "_" + nivel, valores.z); //Guarda el valor de z en el nombre_z (por ejemplo, Jugador_z)
  }

   public void ExitMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }
   
}

