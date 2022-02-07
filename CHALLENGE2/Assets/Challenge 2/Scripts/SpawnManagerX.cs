/*
 * Ian Connors
 * Challenge 2
 * Spawns balls at the top of the screen
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnInterval());
        //InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
    }

    // Spawn random ball at random x position at top of play area
    
    IEnumerator SpawnInterval()
	{
        yield return new WaitForSeconds(startDelay);
        while (!ScoreManager.gameOver)
		{
            SpawnRandomBall();
            yield return new WaitForSeconds(Random.Range(3f, 5f));
        }
	}
    
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
        int randomPrefab = Random.Range(0, 2);
        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[randomPrefab], spawnPos, ballPrefabs[randomPrefab].transform.rotation);
    }

}
