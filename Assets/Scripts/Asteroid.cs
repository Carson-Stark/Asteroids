using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Asteroid : MonoBehaviour
{
    public Sprite[] asteroids;

    public GameObject asteroid;

    public float minVelocity;
    public float maxVelocity;

    public AudioClip explode;
    public AudioClip broken;
    public AudioClip playerDie;

    [HideInInspector]
    public Vector2 direction = Vector2.one;

    Rigidbody2D rb;
    SpriteRenderer rnd;
    AudioSource audioPlayer;

    float deathTimer = 2;

    public int size = 2;

    // Start is called before the first frame update
    void Start()
    {
        asteroid = (GameObject)Resources.Load("asteroid");

        rb = GetComponent<Rigidbody2D>();
        rnd = GetComponent<SpriteRenderer>();
        audioPlayer = GetComponent<AudioSource>();

        rnd.sprite = asteroids[Random.Range(0, asteroids.Length)];

        rb.angularVelocity = Random.Range(-100, 100);

        /*int level = (int)Mathf.Ceil(GameData.score / 10);
        minVelocity += level * (minVelocity / 10);
        maxVelocity += level * (maxVelocity / 10);*/

        rb.linearVelocity = Random.Range(minVelocity, maxVelocity) * direction;

        if (size == 1)
            transform.localScale /= 2;
        else if (size == 0)
            transform.localScale /= 4;

    }

    void Update()
    {
        if (Mathf.Abs(transform.position.x) > 20 || Mathf.Abs(transform.position.y) > 20)
            Destroy(gameObject);

        if (GameData.dead)
        {
            deathTimer -= Time.unscaledDeltaTime;
            if (deathTimer < 0)
            {
                Time.timeScale = 1;
                GameData.score = 0;
                GameData.dead = false;
                SceneManager.LoadScene(0);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Projectile")
        {
            Destroy(other.gameObject);
            if (size > 0)
            {
                spawnAsteroid();
                spawnAsteroid();
                audioPlayer.PlayOneShot(broken, 1);
            }
            else
                audioPlayer.PlayOneShot(explode, 1);

            GameData.score++;

            Destroy(gameObject, 2);
            rnd.GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Asteroid>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
        }
        else if (other.transform.tag == "Player")
        {
            GameData.dead = true;
            audioPlayer.PlayOneShot(playerDie, 1);
            Time.timeScale = 0;
        }

    }

    void spawnAsteroid()
    {
        Vector2 spawnPos = new Vector2(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f));
        GameObject a = (GameObject)Instantiate(asteroid, transform.position, Quaternion.Euler(0, 0, Random.Range(-180, 180)));
        a.GetComponent<Asteroid>().size = size - 1;
        a.GetComponent<Asteroid>().direction = new Vector2(Random.value, Random.value);
    }

}
