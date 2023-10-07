using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private int day = 0;
    public int Day { get { return day; } set { day = value; } }

    private void Awake()
    {
       instance = this;
       /* if (instance == null)
        {
            // If there's no instance, this is the first one, so don't destroy it.
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this one.
            Destroy(gameObject);
        }*/

    }

    // Update is called once per frame
    void Update()
    {
        //Working();
    }

 
}
