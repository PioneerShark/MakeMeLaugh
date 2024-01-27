using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

class ActionHandler
{
    public void Jump(String player, InputAction.CallbackContext value)
    {
        Debug.Log(player + ": MAKE ME JUMP");
    }

    public void UpdateMoveVector(String player, Vector2 moveVector2)
    {
        // Debug.Log(player + ": UPDATE MY MOVEVECTOR");
    }
}

public class PlayerManager : MonoBehaviour
{
    private MultiplayerInputAction multiplayerInput;
    private ActionHandler actionHandler = new ActionHandler();
    [SerializeField] public GameObject collisionDetector;
    [SerializeField] public MonoBehaviour player1;
    [SerializeField] public MonoBehaviour player2;

    private void Awake() 
    {
        multiplayerInput = new MultiplayerInputAction();
    }

    private void OnEnable() 
    {
        multiplayerInput.Enable();
        multiplayerInput.Player1.Jump.performed += value => actionHandler.Jump("Player 1", value); // The idea is to pass the player1 object
        multiplayerInput.Player2.Jump.performed += value => actionHandler.Jump("Player 2", value); // The idea is to pass the player2 object
    }

    private void OnDisable()
    {
        multiplayerInput.Disable();
    }

    private void Update()
    {
        // pass player1 and player2 to collisionDetector
        actionHandler.UpdateMoveVector("Player 1", multiplayerInput.Player1.Movement.ReadValue<Vector2>());
        actionHandler.UpdateMoveVector("Player 2", multiplayerInput.Player2.Movement.ReadValue<Vector2>());
        //Debug.Log("Player 1: " + multiplayerInput.Player1.Movement.ReadValue<Vector2>());
        //Debug.Log("Player 2: " + multiplayerInput.Player2.Movement.ReadValue<Vector2>());
    }
}

