using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunning : MonoBehaviour
{
    private Vector3 moveVector;
    private bool isDead = false;
    private float gravity = 9.8f;
    private CharacterController player;
    [SerializeField] protected float speed = 5f;
    private float verticalVelocity = 0f;
    private float animTime = 2f;
    

    private void Awake()
    {
        player = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < animTime)
        {
            player.Move(Vector3.forward * speed * Time.deltaTime); // Move along the Z-axis
        }
        else
        {
            if (!isDead)
            {
                if (player.isGrounded)
                {
                    verticalVelocity = -0.5f;
                }
                else
                {
                    verticalVelocity -= gravity * Time.deltaTime;
                }

                // Use Input.GetAxis("Horizontal") for horizontal movement
                moveVector.x = Input.GetAxis("Horizontal") * speed;

                // Use Input.GetKey(KeyCode.Space) to check if the Space key is pressed
                if (Input.GetKey(KeyCode.Space))
                {
                    moveVector.y = -verticalVelocity; // Move downward
                }
                else
                {
                    moveVector.y = verticalVelocity; // Move upward
                }

                // Continue moving forward
                moveVector.z = speed;

                player.Move(moveVector * Time.deltaTime); // Move the character controller
            }
            else
            {
                // Handle code for when the player is dead
            }
        }
    }



    public void setSpeed (float v)
    {
        speed += v;
    }

    internal void Dead ()
    {
        isDead = true;
    }
}
