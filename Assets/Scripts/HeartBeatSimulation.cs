// Reference - adapted from ChatGPT 4.0 (https://chat.openai.com/)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeatSimulation : MonoBehaviour
{
    public Mesh[] heartMeshes; // array to hold the heart meshes
    public float heartbeatInterval = 0.1f; // time interval for the beating simulation

    private MeshFilter meshFilter; // the mesh filter being used for rendering
    private int currentMeshIndex = 0; // start of the array of meshes
    private float timer; // used during incrementing of the looping
    private bool isPaused = false; // check to see if the pause button is pressed down or not

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>(); // obtain the MeshFilter component of the GameObject
        timer = heartbeatInterval; // initialise the timer to be equal to the heart beat interval value
    }

    void Update() // script runs every frame 
    {
        // check for pause/unpause on controller input using OVRInput
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

    // function to swap the heart meshes for the looping animation
    void SwapHeartMesh()
    {
        // performs modulus calculation that outputs an incrementing currentMeshIndex value
        // when the index value is equal to the length of the heart meshes,
        // it equals to zero - i.e, the mesh that is rendered goes back to the start of the array
        currentMeshIndex = (currentMeshIndex + 1) % heartMeshes.Length;
        Debug.Log("Value of mesh index" + currentMeshIndex);
        meshFilter.mesh = heartMeshes[currentMeshIndex];
    }

}
