using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create New Gun")]
public class GunSO : ScriptableObject
{
    public GameObject Gun;
    public string GunName;
    public int ClipCount;
    public int MaxClipCount;
    public int BodyDamage;
    public int HeadDamage;
    public GameObject ParticleEffect;

}
