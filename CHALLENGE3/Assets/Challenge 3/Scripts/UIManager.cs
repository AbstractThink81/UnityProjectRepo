
/*
 * Ian Connors
 * Challenge 3
 * Displays the score text and allows for restarting the game
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public PlayerControllerX playerController;

    public bool win = false;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if (score >= 30)
		{
            win = true;
            playerController.gameOver = true;
            scoreText.text = "You Win!\nPress R to try again!";
        }
        else if (playerController.gameOver)
		{
            scoreText.text = "You Lose!\nPress R to try again!";
        }
        if (playerController.gameOver && Input.GetKeyDown(KeyCode.R))
		{
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
    }
    public void AddScore(int points)
	{
        score += points;
        scoreText.text = "Score: " + score;
	}
}
