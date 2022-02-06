/*
 * Ian Connors
 * Prototype 1
 * Increments the score when player passes through trigger zones
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScoreIncrement : MonoBehaviour
{
	// Start is called before the first frame update
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			ScoreManager.score++;
		}
	}
}
