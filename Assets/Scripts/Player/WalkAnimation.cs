using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class WalkAnimation : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 6.0f;
    [SerializeField] private bool isWalk = false;
    [SerializeField] private bool isIdle = true;
    public GameObject _rotate;

    Vector3 lastPos;
    [SerializeField] private Animator Anime;

    private void Awake()
    {
      //  Anime = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Walk();
    }
    public void Walk()
    {
        //Movement
   //     float x = Input.GetAxis("Horizontal");
    //    float z = Input.GetAxis("Vertical");
    //    Vector3 move = transform.right * x + transform.forward * z;
    //    controller.Move(move * speed * Time.deltaTime);


        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput);
        transform.Translate(moveDirection * speed * Time.deltaTime);

        if (Input.GetAxis("Horizontal") != 0)
        {

        }

        if (Input.GetAxis("Horizontal") < 0)
        {

            _rotate.transform.rotation = Quaternion.Euler(0, -90, 0);


        }
        if (Input.GetAxis("Horizontal") > 0)
        {

            _rotate.transform.rotation = Quaternion.Euler(0, 90, 0);


        }
        if (Input.GetAxis("Vertical") > 0)
        {

            _rotate.transform.rotation = Quaternion.Euler(0, 0, 0);


        }
        if (Input.GetAxis("Vertical") < 0)
        {

            _rotate.transform.rotation = Quaternion.Euler(0, 180, 0);
        }


        isWalk = moveDirection.magnitude > 0.01f;
        Anime.SetBool("isWalk", isWalk);
        isIdle = moveDirection.magnitude < 0.01f;
        Anime.SetBool("isIdle", isIdle);
    }

}
