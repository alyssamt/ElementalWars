using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tsunami : Damager {

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

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Barrier")
        {
            if (player == 1) player = 2;
            else if (player == 2) player = 1;
            // Don't destroy; ricochet
        }
        else
        {
            if (collider.tag == "Player")
            {
                collider.gameObject.GetComponent<Character>().TakeDamage(damage);
            }
            else if (collider.tag == "Tower")
            {
                Tower script = collider.GetComponent<Tower>();
                if (gm.ff || script.player != player)
                {
                    script.TakeDamage(damage);
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
