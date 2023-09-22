using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Formula : MonoBehaviour
{
    public Camera cam;

    public static Formula instance;
    private float _gridSize = 0.5f;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
       // cam = Camera.main;
    }

    public Vector3 GetCurTilePosition()
    {
        if (EventSystem.current.IsPointerOverGameObject() == false) //Hover over UI
        {
            Debug.Log(Input.mousePosition);
            return new Vector3(0, -99, 0);
        }

        Plane plane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        float rayDistance = 0.0f;

        if (plane.Raycast(ray, out rayDistance))
        {
            Vector3 newPos = ray.GetPoint(rayDistance);
            newPos = new Vector3(Mathf.RoundToInt(newPos.x / _gridSize) * _gridSize,
                                 0.0f,
                                 Mathf.RoundToInt(newPos.z / _gridSize) * _gridSize);
            
            return newPos;
        }
        

        return new Vector3(0, -99, 0);
    }
}