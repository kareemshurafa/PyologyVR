using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeatSimulation : MonoBehaviour
{
    public Mesh[] heartMeshes; // Array to hold your heart meshes
    public float beatInterval = 0.1f; // Time between beats, adjust as needed

    private MeshFilter meshFilter;
    private int currentMeshIndex = 0;
    private float timer;
    private bool isPaused = false; // Flag to control the pause state

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>(); // Ensure this script is attached to a GameObject with a MeshFilter component
        timer = beatInterval;
    }

    void Update()
    {
        // Check for pause/unpause input using OVRInput
        if (OVRInput.GetDown(OVRInput.Button.One)) // A button for pause
        {
            isPaused = true;
        }
        if (OVRInput.GetDown(OVRInput.Button.Two)) // B button for unpause
        {
            isPaused = false;
        }

        // Update the timer and swap meshes only if not paused
        if (!isPaused)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                SwapHeartMesh();
                timer = beatInterval;
            }
        }
    }

    void SwapHeartMesh()
    {
        currentMeshIndex = (currentMeshIndex + 1) % heartMeshes.Length;
        meshFilter.mesh = heartMeshes[currentMeshIndex];
    }
}