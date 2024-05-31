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

    public void ActivateTeleport()
    {
        var teleportObject = FindObjectOfType<Teleport>(true);
        if (teleportObject != null)
        {
            teleportObject.gameObject.SetActive(true);
        }
    }

}
