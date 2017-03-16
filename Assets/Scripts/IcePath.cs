using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePath : MonoBehaviour {

    public GameObject invisibleCollider;
    private TrailRenderer tr;
    private AbilityManager am;

    private void Start()
    {
        tr = GetComponent<TrailRenderer>();
        tr.enabled = false;
        am = GameObject.Find("GameManager").GetComponent<AbilityManager>();
    }

    public void Enable()
    {
        tr.enabled = true;
        InvokeRepeating("SpawnCollider", 0f, 0.5f);
        Invoke("Disable", am.waterSecondaryDuration);
    }

    private void Disable()
    {
        tr.enabled = false;
        CancelInvoke();

        foreach (GameObject i in GameObject.FindGameObjectsWithTag("IcePath"))
        {
            Destroy(i);
        }

        foreach(GameObject i in GameObject.FindGameObjectsWithTag("Player"))
        {
            i.GetComponent<Character>().StopSlipping();
        }
    }

    private void SpawnCollider()
    {
        GameObject ic = Instantiate(invisibleCollider, transform.position, transform.rotation);
        Physics2D.IgnoreCollision(ic.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
