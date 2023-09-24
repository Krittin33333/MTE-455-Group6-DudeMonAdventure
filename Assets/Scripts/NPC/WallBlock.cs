using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;

public class WallBlock : MonoBehaviour
{
    public GameObject PressF;
    public GameObject DialogPanel;
    public Dialog Dialog;
    
    bool player_detection = false;
   
    void Update()
    {

    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            player_detection = true;
            Debug.Log("F Open");
            TriggerDialog();
            DialogOn();
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        player_detection = false;
        Debug.Log("F Off");
        DialogOff();
    }
    public void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().StartDialog(Dialog);


    }
    
    public void DialogOn()
    {
        if (DialogPanel.activeSelf != true)
        {
            DialogPanel.SetActive(true);
        }
        else
        {
            DialogPanel.SetActive(false);
        }
    }
    public void DialogOff()
    {
        if (DialogPanel.activeSelf != false)
        {
            DialogPanel.SetActive(false);
        }
       
    }

}
