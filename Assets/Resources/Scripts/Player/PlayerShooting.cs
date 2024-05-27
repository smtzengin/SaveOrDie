using System;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    private PlayerGunHolder playerGunHolder;
    public event Action<IGun> OnPlayerShooting;
    public GameObject bulletPrefab;
    private PlayerAnimator playerAnimator;

    private void Start()
    {
        playerGunHolder = GetComponent<PlayerGunHolder>();
        playerAnimator = GetComponent<PlayerAnimator>();
    }

    private void Update()
    {
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
        playerAnimator.ChangeState(new ShootState());

        int currentGun = playerGunHolder.GetCurrentGun();

        switch(currentGun)
        {
            case 0:
                break;
            case 1:
                var rifle = playerGunHolder.playerPrimaryGun.GetComponent<Rifle>();
                if(rifle.ClipCount > 0)
                {
                    GameObject bullet = Instantiate(bulletPrefab,firePoint.position,Quaternion.identity);
                    bullet.transform.position = firePoint.position;
                    bullet.transform.rotation = firePoint.rotation;
                    bullet.GetComponent<Bullet>().Initialize(rifle.BodyDamage);
                    rifle.Shoot();
                    OnPlayerShooting?.Invoke(rifle);
                }
                break;
            case 2:
                var pistol = playerGunHolder.playerSecondaryGun.GetComponent<Pistol>();
                if(pistol.ClipCount > 0)
                {
                    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
                    bullet.transform.position = firePoint.position;
                    bullet.transform.rotation = firePoint.rotation;
                    bullet.GetComponent<Bullet>().Initialize(pistol.BodyDamage);

                    pistol.Shoot();
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
