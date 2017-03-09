using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    public int player;

    public int health;
    public int maxHealth;

    public GameManager gm;

    private SpriteRenderer rend;

    private float colorDecrement;

    void Start()
    {
        health = maxHealth;

        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        rend = GetComponent<SpriteRenderer>();
        rend.color = new Color(255, 255, 255, 255);
        colorDecrement = 1 / maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Damager")
        {
            Damager dmger = collision.collider.GetComponent<Damager>();
            if (gm.ff || dmger.player != player)
            {
                TakeDamage(dmger.damage);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        float newValue = 0f;
        if (health == 4) newValue = 0.8f;
        else if (health == 3) newValue = 0.6f;
        else if (health == 2) newValue = 0.4f;
        else if (health == 1) newValue = 0.2f;
        rend.color = new Color(newValue, newValue, newValue);
        if (health <= 0)
        {
            gm.DestroyTower(gameObject, player);
        }
    }
}
