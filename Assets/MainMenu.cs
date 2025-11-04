using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text musicStatusText;
    public Text totalCoinsText;
    public Button agarthaButton;
    public Button buyAgarthaButton;

    private const int AGARTHA_COST = 50;

    void Start()
    {
        UpdateMusicText();
        UpdateTotalCoins();
        UpdateAgarthaButton();
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

    void UpdateAgarthaButton()
    {
        int unlocked = PlayerPrefs.GetInt("AgarthaUnlocked", 0);
        int coins = PlayerPrefs.GetInt("TotalCoins", 0);

        if (unlocked == 1)
        {
            agarthaButton.interactable = true;
            buyAgarthaButton.gameObject.SetActive(false);
        }
        else
        {
            agarthaButton.interactable = false;
            buyAgarthaButton.gameObject.SetActive(true);
            buyAgarthaButton.interactable = coins >= AGARTHA_COST;
        }
    }

    public void BuyAgartha()
    {
        int coins = PlayerPrefs.GetInt("TotalCoins", 0);
        if (coins >= AGARTHA_COST)
        {
            PlayerPrefs.SetInt("TotalCoins", coins - AGARTHA_COST);
            PlayerPrefs.SetInt("AgarthaUnlocked", 1);
            PlayerPrefs.Save();
            UpdateTotalCoins();
            UpdateAgarthaButton();
        }
    }

    public void GoToAgartha()
    {
        if (PlayerPrefs.GetInt("AgarthaUnlocked", 0) == 1)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
