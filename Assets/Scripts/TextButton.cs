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

    // Use this for initialization
    void Start()
    {
        if (!gm) GameObject.Find("GameManager").GetComponent<GameManager>();
        myText = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (gameObject.name == "Instructions")
        {
            gm.mainMenu.SetActive(false);
            gm.instructions.SetActive(true);
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
            gm.gameScreen.SetActive(false);
            gm.gameOverScreen.SetActive(false);
        }
        else if (gameObject.name == "Fire")
        {
            gm.SelectElement(0);
        }
        else if (gameObject.name == "Air")
        {
            gm.SelectElement(1);
        }
        else if (gameObject.name == "Water")
        {
            gm.SelectElement(2);
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