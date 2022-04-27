/*
 * Ian Connors
 * Assignment 8 (Prototype 5)
 * Manages movement and collision of targets
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;

	private GameManager gameManager;

	public int pointValue;

	public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
	{
		targetRb = GetComponent<Rigidbody>();

		//add force upwards at raondom speed
		targetRb.AddForce(RandomForce(), ForceMode.Impulse);

		//add torque with random x y and z values
		targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

		//set position at random x value
		transform.position = RandomSpawnPos();

		gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}

	private Vector3 RandomSpawnPos()
	{
		return new Vector3(Random.Range(-xRange, xRange), ySpawnPos, 0);
	}

	private float RandomTorque()
	{
		return Random.Range(-maxTorque, maxTorque);
	}

	private Vector3 RandomForce()
	{
		return Vector3.up * Random.Range(minSpeed, maxSpeed);
	}

	private void OnMouseDown()
	{
		if (gameManager.isGameActive)
		{
			gameManager.UpdateScore(pointValue);
			Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!gameObject.CompareTag("Bad"))
		{
			gameManager.GameOver();
		}
		Destroy(gameObject);
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
