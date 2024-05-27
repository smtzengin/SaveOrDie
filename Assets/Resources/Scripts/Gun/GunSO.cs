using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Create New Gun")]
public class GunSO : ScriptableObject
{
    public GameObject Gun;
    public Sprite Sprite;
    public string GunName;
    public int ClipCount;
    public int MaxClipCount;
    public int SpareBullets;
    public int BodyDamage;
    public int HeadDamage;
    public GameObject ParticleEffect;

}
