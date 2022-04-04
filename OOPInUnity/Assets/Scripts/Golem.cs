/*
 * Ian Connors
 * Assignment 6 (OOP Prototype)
 * derives from enemy
 */
using System.Collections;
using UnityEngine;

public class Golem : Enemy
{
	protected override void Awake()
	{
		base.Awake();
		health = 120;
		GameManager.Instance.score += 2;
	}
	protected override void Attack(int amount)
	{
		Debug.Log("Golem Attacks!");
	}
	public override void TakeDamage(int amount)
	{
		Debug.Log("You took " + amount + " points of damage");
	}
}