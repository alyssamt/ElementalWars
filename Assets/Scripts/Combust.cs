using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combust : Damager
{
    void Start()
    {
        Invoke("DestroyMe", 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Character script = collision.GetComponent<Character>();
            if (script.player != player)
            {
                script.TakeDamage(damage);
            }
        }
    }

    private void DestroyMe()
    {
        Destroy(gameObject);
    }
}
