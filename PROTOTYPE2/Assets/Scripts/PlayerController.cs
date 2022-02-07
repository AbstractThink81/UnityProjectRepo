using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    private float xRange = 14;

    public HealthSystem healthSystem;
	private void Start()
	{
        healthSystem = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();
    }
	// Update is called once per frame
	void Update()
    {
        //get horizontal input
        horizontalInput = Input.GetAxis("Horizontal");

        //transform horizontally with input
        if (!healthSystem.gameOver)
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        

        //keep player in bounds
        if (transform.position.x < -xRange)
		{
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
		}
        if (transform.position.x > xRange)
		{
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }
}
