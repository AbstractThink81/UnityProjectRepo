/*
 * Ian Connors
 * Challenge 5
 * Destroys particles when they stay on the screen for too long
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectX : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 2); // destroy particle after 2 seconds
    }


}
