using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WalkAnimation : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6.0f;
    public bool isWalk = false;
    public bool isIdle = true;

    public Animator Anime;


    void Update()
    {
        Run();
        AnimePlayer();
    }
    public void Run()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 inputDirection = new Vector3(horizontalInput, 0.0f, verticalInput);
        Vector3 moveDirection = transform.TransformDirection(inputDirection);
        moveDirection.y = 0.0f; // Ensure the player doesn't move vertically.

        controller.SimpleMove(moveDirection * speed);
        isWalk = (Input.GetAxisRaw("Horizontal") != 0);
        isIdle = (Input.GetAxisRaw("Horizontal") == 0);
    }

    private void AnimePlayer()
    {
        if (isIdle)
        {
            Anime.SetBool("isIdle", isIdle);
        }
        else if (isWalk)
        {
            Anime.SetBool("isWalk", isWalk);
        }

    }
}
