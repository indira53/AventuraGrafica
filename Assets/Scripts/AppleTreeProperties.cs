using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AppleTreeProperties : MonoBehaviour, IPointerClickHandler
{

    public string[] DialogueAppleLook = { "Mmm, me apetece una manzana." };
    public string[] DialogueAppleTake = { "Están demasiado altas para cogerlas." };
    public string[] DialogueAppleUse = { "No llego a las manzanas." };
    public string[] DialogueAppleUseWithBranch = { "¡He hecho que caigan las manzanas al varear el arbol!" };

    public GameObject gameManager;

    // Este campo aparece en el Inspector como un checkbox
    public bool isActive;
    public float targetPositionX;
    public float targetPositionY;

    // Arrastra el GameObject que quieres activar/desactivar
    public GameObject objectToToggle;

    private ButtonsBehaviour buttonsBehaviour;
    public GameObject player;
    private DialogueManager dialogueManager;
    private Inventory inventory;

    public GameObject applesFloor;

    void Start()
    {
        buttonsBehaviour = gameManager.GetComponent<ButtonsBehaviour>();
        dialogueManager = gameManager.GetComponent<DialogueManager>();
        targetPositionY = gameManager.transform.position.y;
        inventory = gameManager.GetComponent<Inventory>();
    }
    public void OnPointerClick(PointerEventData eventData)  //si se ha pulsado el boton usar --> activar dialogo
    {
        if (buttonsBehaviour.GetLookButton())
        {
            dialogueManager.Dialogue(DialogueAppleLook);

            player.GetComponent<Animator>().SetBool("isRunning", true);

        }

        if(buttonsBehaviour.GetTakeButton())
        {
            dialogueManager.Dialogue(DialogueAppleTake);

        }

        if (buttonsBehaviour.GetUseButton()) 
        {

            if (inventory.getSelectedItem() == Inventory.Items.Branch)
            {
                dialogueManager.Dialogue(DialogueAppleUseWithBranch);
                this.gameObject.SetActive(false);
                applesFloor.SetActive(true);
            }
            else
            {
                dialogueManager.Dialogue(DialogueAppleUse);
            }
        }
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
