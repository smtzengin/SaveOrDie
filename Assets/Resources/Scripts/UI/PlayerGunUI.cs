using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGunUI : MonoBehaviour
{
    [Header("Player Rifle Gun Components")]
    [SerializeField] private Image rifleBackground;
    [SerializeField] private TextMeshProUGUI rifleNameText;
    [SerializeField] private Image rifleImage;
    [SerializeField] private TextMeshProUGUI rifleClipCountText;

    [Header("Player Pistol Gun Components")]
    [SerializeField] private Image pistolBackground;
    [SerializeField] private TextMeshProUGUI pistolNameText;
    [SerializeField] private Image pistolImage;
    [SerializeField] private TextMeshProUGUI pistolClipCountText;

    [SerializeField] private PlayerGunHolder playerGunHolder;
    [SerializeField] private PlayerShooting playerShooting;

    private Rifle pickedRifle;
    private Pistol pickedPistol;
    private void Awake()
    {
        ResetGunElements();
        
    }
    private void Start()
    {
        playerGunHolder.OnPlayerPickUpGun += PlayerGunHolder_OnPlayerPickUpGun;
        playerGunHolder.OnPlayerGunChanged += PlayerGunHolder_OnPlayerGunChanged;
        playerShooting.OnPlayerShooting += PlayerShooting_OnPlayerShooting;
    }

    private void PlayerShooting_OnPlayerShooting(IGun shootingGun)
    {
        switch (shootingGun)
        {
            case Rifle rifle:
                pickedRifle = rifle;
                rifleNameText.text = pickedRifle.GunName;
                rifleImage.sprite = pickedRifle.GunSprite;
                rifleClipCountText.text = $"{pickedRifle.ClipCount} / {pickedRifle.MaxClipCount}";
                break;
            case Pistol pistol:
                pickedPistol = pistol;
                pistolNameText.text = pickedPistol.GunName;
                pistolImage.sprite = pickedPistol.GunSprite;
                pistolClipCountText.text = $"{pickedPistol.ClipCount} / {pickedPistol.MaxClipCount}";
                break;
        }
    }

    private void PlayerGunHolder_OnPlayerGunChanged(IGun changedGun)
    {
        switch (changedGun)
        {
            case Rifle:
                rifleBackground.color = Color.green;
                pistolBackground.color = Color.red;
                break;
            case Pistol:
                rifleBackground.color = Color.red;
                pistolBackground.color = Color.green;
                break;
            default:
                rifleBackground.color = Color.white;
                pistolBackground.color = Color.white;
                break;
        }
    }

    private void PlayerGunHolder_OnPlayerPickUpGun(IGun pickedGun)
    {
        switch (pickedGun)
        {
            case Rifle rifle:
                pickedRifle = rifle;
                rifleNameText.text = pickedRifle.GunName;
                rifleImage.sprite = pickedRifle.GunSprite;
                rifleClipCountText.text = $"{pickedRifle.ClipCount} / {pickedRifle.MaxClipCount}";
                break;
            case Pistol pistol:
                pickedPistol = pistol;
                pistolNameText.text = pickedPistol.GunName;
                pistolImage.sprite = pickedPistol.GunSprite;
                pistolClipCountText.text = $"{pickedPistol.ClipCount} / {pickedPistol.MaxClipCount}";
                break;
        }
    }

    private void ResetGunElements()
    {
        rifleImage.sprite = null;
        rifleNameText.text = string.Empty;
        rifleClipCountText.text = string.Empty;

        pistolImage.sprite = null;
        pistolNameText.text = string.Empty;
        pistolClipCountText.text = string.Empty;
    }
}
