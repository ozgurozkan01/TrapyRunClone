using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Timeline;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{

    private Animator _animator;

    private float velocityX;
    private float velocityZ;
    private int velocityXHash;
    private int velocityZHash;

    [SerializeField] private float acceleration = 2.0f;
    [SerializeField] private float deceleration = 2.0f;
    [SerializeField] private float turningAcceleration = 3.0f;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        GetInput();
    }
    
    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    private void GetInput()
    {
        _animator = GetComponent<Animator>();
        velocityXHash = Animator.StringToHash("Velocity X");
        velocityZHash = Animator.StringToHash("Velocity Z");
    }

    private void PlayerMovement()
    {
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool leftPressed = Input.GetKey(KeyCode.A);
        bool rightPressed = Input.GetKey(KeyCode.D);

        //Increase Speed
        if (forwardPressed && velocityZ < 2f)
        {
            velocityZ += Time.deltaTime * acceleration;
        }

        if (leftPressed && velocityX > -2f)
        {
            velocityX -= Time.deltaTime * turningAcceleration;
        }

        if (rightPressed && velocityX < 2f)
        {
            velocityX += Time.deltaTime * turningAcceleration;
        }
        
        //Decrease Speed
        if (!forwardPressed && velocityZ > 0f)
        {
            velocityZ -= Time.deltaTime * deceleration;
        }
        
        if (!leftPressed && velocityX < 0f)
        {
            velocityX += Time.deltaTime * deceleration;
        }

        if (!rightPressed && velocityX > 0f)
        {
            velocityX -= Time.deltaTime * deceleration;
        }
        
        
        _animator.SetFloat(velocityZHash, velocityZ);
        _animator.SetFloat(velocityXHash, velocityX);
    }



}



