using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArbustoProperties : MonoBehaviour, IPointerClickHandler
{
    public string[] DialogueArbustoLook = { "Un arbusto normal y corriente." };
    public string[] DialogueArbustoTake = { "No puedo coger un arbusto entero!" };
    public string[] DialogueArbustoUse = { "No puedo usar un arbusto." };
    public string[] DialogueArbustoSearch = { "¡He encontrado una rama!" };

    public GameObject branch;
    public GameObject gameManager;

    private ButtonsBehaviour buttonsBehaviour;
    public GameObject player;
    private DialogueManager dialogueManager;
    private Inventory inventory;

    public float targetPositionY;
    public float targetPositionX;

    private AudioSource audioSource;

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
            dialogueManager.Dialogue(DialogueArbustoUse);


        }

        if (buttonsBehaviour.GetSearchButton())
        {     
            if (!inventory.inventory.Contains(Inventory.Items.Branch))
            {
                branch.SetActive(true);
                dialogueManager.Dialogue(DialogueArbustoSearch);
                audioSource.Play();
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
        audioSource = GetComponent<AudioSource>();
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
