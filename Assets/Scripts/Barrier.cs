using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour {

    public int player;
    public float duration;

    void Start () {
        Invoke("DestroyMe", duration);
    }

    private void DestroyMe()
    {
        Destroy(gameObject);
    }
}
