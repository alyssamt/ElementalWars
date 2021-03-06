﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Damager {

    public int speed;
    public AudioSource audSrc;

    public override void Start()
    {
        base.Start();
        audSrc = GetComponent<AudioSource>();
        damage = am.earthSecondaryDamage;
        Invoke("DestroyMe", am.earthPrimaryDuration);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "Damager") {
            if (collision.collider.tag == "Tower")
            {
                /*
                Tower tower = collision.collider.GetComponent<Tower>();
                if (gm.ff || player != tower.player)
                {
                    tower.TakeDamage(damage);
                }
                */
                Destroy(gameObject);
            }
            else if (collision.collider.tag == "Barrier")
            {
                if (player == 1) player = 2;
                else if (player == 2) player = 1;
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), parent.GetComponent<Collider2D>(), false);
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

    private void DestroyMe()
    {
        Destroy(gameObject);
    }

    public void DontDestroy()
    {
        CancelInvoke();
    }
}
