using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Damager {

    public int speed;

    void Start()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Barrier")
        {

        }
        else
        {
            if (collision.collider.tag == "Player")
            {
                collision.gameObject.GetComponent<Character>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
