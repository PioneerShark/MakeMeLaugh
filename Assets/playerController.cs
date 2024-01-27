using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float health, speed;
    [HideInInspector]
    PlayerMovement playerInput;
    InputAction movement1;
    Transform transform;
    private void Awake()
    {
        playerInput = new PlayerMovement();
        movement1 = playerInput.Movement1.LeftRight;
    }
    void Start()
    {
        playerInput.Movement1.Enable();
                
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
    }

    private void Movement1(InputValue value)
    {
        transform.Translate(value.Get<Vector2>(), 0);
    }
}
