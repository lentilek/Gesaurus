using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.SmartFormat.Utilities;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public static Settings Instance;

    [SerializeField] private GameObject settingsUI;

    [SerializeField] private Slider sfxSlider;
    private float sfxVolume;
    [SerializeField] private Slider musicSlider;
    private float musicVolume;

    [SerializeField] private TMP_Dropdown lanDropdown;
    private int currentLanIndex = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(Instance.gameObject);
            Instance = this;
        }
        settingsUI.SetActive(false);
    }
    private void Start()
    {
        SetUp();
    }
    public void OpenSettings()
    {
        AudioManager.Instance.PlaySound("click");
        Time.timeScale = 0;

        SetUp();
        settingsUI.SetActive(true);
    }
    public void CloseSettings()
    {
        AudioManager.Instance.PlaySound("click");
        Time.timeScale = 1f;

        if (Pot.Instance != null)
        {
            Pot.Instance.ChangeLanguage();
        }
        settingsUI.SetActive(false);
    }
    private void SetUp()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadMusic();
        }
        else MusicVolume();
        if (PlayerPrefs.HasKey("sfxVolume"))
        {
            LoadVolume();
        }
        else SFXVolume();

        // Languages set up
        lanDropdown.ClearOptions();
        var lanOptions = new List<TMP_Dropdown.OptionData>();
        for (int i = 0; i < LocalizationSettings.AvailableLocales.Locales.Count; i++)
        {
            var locale = LocalizationSettings.AvailableLocales.Locales[i];
            if (LocalizationSettings.SelectedLocale == locale) currentLanIndex = i;
            lanOptions.Add(new TMP_Dropdown.OptionData(locale.name));
        }
        lanDropdown.AddOptions(lanOptions);
        lanDropdown.value = currentLanIndex;
        lanDropdown.onValueChanged.AddListener(SetLanguage);
        lanDropdown.RefreshShownValue();
    }
    static void SetLanguage(int languageIndex)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[languageIndex];
        /*if (Pot.Instance != null)
        {
            Pot.Instance.ChangeLanguage();
        }*/
    }
    public void SFXVolume()
    {
        sfxVolume = sfxSlider.value;
        AudioManager.Instance.volume = sfxVolume;
        PlayerPrefs.SetFloat("sfxVolume", sfxVolume);
    }
    public void MusicVolume()
    {
        musicVolume = musicSlider.value;
        if (MusicManager.Instance != null) MusicManager.Instance.audioSource.volume = musicVolume;
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
    }
    public void LoadMusic()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        MusicVolume();
    }
    public void LoadVolume()
    {
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        SFXVolume();
    }
    public void Hover()
    {
        AudioManager.Instance.PlaySound("hover");
    }
    public void Click()
    {
        AudioManager.Instance.PlaySound("click");
    }
}
