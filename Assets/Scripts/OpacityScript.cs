using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpacityScript : MonoBehaviour
{
    private Renderer heartRenderer;
    private float opacityValue;

    // Start is called before the first frame update
    void Start()
    {
        heartRenderer = GetComponent<Renderer>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnValueChanged(){
        opacityValue = GameObject.Find("OpacitySlider").GetComponent<Slider>().value;
        Color updatedColor = new Color(1.0f, 0.33f, 0.33f, opacityValue);
        heartRenderer.material.SetColor("_Color", updatedColor);
    }
}
