using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour {

    public int player;
    public AudioClip deflect;
    private AudioSource audSrc;
    private AbilityManager am;

    void Start ()
    {
        audSrc = GetComponent<AudioSource>();
        am = GameObject.Find("GameManager").GetComponent<AbilityManager>();
        Invoke("DestroyMe", am.airSecondaryDuration);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audSrc.PlayOneShot(deflect);
    }

    private void DestroyMe()
    {
        Destroy(gameObject);
    }
}
