using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGunHolder : MonoBehaviour
{
    public Transform gunTransform;
    public TextMeshProUGUI pickUpText;
    public LayerMask gunLayerMask;
    public float pickUpRange = 2f;

    private IGun primaryGun;
    private IGun secondaryGun;
    private Camera playerCamera;

    [SerializeField] public GameObject playerPrimaryGun;
    [SerializeField] public GameObject playerSecondaryGun;

    public event Action<IGun> OnPlayerPickUpGun;
    public event Action<IGun> OnPlayerGunChanged;

    void Start()
    {
        playerCamera = Camera.main;
        pickUpText.gameObject.SetActive(false);
    }

    void Update()
    {
        CheckForGunPickUp();
        CheckForGunSwitch();
    }

    private void CheckForGunPickUp()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, pickUpRange, gunLayerMask))
        {
            var gunComponent = hit.transform.GetComponent<IGun>();
            if (gunComponent != null)
            {
                string gunName = GetGunName(gunComponent);
                pickUpText.text = $"Yerden {gunName} silahını E tuşuna basarak alabilirsiniz";
                pickUpText.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    PickUpGun(gunComponent, hit.transform.gameObject);
                }
            }
        }
        else
        {
            pickUpText.gameObject.SetActive(false);
        }
    }

    private void CheckForGunSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeGun(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeGun(2);
        }
    }

    private void ChangeGun(int gunNumber)
    {
        if (gunNumber == 1 && playerPrimaryGun != null)
        {
            playerPrimaryGun.SetActive(true);
            if (playerSecondaryGun != null)
            {
                playerSecondaryGun.SetActive(false);
            }
            OnPlayerGunChanged?.Invoke(primaryGun);
        }
        else if (gunNumber == 2 && playerSecondaryGun != null)
        {
            playerSecondaryGun.SetActive(true);
            if (playerPrimaryGun != null)
            {
                playerPrimaryGun.SetActive(false);
            }
            OnPlayerGunChanged?.Invoke(secondaryGun);
        }
    }

    private void PickUpGun(IGun gun, GameObject pickedGun)
    {
        if (gun is Rifle rifle)
        {
            if (primaryGun != null)
            {
                Destroy(playerPrimaryGun);
            }
            primaryGun = gun;
            if(playerPrimaryGun == null)
            {
                playerPrimaryGun = Instantiate(rifle.GunSO.Gun, gunTransform);
                if(playerSecondaryGun != null && !playerSecondaryGun.activeSelf)
                    playerPrimaryGun.SetActive(true);
                OnPlayerPickUpGun?.Invoke(primaryGun);
            }
        }
        else if (gun is Pistol pistol)
        {
            if (secondaryGun != null)
            {
                Destroy(playerSecondaryGun);
            }
            secondaryGun = gun;
            if(playerSecondaryGun == null)
            {
                playerSecondaryGun = Instantiate(pistol.GunSO.Gun, gunTransform);
                if (playerPrimaryGun != null && !playerPrimaryGun.activeSelf)
                    playerSecondaryGun.SetActive(true);
                OnPlayerPickUpGun?.Invoke(secondaryGun);
            }
        }

        Destroy(pickedGun);
    }

    private string GetGunName(IGun gun)
    {
        if (gun is Pistol pistol)
        {
            return pistol.GunName;
        }
        else if (gun is Rifle rifle)
        {
            return rifle.GunName;
        }
        return "Unknown Gun";
    }

    public int GetCurrentGun()
    {
        if (playerPrimaryGun != null && playerPrimaryGun.activeSelf)
        {
            return 1;
        }
        if (playerSecondaryGun != null && playerSecondaryGun.activeSelf)
        {
            return 2;
        }
        return 0;
    }

}
