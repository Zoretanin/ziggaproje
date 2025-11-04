using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;

    public GameObject pausePanel; // Pause menüsü paneli

    void Start()
    {
        if (pausePanel != null)
            pausePanel.SetActive(false);
    }

    public void TogglePause()
    {
        if (!isPaused)
        {
            Time.timeScale = 0f;        // Oyun durur
            pausePanel.SetActive(true); // Panel görünür
            isPaused = true;
        }
        else
        {
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
            isPaused = false;
        }
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f; // Menüye dönmeden önce oyunu tekrar çalýþtýr
        SceneManager.LoadScene(0); // Build index 0 = MainMenu
    }
}
