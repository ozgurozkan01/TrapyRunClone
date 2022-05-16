using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FallDownCube : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Collider _collider;
    private const int deactiveCubeLayer = 10;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            ActivateCube();
        }
    }
    
    private void ActivateCube()
    {
        _rigidbody.isKinematic = false;
        
        gameObject.layer = deactiveCubeLayer;
    }
    
    
}
