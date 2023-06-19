using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Rigidbody rb;
    private Vector3 playerVelocity;
    private float speed = 5f;
    private float originalSpeed;
    private float sprintSpeed;

    private float jumpForce = 2000f;
    private bool isOnGround = true;

    private bool isCrouching = false;
    private float crouchScale = 0.5f;
    private float originalScale;

    private bool isSprinting = false;


    private float gravityScale = 4f;
    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        rb = gameObject.GetComponent<Rigidbody>();

        originalSpeed = speed;
        sprintSpeed = 4 * speed;

        originalScale = transform.localScale.y; originalScale = transform.localScale.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(Physics.gravity * gravityScale, ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isOnGround = true;
        }
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        moveDirection = transform.TransformDirection(moveDirection);
        rb.velocity = moveDirection * speed;
        // controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
    }

    public void Jump()
    {
        if (isOnGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    public void Crouch()
    {
        if (!isCrouching)
        {
            isCrouching = true;
            transform.localScale = new Vector3(transform.localScale.x, originalScale * crouchScale, transform.localScale.z);
        }
        else
        {
            isCrouching = false;
            transform.localScale = new Vector3(transform.localScale.x, originalScale, transform.localScale.z);
        }
    }

    public void Sprint()
    {

        if (!isSprinting)
        {
            isSprinting = true;
            speed = sprintSpeed;
        }
        else
        {
            isSprinting = false;
            speed = originalSpeed;
        }
    }
}
