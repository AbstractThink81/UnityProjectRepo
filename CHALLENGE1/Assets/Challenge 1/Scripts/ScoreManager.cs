using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public static bool gameOver;
    public static bool won;
	public Text scoreText;
	private void Start()
	{
		score = 0;
		gameOver = false;
		won = false;
	}
	// Update is called once per frame
	void Update()
    {
        if (score >= 5)
		{
			gameOver = true;
			won = true;
		}
		if (!gameOver)
		{
			scoreText.text = "Score: " + score;
		}
		if (gameOver)
		{
			if (won)
			{
				scoreText.text = "You Win!\nPress R to try again!";
			}
			else
			{
				scoreText.text = "You Lose!\nPress R to try again!";
			}
		}
		if (gameOver && Input.GetKeyDown(KeyCode.R))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
    }
}
