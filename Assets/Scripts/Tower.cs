using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    public int player;

    public int health;
    public int maxHealth;

    public GameManager gm;

    private SpriteRenderer rend;

    private int colorDecrement;

    void Start()
    {
        health = maxHealth;

        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        rend = GetComponent<SpriteRenderer>();
        rend.color = new Color(255, 255, 255, 255);
        colorDecrement = (255 - 100) / maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        rend.color = new Color((rend.color.r - (colorDecrement*damage))/255, (rend.color.g - (colorDecrement*damage)) / 255, (rend.color.b - (colorDecrement*damage)) / 255, 1);
        if (health <= 0)
        {
            gm.DestroyTower(gameObject, player);
        }
    }
}
