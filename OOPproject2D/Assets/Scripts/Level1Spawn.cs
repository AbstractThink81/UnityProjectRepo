/*
 * Ian Connors
 * Assignment 6 (OOP Prototype)
 * controls the spawning of enemies for level 1
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Spawn : AbstractSpawnManager
{
    protected override IEnumerator Spawn()
    {
        while (enemiesLeftToSpawn > 0)
        {
            if (GameManager.score < 5)
            {
                yield return new WaitForSeconds(Random.Range(2f, 7f));
            }
            else
            {
                yield return new WaitForSeconds(Random.Range(1f, 5f));
            }
            Instantiate(centaurPrefab, spawnPos, Quaternion.identity);
            enemiesLeftToSpawn--;
        }

    }
}
