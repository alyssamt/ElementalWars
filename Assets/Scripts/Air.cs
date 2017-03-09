using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : Character
{

    public GameObject tornadoPrefab;
    public GameObject barrierPrefab;

    public override void Primary()
    {
        // Tornado

        GameObject tornado = Instantiate(tornadoPrefab, gameObject.transform.position, Quaternion.identity, gameObject.transform);
        Tornado script = tornado.GetComponent<Tornado>();
        script.player = player;
    }

    public override void Secondary()
    {
        // Wind Barrier

        GameObject barrier = Instantiate(barrierPrefab, gameObject.transform.position, Quaternion.identity, gameObject.transform);
        Barrier script = barrier.GetComponent<Barrier>();
        script.player = player;
    }
}