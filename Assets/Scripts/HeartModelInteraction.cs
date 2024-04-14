using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartModelInteraction : MonoBehaviour
{
    public float rotationSpeed = 100.0f; // speed of rotation

    public float scaleFactor = 1.1f; // 10% scale increase

    void Update()
    {
        // get the horizontal axis of the right thumbstick
        float horizontalInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch).x;

        // rotate heart model around Y axis based on thumbstick's horizontal input
        transform.Rotate(0f, horizontalInput * rotationSpeed * Time.deltaTime, 0f);
        
        // check for Y key press to scale up by 10%
        if (OVRInput.GetDown(OVRInput.RawButton.Y))
        {
            ScaleUp();
        }

        // check for X key press to scale down by 10%
        if (OVRInput.GetDown(OVRInput.RawButton.X))
        {
            ScaleDown();
        }
    }

    
    // functions are used for the controller buttons and UI buttons
    public void ScaleUp(){
        transform.localScale *= scaleFactor; // multiply the XYZ scale of heart by the scaling factor
    }

    public void ScaleDown(){
        transform.localScale /= scaleFactor; // divide the XYZ scale of heart by the scaling factor
    }
}