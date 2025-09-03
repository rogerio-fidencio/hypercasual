using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject gameStartScreen;
    [SerializeField] private PlayerController playerController;

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
