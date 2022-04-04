/*
 * Ian Connors
 * Assignment 6 (OOP Prototype)
 * controls the crossbow movement of the player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    private float speedMultiplier = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
		{
            speedMultiplier = 5;
		}
		else
		{
            speedMultiplier = 1;
		}
        if (Input.GetAxis("Vertical") != 0)
        {

            float verticalInput;
            verticalInput = Input.GetAxis("Vertical");
            //range for rotation is -50 to 70
            if ((verticalInput < 0 && transform.localEulerAngles.z < 115)
                || (verticalInput > 0 && transform.localEulerAngles.z > 65))
            {
                transform.Rotate(0, 0, -verticalInput * speed * speedMultiplier * Time.deltaTime);

            }
        }
    }
}
