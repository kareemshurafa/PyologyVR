using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSlicerUI : MonoBehaviour
{
    public HeartBeatSimulation heartBeatSimulation;

    public void OnSliceButtonClick()
    {
        // Call the function to toggle the slicing from the HeartBeatSimulation script
        heartBeatSimulation.ToggleSlicing();
    }
}