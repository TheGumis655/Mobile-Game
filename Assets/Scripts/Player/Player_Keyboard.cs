using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Keyboard : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    public Joystick joystick;

    bool keyboard = true;

    Vector2 movement;

    

    void Update()
    {
        movement.x = 0;
        movement.y = 0;
        if (keyboard)
        {

            if (Input.anyKey)
            {
                movement.x = Input.GetAxisRaw("Horizontal") + joystick.Horizontal;
                movement.y = Input.GetAxisRaw("Vertical") + joystick.Vertical;

            }


            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void SetKeyboard(bool enable)
    { 
        keyboard = enable;
    }
    public bool GetKeyboard()
    {
        return keyboard;
    }
}
