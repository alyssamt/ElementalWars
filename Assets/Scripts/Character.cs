using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {

    public int player;
    public KeyCode primaryKey;
    public KeyCode secondaryKey;

    [HideInInspector]
    public float primaryCD;
    public float maxPrimaryCD;
    [HideInInspector]
    public float secondaryCD;
    public float maxSecondaryCD;
    private Image primaryCDimg;
    private Image secondaryCDimg;

    public int speed;
    [HideInInspector]
    public int health;
    public int maxHealth;

    public GameManager gm;
    private Rigidbody2D rigid;

    private int horiz;
    private int vert;

	void Start()
    {
        primaryCD = maxPrimaryCD;
        secondaryCD = maxSecondaryCD;
        health = maxHealth;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        rigid = GetComponent<Rigidbody2D>();
        if (player == 1)
        {
            primaryCDimg = GameObject.Find("P1PI").GetComponent<Image>();
            secondaryCDimg = GameObject.Find("P1SI").GetComponent<Image>();
        }
        if (player == 2)
        {
            primaryCDimg = GameObject.Find("P2PI").GetComponent<Image>();
            secondaryCDimg = GameObject.Find("P2SI").GetComponent<Image>();
        }
	}
	
	public virtual void FixedUpdate()
    {
        if (gm.playing)
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

            // Cooldowns
            if (primaryCD < maxPrimaryCD) primaryCD += Time.deltaTime;
            if (primaryCD > maxPrimaryCD) primaryCD = maxPrimaryCD;
            primaryCDimg.fillAmount = primaryCD / maxPrimaryCD;

            if (secondaryCD < maxSecondaryCD) secondaryCD += Time.deltaTime;
            if (secondaryCD > maxSecondaryCD) secondaryCD = maxSecondaryCD;
            secondaryCDimg.fillAmount = secondaryCD / maxSecondaryCD;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        gm.UpdateHealthSliders();
        if (health <= 0)
        {
            gm.GameOver(this);
        }
    }
}
