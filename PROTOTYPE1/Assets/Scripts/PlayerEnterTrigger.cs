/*
 * Ian Connors
 * Prototype 1
 * Adds to score when player passes through trigger zones
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach to player
public class PlayerEnterTrigger : MonoBehaviour
{

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("TriggerZone"))
		{
			ScoreManager.score++;
		}
	}
}
