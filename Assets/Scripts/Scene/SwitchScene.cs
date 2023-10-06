using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] string mapScene;
    public GameObject LoadingScene;

    [SerializeField] private GameObject dudemonPrefab;
    public GameObject DudemonPrefab { get { return dudemonPrefab; } }
    
    private void Awake()
    {
        if (LoadingScene != null)
        LoadingStart();
        
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (LoadingScene != null)
        {
            
        
        print("Trigger Enter");

        if (other.tag == "Player")
        {
            if (mapScene == "Turnbase")
            {
                Office.instance.Setlevelenemy(DudemonPrefab);
                Loading();
                yield return new WaitForSeconds(2f);
                SceneManager.LoadScene(mapScene);
                
            }
            else { 
            Loading();
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(mapScene);
            }
        }
        }
    }

    public void Loading()
    {
        if (LoadingScene.activeSelf != true)
        {
            LoadingScene.SetActive(true);
        }
    }

    public void LoadingStart()
    {
        if (LoadingScene.activeSelf != false)
        {
            LoadingScene.SetActive(false);
        }
    }
}
