using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeatSimulation : MonoBehaviour
{
    public Mesh[] heartMeshes; // Array to hold your heart meshes
    public float beatInterval = 0.1f; // Time between beats, adjust as needed
    public Material originalMaterial; // Assign your original material for the heart
    public Material slicingMaterial; // Assign your slicing material with HeartSliceShader

    private MeshFilter meshFilter;
    private int currentMeshIndex = 0;
    private float timer;
    private bool isPaused = false; // Flag to control the pause state
    private bool isSliced = false; // Variable to track if slicing is active

    public Vector3 planePosition = new Vector3(0, 0, 0);
    public Vector3 planeNormal = new Vector3(0, 1, 0);

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

    public void ToggleSlicing()
    {
        isSliced = !isSliced;
        if (isSliced)
        {
            // Switch to the slicing material and update plane properties
            var renderer = meshFilter.GetComponent<Renderer>();
            renderer.material = slicingMaterial;
            slicingMaterial.SetVector("_PlanePos", new Vector4(planePosition.x, planePosition.y, planePosition.z, 0));
            slicingMaterial.SetVector("_PlaneNorm", new Vector4(planeNormal.x, planeNormal.y, planeNormal.z, 0));
        }
        else
        {
            // Revert to the original material
            meshFilter.GetComponent<Renderer>().material = originalMaterial;
        }
    }

}