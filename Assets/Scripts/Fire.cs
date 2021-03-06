﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Character {

    public GameObject fireballPrefab;
    public GameObject combustPrefab;

    public override void Start()
    {
        base.Start();
        maxPrimaryCD = am.firePrimaryCD;
        maxSecondaryCD = am.fireSecondaryCD;
    }

    public override void Primary()
    {
        // Fireball

        GameObject fireball = Instantiate(fireballPrefab, transform.position, transform.rotation); //, transform.rotation*Quaternion.Euler(0,0,-90));
        Damager script = fireball.GetComponent<Damager>();
        script.player = player;
        script.parent = gameObject;

        Fireball fb = fireball.GetComponent<Fireball>();
        Rigidbody2D fireRigid = fireball.GetComponent<Rigidbody2D>();
        fb.origVel = transform.up * fb.speed;
        fireRigid.velocity = fb.origVel;

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
