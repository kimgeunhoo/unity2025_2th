using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationTest : MonoBehaviour
{
    Animator animator;
    float speed;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // unity 6
        //if(Keyboard.current.tKey.wasPressedThisFrame)
        //{
            
        //}

        if (Input.GetKey(KeyCode.T))
        {
            speed += Time.deltaTime;
            animator.SetFloat("Speed", 1);
        }
        else if (Input.GetKeyUp(KeyCode.T))
        {
            speed = 0;
            animator.SetFloat("Speed", 0);
        }
    }
}
