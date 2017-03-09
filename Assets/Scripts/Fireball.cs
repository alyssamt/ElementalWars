using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Damager {

    public int speed;
    public GameObject fireballPrefab;

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
        if (collision.collider.name.Contains("Rock") && collision.collider.tag != "Wall")
        {
            Damager scr = collision.collider.GetComponent<Damager>();
            int pla = scr.player;
            GameObject par = scr.parent;
            Vector3 pos = collision.transform.position;
            Vector2 vel = scr.origVel;
            Destroy(collision.gameObject);
            GameObject newf = Instantiate(fireballPrefab, pos, Quaternion.identity);
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), newf.GetComponent<Collider2D>());
            scr = newf.GetComponent<Damager>();
            scr.player = pla;
            scr.parent = par;
            scr.GetComponent<Rigidbody2D>().velocity = vel;

            rigid.velocity = origVel;

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
