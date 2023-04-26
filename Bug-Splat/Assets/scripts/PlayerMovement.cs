using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float shootInterval = 1f;
    public GameObject laserPrefab;
    private int health = 3;
    public Transform healthImages;
    public GameObject blamPrefab;
    private GameObject renderObj;
    private bool canMove = true;
    private AudioSource engineSfx, laserSfx, explodeSfx;

    void Start()
    {
        //StartCoroutine(Fire());
        StartGame.startClicked.AddListener(CanStart);
        renderObj = transform.GetChild(0).gameObject;
        score.rampUp.AddListener(RampUp);
        engineSfx = this.GetComponents<AudioSource>()[0];
        laserSfx = this.GetComponents<AudioSource>()[1];
        explodeSfx = this.GetComponents<AudioSource>()[2];
    }
    void Update()
    {
        if(canMove)
        {
            if(transform.position.y >= -4.2f && transform.position.y <= 3.5f)
            {
                if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
                }

                if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    transform.Translate(-Vector3.up * moveSpeed * Time.deltaTime);
                }
            }

            if(transform.position.x >= -8f && transform.position.x <= -4f)
            {
                if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
                }

                if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.Translate(-Vector3.right * moveSpeed * Time.deltaTime);
                }
            }

            Vector3 p = transform.position;
            transform.position = new Vector3(Mathf.Clamp( p.x, -8, -4f ), Mathf.Clamp( p.y, -4.2f, 3.5f ), p.z );
        }
    }

    IEnumerator Fire()
    {
        float randVal = Random.Range(-0.3f, 0.3f);
        laserSfx.pitch = 1 + randVal;
        yield return new WaitForSeconds(shootInterval);
        Instantiate(laserPrefab, transform.position, laserPrefab.transform.rotation);
        laserSfx.Play();
        StartCoroutine(Fire());
    }

    public void CanStart()
    {
        StartCoroutine(Fire());
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.tag == "blooieBullet" || c.gameObject.tag == "enemy")
        {
            LoseHealth();
        }
    }

    void LoseHealth()
    {
        canMove = false;
        renderObj.SetActive(false);
        Instantiate(blamPrefab, transform.position, blamPrefab.transform.rotation);
        healthImages.Find(health.ToString()).gameObject.SetActive(false);
        health--;
        explodeSfx.Play();
        StopAllCoroutines();
        if(health == 0)
        {
            //game over
            StartGame.endGame.Invoke();
            GameObject.Destroy(renderObj.gameObject);
            engineSfx.Stop();
        }
        else
        {
            //StopAllCoroutines();
            //StopCoroutine(Fire());
            StartCoroutine(RestoreVisual());
            
        }
    }

    IEnumerator RestoreVisual()
    {
        yield return new WaitForSeconds(0.75f);
        renderObj.SetActive(true);
        canMove = true;
        StartCoroutine(Fire());
    }

    public void RampUp()
    {
        moveSpeed += 0.2f;
        shootInterval -= 0.15f;
    }
}
