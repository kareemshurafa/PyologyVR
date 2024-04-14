using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpacityScript : MonoBehaviour
{
    private Renderer heartRenderer; // initialise the renderer object of the heart model
    
    private Slider opacitySlider; // create slider object to be used to obtain slider 
    private float opacityValue; // stores the value of the opacity from the slider

    void Start()
    {
        heartRenderer = GetComponent<Renderer>(); // obtain the model renderer at the start
    }

    // function bound to the opacity slider
    // tracks value of opacity and applies it to a new rendered material
    // this runs with every value change of the opacity (i.e. continuously)
    public void OnValueChanged(){
        opacitySlider = GameObject.Find("OpacitySlider").GetComponent<Slider>(); // obtain the slider component from game object
        opacityValue = opacitySlider.value; // store the value of the opacity
        Color updatedColor = new Color(1.0f, 0.33f, 0.33f, opacityValue); // update the new colour with the user-chosen opacity
        heartRenderer.material.SetColor("_Color", updatedColor); // change the current colour of heart model with new colour
    }
}
