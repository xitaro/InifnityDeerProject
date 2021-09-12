using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerMovement : MonoBehaviour
{
    InputHandler inputHandler;

    //Store the movement input
    Vector3 moveDirection;

    Transform cameraObject;

    // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    int floorMask;

    // The length of the ray from the camera into the scene.
    float camRayLength = 100f;          

    Rigidbody rb;

    [Header("Movement Speeds")]
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float rotationSpeed;

    private void Awake()
    {
        inputHandler = GetComponent<InputHandler>();
        rb = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;

        // Create a layer mask for the floor layer.
        floorMask = LayerMask.GetMask("Floor");
    }

    public void HandleAllMovement()
    {
        HandleMovement();

        // Turn the player to face the mouse cursor.
        HandleRotation();
    }

    private Vector3 HandleMovement()
    {
        // Reference the player's input in a Vector3
        Vector3 inputVector = new Vector3(inputHandler.horizontalInput,0,inputHandler.verticalInput);
        // Normalize it to be always 1
        inputVector.Normalize();
        // Calculate the camera angle, so it can move independently
        inputVector = Quaternion.Euler(0, cameraObject.eulerAngles.y, 0) * inputVector;

        Vector3 desiredPosition = transform.position + (inputVector * movementSpeed * Time.deltaTime); 
        rb.MovePosition(desiredPosition);
        return inputVector;
    }

    void HandleRotation()
    {
        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;

        // Perform the raycast and if it hits something on the floor layer...
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 playerToMouse = floorHit.point - transform.position;

            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            // Set the player's rotation to this new rotation.
            rb.MoveRotation(newRotation);
        }
    }
}
