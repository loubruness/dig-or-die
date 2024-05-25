using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class PlayerManager : MonoBehaviour
{
    public GameObject playerPrefab; // Assign the player prefab in the Inspector
    public Transform[] spawnPoints; // Assign spawn points in the Inspector

    private void Start()
    {
        PlayerInputManager.instance.onPlayerJoined += OnPlayerJoined;
    }



    private void OnDisable()
    {
        PlayerInputManager.instance.onPlayerJoined -= OnPlayerJoined;
    }

    private void OnPlayerJoined(PlayerInput playerInput)
    {
        int playerIndex = playerInput.playerIndex;

        // Assign spawn point based on player index
        playerInput.transform.position  = spawnPoints[playerIndex].position;
        playerInput.GetComponent<CharacterController>().enabled = true;

        // Set up the camera for split-screen
        Camera playerCamera = playerInput.GetComponentInChildren<Camera>();

        if (playerIndex == 0)
        {
            playerCamera.rect = new Rect(0, 0, 0.5f, 1);
        }
        else if (playerIndex == 1)
        {
            playerCamera.rect = new Rect(0.5f, 0, 0.5f, 1);
        }

        // Additional setup for the player (e.g., setting player-specific properties)
        playerInput.gameObject.name = "Player" + (playerIndex + 1);
    }
}