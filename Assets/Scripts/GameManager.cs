using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public bool playing;
    public bool ff; // Friendly fire
    public bool noTowers;

    [HideInInspector]
    public TowerManager tm;

    public Toggle ffToggle;
    public Toggle ntmToggle;

    public GameObject countdown;
    public GameObject redText;
    public GameObject blueText;

    public GameObject mainMenu;
    public GameObject instructions;
    public GameObject optionsScreen;
    public GameObject charSelect;
    public GameObject gameScreen;
    public GameObject gameOverScreen;

    public KeyCode leftPrimary;
    public KeyCode leftSecondary;
    public KeyCode rightPrimary;
    public KeyCode rightSecondary;

    public List<GameObject> charPrefabs;
    public List<Sprite> blueSprites;

    public Text gameOverText;

    public Slider p1health;
    public Slider p2health;

    [HideInInspector]
    public Character p1c, p2c;

    private int currPlayer;
    private int p1;
    private int p2;

    private Text cdText;

    void Start()
    {
        playing = false;
        ff = false;
        noTowers = false;

        tm = GetComponent<TowerManager>();

        mainMenu.SetActive(true);
        instructions.SetActive(false);
        optionsScreen.SetActive(false);
        charSelect.SetActive(false);
        gameScreen.SetActive(false);
        gameOverScreen.SetActive(false);

        currPlayer = 1;

        cdText = countdown.GetComponentInChildren<Text>();
	}

    public void ToggleFriendlyFire()
    {
        ff = ffToggle.isOn;
    }

    public void ToggleNoTowerMode()
    {
        noTowers = ntmToggle.isOn;
    }

    public void SelectElement(int e)
    {
        if (currPlayer == 1)
        {
            p1 = e;
            currPlayer = 2;
            redText.SetActive(false);
            blueText.SetActive(true);
        }
        else if (currPlayer == 2)
        {
            p2 = e;
            currPlayer = 1;
            redText.SetActive(true);
            blueText.SetActive(false);

            charSelect.SetActive(false);
            gameScreen.SetActive(true);
            StartBattle();
        }
    }

    public void StartBattle()
    {
        foreach (GameObject p in GameObject.FindGameObjectsWithTag("Player"))
        {
            Destroy(p);
        }

        if (!noTowers) tm.Reset();

        GameObject p1go = Instantiate(charPrefabs[p1], new Vector2(-7, 0), Quaternion.Euler(new Vector3(0, 0, -90)));
        p1c = p1go.GetComponent<Character>();
        p1c.player = 1;
        p1c.primaryKey = leftPrimary;
        p1c.secondaryKey = leftSecondary;
        p1health.maxValue = p1c.maxHealth;
        p1health.value = p1health.maxValue;

        GameObject p2go = Instantiate(charPrefabs[p2], new Vector2(7, 0), Quaternion.Euler(new Vector3(0, 0, 90)));
        p2go.GetComponent<SpriteRenderer>().sprite = blueSprites[p2];
        p2c = p2go.GetComponent<Character>();
        p2c.player = 2;
        p2c.primaryKey = rightPrimary;
        p2c.secondaryKey = rightSecondary;
        p2health.maxValue = p2c.maxHealth;
        p2health.value = p2health.maxValue;

        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        countdown.SetActive(true);

        cdText.text = "READY";
        yield return new WaitForSeconds(1);

        cdText.text = "FIGHT";
        yield return new WaitForSeconds(1);

        countdown.SetActive(false);
        playing = true;
    }

    public void UpdateHealthSliders()
    {
        p1health.value = p1c.health;
        p2health.value = p2c.health;
    }

    public void GameOver(Character loser)
    {
        playing = false;
        gameOverScreen.SetActive(true);
        int p = 0;
        if (loser.player == 1) p = 2;
        else if (loser.player == 2) p = 1;
        gameOverText.text = "PLAYER " + p + " VICTORY";
    }
}
