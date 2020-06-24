using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 1f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;

    public Transform GroundCheck;
    public float groundDistance = .4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public bool inUI;


    void Update()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
            velocity.y = -1f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * x + transform.forward * z) * speed * Time.deltaTime;

        velocity.y += gravity * Time.deltaTime;
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        if (!inUI)
        {
            controller.Move(move);
            controller.Move(velocity * Time.deltaTime);
        }
    }

    public void OnOpenUI()
    {
        inUI = true;
    }

    public void OnCloseUI()
    {
        inUI = false;
    }
}
