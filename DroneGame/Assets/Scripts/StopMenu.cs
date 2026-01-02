using UnityEngine;
using UnityEngine.SceneManagement;

public class StopMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject DeathMenuUI;
    bool isPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }
    public void OnQuit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void OnDeath()
    {
        DeathMenuUI.SetActive(true);
    }
    public void OnRetry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("HoopsGame");
    }
    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
