using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManagment : MonoBehaviour
{
    /**
     * Clase que maneja toda la logica relacionada con la muerte del jugador y el respawn
     */


    // VARIABLES


    // Singleton de este script
    public static CheckpointManagment instance = null;
    // Posicion el ultimo checkpoint
    public Vector3 lastPosition;
    // Referencia a Watashi
    public GameObject watashiGO;
    // Estado en el que se encontraba el mundo en el ultimo checkmpoint



    // METODOS


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// Metodo que retorna la posicion del ultimo checkpoint alcanzado
    /// </summary>
    /// <returns> Vector3 con la posicion del ultimo checkpoint alcanzado </returns>
    public Vector3 giveLastPosition()
    {
        return lastPosition;
    }

    /// <summary>
    /// Metodo que cambia donde esta el checkpoint actual
    /// </summary>
    /// <param name="newLastPosition"></param>
    public void changelastPosition(Vector3 newLastPosition)
    {
        lastPosition = newLastPosition;
    }

    /// <summary>
    /// Metodo que devuelve a Watashi a la posicion del ultimo checkpoint
    /// </summary>
    public void returnToLastCheckpoint()
    {
        watashiGO.GetComponent<Transform>().position = lastPosition;
        watashiGO.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Death")
        {
            //Debug.Log("Es elManager");
            returnToLastCheckpoint();
        }
    }

}
