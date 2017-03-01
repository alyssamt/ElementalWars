using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    public int health;
    public int maxHealth;

    private SpriteRenderer rend;

    void Start()
    {
        health = maxHealth;

        rend = GetComponent<SpriteRenderer>();
        rend.color = new Color(255, 255, 255, 255);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            rend.color = new Color(40, 40, 40, 255);
        }
    }
}
