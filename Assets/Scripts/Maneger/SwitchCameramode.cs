using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameramode : MonoBehaviour
{
    public GameObject cam_Normal_mode;
    public GameObject cam_Buildin_mode;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NormalCamera()
    {
        cam_Normal_mode.SetActive(false);
        cam_Normal_mode.SetActive(true);
    }

    public void BuildingCamera()
    {
        cam_Normal_mode.SetActive(true);
        cam_Normal_mode.SetActive(false);
    }
}
