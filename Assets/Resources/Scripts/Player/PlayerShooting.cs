using System;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Camera playerCamera;
    private PlayerGunHolder playerGunHolder;
    public event Action<IGun> OnPlayerShooting;
    public GameObject bulletPrefab;
    private PlayerAnimator playerAnimator;
    private AudioSource audioSource;

    private void Start()
    {
        playerGunHolder = GetComponent<PlayerGunHolder>();
        playerAnimator = GetComponent<PlayerAnimator>();
        audioSource = GetComponent<AudioSource>();

        AudioManager.instance.SubscribeAudioSource(audioSource, "Player");
    }

    private void Update()
    {
        if (playerGunHolder.playerPrimaryGun == null || playerGunHolder.playerSecondaryGun == null)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    private void Shoot()
    { 
        int currentGun = playerGunHolder.GetCurrentGun();

        switch (currentGun)
        {
            case 0:
                break;
            case 1:
                var rifle = playerGunHolder.playerPrimaryGun.GetComponent<Rifle>();
                if (rifle.ClipCount > 0)
                {
                    playerAnimator.ChangeState(new ShootState());
                    Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                    RaycastHit hit;
                    Vector3 targetPoint;

                    if (Physics.Raycast(ray, out hit))
                    {
                        targetPoint = hit.point;
                    }
                    else
                    {
                        targetPoint = ray.GetPoint(100); // Merminin ulaşacağı varsayılan nokta
                    }

                    Vector3 direction = (targetPoint - playerCamera.transform.position).normalized;
                    GameObject bullet = Instantiate(bulletPrefab, playerCamera.transform.position, Quaternion.identity);
                    bullet.transform.forward = direction;
                    bullet.GetComponent<Bullet>().Initialize(rifle.BodyDamage);

                    rifle.Shoot();
                    AudioManager.instance.PlayAudioClip(audioSource, "Ak");
                    OnPlayerShooting?.Invoke(rifle);
                }
                break;
            case 2:
                var pistol = playerGunHolder.playerSecondaryGun.GetComponent<Pistol>();
                if (pistol.ClipCount > 0)
                {
                    playerAnimator.ChangeState(new ShootState());
                    Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                    RaycastHit hit;
                    Vector3 targetPoint;

                    if (Physics.Raycast(ray, out hit))
                    {
                        targetPoint = hit.point;
                    }
                    else
                    {
                        targetPoint = ray.GetPoint(100); // Merminin ulaşacağı varsayılan nokta
                    }

                    Vector3 direction = (targetPoint - playerCamera.transform.position).normalized;
                    GameObject bullet = Instantiate(bulletPrefab, playerCamera.transform.position, Quaternion.identity);
                    bullet.transform.forward = direction;
                    bullet.GetComponent<Bullet>().Initialize(pistol.BodyDamage);

                    pistol.Shoot();
                    AudioManager.instance.PlayAudioClip(audioSource, "Pistol");
                    OnPlayerShooting?.Invoke(pistol);
                }
                break;
        }
    }

    private void Reload()
    {
        int currentGun = playerGunHolder.GetCurrentGun();

        switch (currentGun)
        {
            case 0:
                break;
            case 1:
                var rifle = playerGunHolder.playerPrimaryGun.GetComponent<Rifle>();
                rifle.ReloadBullet();
                OnPlayerShooting?.Invoke(rifle);
                break;
            case 2:
                var pistol = playerGunHolder.playerSecondaryGun.GetComponent<Pistol>();
                pistol.ReloadBullet();
                OnPlayerShooting?.Invoke(pistol);
                break;
        }
    }
}
