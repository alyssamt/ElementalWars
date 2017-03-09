using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour {

    public int player;
    public int damage;
    public Vector2 origVel;
    public GameObject parent;
    public GameManager gm;

	public virtual void Start () {
        if (!gm) gm = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
}
