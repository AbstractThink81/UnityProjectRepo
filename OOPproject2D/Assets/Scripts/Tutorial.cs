/*
 * Ian Connors
 * Assignment 6 (OOP Prototype)
 * controls the tutorial scene
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : AbstractSpawnManager
{
	public GameObject tutorialTextObject;
	public Text tutorialText;
	public GameObject tutorialButton;
	private int tutorialProgress = 0;
	private int enemies;
    protected override IEnumerator Spawn()
	{
		gameManager.statusTextObj.SetActive(false);
		yield return new WaitForSeconds(1f);
		tutorialText.text = "You are a crossbow knight who has been\ntasked with protecting the village\nfrom any monsters that approach.\nUse the UP and DOWN arrows to\naim your crossbow.";
		tutorialTextObject.SetActive(true);
		yield return new WaitForSeconds(2f);
		tutorialProgress = 1;
		yield return new WaitUntil(() => tutorialProgress == 2);
		yield return new WaitForSeconds(2f);
		tutorialText.text = "Hold down SPACE to charge an arrow.";
		yield return new WaitForSeconds(0.5f);
		tutorialProgress = 3;
		yield return new WaitUntil(() => tutorialProgress == 4);
		yield return new WaitForSeconds(1f);
		tutorialText.text = "Let go when the meter is in the green zone\n for maximum speed and strength.";
		yield return new WaitForSeconds(1f);
		tutorialProgress = 5;
		yield return new WaitUntil(() => tutorialProgress == 6);
		yield return new WaitForSeconds(2f);
		tutorialText.text = "Try killing this enemy.";
		Instantiate(centaurPrefab, spawnPos, Quaternion.identity);
		enemies = gameManager.enemiesLeft;
		yield return new WaitForSeconds(0.5f);
		tutorialProgress = 7;
		yield return new WaitUntil(() => tutorialProgress == 8);
		yield return new WaitForSeconds(1f);
		tutorialText.text = "You can also hold LEFT SHIFT\nto move your crossbow quickly\nand press P to pause at any time.\n" +
			"Congratulations! You completed the tutorial!";
		tutorialButton.SetActive(true);
	}
	private void Update()
	{
		if (tutorialProgress == 1 && Input.GetAxis("Vertical") != 0)
		{
			tutorialProgress = 2;
		}
		if (tutorialProgress == 3 && Input.GetKey(KeyCode.Space))
		{
			tutorialProgress = 4;
		}
		if (tutorialProgress == 5 && Input.GetKeyUp(KeyCode.Space))
		{
			tutorialProgress = 6;
		}
		if (tutorialProgress == 7 && enemies > gameManager.enemiesLeft)
		{
			tutorialProgress = 8;
		}
	}
	public void EndTutorial()
	{
		gameManager.mainMenu.SetActive(true);
		gameManager.UnloadCurrentLevel();
	}
}
