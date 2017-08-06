using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    int walkSpeed = 150;
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    float jumpSpeed = 8.0f;
    float gravity = 20.0f;

 
 private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        CharacterController controller = GameObject.Find("Player").GetComponent<CharacterController>();

        if (controller.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= walkSpeed * Time.deltaTime;

            //also with jump ;)
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity 
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);

        // rotate controller
        yaw += speedH * Input.GetAxis("Mouse X");

        if (pitch < 30 && Input.GetAxis("Mouse Y") < 0)
            pitch -= speedV * Input.GetAxis("Mouse Y");
        if (pitch > -30 && Input.GetAxis("Mouse Y") > 0)
            pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        GameObject.Find("Player Camera").GetComponent<Transform>().localPosition = GameObject.Find("Player").GetComponent<Transform>().localPosition;
    }

}