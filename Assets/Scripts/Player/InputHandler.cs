using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    PlayerControls playerControls;
    AnimatorManager animManager;

    //Store the movement input
    Vector2 movementInput;

    private float moveAmount;
    //Split into vertical and horizontal
    public float verticalInput;
    public float horizontalInput;

    public bool shootInput;

    private void Awake()
    {
        animManager = GetComponentInChildren<AnimatorManager>();
    }

    //When the game object that this script is attached is enable
    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();
            //When we hit WASD or move LeftStick, we record the movement to the PlayerMovement 
            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
        }
        playerControls.Enable();
    }

    //When the game object that this script is attached is disable
    private void OnDisable()
    {
        //We disable playerControls
        playerControls.Disable();
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();
        HandleShootInput();
    }


    //Split the Moviment Input (Vector2) in two variables
    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
        //Clamp01 = Clamps between values of 0 and 1
        //Abs = Absolute value / if horizontal or vertical is negative, make it positive
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animManager.UpdateAnimatorValues(0, moveAmount);
    }

    private void HandleShootInput()
    {
        playerControls.PlayerActions.Shoot.performed += i => shootInput = true;
        if (shootInput)
        {
            shootInput = false;
            //shootInput.HandleShoot();
        }
    }

    //Handle Jump Input

    //etc
}
