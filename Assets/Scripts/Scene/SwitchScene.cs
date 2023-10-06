using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] string mapScene;

    [SerializeField] private GameObject dudemonPrefab;
    public GameObject DudemonPrefab { get { return dudemonPrefab; } }

    private void OnTriggerEnter(Collider other)
    {
        print("Trigger Enter");

        if (other.tag == "Player")
        {
            if (mapScene == "Turnbase") { 
                 Office.instance.Setlevelenemy(DudemonPrefab);
                SceneManager.LoadScene(mapScene);
            }
            SceneManager.LoadScene(mapScene);
        }
    }


}