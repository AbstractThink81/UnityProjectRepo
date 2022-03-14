/*
 * Ian Connors
 * 3D Prototype with ProBuilder
 * Makes objects move up until a certain y position
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public float speed;
    public float maxHeight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y < maxHeight)
		{
            transform.Translate(Vector3.up * speed);
		}
        
    }
}
