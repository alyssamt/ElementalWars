using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : Damager {

    public float duration;

    private float dmgTimer;
    public float maxDmgTimer;

    public override void Start()
    {
        base.Start();
        dmgTimer = 0;
        Invoke("DestroyMe", duration);
    }

    private void Update()
    {
        if (gm.playing && dmgTimer > 0) dmgTimer -= Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && dmgTimer <= 0)
        {
            Character script = collision.GetComponent<Character>();
            if (script.player != player)
            {
                script.TakeDamage(damage);
                dmgTimer = maxDmgTimer;
            }
        }
    }

    private void DestroyMe()
    {
        Destroy(gameObject);
    }
}
