using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{

    public Dialog Dialog;

    public void TriggerDialog ()
    {
        FindObjectOfType<DialogManager>().StartDialog(Dialog);

       
    }

}
