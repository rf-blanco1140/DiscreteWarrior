using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGeneral : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Death")
        {
            //Debug.Log("Es el jugador");
            CheckpointManagment.instance.returnToLastCheckpoint();
        }
    }

}
