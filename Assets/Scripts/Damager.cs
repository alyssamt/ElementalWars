using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour {

    public int player;
    [HideInInspector]
    public int damage;
    public Vector2 origVel;
    public GameObject parent;
    public GameManager gm;
    public AbilityManager am;

	public virtual void Start ()
    {
        GameObject temp = GameObject.Find("GameManager");
        gm = temp.GetComponent<GameManager>();
        am = temp.GetComponent<AbilityManager>();
	}
}
