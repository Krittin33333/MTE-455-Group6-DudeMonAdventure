using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject cam_Normal_mode;
    public GameObject cam_Buildin_mode;
    public GameObject Normal_panal;
    public GameObject Building_panal;
    public GameObject Player;
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
}
