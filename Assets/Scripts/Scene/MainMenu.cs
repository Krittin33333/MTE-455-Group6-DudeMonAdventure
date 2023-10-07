using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string mapScene;
    public AudioSource ClickSound;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartNewGame()
    {
        ClickSound.Play();
        SceneManager.LoadScene(mapScene);
    }
    public void ExitScence()
    {
        Application.Quit();
        ClickSound.Play();
    }
}

