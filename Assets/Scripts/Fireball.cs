using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

    public int speed;
    public int damage;

    void Start()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.gameObject.GetComponent<Character>().TakeDamage(damage);
        }
        else if (collision.collider.tag == "Tower")
        {
            collision.gameObject.GetComponent<Tower>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
