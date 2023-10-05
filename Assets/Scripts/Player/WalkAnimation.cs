using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class WalkAnimation : MonoBehaviour
{


    [Header("References")]
    public Transform orientation;
    public Transform playerObj;
    [SerializeField] private float speed = 6.0f;
    [SerializeField] private bool isWalk = false;
    [SerializeField] private bool isIdle = true;

    public float rotationSpeed;

    [SerializeField] private Animator Anime;

    private void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput);
        transform.Translate(moveDirection * speed * Time.deltaTime);

        //  float horizontalInput = Input.GetAxis("Horizontal");
        //     float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (inputDir != Vector3.zero)
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);

        isWalk = moveDirection.magnitude > 0.01f;
        Anime.SetBool("isWalk", isWalk);
        isIdle = moveDirection.magnitude < 0.01f;
        Anime.SetBool("isIdle", isIdle);

    }


}
