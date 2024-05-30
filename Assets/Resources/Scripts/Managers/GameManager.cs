using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Particles")]
    public GameObject[] hitParticles;

    private void Awake()
    {
        Instance = this;
    }



}
