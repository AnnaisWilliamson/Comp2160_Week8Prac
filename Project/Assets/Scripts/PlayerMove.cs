using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private PlayerInput actions;
    private InputAction movementAction;

    [SerializeField] private float moveSpeed;
    private Vector3 direction = new Vector3(0f, 0f, 1f);

    void Awake()
    {
        actions = new PlayerInput();
        movementAction = actions.Walking.Movement;
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
        direction = new Vector3(0f, 0f, 1f);
        float acceleration = movementAction.ReadValue<Vector2>().y;
        if (movementAction.ReadValue<Vector2>().x != 0)
        {
            direction = new Vector3(1f, 0f, 0f);
            acceleration = movementAction.ReadValue<Vector2>().x;
        }
        transform.Translate(direction * acceleration * moveSpeed * Time.deltaTime, Space.Self);
    }
}
