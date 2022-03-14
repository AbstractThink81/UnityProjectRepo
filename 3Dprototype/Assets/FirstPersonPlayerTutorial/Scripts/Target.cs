/*
 * Ian Connors
 * 3D Prototype with ProBuilder
 * Manages health of basic objects
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;

    public void TakeDamage(float amount)
	{
		health -= amount;
		if (health <= 0)
		{
			Die();
		}
	}
	void Die()
	{
		Destroy(gameObject);
	}
}
