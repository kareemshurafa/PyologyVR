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

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>(); // Ensure this script is attached to a GameObject with a MeshFilter component
        timer = beatInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SwapHeartMesh();
            timer = beatInterval;
        }
    }

    void SwapHeartMesh()
    {
        currentMeshIndex = (currentMeshIndex + 1) % heartMeshes.Length;
        meshFilter.mesh = heartMeshes[currentMeshIndex];
    }
}
