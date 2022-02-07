/*
 * Ian Connors
 * Challenge 2
 * Manages score, health, and end conditions
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int health = 5;
    public int maxHealth = 5;

    public static int score;

    public static bool gameOver = false;

    public GameObject gameOverText;
    public Text healthText;
    public Text scoreText;
	private void Start()
	{
        gameOverText.SetActive(false);
        gameOver = false;
        score = 0;
        health = maxHealth;
	}
	// Update is called once per frame
	void Update()
    {
        healthText.text = "Health: " + health;
        scoreText.text = "Score: " + score;
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        if (health <= 0)
        {
            gameOver = true;
            gameOverText.SetActive(true);

            //Press R to restart if game is over
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
