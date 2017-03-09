﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleCollider : MonoBehaviour {

    public float duration;

    private List<Collider2D> triggerList;

	// Use this for initialization
	void Start () {
        triggerList = new List<Collider2D>();
        Invoke("DestroyMe", duration);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            triggerList.Add(collision);
            Character script = collision.GetComponent<Character>();
            script.StartSlipping();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            triggerList.Remove(collision);
            Character script = collision.GetComponent<Character>();
            script.StopSlipping();
        }
    }

    private void DestroyMe()
    {
        foreach (Collider2D c in triggerList)
        {
            c.GetComponent<Character>().StopSlipping();
        }
        Destroy(gameObject);
    }
}
