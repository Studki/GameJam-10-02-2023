using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private int speedForce = 10;
    [SerializeField] private int jumpForce = 10;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speedForce;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }
        moveDirection.y -= 20 * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
