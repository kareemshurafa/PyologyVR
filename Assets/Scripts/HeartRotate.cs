using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartRotate : MonoBehaviour
{
    public float rotationSpeed = 50.0f; // Adjust the speed of rotation

    void Update()
    {
        // Get the horizontal axis of the right thumbstick
        float horizontalInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch).x;

        // Rotate the heart model around the Y axis based on the thumbstick's horizontal input
        transform.Rotate(0f, horizontalInput * rotationSpeed * Time.deltaTime, 0f);
    }
}
