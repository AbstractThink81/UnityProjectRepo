﻿/*
 * Ian Connors
 * Assignment 6 (OOP Prototype)
 * loads and unloads scenes asyncronously
 */
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager: Singleton<GameManager>
{
	public int score;

	public GameObject pauseMenu;

	//varaible to keep track of current level
	private string CurrentLevelName = string.Empty;


/*	#region this code makes this class a Singleton
	public static GameManager instance;
	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			//make sure this game manger persists between scenes
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
			Debug.LogError("Trying to instantiate a second " +
				"instance of singleton Game Manager");
		}
	}
	#endregion*/

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

	public void UnloadCurrentLevel()
	{
		AsyncOperation ao = SceneManager.UnloadSceneAsync(CurrentLevelName);
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