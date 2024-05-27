using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour, IGun
{
    public GunSO GunSO;
    public string GunName;
    public int ClipCount;
    public int MaxClipCount;
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
        ClipCount = GunSO.ClipCount;
        MaxClipCount = GunSO.MaxClipCount;
        BodyDamage = GunSO.BodyDamage;
        HeadDamage = GunSO.HeadDamage;
        ParticleEffect = GunSO.ParticleEffect;
        Debug.Log("Setup Successfull!");
    }
    public void ReloadBullet()
    {

    }
    public void Shoot()
    {

    }
}
