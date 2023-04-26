using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject blamPrefab;
    public int health = 1;
    public float moveSpeed = 3f;

    void Start()
    {
        gameObject.layer = 2;
        score.rampUp.AddListener(RampUp);
    }

    void Update()
    {
        if(transform.position.x <= -11)
        {
            GameObject.Destroy(this.gameObject);
        }

        transform.Translate(-Vector3.right * moveSpeed * Time.deltaTime);
    }

    protected void OnTriggerEnter2D(Collider2D c)
    {
        //print(c.gameObject.tag);
        if(c.gameObject.tag == "laser")
        {
            health--;
            if(health == 0)
            {
                KillMe();
            }
            GameObject.Destroy(c.gameObject);
        }
    }

    void KillMe()
    {
        //instantiate blam prefab
        Instantiate(blamPrefab, transform.position, blamPrefab.transform.rotation);
        GameObject.Destroy(this.gameObject);
        //score._score = score._score + 100;
        score.changeScore.Invoke();
    }

    void RampUp()
    {
        moveSpeed += 0.5f;
    }
}
