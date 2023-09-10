using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameramode : MonoBehaviour
{
    public GameObject cam_Normal_mode;
    public GameObject cam_Buildin_mode;
    public GameObject Normal_panal;
    public GameObject Building_panal;
    public GameObject Player;

    public GameObject lowerTree_panal;
    public GameObject lowerBuliding_panal;
    public GameObject lowerFarm_panal;

    // Start is called before the first frame update
    void Start()
    {
        Normal_panal.SetActive(true);
        Building_panal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NormalCamera()
    {
        
        cam_Normal_mode.SetActive(false);
        cam_Buildin_mode.SetActive(true);
        Building_panal.SetActive(true);
        Normal_panal.SetActive(false);
        Player.SetActive(false);
    }

    public void BuildingCamera()
    {       
        cam_Normal_mode.SetActive(true);
        cam_Buildin_mode.SetActive(false);
        Normal_panal.SetActive(true);
        Building_panal.SetActive(false);
        Player.SetActive(true);
    }

    public void SwitchTolowerTree_panal()
    {
        Switchbulidingtype(0);
    }
    public void SwitchTolowerlowerBuliding_panal()
    {
        Switchbulidingtype(1);
    }
    public void SwitchTolowerFarm_panal()
    {
        Switchbulidingtype(2);
    }

    public void Switchbulidingtype(int n)
    {
        switch (n)
        {
            case 0:
                lowerTree_panal.SetActive(true);
                lowerBuliding_panal.SetActive(false);
                lowerFarm_panal.SetActive(false);
                break;
            case 1:
                lowerTree_panal.SetActive(false);
                lowerBuliding_panal.SetActive(true);
                lowerFarm_panal.SetActive(false);
                break;
            case 2:
                lowerTree_panal.SetActive(false);
                lowerBuliding_panal.SetActive(false);
                lowerFarm_panal.SetActive(true);
                break;
        }
    }
}
