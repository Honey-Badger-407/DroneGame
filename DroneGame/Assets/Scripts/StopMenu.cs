using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class StopMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public void onPause()
    {
        PauseGame();
    }

    public void OnContinue()
    {
        ResumeGame();
    }

    public void OnQuit()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("quit");
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
