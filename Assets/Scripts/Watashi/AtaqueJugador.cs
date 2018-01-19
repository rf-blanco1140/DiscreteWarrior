using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueJugador : MonoBehaviour
{

    [SerializeField] Animator animator;

    private bool isAtaking;


	// Use this for initialization
	void Start ()
    {
        isAtaking = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            isAtaking = true;
            animator.SetBool("Atacando", true);
        }
    }

    public void changeAtackBool()
    {
        animator.SetBool("Atacando", false);
        isAtaking = false;
    }

    public bool giveIsAtaking()
    {
        return isAtaking;
    }
}
