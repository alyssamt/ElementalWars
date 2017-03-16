using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public bool playing;

    public GameObject mainMenu;
    public GameObject instructions;
    public GameObject charSelect;
    public GameObject gameScreen;
    public GameObject gameOverScreen;

    public GameObject countdown;
    private Text cdText;
    public Text playerText;
    public Text gameOverText;

    public List<GameObject> charPrefabs;

    private int currPlayer;
    private int p1;
    private int p2;
    public Character p1c;
    public Character p2c;
    public Slider p1health;
    public Slider p2health;

    public bool ff;
    public Toggle fftoggle;

    public List<Sprite> blueSprites;

    public TowerManager tm;

	void Start()
    {
        playing = false;

        mainMenu.SetActive(true);
        instructions.SetActive(false);
        charSelect.SetActive(false);
        gameScreen.SetActive(false);
        gameOverScreen.SetActive(false);

        cdText = countdown.GetComponentInChildren<Text>();

        currPlayer = 1;

        ff = true;

        if (!tm) tm = GetComponent<TowerManager>();
	}
	
	void Update()
    {
		
	}

    public void SelectElement(int e)
    {
        if (currPlayer == 1)
        {
            p1 = e;
            currPlayer = 2;
            playerText.text = "P2";
        }
        else if (currPlayer == 2)
        {
            p2 = e;
            currPlayer = 1;
            playerText.text = "P1";
            charSelect.SetActive(false);
            gameScreen.SetActive(true);
            StartBattle();
        }
    }

    public void ToggleFriendlyFire()
    {
        ff = fftoggle.isOn;
    }

    public void StartBattle()
    {
        foreach (GameObject p in GameObject.FindGameObjectsWithTag("Player"))
        {
            Destroy(p);
        }

        tm.Reset();

        GameObject p1go = Instantiate(charPrefabs[p1], new Vector2(-7, 0), Quaternion.Euler(new Vector3(0, 0, -90)));
        p1c = p1go.GetComponent<Character>();
        p1c.player = 1;
        p1c.primaryKey = KeyCode.LeftShift;
        p1c.secondaryKey = KeyCode.Space;
        p1health.maxValue = p1c.maxHealth;
        p1health.value = p1health.maxValue;

        GameObject p2go = Instantiate(charPrefabs[p2], new Vector2(7, 0), Quaternion.Euler(new Vector3(0, 0, 90)));
        p2go.GetComponent<SpriteRenderer>().sprite = blueSprites[p2];
        p2c = p2go.GetComponent<Character>();
        p2c.player = 2;
        p2c.primaryKey = KeyCode.RightControl;
        p2c.secondaryKey = KeyCode.Keypad0;
        p2health.maxValue = p2c.maxHealth;
        p2health.value = p2health.maxValue;

        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        countdown.SetActive(true);
        /*
        cdText.text = "3";
        yield return new WaitForSeconds(1);

        cdText.text = "2";
        yield return new WaitForSeconds(1);
        */
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

    /*
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    */
}
