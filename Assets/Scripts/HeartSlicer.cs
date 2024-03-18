using UnityEngine;
using UnityEngine.UI;

public class HeartSlicer : MonoBehaviour
{
    public Material slicingMaterial; // Assign in inspector
    public Material originalMaterial; // Assign the current material of the heart model
    public Transform slicingPlane; // Assign a GameObject to represent the slicing plane
    public Button sliceButton; // Assign your UI button

    private Renderer heartRenderer;
    private bool isSliced = false;

    void Start()
    {
        heartRenderer = GetComponent<Renderer>();
        sliceButton.onClick.AddListener(ToggleSlicing); // Assuming you have a Button component on your UI Button
    }

    void ToggleSlicing()
    {
        isSliced = !isSliced;

        // If the model is paused and we want to slice
        if (isSliced)
        {
            heartRenderer.material = slicingMaterial;
            UpdateShaderProperties();
        }
        else // Reverting to original state
        {
            heartRenderer.material = originalMaterial;
        }
    }

    void UpdateShaderProperties()
    {
        Vector3 planePosition = slicingPlane.position;
        Vector3 planeNormal = slicingPlane.up;

        slicingMaterial.SetVector("_PlanePos", new Vector4(planePosition.x, planePosition.y, planePosition.z, 0.0f));
        slicingMaterial.SetVector("_PlaneNorm", new Vector4(planeNormal.x, planeNormal.y, planeNormal.z, 0.0f));
    }
}
