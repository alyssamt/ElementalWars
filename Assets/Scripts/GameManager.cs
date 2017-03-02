﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int maxTowers;

    public GameObject charSelect;
    public GameObject instructions;
    public GameObject gameScreen;
    public GameObject gameOverScreen;
    public Text playerText;
    public Text gameOverText;

    public List<GameObject> charPrefabs;

    private int currPlayer;
    private int p1;
    private int p2;
    private Character p1c;
    private Character p2c;
    public Slider p1health;
    public Slider p2health;
    public int p1towers;
    public int p2towers;

	void Start()
    {
        charSelect.SetActive(true);
        instructions.SetActive(false);
        gameScreen.SetActive(false);
        gameOverScreen.SetActive(false);

        currPlayer = 1;

        p1towers = maxTowers;
        p2towers = maxTowers;
	}
	
	void Update()
    {
		
	}

    public void SelectFire()
    {
        if (currPlayer == 1)
        {
            p1 = 0;
            currPlayer += 1;
            playerText.text = "P2";
        }
        else if (currPlayer == 2)
        {
            p2 = 0;
            charSelect.SetActive(false);
            instructions.SetActive(true);
        }
    }

    public void StartBattle()
    {
        charSelect.SetActive(false);
        instructions.SetActive(false);
        gameScreen.SetActive(true);

        GameObject p1go = Instantiate(charPrefabs[p1], new Vector2(-7, 0), Quaternion.identity);
        p1c = p1go.GetComponent<Character>();
        p1c.player = 1;
        p1c.primaryKey = KeyCode.LeftShift;
        p1c.secondaryKey = KeyCode.Space;
        p1health.maxValue = p1c.maxHealth;
        p1health.value = p1health.maxValue;

        GameObject p2go = Instantiate(charPrefabs[p2], new Vector2(7, 0), Quaternion.identity);
        p2c = p2go.GetComponent<Character>();
        p2c.player = 2;
        p2c.primaryKey = KeyCode.RightControl;
        p2c.secondaryKey = KeyCode.Keypad0;
        p2health.maxValue = p2c.maxHealth;
        p2health.value = p2health.maxValue;
    }

    public void UpdateHealthSliders()
    {
        p1health.value = p1c.health;
        p2health.value = p2c.health;
    }

    public void DestroyTower(GameObject t, int player)
    {
        Destroy(t);
        if (player == 1)
        {
            p1towers -= 1;
            if (p1towers == 0) GameOver(p1c);
        }
        else if (player == 2)
        {
            p2towers -= 1;
            if (p2towers == 0) GameOver(p2c);
        }
    }

    public void GameOver(Character loser)
    {
        gameOverScreen.SetActive(true);
        int p = 0;
        if (loser.player == 1) p = 2;
        else if (loser.player == 2) p = 1;
        gameOverText.text = "PLAYER " + p + " VICTORY";
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}