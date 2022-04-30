using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    private Rigidbody rb;

    [Range(50f, 200f)]
    public float walkSpeed = 100f;
    [Range(50f, 500f)]
    public float runSpeed = 200f;
    [Range(1000f, 2000f)]
    public float jumpForce = 1000f;

    public LayerMask Ground;
    public Transform groundDetector;
    private float mSpeed;
    public Camera cam;
    float baseFOV;
    public float SprintFOV = 1.25f;

    public bool jump = false;
    public bool sprint = false;
    public Vector3 movement;



    void Start()
    {
        baseFOV = cam.fieldOfView;
        mSpeed = walkSpeed;
        rb = GetComponent<Rigidbody>();
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        bool groundCheck = Physics.Raycast(groundDetector.position, Vector3.down, 0.1f, Ground);
        jump = Input.GetKey(KeyCode.Space) && groundCheck;


        if (jump == true)
        {
            
            rb.AddForce(Vector3.up * jumpForce);
            
        }
    
        sprint = (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift));
       
        if (sprint == true && moveVertical > 0)
        {
           
            mSpeed = runSpeed;
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, baseFOV * SprintFOV, Time.fixedDeltaTime * 8f);
           
        }
        else
        {
            
            mSpeed = walkSpeed;
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, baseFOV, Time.fixedDeltaTime * 8f);
        }

        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        movement.Normalize();

       
        Vector3 v = transform.TransformDirection(movement) * mSpeed * Time.fixedDeltaTime;
        v.y = rb.velocity.y;
        rb.velocity = v;
        
       
     
    }
}
