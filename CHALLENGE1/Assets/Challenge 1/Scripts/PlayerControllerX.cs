/*
 * Ian Connors
 * Prototype 1
 * Controls player movement
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;
    public float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        // player movement  
            transform.Translate(Vector3.forward * speed * horizontalInput * Time.deltaTime);
            transform.Rotate(Vector3.right * verticalInput * rotationSpeed * Time.deltaTime);
        
        
        //detects out of bounds for loss condition
        if (transform.position.y > 80 || transform.position.y < -51)
		{
            ScoreManager.gameOver = true;
		}
    }
}
