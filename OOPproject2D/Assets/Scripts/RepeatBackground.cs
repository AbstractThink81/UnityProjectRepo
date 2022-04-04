/*
 * Ian Connors
 * Assignment 6 (OOP Prototype)
 * creates the illusion of an endless background (edited from prototype 3)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPosition;
    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        repeatWidth = GetComponent<BoxCollider2D>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPosition.x - 0.4 * repeatWidth)
        {
            transform.position = startPosition;
        }
    }
}

