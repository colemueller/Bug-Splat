using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blooie : Enemy
{
    public GameObject blooieBulletPrefab;
    public float fireDelay = 1f;
    void Start()
    {
        StartCoroutine(blooieFire());
    }

    IEnumerator blooieFire()
    {
        yield return new WaitForSeconds(fireDelay);
        Vector3 bulletOrigin = new Vector3(transform.position.x - 1.12f, transform.position.y - 0.2f, transform.position.z);
        Instantiate(blooieBulletPrefab, bulletOrigin, blooieBulletPrefab.transform.rotation);
        StartCoroutine(blooieFire());
    }
}
