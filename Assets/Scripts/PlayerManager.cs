using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

class ActionHandler
{
    public void Jump(GameObject player, InputAction.CallbackContext value)
    {
        playerController controller = player.GetComponent<playerController>();
        controller.Jump(value);
    }

    public void UpdateMoveVector(GameObject player, Vector2 moveVector2)
    {
        playerController controller = player.GetComponent<playerController>();
        controller.Move(moveVector2);
    }
}

public class PlayerManager : MonoBehaviour
{
    private MultiplayerInputAction multiplayerInput;
    private ActionHandler actionHandler = new ActionHandler();

    [Header("Players")]
    [SerializeField] public GameObject player1;
    [SerializeField] public GameObject player2;

    [Header("Scripts")]
    [SerializeField] public GameObject collisionDetector;
    [SerializeField] public GameObject playerController;

    private void Awake() 
    {
        multiplayerInput = new MultiplayerInputAction();
    }

    private void OnEnable() 
    {
        multiplayerInput.Enable();
        multiplayerInput.Player1.Jump.performed += value => actionHandler.Jump(player1, value); // The idea is to pass the player1 object
        multiplayerInput.Player2.Jump.performed += value => actionHandler.Jump(player2, value); // The idea is to pass the player2 object
    }

    private void OnDisable()
    {
        multiplayerInput.Disable();
    }

    private void Update()
    {
        // pass player1 and player2 to collisionDetector
        actionHandler.UpdateMoveVector(player1, multiplayerInput.Player1.Movement.ReadValue<Vector2>());
        actionHandler.UpdateMoveVector(player2, multiplayerInput.Player2.Movement.ReadValue<Vector2>());
        //Debug.Log("Player 1: " + multiplayerInput.Player1.Movement.ReadValue<Vector2>());
        //Debug.Log("Player 2: " + multiplayerInput.Player2.Movement.ReadValue<Vector2>());
    }
}

