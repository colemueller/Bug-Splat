using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject greeniePrefab, blooiePrefab, rufusPrefab;
    public float spawnDelay = 1f;
    void Start()
    {
        //StartCoroutine(GenerateEnemy());
        StartGame.startClicked.AddListener(CanStart);
        score.rampUp.AddListener(RampUp);
    }

    IEnumerator GenerateEnemy()
    {
        yield return new WaitForSeconds(spawnDelay);

        int i = Random.Range(1,7);
        float randY = Random.Range(-3.5f, 3.5f);
        Vector3 spawnPos = new Vector3(transform.position.x, randY, transform.position.z);

        if(i == 1 || i ==2 || i == 3)
        {
            Instantiate(greeniePrefab, spawnPos, greeniePrefab.transform.rotation);
        }
        else if(i == 4 || i == 5)
        {
            Instantiate(blooiePrefab, spawnPos, blooiePrefab.transform.rotation);
        }
        else
        {
            Instantiate(rufusPrefab, spawnPos, rufusPrefab.transform.rotation);
        }

        StartCoroutine(GenerateEnemy());
    }

    public void CanStart()
    {
        StartCoroutine(GenerateEnemy());
    }

    public void RampUp()
    {
        if(spawnDelay >= 0)
        {
            spawnDelay -= 0.4f;
            if(spawnDelay <= 0)
            {
                spawnDelay = 0.1f;
            }

        }
    }

}
