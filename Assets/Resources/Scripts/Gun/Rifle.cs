using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour, IGun
{
    public GunSO GunSO;
    public Sprite GunSprite;
    public string GunName;
    public int ClipCount; 
    public int MaxClipCount; 
    public int SpareBullets; 
    public int BodyDamage;
    public int HeadDamage;
    public GameObject ParticleEffect;

    private void Awake()
    {
        SetupGun();
    }


    public void SetupGun()
    {
        GunName = GunSO.GunName;
        GunSprite = GunSO.Sprite;
        ClipCount = GunSO.ClipCount;
        MaxClipCount = GunSO.MaxClipCount;
        SpareBullets = GunSO.SpareBullets;
        BodyDamage = GunSO.BodyDamage;
        HeadDamage = GunSO.HeadDamage;
        ParticleEffect = GunSO.ParticleEffect;
        Debug.Log("Setup Successful!");
    }

    public void ReloadBullet()
    {
       if(ClipCount < SpareBullets && MaxClipCount > 0)
        {
            int neededBullet = SpareBullets - ClipCount;
            ClipCount += neededBullet;
            MaxClipCount -= neededBullet;
            if(MaxClipCount < 0) MaxClipCount = 0;
        }
        else
        {
            Debug.Log("No have clip!");
        }
    }

    public void Shoot()
    {
        if (ClipCount > 0)
        {
            ClipCount--;

            Debug.Log($"Bang! Bullets left in magazine: {ClipCount}");

        }
        else
        {
            Debug.Log("No bullets left in the clip! Reloading...");
            ReloadBullet();
        }
    }
}
