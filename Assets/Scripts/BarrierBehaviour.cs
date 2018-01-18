using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierBehaviour : MonoBehaviour {

    public FragmentationPoint[] childsBreakingScripts;


	// Use this for initialization
	void Start ()
    {
        childsBreakingScripts = GetComponentsInChildren<FragmentationPoint>();
	}

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<AtaqueJugador>().giveIsAtaking())
        {
            //Debug.Log("Is_Weapon");
            foreach(FragmentationPoint fragScript in childsBreakingScripts)
            {
                fragScript.callGetSpaceCoroutine();
            }
        }
    }
}
