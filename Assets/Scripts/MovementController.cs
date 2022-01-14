using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Joystick joystick;
    public float speed = 4;
    private Vector3 velocityVector = Vector3.zero; // Initial Velocity

    public float maxVelocityChange = 4f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Taking the joystick inputs
        float _xMovementInput = joystick.Horizontal;
        float _zMovementInput = joystick.Vertical;

        // Calculating velocity vectors
        Vector3 _movementHorizontanl = transform.right * _xMovementInput;
        Vector3 _movementVertical = transform.forward * _zMovementInput;

        // Calculate the final movement velocity vector
        Vector3 _movementVelocityVector = (_movementHorizontanl + _movementVertical).normalized * speed;

        //Apply Movement
        Move(_movementVelocityVector);
    }

    void Move(Vector3 movementVelocityVector)
    {
        velocityVector = movementVelocityVector;
    }

    private void FixedUpdate()
    {
        if ( velocityVector != Vector3.zero)
        {
            // Get rigifbod's currten velocity
            Vector3 velocity = rb.velocity;
            Vector3 velocityChange = (velocityVector - velocity);
            
            // Apply a force by the amount of velocity change to reach the target velocity
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0;

            rb.AddForce(velocityChange, ForceMode.Acceleration);
        }
    }


}
