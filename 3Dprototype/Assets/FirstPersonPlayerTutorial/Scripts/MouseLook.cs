/*
 * Ian Connors
 * 3D Prototype with ProBuilder
 * Rotates the camera based on mouse movement
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    public GameObject player;
    private float verticalLookRoation = 0f;

    //hide and lock cursor to center of screen
    private void OnApplicationFocus(bool focus)
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //Rotate player GameObject with horizontal mouse input
        player.transform.Rotate(Vector3.up * mouseX);

        //Rotate camera around the x axis with vertical mouse input
        verticalLookRoation -= mouseY;

        //limit vertical rotation
        verticalLookRoation = Mathf.Clamp(verticalLookRoation, -90f, 90f);

        //apply rotation to camera
        transform.localRotation = Quaternion.Euler(verticalLookRoation, 0f, 0f);
    }
}
