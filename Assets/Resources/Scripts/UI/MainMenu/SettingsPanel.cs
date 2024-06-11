using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider VFXSlider;
    [SerializeField] private Slider sensitivitySlider;
    [SerializeField] private Dropdown graphicDropdown;

    [SerializeField] private TextMeshProUGUI musicPercentageText;
    [SerializeField] private TextMeshProUGUI VFXPercentageText;
    private const string SensitivityPrefKey = "Sensitivity";

    private void Start()
    {
        
        if(!PlayerPrefs.HasKey(SensitivityPrefKey))
        {
            PlayerPrefs.SetFloat(SensitivityPrefKey, 0.5f);
        }

        musicSlider.onValueChanged.AddListener(OnMusicSliderValueChanged);
        VFXSlider.onValueChanged.AddListener(OnVFXSliderValueChanged);
        sensitivitySlider.onValueChanged.AddListener(OnSensitivitySliderValueChanged);


        musicSlider.value = AudioManager.instance.MainMenuAudioSource.volume;
        VFXSlider.value = AudioManager.instance.PlayerAudioSource != null ? AudioManager.instance.PlayerAudioSource.volume : 1.0f;

        float savedSensitivity = PlayerPrefs.GetFloat(SensitivityPrefKey); 
        sensitivitySlider.value = savedSensitivity;

        UpdatePercentageTexts();

        
        PopulateGraphicsDropdown();
        graphicDropdown.onValueChanged.AddListener(OnGraphicsDropdownValueChanged);
        graphicDropdown.value = QualitySettings.GetQualityLevel();
        graphicDropdown.RefreshShownValue();
    }

    private void OnMusicSliderValueChanged(float value)
    {
        AudioManager.instance.SetVolume(value, VFXSlider.value);
        UpdatePercentageTexts();
    }

    private void OnVFXSliderValueChanged(float value)
    {
        AudioManager.instance.SetVolume(musicSlider.value, value);
        UpdatePercentageTexts();
    }

    private void OnGraphicsDropdownValueChanged(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

    private void UpdatePercentageTexts()
    {
        musicPercentageText.text = $"{(int)(musicSlider.value * 100)}%";
        VFXPercentageText.text = $"{(int)(VFXSlider.value * 100)}%";
    }

    private void PopulateGraphicsDropdown()
    {
        graphicDropdown.ClearOptions();
        List<string> options = new List<string>();

        foreach (string qualityName in QualitySettings.names)
        {
            options.Add(qualityName);
        }

        graphicDropdown.AddOptions(options);
    }

    private void OnSensitivitySliderValueChanged(float value)
    {

        
        PlayerPrefs.SetFloat(SensitivityPrefKey, value * 1000);
        PlayerPrefs.Save();

        // Update the sensitivity text
        UpdatePercentageTexts();
    }
}
