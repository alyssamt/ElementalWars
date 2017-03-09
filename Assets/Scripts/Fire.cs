using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Character {

    public GameObject fireballPrefab;
    public GameObject combustPrefab;

    public override void Primary()
    {
        // Fireball

        GameObject fireball = Instantiate(fireballPrefab, transform.position, transform.rotation);
        Damager script = fireball.GetComponent<Damager>();
        script.player = player;

        Rigidbody2D fireRigid = fireball.GetComponent<Rigidbody2D>();
        fireRigid.velocity = transform.up * fireball.GetComponent<Fireball>().speed;

        Physics2D.IgnoreCollision(fireball.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    public override void Secondary()
    {
        // Combust

        GameObject combust = Instantiate(combustPrefab, gameObject.transform.position, Quaternion.identity, gameObject.transform);
        Damager script = combust.GetComponent<Damager>();
        script.player = player;
    }
}
