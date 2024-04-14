using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeatSimulation : MonoBehaviour
{
    public Mesh[] heartMeshes; // array for heart meshes
    public float heartbeatInterval = 0.1f; // time interval for the beating simulation

    private MeshFilter meshFilter;
    private int currentMeshIndex = 0;
    private float timer;
    private bool isPaused = false; 

    // Reference - adapted from ChatGPT 4.0 (https://chat.openai.com/)
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>(); // obtain the MeshFilter component of the GameObject
        timer = heartbeatInterval;
    }

    void Update() // script runs every frame 
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

        // if not paused - i.e. during normal runtime
        if (!isPaused)
        {
            timer -= Time.deltaTime; // takes time since last frame and subtracts from current timer
            if (timer <= 0f) // when timer reaches 0 or under 0
            {
                // run the heart mesh loop script, which moves to the next heart mesh
                SwapHeartMesh();
                timer = heartbeatInterval;
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