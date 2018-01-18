using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectCheckpointBehaivour : MonoBehaviour
{

    // VARIABLES

    // Indica si este checpoint ya fue alcanzado
    private bool checkpointAlcanzado;



    // Use this for initialization
    void Start ()
    {
        checkpointAlcanzado = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && checkpointAlcanzado==false)
        {
            checkpointAlcanzado = true;
            CheckpointManagment.instance.changelastPosition(this.transform.position);
        }
    }
}
