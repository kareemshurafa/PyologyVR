using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class SliceObject : MonoBehaviour
{
    public Transform planeDebug; // references plane
    public GameObject target; // references target object to slice

    public Material cross_section_material;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // TESTING USING SPACE KEY
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Slice(target);
        }

    }

    public void Slice(GameObject target)
    {
        SlicedHull hull = target.Slice(planeDebug.position, planeDebug.up); // needs plane position and normal to slice object

        GameObject upperHull = hull.CreateUpperHull(target, cross_section_material); // can generate mesh using plane coordinate
        upperHull.transform.position = new Vector3(0.45f, 1.0f, 0.1f);
        upperHull.transform.Rotate(0, 90, 0);
        
        GameObject lowerHull = hull.CreateLowerHull(target, cross_section_material);
        lowerHull.transform.position = new Vector3(0.75f, 1.0f, 0.1f);
        lowerHull.transform.Rotate(0, 90, 0);
        
    }
}
