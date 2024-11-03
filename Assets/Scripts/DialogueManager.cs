using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] dialogues;
    public float letterDelay = 0.0f; //delay entre cada letra
    private Coroutine typingCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        StartDialogue(); //comienza el dialogo

    }

    public void StartDialogue()
    {
        typingCoroutine = StartCoroutine(TypeDialogue());
    }

    public void Dialogue (string[] text)
    {
        SkipDialogue();
        SetDialogues(text);
        StartDialogue();
    }

    IEnumerator TypeDialogue()
    {
        foreach (string dialogue in dialogues)
        {
            dialogueText.text = ""; //limpia el texto actual

            foreach (char letter in dialogue) //muestra el texto letra por letra
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(letterDelay);
            }

        }
    }
    

    public void SkipDialogue()
    {
        //Si el diálogo está siendo mostrado letra por letra, se puede saltar al siguiente diálogo
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
            dialogueText.text = dialogues[dialogues.Length - 1]; //Muestra todo el texto de una vez
        }
    }

    public void SetDialogues(string[] text)
    {
        dialogues = text;
    }



    
}
