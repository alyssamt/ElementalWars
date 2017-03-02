using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {

    public int player;
    public KeyCode primaryKey;
    public KeyCode secondaryKey;

    public int speed;
    public int health;
    public int maxHealth;

    public GameManager gm;
    public Rigidbody2D rigid;

    private int horiz;
    private int vert;

	void Start()
    {
        health = maxHealth;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        rigid = GetComponent<Rigidbody2D>();
	}
	
	public virtual void FixedUpdate()
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
