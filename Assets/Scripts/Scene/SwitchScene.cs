using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] string mapScene;
    public GameObject LoadingScene;

    private void Awake()
    {
        LoadingStart();
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {

        print("Trigger Enter");

        if (other.tag == "Player")
        {
            Loading();
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(mapScene);
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
