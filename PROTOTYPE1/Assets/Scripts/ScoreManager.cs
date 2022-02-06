/*
 * Ian Connors
 * Prototype 1
 * Manages score and end conditions
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
	public static bool gameOver;
    public static bool won;
    public static int score;

    public Text textbox;

	private void Start()
	{
		won = false;
		gameOver = false;
		score = 0;
	}
	// Update is called once per frame
	void Update()
    {
        if (!gameOver)
		{
            textbox.text = "Score: " + score;
		}

        //win condition 3 or more points
        if (score >= 3)
		{
            won = true;
            gameOver = true;
		}
        if (gameOver)
		{
            if (won)
			{
                textbox.text = "You Win!\nPress R to Try Again!";
			}
			else
			{
                textbox.text = "You Lose!\nPress R to Try Again";
			}
            if (Input.GetKeyDown(KeyCode.R))
			{
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		}
    }
}
