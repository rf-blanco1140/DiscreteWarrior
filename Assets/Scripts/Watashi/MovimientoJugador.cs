using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    
    // VARIABLES

    [SerializeField] Transform transform;
	[SerializeField] Animator animator;
	float limite = 0.075f;

    // Indica si Watashi esta parado en un objeto
    private bool grounded;
    // Indica donde deberia estar el piso con respecto al personaje
    public Transform groundCheck;
    // El radio de la esfera que va a revisar si hay piso
    private float groundRadius = 0.2f;
    // Le indica a Watashi que onjetos son considerados piso
    public LayerMask whatIsGround;
    // Fuerza con la que va a saltar
    public float jumpForce;


    //METHODS

	// Use this for initialization
	void Start ()
    {
        grounded = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 10.0f;
        var y = Input.GetAxis("Vertical"); //* Time.deltaTime * 10.0f;
		//animator.SetBool("Atacando", false);

        transform.Translate(x, 0, 0);
        jumping();


        if(x >= limite || x <= -limite)
        {
        	animator.SetBool("Caminando", true);
        }
        else
        {
			animator.SetBool("Caminando", false);
        }

		if(Input.GetKeyDown (KeyCode.LeftShift))
		{
			animator.SetBool("Atacando", true);
			//Debug.Log(animator.GetBool("Atacando"));

		}
	}

    private void FixedUpdate()
    {
        Collider[] hittingColliders = Physics.OverlapSphere(groundCheck.position, groundRadius, whatIsGround);
        if (hittingColliders.Length > 0) { grounded = true; }
        else { grounded = false; }
        animator.SetBool("Ground", grounded);

        animator.SetFloat("verticalSpeed", GetComponent<Rigidbody>().velocity.y);
    }

    /// <summary>
    /// Metodo que se encarga del salto de watahsi
    /// </summary>
    public void jumping()
    {
        if(grounded && Input.GetButtonDown("Jump"))
        {
            //Debug.Log("quiso saltar");
            animator.SetBool("Ground", false);
            grounded = false;
            GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
