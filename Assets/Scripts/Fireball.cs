using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Damager {

    public int speed;

    private Rigidbody2D rigid;

    public override void Start()
    {
        base.Start();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.up = rigid.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Barrier")
        {
            if (player == 1) player = 2;
            else if (player == 2) player = 1;
            // Don't destroy; ricochet
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
