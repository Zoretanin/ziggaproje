using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public AudioSource musicSource;
    public Text buttonText;

    void Start()
    {
        // Daha önce ayar kaydedilmiþ mi diye kontrol et
        if (PlayerPrefs.GetInt("MusicEnabled", 1) == 1)
        {
            musicSource.Play();
            buttonText.text = "Mute Music";
        }
        else
        {
            musicSource.Pause();
            buttonText.text = "Play Music";
        }
    }

    public void ToggleMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Pause();
            buttonText.text = "Play Music";
            PlayerPrefs.SetInt("MusicEnabled", 0); // Kapalý kaydet
        }
        else
        {
            musicSource.Play();
            buttonText.text = "Mute Music";
            PlayerPrefs.SetInt("MusicEnabled", 1); // Açýk kaydet
        }
    }


    void Awake()
    {
        DontDestroyOnLoad(buttonText);
    }




}
    

