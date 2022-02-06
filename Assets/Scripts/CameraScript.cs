using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    float screenWidth = 28;
    void Start(){
        float orthoSize = screenWidth * Screen.height/ Screen.width *0.5f;
        Camera.main.orthographicSize = orthoSize;
    }
}
