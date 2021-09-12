using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    [SerializeField] private GameObject gameOverPanel;

    public void GameOver()
    {
        PauseGame();
        gameOverPanel.SetActive(true);
    }

    private void PauseGame()
    {
        Time.timeScale = 0.01f;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    public void LoadScene(int sceneIndex)
    {
        ResumeGame();
        SceneManager.LoadScene(sceneIndex);
    }
}

