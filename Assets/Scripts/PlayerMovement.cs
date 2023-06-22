using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpPower = 5f;
    [SerializeField] Transform groundChecker;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] AudioSource jumpSound;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3 (horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);




        if (Input.GetButtonDown("Jump") && groundCheck())
        {
            Jump();

        }
        
    }
    private void Jump() 
    { 
        rb.velocity = new Vector3(rb.velocity.x, jumpPower, rb.velocity.z);
        jumpSound.Play();  
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyHead")
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }
    bool groundCheck()
    {
        return Physics.CheckSphere(groundChecker.position, 0.1f, groundLayer);

    }
}
    