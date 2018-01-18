using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentManager : MonoBehaviour
{

    // VARIABLES

    // Referencia al pool de objetos de donde salen los fragmentos
    public SimpleObjectPool pool;



    // METODOS

    public void initializeFragment(SimpleObjectPool pPool)
    {
        pool = pPool;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            StartCoroutine(disapearInTime());
        }
    }

    private IEnumerator disapearInTime()
    {
        yield return new WaitForSeconds(0.3f);
        pool.ReturnObject(this.gameObject);
    }
}
