using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialog
{

    public string name;

   // public Image Character;
    public Sprite CharacUI;

    [TextArea(3,10)]
    public string[] sentences;

}
