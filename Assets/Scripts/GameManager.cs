using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject gameStartScreen;
    [SerializeField] private PlayerController playerController;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void StartGame()
    {
        gameStartScreen.SetActive(false);
        playerController.StartRunning();
    }
}
