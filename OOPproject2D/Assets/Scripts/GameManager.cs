/*
 * Ian Connors
 * Assignment 6 (OOP Prototype)
 * loads and unloads scenes, and takes care of some variables determining game progress
 */
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager: Singleton<GameManager>
{
	public static int score;
	public int enemiesLeft;
	public int townspeopleAlive;
	public GameObject statusTextObj;
	public Text statusText;
	public bool win = false;

	public GameObject mainMenu;
	public GameObject pauseMenu;
	public GameObject victoryMenu;
	public GameObject loseMenu;
	public AbstractSpawnManager spawnManager;
	//varaible to keep track of current level
	private string CurrentLevelName = string.Empty;

	private void Start()
	{
		SetStatusText();
	}
	public void KillEnemy()
	{
		enemiesLeft--;
		SetStatusText();
		if (enemiesLeft < 1)
		{
			enemiesLeft = 0;
			SetStatusText();
			Win();
		}
	}
	public void KillTownspeople(int amount)
	{
		townspeopleAlive -= amount;
		if (townspeopleAlive < 0)
		{
			townspeopleAlive = 0;
			SetStatusText();
			GameOver();
		}
	}
	//methods to load and unload scenes
	public void LoadLevel(string levelName)
	{
		AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
		if (ao == null)
		{
			Debug.LogError("[GameManager] Unable to load level " + levelName);
			return;
		}
		CurrentLevelName = levelName;
	}
	public void UnloadLevel(string levelName)
	{
		AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);
		if (ao == null)
		{
			Debug.LogError("[GameManager] Unable to unload level " + levelName);
			return;
		}
	}

	//pausing and unpausing

	public void Pause()
	{
		Time.timeScale = 0f;
		pauseMenu.SetActive(true);
	}
	public void Unpause()
	{
		Time.timeScale = 1f;
		pauseMenu.SetActive(false);
	}
	private void GameOver()
	{
		Debug.Log("Game Over!");
		spawnManager.enemiesLeftToSpawn = 0;
		loseMenu.SetActive(true);
	}
	private void Win()
	{
		win = true;
		victoryMenu.SetActive(true);
	}
	public void SetStatusText()
	{
		statusText.text = "Townspeople Alive: " + townspeopleAlive
			+ "\nEnemies Left: " + enemiesLeft
			+ "\nScore: " + score;
	}
	public void UnloadCurrentLevel()
	{
		AsyncOperation ao = SceneManager.UnloadSceneAsync(CurrentLevelName);
		if (ao == null)
		{
			Debug.LogError("[GameManager] Unable to unload level " + CurrentLevelName);
			return;
		}
	}
	public void spawnManagerRef()
	{
		spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<AbstractSpawnManager>();
	}
	public void ReloadCurrentLevel()
	{
		AsyncOperation ao = SceneManager.LoadSceneAsync(CurrentLevelName);
		if (ao == null)
		{
			Debug.LogError("[GameManager] Unable to unload level " + CurrentLevelName);
			return;
		}
	}
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			Pause();
		}
	}
}