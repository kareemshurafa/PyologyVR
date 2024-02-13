using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScalerInstant : MonoBehaviour
{
    public float scaleFactor = 1.2f; // 20% scale increase

    void Update()
    {
        // Check for up arrow key press to scale up by 20%
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.localScale *= scaleFactor;
        }

        // Check for down arrow key press to scale down by 20%
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.localScale /= scaleFactor;
        }
    }
}