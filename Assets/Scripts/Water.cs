using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Character {

    public GameObject tsunamiPrefab;
    public IcePath ip;

    public override void Start()
    {
        base.Start();
        ip = GetComponent<IcePath>();
    }

    public override void Primary()
    {
        // Tsunami

        GameObject tsunami = Instantiate(tsunamiPrefab, transform.position, transform.rotation); //, transform.rotation*Quaternion.Euler(0,0,-90));
        Damager script = tsunami.GetComponent<Damager>();
        script.player = player;
        script.parent = gameObject;

        Rigidbody2D waterRigid = tsunami.GetComponent<Rigidbody2D>();
        waterRigid.velocity = transform.up * tsunami.GetComponent<Tsunami>().speed;

        Physics2D.IgnoreCollision(tsunami.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    public override void Secondary()
    {
        // Ice Path

        ip.Enable();
    }
}
