using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class SliceObject : MonoBehaviour
{
    public Transform planeDebug; // references plane position
    public GameObject heart; // references target object to slice

    public Material crossSectionMaterial; // material object to store the heart model material

    private GameObject upperHull; // creating a gameobject for the upper hull

    private GameObject lowerHull; // creating a gameobject for the lower hull
    
    
    void Update()
    {
        // used for debugging on PC
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Slice(heart);
            Debug.Log("sliced heart");
        }
    }

    // function for slicing heart mesh on UI button press - implemented with EzySlice open-source library
    public void Slice(GameObject heart)
    {
        // the following checks are to see if a hull already exists or not
        // this works by trying to find a game object under the "__Hull" names
        // if there is the existance of previous hulls, these are destroyed
        
        GameObject upperHullDestroyer = GameObject.Find("Upper_Hull");
        if (upperHullDestroyer != null){
            Destroy(upperHullDestroyer);
        }
        
        GameObject lowerHullDestroyer = GameObject.Find("Lower_Hull");
        if (lowerHullDestroyer != null){
            Destroy(lowerHullDestroyer);
        }
        
        // EzySlice contains a check to see if the plane is correctly slicing the target object or not
        SlicedHull hull = heart.Slice(planeDebug.position, planeDebug.up); // needs plane position and normal to slice object

        if(hull != null){ // check to see if the plane is aligned on the heart mesh
            GameObject upperHull = hull.CreateUpperHull(heart, crossSectionMaterial); // can generate mesh using plane coordinate
            upperHull.transform.position = new Vector3(0.45f, 1.0f, 0.1f); // positioning and orientiation for the user
            upperHull.transform.Rotate(0, 90, 0);
        
            GameObject lowerHull = hull.CreateLowerHull(heart, crossSectionMaterial);
            lowerHull.transform.position = new Vector3(0.75f, 1.0f, 0.1f);
            lowerHull.transform.Rotate(0, 90, 0);
        }
        
    }
}
