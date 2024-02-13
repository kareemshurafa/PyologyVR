using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartMeshLoopControl : MonoBehaviour
{
    public MeshFilter meshFilter; // Assign the MeshFilter component of your heart model
    public Mesh[] heartFrames; // Assign your heart mesh frames here in the inspector
    public float animationSpeed = 1f; // Speed of the animation

    private int currentFrameIndex = 0;
    private bool isPaused = false;
    private bool isAnimating = false;

    void Start()
    {
        StartAnimation();
    }

    void Update()
    {
        // Pause the animation with the right arrow key
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            PauseAnimation();
        }
        // Unpause the animation with the left arrow key
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            UnpauseAnimation();
        }
    }

    void PauseAnimation()
    {
        if (isAnimating && !isPaused)
        {
            isPaused = true;
            // Optional: Stop the animation coroutine here if you're using one
            // StopCoroutine("AnimateHeart");
        }
    }

    void UnpauseAnimation()
    {
        if (isAnimating && isPaused)
        {
            isPaused = false;
            // Optional: Resume the animation coroutine here if you're using one
            // StartCoroutine("AnimateHeart");
        }
    }

    void StartAnimation()
    {
        if (!isAnimating)
        {
            isAnimating = true;
            StartCoroutine(AnimateHeart());
        }
    }

    IEnumerator AnimateHeart()
    {
        while (isAnimating)
        {
            if (!isPaused)
            {
                // Update the mesh to the next frame
                meshFilter.mesh = heartFrames[currentFrameIndex];
                currentFrameIndex = (currentFrameIndex + 1) % heartFrames.Length;
            }
            yield return new WaitForSeconds(1f / animationSpeed);
        }
    }
} 

