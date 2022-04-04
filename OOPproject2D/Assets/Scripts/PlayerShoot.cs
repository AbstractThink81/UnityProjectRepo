/*
 * Ian Connors
 * Assignment 6 (OOP Prototype)
 * controls the functionality for shooting arrows
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    public bool shooting = false;
    public bool goingUp = true;
    public GameObject arrowPrefab;
    public int barValue = 0;
    public int speed = 7;
    public Slider EnergyBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            barValue = 0;
            shooting = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            shooting = false;
            EnergyBar.value = barValue;
            Instantiate(arrowPrefab, new Vector3(transform.position.x, transform.position.y + 0.1f, -4), transform.rotation);
        }
    }
    void FixedUpdate()
    {

        if (shooting)
        {
            Debug.Log("shooting!");
            if (goingUp)
            {
                barValue += speed;
            }
            else
            {
                barValue -= speed;
            }
            if (barValue >= 100)
            {
                goingUp = false;
            }
            if (barValue <= 0)
            {
                goingUp = true;
            }
            EnergyBar.value = barValue;
        }
    }
}
