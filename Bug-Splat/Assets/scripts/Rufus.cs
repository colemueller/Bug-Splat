using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rufus : Enemy
{
    public float verticalSpeed = 2f;
    private float origY;
    void Start()
    {
        origY = transform.position.y;
    }
    void LateUpdate()
    {
        float newY = Mathf.Sin(Time.time * verticalSpeed) * 3.5f;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
