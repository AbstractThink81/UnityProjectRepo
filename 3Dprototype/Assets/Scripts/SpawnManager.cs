/*
 * Ian Connors
 * 3D Prototype with ProBuilder
 * Spawns enemies at random intervals
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public Vector3 spawnPosition;
	public GameObject enemy;
	public float minWait;
	public float maxWait;
    void Start()
    {
        StartCoroutine(Spawn());
    }


    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(10f);
        while (true)
        {
            Instantiate(enemy, spawnPosition, gameObject.transform.rotation);
            float wait = Random.Range(minWait, maxWait);
            yield return new WaitForSeconds(wait);
        }

    }
}
