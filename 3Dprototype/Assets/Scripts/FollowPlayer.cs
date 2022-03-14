/*
 * Ian Connors
 * 3D Prototype with ProBuilder
 * Makes enemies follow the player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
	public float speed;
	public float maxSpeed;
	public float minSpeed;
	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		speed = Random.Range(minSpeed, maxSpeed);
	}
	private void Update()
	{
		transform.LookAt(player);
		transform.Translate(transform.forward * speed * Time.deltaTime);
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			other.gameObject.GetComponent<PlayerHealthAndUI>().TakeDamage(0.1f);
		}
	}
}
