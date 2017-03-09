using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour {

    public int player;
    public int damage;

    public GameManager gm;

	public virtual void Start () {
        if (!gm) gm = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
}
