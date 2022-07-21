using RespawnSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CameraManager cameraManager;
    [SerializeField] private RespawnPointManager spawnPointManager;
    [SerializeField] private Agent player;
    private LevelManagement sceneManager;

    private void Awake()
    {
        if (cameraManager == null)
            cameraManager = GameObject.FindObjectOfType<CameraManager>();
        if (spawnPointManager == null)
            spawnPointManager = GameObject.FindObjectOfType<RespawnPointManager>();
        if (player == null)
            player = GameObject.FindObjectOfType<PlayerInput>().GetComponentInChildren<Agent>();
        sceneManager = GameObject.FindObjectOfType<LevelManagement>();
    }

    private void Start()
    {
        player.gameObject.SetActive(false);
        spawnPointManager.Respawn(player.gameObject);
        cameraManager.SetCameraTarget(player.transform);
    }
}
