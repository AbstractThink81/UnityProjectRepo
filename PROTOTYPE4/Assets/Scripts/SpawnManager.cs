/*
 * Ian Connors
 * Prototype 4
 * Handles spawning of enemies and powerups
 */
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
	public GameObject powerupPrefab;
	public Text WaveText;
    private float spawnRange = 9;

	public int enemyCount;
	public int waveNumber = 1;
	// Start is called before the first frame update
	void Start()
	{
		SpawnEnemyWave(waveNumber);
		SpawnPowerup(1);
	}

	private void SpawnEnemyWave(int enemiesToSpawn)
	{
		for (int i = 0; i < enemiesToSpawn; i++)
		{
			Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
		}
	}
	private void SpawnPowerup(int powerupsToSpawn)
	{
		for (int i = 0; i < powerupsToSpawn; i++)
		{
			Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
		}
	}

	private Vector3 GenerateSpawnPosition()
	{
		//generate a random position on the platform
		float spawnPosX = Random.Range(-spawnRange, spawnRange);
		float spawnPosZ = Random.Range(-spawnRange, spawnRange);
		Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
		return randomPos;
	}

	// Update is called once per frame
	void Update()
    {
		enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
		if (enemyCount == 0 && !GameManager.gameOver)
		{
			if (waveNumber == 10)
			{
				GameManager.Win();
			}
			waveNumber++;
			WaveText.text = "Wave: " + waveNumber;
			SpawnEnemyWave(waveNumber);
			SpawnPowerup(1);
		}
    }
}
