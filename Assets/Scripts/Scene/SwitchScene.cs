using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] string mapScene;


    private void OnTriggerEnter(Collider other)
    {
        print("Trigger Enter");

        if (other.tag == "Player")
        {

            Setlevelenemy();
            SceneManager.LoadScene(mapScene);
        }
    }

    public void Setlevelenemy()
    {
        Office.instance.Enemyhitted = LevelUI.instance.WorkerPrefab;
        Office.instance.Levelenemy = LevelUI.instance.Levelenemy;
    }
}