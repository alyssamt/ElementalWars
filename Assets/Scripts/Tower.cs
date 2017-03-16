using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    public int player;
    public int health;
    public int maxHealth;

    public Vector2 origPos;
    public Vector2 moveTo;

    public GameManager gm;
    public TowerManager tm;

    private float colorDecrement;
    private SpriteRenderer rend;
    private AudioSource audSrc;

    void Start()
    {
        health = maxHealth;
        GameObject temp = GameObject.Find("GameManager");
        gm = temp.GetComponent<GameManager>();
        tm = temp.GetComponent<TowerManager>();

        rend = GetComponent<SpriteRenderer>();
        rend.color = new Color(255, 255, 255, 255);
        colorDecrement = 1f / maxHealth;
        audSrc = GetComponent<AudioSource>();
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(origPos, moveTo, Mathf.PingPong(Time.time * tm.speed, 1.0f));
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
        audSrc.Play();
        health -= damage;

        /*
        float newValue = 0f;
        if (health == 4) newValue = 0.8f;
        else if (health == 3) newValue = 0.6f;
        else if (health == 2) newValue = 0.4f;
        else if (health == 1) newValue = 0.2f;
        */

        float newValue = rend.color.r;
        // Debug.Log(newValue);
        if (newValue > 1) newValue /= 255;
        // Debug.Log(newValue);
        newValue -= colorDecrement;
        // Debug.Log(newValue);

        rend.color = new Color(newValue, newValue, newValue);
        if (health <= 0)
        {
            Invoke("DestroyMe", 0.5f);
        }
    }

    private void DestroyMe()
    {
        tm.DestroyTower(gameObject, player);
    }
}
