using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private PlayerInput actions;
    private InputAction movementAction;
    private InputControl control;
    
    private enum PlayerMode
    {
        Keyboard,
        Gamepad
    }
    [SerializeField] private PlayerMode playerMode;
    private bool allowMove;

    [SerializeField] private float moveSpeed;
    private Vector3 direction = new Vector3(0f, 0f, 1f);

    void Awake()
    {
        actions = new PlayerInput();
        movementAction = actions.player.move;
        movementAction.performed += OnInput;
    }

    void OnEnable()
    {
        movementAction.Enable();
    }

    void OnDisable()
    {
        movementAction.Disable();
    }

    void Start()
    {
    }

    void Update()
    {
        if (allowMove)
        {
            OnMove();
        }
    }

    void OnMove()
    {
        direction = new Vector3(0f, 0f, 1f);
        float acceleration = movementAction.ReadValue<Vector2>().y;
        if (movementAction.ReadValue<Vector2>().x != 0)
        {
            direction = new Vector3(1f, 0f, 0f);
            acceleration = movementAction.ReadValue<Vector2>().x;
        }
        transform.Translate(direction * acceleration * moveSpeed * Time.deltaTime, Space.Self);
    }

    void OnInput(InputAction.CallbackContext context)
    {
        if (context.control.displayName.Length == 1) // WASD or character key input
        {
            if (playerMode == PlayerMode.Keyboard)
            {
                allowMove = true; // allow movement of this object if the inputted key matches this object's player mode.
            }
            else 
            {
                allowMove = false;
            }
        } 
        else // includes gamepad input and arrow keys
        {
            if (playerMode == PlayerMode.Gamepad)
            {
                allowMove = true;
            }
            else 
            {
                allowMove = false;
            }
        }
    }
}
