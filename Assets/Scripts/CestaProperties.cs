using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CestaProperties : MonoBehaviour, IPointerClickHandler
{


    public GameObject gameManager;

    private ButtonsBehaviour buttonsBehaviour;
    public GameObject player;
    private DialogueManager dialogueManager;
    private Inventory inventory;

    public string[] DialogueCestaLook = { "Una cesta." };
    public string[] DialogueCestaTake = { "He cogido una cesta." };
    public string[] DialogueCestaUse = { "No puedo usar la cesta si no la tengo." };
    public string[] DialogueCestaSearch = { "Solo es una cesta." };

    public float targetPositionX;


    // Start is called before the first frame update
    void Start()
    {
        buttonsBehaviour = gameManager.GetComponent<ButtonsBehaviour>();
        dialogueManager = gameManager.GetComponent<DialogueManager>();
        inventory = gameManager.GetComponent<Inventory>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
       /* if (buttonsBehaviour.GetLookButton() || buttonsBehaviour.GetTakeButton() || buttonsBehaviour.GetUseButton() && player.transform.position.x >= targetPositionX)
        {
            player.GetComponent<Animator>().SetBool("isRunningR", true);
        }*/

        if (buttonsBehaviour.GetLookButton())
        {
            dialogueManager.Dialogue(DialogueCestaLook);
            player.GetComponent<Animator>().SetBool("isRunningR", true);
        }

        if (buttonsBehaviour.GetTakeButton())
        {
            inventory.addItemsToInventory(Inventory.Items.Cesta); //añade la cesta al inventario

            gameObject.SetActive(false);

            dialogueManager.Dialogue(DialogueCestaTake);

        }

        if (buttonsBehaviour.GetUseButton())
        {
            dialogueManager.Dialogue(DialogueCestaUse);
        }

        if (buttonsBehaviour.GetSearchButton())
        {
            dialogueManager.Dialogue(DialogueCestaSearch);

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x >= targetPositionX && player.GetComponent<Animator>().GetBool("isRunningR"))
        {

            player.GetComponent<Animator>().SetBool("isRunningR", false);


        }
    }
}

