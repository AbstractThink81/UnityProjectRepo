using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //set references to animals in inpsector
    public GameObject[] prefabsToSpawn;

    private float leftBound = -14;
    private float rightBound = 14;
    private float spawnPosZ = 20;

    public HealthSystem healthSystem;
	private void Start()
	{
        healthSystem = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();
        //vokeRepeating("SpawnRandomPrefab", 2, 1.5f);
        StartCoroutine(SpawnRandomPrefabWithCoroutine());
	}

    IEnumerator SpawnRandomPrefabWithCoroutine()
	{
        //add 3 second delay
        yield return new WaitForSeconds(3f);

        while (!healthSystem.gameOver)
		{
            SpawnRandomPrefab();

            float randomDelay = Random.Range(1.5f, 3.0f);
            yield return new WaitForSeconds(randomDelay);
		}
	}
	// Update is called once per frame
	void Update()
    {
    }
    void SpawnRandomPrefab()
	{
        int prefabIndex = Random.Range(0, prefabsToSpawn.Length);
        Vector3 spawnPos = new Vector3(Random.Range(leftBound, rightBound), 0, spawnPosZ);

        //spawn animal
        Instantiate(prefabsToSpawn[prefabIndex], spawnPos, prefabsToSpawn[prefabIndex].transform.rotation);
    }
}
