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

    public GameObject player1Text;
    public GameObject player2Text;

    // Players
    public GameObject player1;
    public GameObject player2;
    [SerializeField] GameObject startingWeapon;

    // Game state
    public gameState currentGameState;

    private bool settingsApplied;

    // Cameras
    public GameObject gameCam;

    // Positions
    private Vector2 player1_lobby = new Vector2(25, -7);
    private Vector2 player2_lobby = new Vector2(34, -7);
    private Vector2 player1_map1 = new Vector2(-16, -3);
    private Vector2 player2_map1 = new Vector2(16, -3);

    private Vector3 lobbyCamPos = new Vector3(30f, -5f, -10f);
    private Vector3 lobbyCamScale = new Vector3(1f, 1f, 1f);
    private float lobbyCamSize = 5;

    private Vector3 gameCamPos = new Vector3(0, 0, -10f);
    private Vector3 gameCamScale = new Vector3(1.925f, 1f, 1f);
    private float gameCamSize = 10;

    // References to the scripts
    private playerController playerController1;
    private playerController playerController2;

    // Start is called before the first frame update
    void Start()
    {
        gameCam.transform.position = lobbyCamPos;
        gameCam.transform.localScale = lobbyCamScale;
        gameCam.GetComponent<Camera>().orthographicSize = lobbyCamSize;

        playerController1 = player1.GetComponent<playerController>();
        playerController2 = player2.GetComponent<playerController>();

        AudioManager.Instance.PlayOST("Clown's Respite");
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
            settingsApplied = true;
        }

        if (currentGameState == gameState.starting && settingsApplied == false)
        {
            player1.transform.position = player1_map1;
            player2.transform.position = player2_map1;
            settingsApplied = true;
            currentGameState = gameState.inProgress;
        }

        if ((playerController1.health < 0) && currentGameState == gameState.inProgress)
        {
            player1Text.transform.gameObject.SetActive(false);
            player2Text.transform.gameObject.SetActive(true);
            currentGameState = gameState.gameEnd;
        }

        if ((playerController2.health < 0) && currentGameState == gameState.inProgress)
        {
            player1Text.transform.gameObject.SetActive(true);
            player2Text.transform.gameObject.SetActive(false);
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
            AudioManager.Instance.PlayOST("Give Them a Show");
            settingsApplied = false;
            playerController1.health = 100;
            playerController2.health = 100;
            gameCam.transform.position = gameCamPos;
            gameCam.transform.localScale = gameCamScale;
            playerController1.Equip(startingWeapon);
            playerController2.Equip(startingWeapon);
            gameCam.GetComponent<Camera>().orthographicSize = gameCamSize;
            lobbyCanvas.enabled = false;
            currentGameState = gameState.starting;
        }
    }

    public void backToLobbyPressed()
    {
        if (currentGameState == gameState.gameEnd)
        {
            AudioManager.Instance.PlayOST("Clown's Respite");
            playerController1.Unequip();
            playerController2.Unequip();
            settingsApplied = false;
            gameCam.transform.position = lobbyCamPos;
            gameCam.transform.localScale = lobbyCamScale;
            gameCam.GetComponent<Camera>().orthographicSize = lobbyCamSize;
            gameOverCanvas.enabled = false;
            lobbyCanvas.enabled = true;
            currentGameState = gameState.lobby;
        }
    }
}
