/*
 * Ian Connors
 * Assignment 6 (OOP Prototype)
 * weapon that can be held by an enemy
 */
using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{

	public int damageBonus;

	public Enemy enemyHoldingWeapon;
	private void Awake()
	{
		enemyHoldingWeapon = gameObject.GetComponent<Enemy>();
		EnemyEatsWeapon(enemyHoldingWeapon);
	}
	
	protected void EnemyEatsWeapon(Enemy enemy)
	{
		Debug.Log("Enemy eats weapon");
	}
	public void Recharge()
	{
		Debug.Log("Recharging Weapon!");
	}
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}