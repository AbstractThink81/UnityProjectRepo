/*
 * Ian Connors
 * Assignment 6 (OOP Prototype)
 * controls all functionality of enemies except for movement
 */
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, IDamagable
{
	public int health;
	public float strength;
	public Slider HealthBar;
	public GameManager gameManager;
	public SpriteRenderer sprite;
	public MoveForward moveScript;

	//[SerializeField] protected Weapon weapon;

	protected virtual void Awake()
	{
		gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
		sprite = GetComponent<SpriteRenderer>();
		HealthBar = transform.GetComponentInChildren<Slider>();
		moveScript = GetComponent<MoveForward>();

		strength = Random.Range(0, GameManager.score / 5) + 1;
		if (strength > 5)
			strength = 5;
		Debug.Log("Spanwed Enemy of strength " + strength);
		health *= Mathf.FloorToInt(strength);
		moveScript.speed /= strength;
	}
	protected virtual void Start()
	{
		HealthBar.maxValue = health;
		float color = (strength / -5) + (6 / 5);
		sprite.color = new Color(color, color, color);
	}
	protected virtual void Update()
	{
		if (transform.position.x > 10)
		{
			gameManager.KillTownspeople(Mathf.FloorToInt(health * strength));
			Die();
		}
	}
	public virtual void TakeDamage(int amount)
	{
		health -= amount;
		HealthBar.value = health;
		if (health < 1)
		{
			GameManager.score++;
			Die();
		}
	}
	public virtual void Die()
	{
		gameManager.KillEnemy();
		Destroy(gameObject);
	}
}