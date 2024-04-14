using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class SliceObject : MonoBehaviour
{
    public Transform planeDebug; // references plane
    public GameObject heart; // references target object to slice

    public Material cross_section_material;

    private GameObject upperHull;

    private GameObject lowerHull;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // debugging
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Slice(heart);
            Debug.Log("sliced heart");
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            RemoveHulls();
            Debug.Log("Removed hulls");
        }



    }

    // function for slicing heart mesh - implemented with EzySlice library
    public void Slice(GameObject heart)
    {
        // check to see if hulls exist
        
        // EzySlice already contains a check to see if the plane is correctly slicing the target object or not
        SlicedHull hull = heart.Slice(planeDebug.position, planeDebug.up); // needs plane position and normal to slice object

        GameObject upperHull = hull.CreateUpperHull(heart, cross_section_material); // can generate mesh using plane coordinate
        upperHull.transform.position = new Vector3(0.45f, 1.0f, 0.1f);
        upperHull.transform.Rotate(0, 90, 0);
        
        GameObject lowerHull = hull.CreateLowerHull(heart, cross_section_material);
        lowerHull.transform.position = new Vector3(0.75f, 1.0f, 0.1f);
        lowerHull.transform.Rotate(0, 90, 0);
        
    }
    // function to remove the generated hulls
    public void RemoveHulls(){
        Destroy(upperHull);
        Destroy(lowerHull);
    }
}
