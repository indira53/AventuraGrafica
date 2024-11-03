using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArbustoProperties : MonoBehaviour, IPointerClickHandler
{
    public string[] DialogueArbustoLook = { "Un arbusto normal y corriente." };
    public string[] DialogueArbustoTake = { "No puedo coger un arbusto entero!" };
    public string[] DialogueArbustoUse = { "No puedo usar un arbusto." };

    public GameObject branch;
    public GameObject gameManager;

    private ButtonsBehaviour buttonsBehaviour;
    public GameObject player;
    private DialogueManager dialogueManager;
    private Inventory inventory;

    public float targetPositionY;
    public float targetPositionX;

    public void OnPointerClick(PointerEventData eventData)
    {
        
        if (buttonsBehaviour.GetLookButton())
        {
            dialogueManager.Dialogue(DialogueArbustoLook);
            player.GetComponent<Animator>().SetBool("isRunning", true);

        }

        if (buttonsBehaviour.GetTakeButton())
        {
            dialogueManager.Dialogue(DialogueArbustoTake);


        }

        if (buttonsBehaviour.GetUseButton())
        {     
            if (!inventory.inventory.Contains(Inventory.Items.Branch))
            {
                branch.SetActive(true);
                dialogueManager.Dialogue(DialogueArbustoUse);
            }

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        buttonsBehaviour = gameManager.GetComponent<ButtonsBehaviour>();
        dialogueManager = gameManager.GetComponent<DialogueManager>();
        inventory = gameManager.GetComponent<Inventory>();
        targetPositionY = gameManager.transform.position.y;
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
