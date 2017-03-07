using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{

    private Rigidbody player;

    public float movementSpeed = 10.0f;
    public float walkingSpeed = 5.0f;
    public float mouseSensitivity = 1f;
    public float upDownRange = 80.0f;

    float verticalRotation = 0;
    float horizontalRotation = 0;
    float verticalVelocity = 0;
    float jumpSpeed = 4.0f;
    float standardCamHeight;
    float crouchingCamHeight;

    bool isCrouched = false;

    CharacterController characterController;

    // Use this for initialization
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;

        standardCamHeight = Camera.main.transform.localPosition.y;
        crouchingCamHeight = standardCamHeight * 0.7F;
    }

    // Update is called once per frame
    void Update()
    {
        //Rotation
        RotatePlayer();

        //Movement
        MovePlayer();
    }

    private void RotatePlayer()
    {
        verticalRotation -= GetVerticalRotation();
        horizontalRotation = GetHorizontalRotation();

        transform.Rotate(0, horizontalRotation, 0);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

    public float GetHorizontalRotation()
    {
        var horizontalInput = Input.GetAxis("Mouse X") * mouseSensitivity;
        horizontalInput = Mathf.Clamp(horizontalInput, -upDownRange, upDownRange);

        return horizontalInput;
    }

    public float GetVerticalRotation()
    {
        var verticalInput = Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalInput = Mathf.Clamp(verticalInput, -upDownRange, upDownRange);

        return verticalInput;
    }

    private void MovePlayer()
    {
        float verticalSpeed = Input.GetAxis("Vertical") * movementSpeed;
        float horizontalSpeed = Input.GetAxis("Horizontal") * movementSpeed;

        if (!characterController.isGrounded)
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetButtonDown("Crouch"))
        {
            if (!isCrouched)
            {
                Crouch();
            }
        }

        if (Input.GetButtonUp("Crouch"))
        {
            if (isCrouched)
            {
                StopCrouch();
            }
        }

        Vector3 speed = new Vector3(horizontalSpeed, verticalVelocity, verticalSpeed);

        speed = transform.rotation * speed;
        characterController.Move(speed * Time.deltaTime);
    }

    private void Jump()
    {
        if (characterController.isGrounded)
        {
            verticalVelocity = jumpSpeed;
        }
    }

    private void Crouch()
    {
        //Camera.main.transform.localPosition = new Vector3(0, crouchingCamHeight, 0);
        //characterController.transform.localPosition -= new Vector3(0, crouchingCamHeight, 0);
        characterController.height = crouchingCamHeight;
        isCrouched = true;
    }

    private void StopCrouch()
    {
        //Camera.main.transform.localPosition = new Vector3(0, standardCamHeight, 0);
        //characterController.transform.localPosition += new Vector3(0, standardCamHeight, 0);
        characterController.height = standardCamHeight;
        isCrouched = false;
    }
}
