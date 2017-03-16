using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour {

    public GameObject towerPrefab;

    public Sprite redTower;
    public Sprite blueTower;

    public List<Vector2> redPos;
    public List<Vector2> redMov;
    public List<Vector2> bluePos;
    public List<Vector2> blueMov;

    public float speed;

    [HideInInspector]
    public int numRed, numBlue;

    [HideInInspector]
    public GameManager gm;

    private List<GameObject> redTowers;
    private List<GameObject> blueTowers;

	void Start ()
    {
        if (!gm) gm = GetComponent<GameManager>();
        redTowers = new List<GameObject>();
        blueTowers = new List<GameObject>();
        Reset();
    }
	
	void Update ()
    {
        /*
        if (gm.playing)
        {
            Debug.Log(redTowers.Count);
            for (int i = 0; i != redTowers.Count; i++)
            {
                redTowers[i].transform.position = Vector3.Lerp(redPos[i], redMov[i], Mathf.PingPong(Time.time * speed, 1.0f));
                blueTowers[i].transform.position = Vector3.Lerp(bluePos[i], blueMov[i], Mathf.PingPong(Time.time * speed, 1.0f));
            }
        }
        */
    }

    public void Reset()
    {
        foreach (GameObject t in GameObject.FindGameObjectsWithTag("Tower"))
        {
            Destroy(t);
        }

        for (int i = 0; i != redPos.Count; i++)
        {
            GameObject t = Instantiate(towerPrefab, redPos[i], Quaternion.identity);
            t.GetComponent<SpriteRenderer>().sprite = redTower;
            Tower ts = t.GetComponent<Tower>();
            ts.player = 1;
            ts.origPos = redPos[i];
            ts.moveTo = redMov[i];
            redTowers.Add(t);
        }

        for (int i = 0; i != bluePos.Count; i++)
        {
            GameObject t = Instantiate(towerPrefab, bluePos[i], Quaternion.identity);
            t.GetComponent<SpriteRenderer>().sprite = blueTower;
            Tower ts = t.GetComponent<Tower>();
            ts.player = 2;
            ts.origPos = bluePos[i];
            ts.moveTo = blueMov[i];
            blueTowers.Add(t);
        }

        numRed = redPos.Count;
        numBlue = bluePos.Count;
    }

    public void DestroyTower(GameObject t, int player)
    {
        Destroy(t);
        if (player == 1)
        {
            numRed -= 1;
            if (numRed == 0) gm.GameOver(gm.p1c);
        }
        else if (player == 2)
        {
            numBlue -= 1;
            if (numBlue == 0) gm.GameOver(gm.p2c);
        }
    }
}
