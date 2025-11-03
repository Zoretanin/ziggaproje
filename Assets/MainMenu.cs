using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text musicStatusText; // Music durumu gösterecek UI Text

    void Start()
    {
        UpdateMusicText();
    }

    // Start Game butonuna basýnca
    public void StartGame()
    {
        SceneManager.LoadScene(1); // Build Settings'de GameScene index 1
    }

    // Music Toggle butonuna basýnca
    public void ToggleMusic()
    {
        MusicToggle mc = FindObjectOfType<MusicToggle>();
        if (mc != null)
        {
            mc.ToggleMusic();
            UpdateMusicText();
        }
    }

    // Music butonunun yanýndaki texti güncelle
    void UpdateMusicText()
    {
        bool enabled = PlayerPrefs.GetInt("MusicEnabled", 1) == 1;
        if (musicStatusText != null)
            musicStatusText.text = enabled ? "Music: ON" : "Music: OFF";
    }

    // Quit butonuna basýnca
    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
