/*
 * Ian Connors
 * Assignment 6 (OOP Prototype)
 * controls the spawning of enemies for level 2
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Spawn : AbstractSpawnManager
{
    protected override IEnumerator Spawn()
    {
        while (enemiesLeftToSpawn > 0)
        {
            if (GameManager.score < 10)
			{
                yield return new WaitForSeconds(Random.Range(2f, 7f));
            }
            else if (GameManager.score < 20)
			{
                yield return new WaitForSeconds(Random.Range(1f, 5f));
			}
			else
			{
                yield return new WaitForSeconds(Random.Range(0.5f, 3f));
            }
            spawnPos.y = Random.Range(-4, 3);
            Instantiate(harpiePrefab, spawnPos, Quaternion.identity);
            enemiesLeftToSpawn--;
        }

    }
}
