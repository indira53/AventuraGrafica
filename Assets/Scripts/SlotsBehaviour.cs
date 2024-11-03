using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotsBehaviour : MonoBehaviour, IPointerClickHandler
{
    private ButtonsBehaviour buttonsBehaviour;
    public GameObject gameManager;
    private Inventory inventory;
    private DialogueManager dialogueManager;
    private AudioSource audioSource;

    public string[] DialogueApple = { "Mmm, que rica." };

    public int slot;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (this.GetComponent<SpriteRenderer>().sprite != null)
        {
            if (inventory.selectedItem == slot)
            {
                inventory.selectedItem = 0;
                inventory.updateInventoryDisplay();
            }

            else
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
                        audioSource.Play();
                    }

                }

            }

        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        buttonsBehaviour = gameManager.GetComponent<ButtonsBehaviour>();
        inventory = gameManager.GetComponent<Inventory>();
        dialogueManager = gameManager.GetComponent<DialogueManager>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
