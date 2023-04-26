using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovement : MonoBehaviour
{

    public float moveSpeed = 10f;
    public bool reverseDirection = false;
    
    void Update()
    {
        moveSpeed += 0.15f;
        if(transform.position.x >= 10 || transform.position.x <= -12)
        {
            GameObject.Destroy(this.gameObject);
        }

        if(reverseDirection)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
    }
}
