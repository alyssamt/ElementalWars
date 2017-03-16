using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour {

    public int player;
    private AbilityManager am;

    void Start ()
    {
        am = GameObject.Find("GameManager").GetComponent<AbilityManager>();
        Invoke("DestroyMe", am.airSecondaryDuration);
    }

    private void DestroyMe()
    {
        Destroy(gameObject);
    }
}
