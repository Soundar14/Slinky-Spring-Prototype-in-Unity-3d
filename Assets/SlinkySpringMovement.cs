using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum HeadOrTail
{
    Head,
    Body,
    Tail
}
public class SlinkySpringMovement : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    
     public HeadOrTail headOrTail;

    SlinkySpringMovement relatedEnd;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();        
    }

    private void Update()
    {
        if(headOrTail == HeadOrTail.Head)
        {

            //rb.velocity += Vector3.forward*speed*Time.deltaTime;

            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(Vector3.up * speed);
                rb.AddForce(Vector3.forward * speed * 1.2f);

            }

            // Perform the ground check
            isGrounded = CheckGrounded();

            // Use the grounded flag for further logic or actions
            if (isGrounded)
            {
                // Collider is grounded
                Debug.Log("Collider is grounded!");

                SlinkyManager.Instance.ToggleSlinkyParts();
                rb.AddForce(Vector3.up * speed);
            }
            else
            {
                // Collider is not grounded
                Debug.Log("Collider is not grounded!");
            }
        }

        


    }

    public float groundCheckDistance = 0.1f; // The distance to check for ground

    private bool isGrounded; // Flag to store the grounded state

    

    private bool CheckGrounded()
    {
        // Perform a raycast from the ground check position downwards
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance))
        {
            // If the raycast hits something, the collider is grounded
            return true;
        }

        // The collider is not grounded
        return false;
    }

}
