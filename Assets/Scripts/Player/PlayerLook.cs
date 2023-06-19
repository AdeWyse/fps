using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;

    private float xRotation = 0f;

    public float xSensitivity = 40f;
    public float ySensitivity = 40f;

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80, 80);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    } 
}