using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class PointCloudAdjustment : MonoBehaviour
{
    public float sigma = 1.0f;
    public Vector3 center = Vector3.zero;
    public Color color = Color.white;

    private MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        // Update shader properties
        meshRenderer.material.SetFloat("_Sigma", sigma);
        meshRenderer.material.SetVector("_Center", new Vector4(center.x, center.y, center.z, 1));
        meshRenderer.material.SetColor("_Color", color);
    }
}
