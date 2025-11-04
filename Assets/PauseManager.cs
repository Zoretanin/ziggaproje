using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;

    public GameObject pausePanel;
    public Text musicStatusText; // Pause menüsünde "Music: ON/OFF" yazýsý

    void Start()
    {
        if (pausePanel != null)
            pausePanel.SetActive(false);

        UpdateMusicText();
    }

    public void TogglePause()
    {
        if (!isPaused)
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
            isPaused = true;
        }
        else
        {
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
            isPaused = false;
        }
    }

    //  Oyun içindeki music butonu
    public void ToggleMusicInGame()
    {
        MusicToggle mc = Object.FindAnyObjectByType<MusicToggle>();
        if (mc != null)
        {
            mc.ToggleMusic();
            UpdateMusicText();
        }
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    void UpdateMusicText()
    {
        if (musicStatusText != null)
        {
            bool enabled = PlayerPrefs.GetInt("MusicEnabled", 1) == 1;
            musicStatusText.text = enabled ? "Music: ON" : "Music: OFF";
        }
    }
}
