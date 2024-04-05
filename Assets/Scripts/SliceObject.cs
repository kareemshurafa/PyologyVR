using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class SliceObject : MonoBehaviour
{
    public Transform planeDebug; // references plane
    public GameObject target; // references target object to slice
    
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

        if(hull != null) // can generate mesh using plane coordinate
        {
            GameObject upperHull = hull.CreateUpperHull(target);
            GameObject lowerHull = hull.CreateLowerHull(target);
        }
    }
}
