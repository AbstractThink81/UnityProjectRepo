/*
 * Ian Connors
 * Assignment 6 (OOP Prototype)
 * moves an object to the left (or right if speed is negative)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed;
	public float lifetime;
	// Update is called once per frame
	void Awake()
	{
		if (lifetime != 0)
			StartCoroutine(DestroyAfterSeconds(lifetime));
	}
	void Update()
    {
        transform.Translate(Time.deltaTime * -speed * transform.right);
    }
    IEnumerator DestroyAfterSeconds(float amount)
	{
		yield return new WaitForSeconds(amount);
        Destroy(gameObject);
	}
}
