﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {

    public int player;
    public KeyCode primaryKey;
    public KeyCode secondaryKey;

    //[HideInInspector]
    public float primaryCD, maxPrimaryCD, secondaryCD, maxSecondaryCD;

    private Image primaryIconImg;
    private Image primaryCDimg;
    private Image secondaryIconImg;
    private Image secondaryCDimg;

    public Sprite primaryIcon;
    public Sprite secondaryIcon;

    public int speed;
    [HideInInspector]
    public int health;
    public int maxHealth;

    public GameManager gm;
    public AbilityManager am;
    private Rigidbody2D rigid;
    private AudioSource audSrc;

    private int horiz;
    private int vert;

    private bool slipping;

	public virtual void Start()
    {
        primaryCD = 0;
        secondaryCD = 0;
        health = maxHealth;
        GameObject temp = GameObject.Find("GameManager");
        gm = temp.GetComponent<GameManager>();
        am = temp.GetComponent<AbilityManager>();
        rigid = GetComponent<Rigidbody2D>();
        audSrc = GetComponent<AudioSource>();
        if (player == 1)
        {
            primaryIconImg = GameObject.Find("P1PA").GetComponent<Image>();
            primaryCDimg = GameObject.Find("P1PI").GetComponent<Image>();
            secondaryIconImg = GameObject.Find("P1SA").GetComponent<Image>();
            secondaryCDimg = GameObject.Find("P1SI").GetComponent<Image>();
        }
        if (player == 2)
        {
            primaryIconImg = GameObject.Find("P2PA").GetComponent<Image>();
            primaryCDimg = GameObject.Find("P2PI").GetComponent<Image>();
            secondaryIconImg = GameObject.Find("P2SA").GetComponent<Image>();
            secondaryCDimg = GameObject.Find("P2SI").GetComponent<Image>();
        }
        primaryIconImg.sprite = primaryIcon;
        secondaryIconImg.sprite = secondaryIcon;

        slipping = false;
	}

    public virtual void Update()
    {
        // Cooldowns
        if (primaryCD > 0) primaryCD -= Time.deltaTime;
        if (primaryCD < 0) primaryCD = 0;
        primaryCDimg.fillAmount = primaryCD / maxPrimaryCD;

        if (secondaryCD > 0) secondaryCD -= Time.deltaTime;
        if (secondaryCD < 0) secondaryCD = 0;
        if (maxSecondaryCD == 0) secondaryCDimg.fillAmount = 0;
        else secondaryCDimg.fillAmount = secondaryCD / maxSecondaryCD;

        // Abilities
        if (primaryCD <= 0 && Input.GetKeyDown(primaryKey))
        {
            Primary();
            primaryCD = maxPrimaryCD;
        }

        if (secondaryCD <= 0 && Input.GetKeyDown(secondaryKey))
        {
            Secondary();
            secondaryCD = maxSecondaryCD;
        }
    }
	
	public virtual void FixedUpdate()
    {
        if (gm.playing)
        {
            if (!slipping)
            {
                // Movement
                if (player == 1)
                {
                    if (Input.GetKey(KeyCode.A)) horiz = -1;
                    else if (Input.GetKey(KeyCode.D)) horiz = 1;
                    else horiz = 0;

                    if (Input.GetKey(KeyCode.W)) vert = 1;
                    else if (Input.GetKey(KeyCode.S)) vert = -1;
                    else vert = 0;
                }
                else if (player == 2)
                {
                    if (Input.GetKey(KeyCode.LeftArrow)) horiz = -1;
                    else if (Input.GetKey(KeyCode.RightArrow)) horiz = 1;
                    else horiz = 0;

                    if (Input.GetKey(KeyCode.UpArrow)) vert = 1;
                    else if (Input.GetKey(KeyCode.DownArrow)) vert = -1;
                    else vert = 0;
                }
                rigid.velocity = new Vector2(Mathf.Lerp(0, horiz * speed, 0.8f), Mathf.Lerp(0, vert * speed, 0.8f));

                // Rotation
                if (rigid.velocity != Vector2.zero)
                    transform.up = rigid.velocity;
            }
        }
    }

    public virtual void TakeDamage(int damage)
    {
        audSrc.Play();
        health -= damage;
        gm.UpdateHealthSliders();
        if (health <= 0)
        {
            gm.GameOver(this);
        }
    }

    public void StartSlipping()
    {
        slipping = true;
        rigid.velocity /= 2;
    }

    public void StopSlipping()
    {
        slipping = false;
    }

    public virtual void Primary()
    {

    }

    public virtual void Secondary()
    {

    }
}
