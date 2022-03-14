/*
 * Ian Connors
 * 3D Prototype with ProBuilder
 * Manages player health, scene reloading, and UI
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthAndUI : MonoBehaviour
{
	public float health = 100f;
	public Slider healthSlider;
	public Vector3 respawnPos;
	public int deathYPos;
	public GameObject LoseText;
	public GameObject InstructionsText;
	public GameObject WinText;
	public PlayerMovement MovementScript;

	public bool gameOver = false;
	public void Start()
	{
		LoseText.SetActive(false);
		WinText.SetActive(false);
		InstructionsText.SetActive(false);
		StartCoroutine(Instructions());
	}
	public void Update()
	{
		if (gameOver)
		{
			if (Input.GetKeyDown(KeyCode.R))
			{
				UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
			}
		}
	}
	public void TakeDamage(float amount)
	{
		health -= amount;
		healthSlider.value = health;
		if (health <= 0)
		{
			LoseText.SetActive(true);
			gameOver = true;
		}
		Debug.Log("Ouch!");
	}
	IEnumerator Instructions()
	{
		yield return new WaitForSeconds(7f);
		InstructionsText.SetActive(true);
		yield return new WaitForSeconds(5f);
		InstructionsText.SetActive(false);
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("WinTrigger"))
		{
			WinText.SetActive(true);
			gameOver = true;
		}
	}
}
