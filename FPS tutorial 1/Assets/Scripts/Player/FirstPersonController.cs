using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour {

    public float movementSpeed = 10.0f;
    public float walkingSpeed = 5.0f;
    public float mouseSensitivity = 1f;
    public float upDownRange = 80.0f;

    float verticalRotation = 0;
    float verticalVelocity = 0;

    float jumpSpeed = 4.0f;

    bool isCrouched = false;
    
    CharacterController characterController;

    // Use this for initialization
    void Start () {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }
	
	// Update is called once per frame
	void Update ()
    {   
        //Rotation
        float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, rotLeftRight, 0);
        
        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);

        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        //Movement 
        float verticalSpeed = Input.GetAxis("Vertical") * movementSpeed;
        float horizontalSpeed = Input.GetAxis("Horizontal") * movementSpeed;

        if (!characterController.isGrounded)
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }

        if (characterController.isGrounded && Input.GetButtonDown("Jump"))
        {
            verticalVelocity = jumpSpeed;
        }

        if (characterController.isGrounded && Input.GetButtonDown("Crouch"))
        {
            isCrouched = !isCrouched;


        }

        Vector3 speed = new Vector3(horizontalSpeed, verticalVelocity, verticalSpeed);
        
        speed = transform.rotation * speed;
        characterController.Move(speed * Time.deltaTime);
    }
}
