using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : Character
{

    public GameObject tornadoPrefab;
    public GameObject barrierPrefab;

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        if (primaryCD == maxPrimaryCD && Input.GetKeyDown(primaryKey))
        {
            Tornado();
            primaryCD = 0;
        }

        if (secondaryCD == maxSecondaryCD && Input.GetKeyDown(secondaryKey))
        {
            Barrier();
            secondaryCD = 0;
        }
    }

    private void Tornado()
    {
        GameObject tornado = Instantiate(tornadoPrefab, gameObject.transform.position, Quaternion.identity, gameObject.transform);
        Tornado script = tornado.GetComponent<Tornado>();
        script.player = player;
    }

    private void Barrier()
    {
        GameObject barrier = Instantiate(barrierPrefab, gameObject.transform.position, Quaternion.identity, gameObject.transform);
        Barrier script = barrier.GetComponent<Barrier>();
        script.player = player;
    }
}