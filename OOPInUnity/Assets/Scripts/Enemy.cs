using System.Collections;
using UnityEngine;

	public abstract class Enemy : MonoBehaviour, IDamagable
	{
		protected float speed;
		protected int health;

		[SerializeField] protected Weapon weapon;

		protected virtual void Awake()
		{
			weapon = gameObject.AddComponent<Weapon>();
			speed = 5f;
			health = 100;
		}
		protected abstract void Attack(int amount);
		public abstract void TakeDamage(int amount);
	}