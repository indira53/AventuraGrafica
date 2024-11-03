using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;

    public Sprite cestaSprite;
    public Sprite branchSprite;
    public Sprite appleCestaSprite;
    public Sprite appleSprite;

    public Sprite cestaSpriteHighlight;
    public Sprite branchSpriteHighlight;
    public Sprite appleCestaSpriteHighlight;
    public Sprite appleSpriteHighlight;

    public int selectedItem;
    public enum Items //en esta clase definimos lo0s diferentes items que hay en el videojuego
    {
        AppleCesta,
        Cesta,
        Branch,
        Apple,
        None,
    }
    public Sprite getItemSprite(Items item, bool highlighted) //método para obtener el sprite de un item
    {if (!highlighted)
        {
            return item switch
            {
                Items.AppleCesta => appleCestaSprite,
                Items.Cesta => cestaSprite,
                Items.Branch => branchSprite,
                Items.Apple => appleSprite,
                _ => null,
            };
        }
        else
        {
            return item switch
            {
                Items.AppleCesta => appleCestaSpriteHighlight,
                Items.Cesta => cestaSpriteHighlight,
                Items.Branch => branchSpriteHighlight,
                Items.Apple => appleSpriteHighlight,
                _ => null,
            };
        }
        
    }
    
    public List<Items> inventory; //definimos la lisla de los items que tiene actualmente nuestro personaje

    public void addItemsToInventory(Items item) //método para añadir un item a la lista de items
    {
        
       //añadir el item a la lista de items.
        inventory.Add(item);
        updateInventoryDisplay();

    }
    public void removeItemsFromInventory(Items item)  
    {
        inventory.Remove(item);
        updateInventoryDisplay();
    }
    public void updateInventoryDisplay() //actualiza el inventatio que se muestra en pantalla
      
    {
 
        if (inventory.Count > 0) 
        {

            slot1.GetComponent<SpriteRenderer>().sprite = getItemSprite(inventory[0], selectedItem == 1); //obtenemos el sprite del spriteRenderer del slot 1 y lo cambiamos al sprite del item en primera posición 
        }
        else { slot1.GetComponent<SpriteRenderer>().sprite = null; } //eliminar el sprite del sprite renderer cuando el item se va del inventario

        if (inventory.Count > 1)
        {
            slot2.GetComponent<SpriteRenderer>().sprite = getItemSprite(inventory[1], selectedItem == 2); 
        }
        else { slot2.GetComponent<SpriteRenderer>().sprite = null; }

        if (inventory.Count > 2)
        {
            slot3.GetComponent<SpriteRenderer>().sprite = getItemSprite(inventory[2], selectedItem == 3);

        }
        else { slot3.GetComponent<SpriteRenderer>().sprite = null; }

    }

    public Items getSelectedItem() 
    {
        if (inventory.Count > 0 && selectedItem  != 0)
        {
            return inventory[selectedItem - 1];
        }
        else return Items.None;
    }

    

    // Start is called before the first frame update
    void Start()
    {
        inventory = new List<Items>();   //inicializa la lista
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
