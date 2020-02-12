using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBSpawnObstacle : MonoBehaviour
{
    [SerializeField]
    private GameObject obstaclePrefab = null;
    [SerializeField]
    private float startTime = 5f;
    [SerializeField]
    private float timeBetweenObstacles = 2f;
    [SerializeField]
    private float minY = -2;
    [SerializeField]
    private float maxY = 2;

    private void Start()
    {
        StartCoroutine(StartSpawningDelay());
    }

    private IEnumerator StartSpawningDelay()
    {
        yield return new WaitForSeconds(startTime);

        StartCoroutine(StartSpawning());
    }

    private IEnumerator StartSpawning()
    {
        while (FBGameManager.IsRunning)
        {
            float randY = Random.Range(minY, maxY);

            Vector3 spawnPos = new Vector3(transform.position.x, randY);

            Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);

            yield return new WaitForSeconds(timeBetweenObstacles);
        }
    }
}
