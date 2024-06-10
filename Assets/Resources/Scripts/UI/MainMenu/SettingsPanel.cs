using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider VFXSlider;
    [SerializeField] private Dropdown graphicDropdown;

    [SerializeField] private TextMeshProUGUI musicPercentageText;
    [SerializeField] private TextMeshProUGUI VFXPercentageText;

    private void Start()
    {
        musicSlider.onValueChanged.AddListener(OnMusicSliderValueChanged);
        VFXSlider.onValueChanged.AddListener(OnVFXSliderValueChanged);

        musicSlider.value = AudioManager.instance.MainMenuAudioSource.volume;
        VFXSlider.value = AudioManager.instance.PlayerAudioSource != null ? AudioManager.instance.PlayerAudioSource.volume : 1.0f;

        UpdatePercentageTexts();
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

    private void UpdatePercentageTexts()
    {
        musicPercentageText.text = $"{(int)(musicSlider.value * 100)}%";
        VFXPercentageText.text = $"{(int)(VFXSlider.value * 100)}%";
    }

    
}
