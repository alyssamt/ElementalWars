using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour {

    public int player;
    public int damage;

    public GameManager gm;

	// Use this for initialization
	public virtual void Start () {
        if (!gm) gm = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
