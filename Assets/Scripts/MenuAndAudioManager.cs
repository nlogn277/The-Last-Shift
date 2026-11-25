using UnityEngine;
using UnityEngine.UI;

public class MenuAndAudioManager : MonoBehaviour
{
    [Header("Menu Panels")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject audioPanel;
    [SerializeField] private GameObject keybindsPanel;

    [Header("Audio Controls")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Toggle muteToggle;

    private float savedVolume = 1f;
    private bool openedFromPause = false;

    private void Start()
    {
        ShowMainMenu();

        if (musicSource != null)
        {
            savedVolume = musicSource.volume;
            if (volumeSlider != null) volumeSlider.value = savedVolume;
            if (muteToggle != null) muteToggle.isOn = musicSource.mute;
        }
    }

    // --- Screen Navigation ---
    public void ShowMainMenu()
    {
        openedFromPause = false;
        mainMenuPanel.SetActive(true);
        if (pausePanel != null) pausePanel.SetActive(false);
        optionsPanel.SetActive(false);
        audioPanel.SetActive(false);
        keybindsPanel.SetActive(false);
    }

    // Call this from the Main Menu's Options button
    public void ShowOptionsFromMainMenu()
    {
        openedFromPause = false;
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);
        audioPanel.SetActive(false);
        keybindsPanel.SetActive(false);
    }

    // Call this from the Pause Menu's Options button
    public void ShowOptionsFromPause()
    {
        openedFromPause = true;
        if (pausePanel != null) pausePanel.SetActive(false);
        optionsPanel.SetActive(true);
        audioPanel.SetActive(false);
        keybindsPanel.SetActive(false);
    }

    // Call this from OptionsPanel's Back button
    public void BackFromOptions()
    {
        optionsPanel.SetActive(false);
        if (openedFromPause)
        {
            if (pausePanel != null) pausePanel.SetActive(true);
        }
        else
        {
            mainMenuPanel.SetActive(true);
        }
    }

    public void ShowAudio()
    {
        optionsPanel.SetActive(false);
        audioPanel.SetActive(true);
    }

    public void ShowKeybinds()
    {
        optionsPanel.SetActive(false);
        keybindsPanel.SetActive(true);
    }

    // --- Audio Controls ---
    public void SetVolume(float value)
    {
        if (musicSource == null) return;

        musicSource.volume = value;
        if (value > 0f)
        {
            savedVolume = value;
            musicSource.mute = false;
            if (muteToggle != null) muteToggle.SetIsOnWithoutNotify(false);
        }
        else
        {
            musicSource.mute = true;
            if (muteToggle != null) muteToggle.SetIsOnWithoutNotify(true);
        }
    }

    public void ToggleMute(bool isMuted)
    {
        if (musicSource == null) return;

        musicSource.mute = isMuted;
        if (volumeSlider != null)
        {
            volumeSlider.SetValueWithoutNotify(isMuted ? 0f : savedVolume);
        }
    }


}