/*
 * Ian Connors
 * Prototype 1
 * Adds to score when player passes through triggers
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneAddScore : MonoBehaviour
{
    private bool triggered = false;
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") && !triggered)
		{
			triggered = true;
			ScoreManager.score++;
		}
	}
}
