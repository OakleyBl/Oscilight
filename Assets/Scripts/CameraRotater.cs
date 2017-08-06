using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotater : MonoBehaviour {

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    // Use this for initialization
    void Start ()
    {
        CharacterController controller = GameObject.Find("Player").GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update ()
    {

        yaw += speedH * Input.GetAxis("Mouse X");

        if (pitch < 30 && Input.GetAxis("Mouse Y") < 0)
            pitch -= speedV * Input.GetAxis("Mouse Y");
        if (pitch > -30 && Input.GetAxis("Mouse Y") > 0)
            pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
