using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class BranchProperties : MonoBehaviour, IPointerClickHandler
{
    public GameObject gameManager;

    private ButtonsBehaviour buttonsBehaviour;
    public GameObject player;
    private DialogueManager dialogueManager;
    private Inventory inventory;

    public string[] DialogueBranchLook = { "Una rama." };
    public string[] DialogueBranchTake = { "Ahora tengo una rama." };
    public string[] DialogueBranchUse = { "No puedo usar algo que no tengo." };


    // Start is called before the first frame update
    void Start()
    {
        buttonsBehaviour = gameManager.GetComponent<ButtonsBehaviour>();
        dialogueManager = gameManager.GetComponent<DialogueManager>();
        inventory = gameManager.GetComponent<Inventory>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (buttonsBehaviour.GetLookButton())
        {
            dialogueManager.Dialogue(DialogueBranchLook);
        }

        if (buttonsBehaviour.GetTakeButton())
        {
            inventory.addItemsToInventory(Inventory.Items.Branch); //añade la cesta al inventario

            gameObject.SetActive(false);

            dialogueManager.Dialogue(DialogueBranchTake);
        }

        if (buttonsBehaviour.GetUseButton())
        {
            dialogueManager.Dialogue(DialogueBranchUse);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
