using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

	// Use this for initialization
	void Start ()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
	
    public SimpleObjectPool givePool()
    {
        SimpleObjectPool poolToReturn = this.GetComponent<SimpleObjectPool>();
        return poolToReturn;
    }

}
