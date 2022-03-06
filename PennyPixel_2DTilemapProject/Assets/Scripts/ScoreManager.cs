/*
 * Ian Connors
 * Assignment 5A
 * Manages score display and replay looping
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public int score;
    int maxScore = 5;

    public AudioSource ding;

    public GameObject greenGems;
    public GameObject blueGems;

    public bool win = false;
    // Start is called before the first frame update
    void Start()
    {
        greenGems.SetActive(false);
        blueGems.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (score < 27)
            scoreText.text = "Gems: " + score + "/" + maxScore;
        if (score == 5 && maxScore < 16)
		{
            maxScore = 16;
            StartCoroutine(dingDing());
            spawnGreen();
		}
        if (score == 16 && maxScore < 27)
		{
            maxScore = 27;
            StartCoroutine(dingDing());
            spawnBlue();
		}
        if (score == 27)
		{
            scoreText.text = "Gems: " + score + "/" + maxScore + "\nYOU WIN! Press R to retry!";
            win = true;
            if (Input.GetKeyDown(KeyCode.R))
			{
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
        }
    }
    void spawnGreen()
	{
        greenGems.SetActive(true);
    }
    void spawnBlue()
    {
        blueGems.SetActive(true);
    }
    IEnumerator dingDing()
	{
        for (int i = 0; i < 7; i++)
		{
            ding.Play();
            yield return new WaitForSeconds(0.5f);
		}
        
	}
}
