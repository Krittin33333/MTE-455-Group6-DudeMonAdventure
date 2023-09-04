using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    // Start is called before the first frame update
    public int seceneBuildIndex;

    private void OnTriggerEnter(Collider other)
    {
        print("Trigger Enter");

        if (other.tag == "Player" )
        {
            SceneManager.LoadScene(seceneBuildIndex);
        }
    }
}
