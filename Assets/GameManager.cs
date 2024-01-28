using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public enum gameState { lobby, starting, inProgress, gameEnd }

public class GameManager : MonoBehaviour
{
    // UI References
    public Canvas lobbyCanvas;
    public Canvas countdownCanvas;
    public Canvas inProgressCanvas;
    public Canvas gameOverCanvas;

    // Players
    public GameObject player1;
    public GameObject player2;

    // Player variables
    public float player1_health;
    public float player2_health;

    // Game state
    public gameState currentGameState;

    private bool settingsApplied;

    // Positions
    private Vector2 player1_lobby;
    private Vector2 player2_lobby;
    private Vector2 player1_map1;
    private Vector2 player2_map1;

    // References to the scripts
    //private PlayerManager playerManager;
    private playerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        settingsApplied = false;
        currentGameState = gameState.lobby;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentGameState == gameState.lobby && settingsApplied == false)
        {
            player1.transform.position = player1_lobby;
            player2.transform.position = player2_lobby;
            lobbyCanvas.enabled = true;
            settingsApplied = true;
        }

        if (currentGameState == gameState.starting && settingsApplied == false)
        {
            player1.transform.position = player1_map1;
            player2.transform.position = player2_map1;
            lobbyCanvas.enabled = false;
            settingsApplied = true;
            currentGameState = gameState.inProgress;
        }

        if ((player1_health < 0 || player2_health < 0) && currentGameState == gameState.inProgress)
        {
            currentGameState = gameState.gameEnd;
        }

        if (currentGameState == gameState.gameEnd)
        {
            gameOverCanvas.enabled = true;
        }
    }

    public void playPressed()
    {
        if (currentGameState == gameState.lobby)
        {
            settingsApplied = false;
            currentGameState = gameState.starting;
        }
    }

    public void backToLobbyPressed()
    {
        if (currentGameState == gameState.gameEnd)
        {
            settingsApplied = false;
            currentGameState = gameState.lobby;
        }
    }
}
