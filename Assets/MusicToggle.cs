using UnityEngine;

public class MusicToggle : MonoBehaviour
{
    public AudioSource musicSource;
    private const string MUSIC_PREF = "MusicEnabled";

    private static MusicToggle instance;

    void Awake()
    {
        // Singleton: sahneler arasý müzik devam etsin
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        // Kaydedilmiþ müzik durumunu oku
        bool enabled = PlayerPrefs.GetInt(MUSIC_PREF, 1) == 1;

        if (enabled)
            musicSource.Play();
        else
            musicSource.Pause();
    }

    // Music toggle
    public void ToggleMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Pause();
            PlayerPrefs.SetInt(MUSIC_PREF, 0);
        }
        else
        {
            musicSource.Play();
            PlayerPrefs.SetInt(MUSIC_PREF, 1);
        }

        PlayerPrefs.Save();
    }
}
