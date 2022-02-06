﻿/*
 * Ian Connors
 * Challenge 1
 * Makes camera follow the player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(40, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!ScoreManager.gameOver)
        transform.position = plane.transform.position + offset;
    }
}