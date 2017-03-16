using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TextButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Color defaultColor;
    public Color hoverColor;
    public GameManager gm;
    private Text myText;

    void Start()
    {
        if (!gm) GameObject.Find("GameManager").GetComponent<GameManager>();
        myText = gameObject.GetComponent<Text>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (gameObject.name == "Instructions")
        {
            gm.mainMenu.SetActive(false);
            gm.instructions.SetActive(true);
        }
        else if (gameObject.name == "Options")
        {
            gm.mainMenu.SetActive(false);
            gm.optionsScreen.SetActive(true);
        }
        else if (gameObject.name == "Play")
        {
            gm.mainMenu.SetActive(false);
            gm.charSelect.SetActive(true);
        }
        else if (gameObject.name == "Back" || gameObject.name == "MainMenu")
        {
            gm.mainMenu.SetActive(true);
            gm.instructions.SetActive(false);
            gm.optionsScreen.SetActive(false);
            gm.gameScreen.SetActive(false);
            gm.gameOverScreen.SetActive(false);
        }
        else if (gameObject.name.Contains("Fire"))
        {
            gm.SelectElement(0);
        }
        else if (gameObject.name.Contains("Air"))
        {
            gm.SelectElement(1);
        }
        else if (gameObject.name.Contains("Water"))
        {
            gm.SelectElement(2);
        }
        else if (gameObject.name.Contains("Earth"))
        {
            gm.SelectElement(3);
        }
        else if (gameObject.name == "Quit")
        {
            Application.Quit();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        myText.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        myText.color = defaultColor;
    }
}