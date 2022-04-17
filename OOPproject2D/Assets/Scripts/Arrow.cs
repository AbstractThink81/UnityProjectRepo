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
	private Rigidbody2D rb;
	public float speed;
	public float lifetime;
	// Use this for initialization
	void Awake()
	{
		playerShoot = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShoot>();
		strength = playerShoot.barValue / 3;
		speed = playerShoot.barValue / 5;
		rb = gameObject.GetComponent<Rigidbody2D>();
		//green zone: 78 to 97
		if (playerShoot.barValue < 97 && playerShoot.barValue > 78)
		{
			strength = 40;
			speed = 40;
		}

		if (lifetime != 0)
			StartCoroutine(DestroyAfterSeconds(lifetime));
	}

	// Update is called once per frame
	void Start()
	{
		rb.AddForce(transform.right * 10 * -speed, ForceMode2D.Impulse);
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

	IEnumerator DestroyAfterSeconds(float amount)
	{
		yield return new WaitForSeconds(amount);
		Destroy(gameObject);
	}
}