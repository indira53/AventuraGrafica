using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotsBehaviour : MonoBehaviour, IPointerClickHandler
{
    private ButtonsBehaviour buttonsBehaviour;
    public GameObject gameManager;
    private Inventory inventory;
    private DialogueManager dialogueManager;

    public string[] DialogueApple = { "Mmm, que rica." };

    public int slot;
    public void OnPointerClick(PointerEventData eventData)
    {
        inventory.selectedItem = slot; 
        inventory.updateInventoryDisplay();

        if (buttonsBehaviour.GetUseButton())
        {
            if (inventory.getSelectedItem() == Inventory.Items.Apple)
            {
                dialogueManager.Dialogue(DialogueApple);
                inventory.removeItemsFromInventory(Inventory.Items.Apple);
                inventory.updateInventoryDisplay();
            }

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        buttonsBehaviour = gameManager.GetComponent<ButtonsBehaviour>();
        inventory = gameManager.GetComponent<Inventory>();
        dialogueManager = gameManager.GetComponent<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
