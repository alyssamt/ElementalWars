using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water :Character {

    public GameObject tsunamiPrefab;
    public GameObject ridewavePrefab;
    
    public override void Primary()
    {
        //tsunami
        GameObject tsunami = Instantiate(tsunamiPrefab, transform.position, transform.rotation); //, transform.rotation*Quaternion.Euler(0,0,-90));
        Damager script = tsunami.GetComponent<Damager>();
        script.player = player;

        Rigidbody2D waterRigid = tsunami.GetComponent<Rigidbody2D>();
        waterRigid.velocity = transform.up * tsunami.GetComponent<Fireball>().speed;

        Physics2D.IgnoreCollision(tsunami.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
    public override void Secondary()
    {
        GameObject ridewave = Instantiate(ridewavePrefab, gameObject.transform.position, Quaternion.identity, gameObject.transform);
        Damager script = ridewave.GetComponent<Damager>();
        script.player = player;
    }
}
