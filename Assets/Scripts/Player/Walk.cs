using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Walk : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Walking();
    }
    public void Walking()

    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 wal = transform.forward * zInput + transform.right * xInput;
        transform.position += wal * moveSpeed * Time.deltaTime;

    }
}
