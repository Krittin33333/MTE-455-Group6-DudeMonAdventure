using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogText;
    // Start is called before the first frame update
    private Queue<string> sentences;
    public AudioSource ClickSound;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialog (Dialog dialog)
    {
       
        nameText.text = dialog.name;

        sentences.Clear();

        foreach (string sentence in dialog.sentences) 
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
        if (sentences.Count == 0) 
        {
            EndDialog();
            return;
        }
        ClickSound.Play();
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return null;
        }
    }

    void EndDialog () 
    {
        Debug.Log("End of conversation.");
    }

 
}
