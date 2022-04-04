/*
 * Ian Connors
 * Assignment 6 (OOP Prototype)
 * makes an object able to be hurt with arrows
 */
using System.Collections;
using UnityEngine;
	public interface IDamagable
	{
		void TakeDamage(int damage);
		void Die();
	}