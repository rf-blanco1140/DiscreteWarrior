using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentationPoint : MonoBehaviour
{

    public SimpleObjectPool thePool;

    public int numberOfFragments;

    public GameObject ObjectToFragment;

    private GameManager gmRefrence;



    // Use this for initialization
    void Start()
    {
        gmRefrence = GameManager.instance;

        thePool = gmRefrence.givePool();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetButtonDown("Jump"))
        {
            ObjectToFragment.GetComponent<BoxCollider>().enabled = false;
            //getSpace ();
            StartCoroutine(getSpace());
            breakMe();
        }*/
    }

    public void callGetSpaceCoroutine()
    {
        ObjectToFragment.GetComponent<BoxCollider>().enabled = false;
        //getSpace ();
        StartCoroutine(getSpace());
        breakMe();
    }

    private IEnumerator getSpace()
    {
        for (int i = 0; i < numberOfFragments; i++)
        {
            GameObject fragment = thePool.GetObject();
            fragment.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -1f);
            //fragment.GetComponent<Rigidbody> ().AddForce (transform.right * -150);
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void breakMe()
    {
        //ObjectToFragment.SetActive (false);
        ObjectToFragment.GetComponent<MeshRenderer>().enabled = false;
    }
}
