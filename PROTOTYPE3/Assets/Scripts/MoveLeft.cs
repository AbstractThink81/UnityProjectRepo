
/*
 * Ian Connors
 * Prototype 3
 * Moves the gameobject to the left at a fixed speed
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30f;
    public float leftBound = -15;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver)
            transform.Translate(Vector3.left * Time.deltaTime * speed);

        //if the gameobject is an obstacle, destroy it
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
		{
            Destroy(gameObject);
		}
    }
}
