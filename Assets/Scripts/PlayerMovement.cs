using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Vector3 movementDirection;

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    void Update()
    { 
        GetAxisInput();
        MovePlayer();
        JumpPlayer();
    }

    private void GetAxisInput()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        movementDirection = new Vector3(x, 0f, z);
    }
    
    private void MovePlayer()
    {
        Vector3 moveVector = transform.TransformDirection(movementDirection) * speed;
        _rigidbody.velocity = new Vector3(moveVector.x, _rigidbody.velocity.y, moveVector.z);
    }

    private void JumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}