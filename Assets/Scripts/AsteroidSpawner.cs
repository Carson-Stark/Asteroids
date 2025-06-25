using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Transform player;

    public GameObject asteroid;

    public AudioClip levelUp;

    public float spawnRate;
    public float rateRange;

    public float spawnDistance;

    float spawnTimer;

    int level;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = 2;

    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer < 0)
        {
            spawnTimer = Random.Range(spawnRate - rateRange, spawnRate + rateRange);

            GameObject a = (GameObject)Instantiate(asteroid, getPointOutsideScreen(), Quaternion.Euler(0, 0, Random.Range(-180, 180)));
            a.GetComponent<Asteroid>().size = Random.Range(0, 3);
            a.GetComponent<Asteroid>().direction = (player.position - a.transform.position).normalized;
        }

        if (GameData.score % 10 == 0 && GameData.score / 10 != level && GameData.score > 0)
        {
            level++;
            if (spawnRate > rateRange)
                spawnRate *= 0.9f;
            else
                rateRange *= 0.9f;
            Debug.Log(spawnRate + " " + rateRange);
            GetComponent<AudioSource>().PlayOneShot(levelUp, 1);
        }
    }

    Vector2 getPointOutsideScreen()
    {
        Vector2 viewportPos = new Vector2();

        if (Random.Range(0, 2) == 0)
        {
            //top or bottom
            viewportPos.x = Random.Range(0f, 1);
            if (Random.Range(0, 2) == 0)
                //top
                viewportPos.y = 1 + spawnDistance;
            else
                //bottom
                viewportPos.y = 0 - spawnDistance;
        }
        else
        {
            //left or right
            viewportPos.y = Random.Range(0f, 1);
            if (Random.Range(0, 2) == 0)
                //left
                viewportPos.x = 1 + spawnDistance;
            else
                //right
                viewportPos.x = 0 - spawnDistance;
        }

        Debug.Log(viewportPos);
        return Camera.main.ViewportToWorldPoint(viewportPos);
    }
}
