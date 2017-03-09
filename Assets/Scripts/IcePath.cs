using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePath : MonoBehaviour {

    public float duration;
    public GameObject invisibleCollider;

    private TrailRenderer tr;

    private void Start()
    {
        tr = GetComponent<TrailRenderer>();
        tr.enabled = false;
    }

    public void Enable()
    {
        tr.enabled = true;
        InvokeRepeating("SpawnCollider", 0f, 0.5f);
        Invoke("Disable", duration);
    }

    private void Disable()
    {
        tr.enabled = false;
        CancelInvoke();
    }

    private void SpawnCollider()
    {
        GameObject ic = Instantiate(invisibleCollider, transform.position, transform.rotation);
        Physics2D.IgnoreCollision(ic.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
