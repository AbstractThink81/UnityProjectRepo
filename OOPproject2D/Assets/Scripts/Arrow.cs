/*
 * Ian Connors
 * Assignment 6 (OOP Prototype)
 * controls the damaging functionality of the arrows shot by the player
 */
using System.Collections;
using UnityEngine;

public class Arrow : MonoBehaviour
{
	public int strength;
	public PlayerShoot playerShoot;
	public MoveForward moveScript;
	// Use this for initialization
	void Awake()
	{
		playerShoot = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShoot>();
		strength = playerShoot.barValue / 3;
		moveScript.speed = playerShoot.barValue / 5;
		//green zone: 78 to 97
		if (playerShoot.barValue < 97 && playerShoot.barValue > 78)
		{
			strength = 40;
			moveScript.speed = 40;
		}
	}

	// Update is called once per frame
	void Update()
	{

	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		IDamagable hit = collision.GetComponent<IDamagable>();
		if (hit != null)
		{
			hit.TakeDamage(strength);
			Destroy(gameObject);
		}
	}
}