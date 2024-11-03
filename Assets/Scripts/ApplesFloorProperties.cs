using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ApplesFloorProperties : MonoBehaviour, IPointerClickHandler
{
    private ButtonsBehaviour buttonsBehaviour;
    private DialogueManager dialogueManager;
    private Inventory inventory;
    public GameObject gameManager;
    public GameObject Apple;

    public string[] DialogueApplesFloorLook = { "Hay manzanas en el suelo." };
    public string[] DialogueApplesFloorTake = { "Tengo una manzana, pero necesito algo donde guardar las demás." };
    public string[] DialogueApplesFloorUse = { "Sigo necesitango algo donde guardarlas." };
    public string[] DialogueApplesFloorUseWithCesta = { "¡Qué bien! Ahora tengo una cesta con manzanas." };
    public string[] DialogueApplesFloorUseWithApple = { "No puedo usar una manzana con las manzanas." };
    public string[] DialogueApplesFloorUseWithBranch = { "La rama no me sirve para guardar las manzanas." };
    public void OnPointerClick(PointerEventData eventData)
    {
        if (buttonsBehaviour.GetLookButton())
        {
            dialogueManager.Dialogue(DialogueApplesFloorLook);
        }

        if (buttonsBehaviour.GetTakeButton())
        {
            dialogueManager.Dialogue(DialogueApplesFloorTake);
            Apple.SetActive(false);
            inventory.addItemsToInventory(Inventory.Items.Apple);
        }

        if (buttonsBehaviour.GetUseButton())
        {
            if (inventory.getSelectedItem() == Inventory.Items.Cesta)
            {
                dialogueManager.Dialogue(DialogueApplesFloorUseWithCesta);
                this.gameObject.SetActive(false);
                inventory.addItemsToInventory(Inventory.Items.AppleCesta);
                inventory.removeItemsFromInventory(Inventory.Items.Cesta);
                

            }

            if (inventory.getSelectedItem() == Inventory.Items.Apple)
            {
                dialogueManager.Dialogue(DialogueApplesFloorUseWithApple);
                inventory.selectedItem = 0;
            }

            if (inventory.getSelectedItem() == Inventory.Items.Branch)
            {
                dialogueManager.Dialogue(DialogueApplesFloorUseWithBranch);
                inventory.selectedItem = 0;
            }

            if (inventory.getSelectedItem() == Inventory.Items.None)
            {
                dialogueManager.Dialogue(DialogueApplesFloorUse);
                inventory.selectedItem = 0;
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        buttonsBehaviour = gameManager.GetComponent<ButtonsBehaviour>();
        dialogueManager = gameManager.GetComponent<DialogueManager>();
        
        inventory = gameManager.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
