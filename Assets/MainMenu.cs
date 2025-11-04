using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text musicStatusText;
    public Text totalCoinsText; 

    void Start()
    {
        UpdateMusicText();
        UpdateTotalCoins(); 
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ToggleMusic()
    {
        MusicToggle mc = Object.FindFirstObjectByType<MusicToggle>();
        if (mc != null)
        {
            mc.ToggleMusic();
            UpdateMusicText();
        }
    }

    void UpdateMusicText()
    {
        bool enabled = PlayerPrefs.GetInt("MusicEnabled", 1) == 1;
        if (musicStatusText != null)
            musicStatusText.text = enabled ? "ON" : "OFF";
    }

    void UpdateTotalCoins()
    {
        int coins = PlayerPrefs.GetInt("TotalCoins", 0);
        if (totalCoinsText != null)
            totalCoinsText.text = ":" + coins;
    }

    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
