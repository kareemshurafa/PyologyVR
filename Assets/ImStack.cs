using UnityEngine;
using System.IO;

public class ImageStackGenerator : MonoBehaviour
{
    public string folderPath; // Path to the folder containing images
    public GameObject cubePrefab; // Prefab for creating cube GameObjects
    public float stackSpacing = 0.1f; // Spacing between images in the stack

    void Start()
    {
        StackImages();
    }

    void StackImages()
    {
        if (!Directory.Exists(folderPath))
        {
            Debug.LogError("Folder does not exist: " + folderPath);
            return;
        }

        string[] imagePaths = Directory.GetFiles(folderPath, "*.png"); // Adjust extension as needed

        Texture2D textureAtlas = new Texture2D(2, 2);

        // Loop through all images to combine them into a texture atlas
        foreach (string imagePath in imagePaths)
        {
            byte[] fileData = File.ReadAllBytes(imagePath);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(fileData); // Load image data into texture

            // Combine this image into the texture atlas
            CombineIntoAtlas(textureAtlas, texture);
        }

        // Create cube GameObject
        GameObject cubeObj = Instantiate(cubePrefab, transform);

        // Apply texture atlas as material to cube
        cubeObj.GetComponent<Renderer>().material.mainTexture = textureAtlas;

        cubeObj.transform.position = new Vector3(0, 0.5f, 1.3f); // Set the desired position
    }

    void CombineIntoAtlas(Texture2D atlas, Texture2D texture)
    {
        // Combine texture into texture atlas (implement your logic here)
        // For simplicity, you can use Graphics.CopyTexture or other methods to copy the texture data into the atlas
        // You might need to calculate UV coordinates for each image in the atlas
    }
}