 using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float gravity = -9.81f;

    [SerializeField] private float acceleration = 1f;
    [SerializeField] private float decceleration = 1f;
    
    private float vectorZ = 0.0f;
    private float vectorX = 0.0f;

    private Vector3 movementDirectionX;
    private Vector3 movementDirectionZ;
    private Vector3 gravityDirection;
    
    private CharacterController _controller;
    [SerializeField] private float speedZ;
    [SerializeField] private float speedX; 
    
    
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        GetMovementInput();
        Gravity();
        PlayerMoveForward();
        PlayerTurningMove();
    }

    private void GetMovementInput()
    {
        vectorZ = Input.GetAxis("Vertical");
        vectorX = Input.GetAxis("Horizontal");
    }

    private void Gravity()
    {
        gravityDirection.y += gravity * Time.deltaTime;
        _controller.Move(gravityDirection);
    }
    
    
    private void PlayerMoveForward()
    {
        if (Input.GetKey(KeyCode.W) && speedZ < 12)
        {
            speedZ += Time.deltaTime * acceleration;
        }

        if (!Input.GetKey(KeyCode.W) && speedZ > 0)
        {
            speedZ -= Time.deltaTime * decceleration;
        }
        movementDirectionZ = transform.forward * vectorZ;
        _controller.Move(movementDirectionZ * speedZ * Time.deltaTime);
    }

    private void PlayerTurningMove()
    {

        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && speedX < 5f)
        {
            speedX += Time.deltaTime * acceleration;
        }

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && speedX > 0f)
        {
            speedX -= Time.deltaTime * decceleration;
        }

        movementDirectionX = transform.right * vectorX;
        _controller.Move(movementDirectionX * speedX * Time.deltaTime);

    }
}