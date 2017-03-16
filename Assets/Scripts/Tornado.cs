using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : Damager {

    private float dmgTimer;
    public float maxDmgTimer;

    public override void Start()
    {
        base.Start();
        dmgTimer = 0;
        damage = am.airPrimaryDamage;
        Invoke("DestroyMe", am.airPrimaryDuration);
    }

    private void Update()
    {
        if (gm.playing && dmgTimer > 0) dmgTimer -= Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (dmgTimer <= 0)
        {
            if (collision.tag == "Player")
            {
                Character script = collision.GetComponent<Character>();
                if (script.player != player)
                {
                    script.TakeDamage(damage);
                    dmgTimer = maxDmgTimer;
                }
            }
            else if (collision.tag == "Tower")
            {
                Tower script = collision.GetComponent<Tower>();
                if (gm.ff || script.player != player)
                {
                    script.TakeDamage(damage);
                    dmgTimer = maxDmgTimer;
                }
            }
        }
    }

    private void DestroyMe()
    {
        Destroy(gameObject);
    }
}
