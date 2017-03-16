using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : Character {

    public GameObject rockPrefab;

    private Collider2D wallTrigger;

    public override void Start()
    {
        base.Start();
        maxPrimaryCD = am.earthPrimaryCD;
        maxSecondaryCD = am.earthSecondaryCD;
        wallTrigger = GetComponentInChildren<CapsuleCollider2D>();
    }

    public override void Primary()
    {
        // Rock Wall

        GameObject r = Instantiate(rockPrefab, transform.position, Quaternion.identity);
        Damager script = r.GetComponent<Damager>();
        script.player = player;
        script.parent = gameObject;

        Physics2D.IgnoreCollision(r.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    public override void Secondary()
    {
        foreach (GameObject rock in GameObject.FindGameObjectsWithTag("Wall")) {
            Bounds b = rock.GetComponent<Collider2D>().bounds;
            if (wallTrigger.bounds.Contains(rock.transform.position) || wallTrigger.bounds.Intersects(b))
            {
                Rock rs = rock.GetComponent<Rock>();
                rs.DontDestroy();
                Rigidbody2D rr = rock.GetComponent<Rigidbody2D>();
                rs.origVel = transform.up * rs.speed;
                rr.bodyType = RigidbodyType2D.Dynamic;
                rr.velocity = rs.origVel;
                rock.GetComponent<Collider2D>().isTrigger = false;
                rock.tag = "Damager";
                rs.audSrc.Play();
            }
        }
    }
}
