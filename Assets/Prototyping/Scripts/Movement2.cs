using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    public float speed = 3;
    public float minPosX;
    public float maxPosX;
    public float jumpHeightX;
    float CurrentX = 0f;

    Rigidbody rb;
    public LayerMask groundLayers;
    public float jumpForce = 7f;
    public CapsuleCollider col;

    void Start()
    {
        CurrentX = transform.position.x;
        minPosX = transform.position.x - 1;  // Set the values of the current, max and min position to be universal for every starting position
        maxPosX = transform.position.x + 1;

        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }
    public void LeftMoved()
    {
        if (transform.position.x == CurrentX) // Checks is the player inst in move rn
        {
            CurrentX -= 1; // Creates the direction of the player-object by decreasing the value of the current position of the player-object on the x-axis by 1
        }
    }
    public void RightMoved()
    {
        if (transform.position.x == CurrentX) // Checks is the player inst in move rn
        {
            CurrentX += 1; // Creates the direction of the player-object by increasing the value of the current position of the player-object on the x-axis by 1
        }
    }

    public void SwipedUp()
    {
        if (IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime); // Moves the object automatically at speed unit/s

        CurrentX = Mathf.Clamp(CurrentX, minPosX, maxPosX); // Checks if the CurrentX is in the right value considering the 3-band rule. If not, it will correct the value
        transform.position = Vector3.MoveTowards(transform.position,  // Moves the object smoothly to the direction
            new Vector3(CurrentX, transform.position.y, transform.position.z),
            speed * Time.fixedDeltaTime);
    }
    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z),
            col.radius * .9f, groundLayers); // Checks if the object is on an object layered with one of the groundLayers 
                                             // The cause of the multiplying with .9f is that we dont want our player-object to be able to jump if he hits a side of a wall
    }
}
