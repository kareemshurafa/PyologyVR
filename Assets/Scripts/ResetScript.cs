using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScript : MonoBehaviour
{

    // function to reload the scene being used
    public void Reset(){
        SceneManager.LoadScene("OVRSceneUI");
    }

}
