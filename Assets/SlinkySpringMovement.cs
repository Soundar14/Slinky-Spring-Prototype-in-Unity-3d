using System.Collections;
using System.Collections.Generic;
using System.Threading;
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

    public float swipeThreshold = 12f;
    Rigidbody rb;
    
     public HeadOrTail headOrTail;

    SlinkySpringMovement relatedEnd;


    Vector2 touchPosition;
    bool isSwipeUp;
    bool isSwipeDown;

    public float groundCheckDistance = 0.1f; // The distance to check for ground

    private bool isGrounded; // Flag to store the grounded state
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();        
    }

    private void Update()
    {
        
        

        if(headOrTail == HeadOrTail.Head)
        {
            rb.AddForce(transform.forward * speed * 4, ForceMode.Force);


            if (Input.touchCount > 0)
            {
                rb.velocity = Vector3.forward * speed * 2f;
                rb.AddForce(transform.forward *  speed,ForceMode.Force);
                Touch touchInput = Input.GetTouch(0);

                switch (touchInput.phase)
                {
                    case TouchPhase.Began:
                        touchPosition = touchInput.position;
                        isSwipeUp = false;
                        isSwipeDown = false;
                        break;

                    case TouchPhase.Moved:
                        Vector2 swipeDir = touchInput.position - touchPosition;
                        float swipeMagnitude = swipeDir.magnitude;

                        if (swipeMagnitude >= swipeThreshold)
                        {
                            if (swipeDir.y > 0)
                            {
                                isSwipeUp = true;
                            }
                            else if (swipeDir.y < 0)
                            {
                                 
                                
                                  isSwipeDown = true;
                                
                            }
                        }

                        break;

                    case TouchPhase.Ended:

                        if (isSwipeUp)
                        {
                            Jump();
                            isSwipeUp = false;
                        }
                        else if (isSwipeDown)
                        {
                            FallDown();
                            isSwipeDown = false;
                        }
                        else
                        {
                            rb.AddForce(Vector3.up* speed,ForceMode.Impulse);
                        }

                        break;
                }

            }



            // Perform the ground check
            isGrounded = CheckGrounded();

            // Use the grounded flag for further logic or actions
            if (isGrounded)
            {
                // Collider is grounded
                //Debug.Log("Collider is grounded!");

                SlinkyManager.Instance.ToggleSlinkyParts();
                rb.AddForce(Vector3.up * speed);
            }
            else
            {
                // Collider is not grounded
                //Debug.Log("Collider is not grounded!");
            }
        }

        


    }

    void Jump()
    {
        rb.AddForce (Vector3.up * speed , ForceMode.Impulse);
        rb.velocity = transform.forward * speed;
    }
    void FallDown()
    {
        Debug.Log("Swiped Down");
        rb.velocity = Vector3.zero;
        //rb.angularVelocity *= Vector3.zero;

        rb.AddForce(Vector3.down * speed * 4f, ForceMode.Force);
        rb.velocity += Vector3.down * speed *4;
    }

    

    

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
