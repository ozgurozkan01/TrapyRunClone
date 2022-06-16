using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationMovementController : MonoBehaviour
{
    private Animator _animator;
    float velocity = 0.0f;
    public float acceleration = 0.1f;
    public float decceleration = 0.5f;
    int velocityHash;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        velocityHash = Animator.StringToHash("Velocity");
    }
 
    // Update is called once per frame
    void Update()
    {
        PlayerSpeedUp();
        PlayerSpeedDown();
        PlayerNotMove();
    }

    /*
    private void PlayerWalking()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _animator.SetBool("isWalking", true);
        }

        if (!Input.GetKey(KeyCode.W))
        {
            _animator.SetBool("isWalking", false);
        }
    }

    private void PlayerRunning()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            _animator.SetBool("isRunning", true);
        }

        if (!(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift)))
        {
            _animator.SetBool("isRunning", false);
        }
    }
    */

    private void PlayerSpeedUp()
    {
        if (Input.GetKey(KeyCode.W) && velocity < 1.0f)
        {
            velocity += Time.deltaTime * acceleration;
        }
        _animator.SetFloat(velocityHash, velocity);
    }

    private void PlayerSpeedDown()
    {
        if (!Input.GetKey(KeyCode.W) && velocity > 0.0f)
        {
            velocity -= Time.deltaTime * decceleration;
        }
        _animator.SetFloat(velocityHash, velocity);
    }

    private void PlayerNotMove()
    {
        if (!Input.GetKey(KeyCode.W) && velocity < 0.0f)
        {
            velocity = 0.0f;
        }
        _animator.SetFloat(velocityHash, velocity);
    }
    
}
