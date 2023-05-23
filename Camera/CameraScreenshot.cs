using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScreenshot : MonoBehaviour
{
    public string fileName;

    private void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            ScreenCapture.CaptureScreenshot(fileName + ".png");
        }
    }
}
