/*
 * Ian Connors
 * 3D Prototype with ProBuilder
 * Makes lava hurt the player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			other.gameObject.GetComponent<PlayerHealthAndUI>().TakeDamage(0.1f);
    	}
	}
}
