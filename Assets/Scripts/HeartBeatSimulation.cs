using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeatSimulation : MonoBehaviour
{
    public Mesh[] heartMeshes; // array for heart meshes
    public float beatInterval = 0.1f; // time interval for the beating simulation

    private MeshFilter meshFilter;
    private int currentMeshIndex = 0;
    private float timer;
    private bool isPaused = false; 

    // Reference - adapted from ChatGPT 4.0 (https://chat.openai.com/)
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>(); // obtain the MeshFilter component of the GameObject
        timer = beatInterval;
    }

    void Update()
    {
        // Check for pause/unpause input using OVRInput
        if (OVRInput.GetDown(OVRInput.Button.One)) // A button for pause
        {
            if (isPaused == true)
            {
                isPaused = false;
            }
            else if (isPaused == false)
            {
                isPaused = true;
            }
        }

        // Update the timer and swap meshes only if not paused
        if (!isPaused)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                // run the heart mesh loop script
                SwapHeartMesh();
                timer = beatInterval;
            }
        }
    }

    void SwapHeartMesh()
    {
        // move to the next mesh 
        currentMeshIndex = (currentMeshIndex + 1) % heartMeshes.Length;
        meshFilter.mesh = heartMeshes[currentMeshIndex];
    }

}