using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12;
    public float jump = 5;
    private float gravitiy = -9.81f;

    private bool isJumping = false;
    private bool canDoubleJump = false;
    private int clickSpaceCount;
    

    private Vector3 velocity;
    private Vector3 jumpVelocity;
    private Vector3 moveVelocity;

    private void Update()
    {
        moveVelocity.x = Input.GetAxis("Horizontal");
        moveVelocity.z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveVelocity.x + transform.forward * moveVelocity.z;

        controller.Move(move * speed * Time.deltaTime);


        bool isButtonDown = Input.GetButtonDown("Jump");

        if (isButtonDown && !isJumping)
        {
            isJumping = true;
            jumpVelocity = Vector3.up * jump;
            canDoubleJump = true;
        }
        else if (isButtonDown && canDoubleJump)
        {
            Debug.Log("Çift zıplama");
            jumpVelocity = Vector3.up * jump;
            canDoubleJump = false; // Çift zıplama yapıldı, artık tekrar yapamaz.
        }

        if (isJumping)
        {
            controller.Move((moveVelocity + jumpVelocity) * Time.deltaTime);
            jumpVelocity += Physics.gravity * Time.deltaTime;
            if (controller.isGrounded)
            {
                isJumping = false;
                canDoubleJump = false;
            }
        }
        else
        {
            controller.SimpleMove(moveVelocity);
        }
    }

    public void onPointClick(PointerEventData eventData)
    {
        
    }
}
