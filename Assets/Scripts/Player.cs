using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;

    public float gunCoolDown;
    public float kick;
    public GameObject projectile;
    public float bulletSpeed;
    public float bulletLifetime;

    public Text score;

    public AudioClip shoot;

    float coolDownTimer;

    Rigidbody2D rb;
    ScreenWrap sw;
    AudioSource audioPlayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sw = GetComponent<ScreenWrap>();
        audioPlayer = GetComponent<AudioSource>();
        coolDownTimer = gunCoolDown;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameData.dead)
            return;

        if (coolDownTimer > 0)
            coolDownTimer -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && coolDownTimer < 0)
        {
            coolDownTimer = gunCoolDown;
            Vector2 spawnP = transform.position + transform.up / 2;
            GameObject bullet = (GameObject)Instantiate(projectile, spawnP, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().linearVelocity = bullet.transform.up * bulletSpeed;
            Destroy(bullet, bulletLifetime);

            audioPlayer.PlayOneShot(shoot, 0.5f);

            rb.AddRelativeForce(Vector2.down * kick, ForceMode2D.Impulse);
        }

        score.text = GameData.score.ToString();
    }

    bool thrusting;

    void FixedUpdate()
    {

        if (sw.isWrappingX || sw.isWrappingY)
        {
            rb.angularVelocity = 0;
            return;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddRelativeForce(Vector2.up * moveSpeed);
            if (!GetComponent<AudioSource>().isPlaying)
                GetComponent<AudioSource>().Play();

            if (!thrusting)
            {
                thrusting = true;
                transform.GetChild(0).GetComponent<ParticleSystem>().Play();
            }
        }
        else if (thrusting)
        {
            GetComponent<AudioSource>().Stop();
            thrusting = false;
            transform.GetChild(0).GetComponent<ParticleSystem>().Stop();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddTorque(rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddTorque(-rotationSpeed);
        }
    }
}
