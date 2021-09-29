using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player_Controller : MonoBehaviour
{
    public bool canMove = true;
    public float speed = 6f;
    public float gravity = 20f;

    public Vector3 moveDirection = Vector3.zero;
    public CharacterController controller;

    public float jumpSpeed = 8f;
    public int maxDoubleJumps = 0;
    public int jumps;

    public float rot = 0f;
    public float rotSpeed = 150f;

    public bool isFlying;
    public float particlePlayDistance = 0.2f;

    public Camera playerCam;
    public Animator anim;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
        isFlying = controller.isGrounded;
    }

    // Update is called once per frame
    private void Update()
    {
        checkForLanding();
        Rotate();
        Move();
        Animate();
    }

    public void Move()
    {
        if (canMove == false) return;
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal") / 2, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetKey(KeyCode.Space))
            {
                moveDirection.y = jumpSpeed;

                anim.SetTrigger("Jumping");
            }
            jumps = 0;
        }
        else
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal") / 2, moveDirection.y, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection.x *= speed;
            moveDirection.z *= speed;
            if (Input.GetKeyDown(KeyCode.Space) && jumps < maxDoubleJumps)
            {
                moveDirection.y = jumpSpeed;
                jumps++;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    public void Rotate()
    {
        transform.eulerAngles = new Vector3(0, playerCam.transform.rotation.eulerAngles.y, 0);
    }

    public void checkForLanding()
    {
        RaycastHit hit;
        Debug.DrawRay(this.transform.position + new Vector3(0, particlePlayDistance, 0), this.transform.TransformDirection(Vector3.down) * particlePlayDistance, Color.red);
        if (Physics.Raycast(this.transform.position + new Vector3(0, particlePlayDistance, 0), this.transform.TransformDirection(Vector3.down), out hit, particlePlayDistance))
        {
            if (hit.collider != null)
            {
                isFlying = false;
            }
        }
        else
        {
            isFlying = true;
        }
    }

    public void Animate()
    {
        if (moveDirection.x != 0 || moveDirection.z != 0)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("IsJumping", true);
        }

        else
        {
            anim.SetBool("IsJumping", false);
        }
    }
}
