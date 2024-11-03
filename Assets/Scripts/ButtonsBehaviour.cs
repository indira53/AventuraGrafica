using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonsBehaviour : MonoBehaviour

{   //enlazado con el texto de los botones
    public GameObject buttonUse;
    public GameObject buttonTake;
    public GameObject buttonLook;
    public GameObject buttonSearch;

    private Image buttonTakeImage;
    private Image buttonLookImage;
    private Image buttonUseImage;
    private Image buttonSearchImage;

    public Color activeColor = Color.green;
    public Color inactiveColor = Color.white;

    //botones
    private bool useButton, takeButton, lookButton, searchButton = false;

    void Start()
    {
        // Obtenemos los componentes Image de cada botón
        buttonUseImage = buttonUse.GetComponent<Image>();
        buttonTakeImage = buttonTake.GetComponent<Image>();
        buttonLookImage = buttonLook.GetComponent<Image>();
        buttonSearchImage = buttonSearch.GetComponent<Image>();

        // Inicializamos colores a inactivo
        SetButtonColors();
    }

    public void UseButton() //si no está activado --> activar al pulsar. Cambiar de color y desactivar lso otros botones.
    {
        if (!useButton)
        {
            useButton = true; Debug.Log("usar está activado");
            takeButton = false; 
            lookButton = false;
            searchButton = false;

        }
        else
        {
            useButton = false; Debug.Log("usar está desactivado");
        }

        SetButtonColors();
    }
    public void TakeButton() //si no está activado --> activar al pulsar. Cambiar de color y desactivar lso otros botones.
    {
        if (!takeButton)
        {
            takeButton = true; Debug.Log("coger está activado");
            useButton = false;
            lookButton = false;
            searchButton = false;

        }
        else
        {
            takeButton = false; Debug.Log("coger está desactivado");
        }

        SetButtonColors();
    }
    public void LookButton() //si no está activado --> activar al pulsar. Cambiar de color y desactivar lso otros botones.
    {
        if (!lookButton)
        {
            lookButton = true; Debug.Log("mirar está activado");
            useButton = false;
            takeButton = false;
            searchButton = false;
        }
        else
        {
            lookButton = false; Debug.Log("mirar está desactivado");
        }

        SetButtonColors();
    }
    public void SearchButton() //si no está activado --> activar al pulsar. Cambiar de color y desactivar lso otros botones.
    {
        if (!searchButton)
        {
            searchButton = true; Debug.Log("buscar está activado");
            useButton = false;
            takeButton = false;
            lookButton = false;
        }
        else
        {
            searchButton = false; Debug.Log("buscar está desactivado");
        }

        SetButtonColors();

    }
    private void SetButtonColors()
    {
        // Cambiamos el color de cada botón según su estado
        if (useButton)
        {
            // Cambiamos el color de cada botón según su estado
            buttonUseImage.color = activeColor;
        }
        else
        {
            // Cambiamos el color de cada botón según su estado
            buttonUseImage.color = inactiveColor;
        }
        if (takeButton)
        {
            buttonTakeImage.color = activeColor;
        }
        else
        {
            buttonTakeImage.color = inactiveColor;
        }
        if (lookButton)
        {
            buttonLookImage.color = activeColor;
        }
        else
        {
            buttonLookImage.color = inactiveColor;
        }
        if (searchButton)
        {
            buttonSearchImage.color = activeColor;
        }
        else
        {
            buttonSearchImage.color = inactiveColor;
        }
    }

    public bool GetUseButton()
        { return useButton; }

    public bool GetTakeButton()
        { return takeButton; }
    public bool GetLookButton()
    { 
        return lookButton; 
    }public bool GetSearchButton()
    {
        return searchButton;
    }


}




