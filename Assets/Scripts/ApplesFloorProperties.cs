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
    public GameObject player;

    public bool meComiUnaManzana;

    public float targetPositionX;
    public float targetPositionY;   


    public string[] DialogueApplesFloorLook = { "Hay manzanas en el suelo." };
    public string[] DialogueApplesFloorTake = { "Tengo una manzana, pero necesito algo donde guardar las demás." };
    public string[] DialogueApplesFloorUse = { "Sigo necesitando algo donde guardarlas." };
    public string[] DialogueApplesFloorSearch = { "Solo son manzanas." };
    public string[] DialogueApplesFloorUseWithCesta = { "¡Qué bien! Ahora tengo una cesta con manzanas." };
    public string[] DialogueApplesFloorUseWithApple = { "No puedo usar una manzana con las manzanas." };
    public string[] DialogueApplesFloorUseWithBranch = { "La rama no me sirve para guardar las manzanas." };
    public string[] DialogueApplesFloorMeComiUnaManzana = { "No, ya me he comido una manzana, tengo que llevar las otras a casa." };
    public void OnPointerClick(PointerEventData eventData)
    {
        if (buttonsBehaviour.GetLookButton())
        {
            dialogueManager.Dialogue(DialogueApplesFloorLook);
            player.GetComponent<Animator>().SetBool("isRunning", true);
        }

        if (buttonsBehaviour.GetTakeButton()) 
        {
            if (!meComiUnaManzana) 
            {
                dialogueManager.Dialogue(DialogueApplesFloorTake);
                Apple.SetActive(false);
                inventory.addItemsToInventory(Inventory.Items.Apple);

                meComiUnaManzana = true;
            }

            else
            {
                dialogueManager.Dialogue(DialogueApplesFloorMeComiUnaManzana);
            }
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
            }

            if (inventory.getSelectedItem() == Inventory.Items.Branch)
            {
                dialogueManager.Dialogue(DialogueApplesFloorUseWithBranch);
            }

            if (inventory.getSelectedItem() == Inventory.Items.None)
            {
                dialogueManager.Dialogue(DialogueApplesFloorUse);
            }

        }

        if (buttonsBehaviour.GetSearchButton())
        {
            dialogueManager.Dialogue(DialogueApplesFloorSearch);
        }

    }



    // Start is called before the first frame update
    void Start()
    {
        buttonsBehaviour = gameManager.GetComponent<ButtonsBehaviour>();
        dialogueManager = gameManager.GetComponent<DialogueManager>();
        targetPositionY = gameManager.transform.position.y;
        inventory = gameManager.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x <= targetPositionX)
        {
            player.GetComponent<Animator>().SetBool("isRunning", false);
        }
    }
}
