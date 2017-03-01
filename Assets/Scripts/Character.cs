using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public int speed;

    private Rigidbody2D rigid;

	void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate()
    {
        rigid.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * speed, 0.8f), Mathf.Lerp(0, Input.GetAxis("Vertical") * speed, 0.8f));
    }
}
