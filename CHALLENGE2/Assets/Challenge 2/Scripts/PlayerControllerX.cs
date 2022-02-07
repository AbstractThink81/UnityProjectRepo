/*
 * Ian Connors
 * Challenge 2
 * Spawns dogs when the player presses space
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private bool canSpawnDog = true;

	// Update is called once per frame
	private void Start()
	{
	}
	IEnumerator SpawnCooldown()
	{
        yield return new WaitForSeconds(1f);
        canSpawnDog = true;
	}
	void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && canSpawnDog && !ScoreManager.gameOver)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            canSpawnDog = false;
            StartCoroutine(SpawnCooldown());
        }
    }
}
