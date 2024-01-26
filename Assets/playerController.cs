using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float health, speed, jumpPower;
    [SerializeField] Rigidbody2D rb;

    [HideInInspector]
    float horizontal;
    private void Awake()
    {
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    private void OnEnable()
    {
    }

    public void Move(InputAction.CallbackContext context)
    {
        Debug.Log("moving");
        horizontal = context.ReadValue<Vector2>().x;
    }
}
