using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;

public class NPCSystem : MonoBehaviour
{
    public GameObject PressF;
    public GameObject DialogPanel;
    public Dialog Dialog;
    
    bool player_detection = false;
   
    void Update()
    {
        
        if (player_detection && Input.GetKeyDown(KeyCode.F))
        {
            print("Dialogue Start");           
            TriggerDialog();
            DialogOn();


        }
        

    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            player_detection = true;
            HideButton();
            Debug.Log("F Open");
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        player_detection = false;
        HideButtonOff();
        Debug.Log("F Off");
        DialogOff();
    }
    public void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().StartDialog(Dialog);


    }
    public void HideButton()
    {
        if (PressF.activeSelf != true) 
        {
            PressF.SetActive(true);
        }
        else
        {
            PressF.SetActive(false);
        }
    }
    public void HideButtonOff()
    {
        if (PressF.activeSelf != false)
        {
            PressF.SetActive(false);
        }
 
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
