/*
 * Ian Connors
 * Challenge 2
 * Destroys gameobjects that collide
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        ScoreManager.score++;
        Destroy(gameObject);
    }
}
