using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Character {

    public GameObject fireballPrefab;

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        if (primaryCD == maxPrimaryCD && Input.GetKeyDown(primaryKey))
        {
            Fireball();
            primaryCD = 0;
        }
    }

    private void Fireball()
    {
        GameObject fireball = Instantiate(fireballPrefab, transform.position, transform.rotation);
        Rigidbody2D fireRigid = fireball.GetComponent<Rigidbody2D>();
        fireRigid.velocity = transform.up * fireball.GetComponent<Fireball>().speed;

        Physics2D.IgnoreCollision(fireball.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
