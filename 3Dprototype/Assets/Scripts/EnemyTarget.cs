/*
 * Ian Connors
 * 3D Prototype with ProBuilder
 * Manages enemy health
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTarget : MonoBehaviour
{
	public float health = 50f;
	public Slider healthSlider;

	public void TakeDamage(float amount)
	{
		health -= amount;
		healthSlider.value = health;
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
