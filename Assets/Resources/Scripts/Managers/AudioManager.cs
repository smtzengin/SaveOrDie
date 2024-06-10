using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource MainMenuAudioSource;
    public AudioSource PlayerAudioSource;
    public AudioSource EnemyAudioSource;

    [Header("VFX")]
    [SerializeField] private AudioClip footstepVFX;
    [SerializeField] private AudioClip akShootVFX;
    [SerializeField] private AudioClip pistolShootVFX;
    [SerializeField] private AudioClip zombieTakeHitVFX;
    [SerializeField] private AudioClip zombieIdleVFX;
    [SerializeField] private AudioClip zombieAttackVFX;
    [SerializeField] private AudioClip witchAttackVFX;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        MainMenuAudioSource = GetComponentInChildren<AudioSource>();
    }

    public void PlayAudioClip(AudioSource audioSource, string clipName)
    {
        switch (clipName)
        {
            case "Ak":
                audioSource.PlayOneShot(akShootVFX);
                break;
            case "Pistol":
                audioSource.PlayOneShot(pistolShootVFX);
                break;
            case "ZombieAttack":
                audioSource.PlayOneShot(zombieAttackVFX);
                break;
            case "PlayerFootstep":
                audioSource.PlayOneShot(footstepVFX);
                break;
            case "ZombieIdle":
                audioSource.PlayOneShot(zombieIdleVFX);
                break;
            case "ZombieTakeHit":
                audioSource.PlayOneShot(zombieTakeHitVFX);
                break;
            case "WitchAttack":
                audioSource.PlayOneShot(witchAttackVFX);
                break;
        }
    }

    public void SubscribeAudioSource(AudioSource audioSource, string target)
    {
        switch (target)
        {
            case "Player":
                PlayerAudioSource = audioSource;
                break;
            case "Enemy":
                EnemyAudioSource = audioSource;
                break;
            default:
                break;
        }

        audioSource.volume = MainMenuAudioSource.volume;
    }

    public void SetVolume(float musicVolume, float vfxVolume)
    {
        MainMenuAudioSource.volume = musicVolume;
        if (PlayerAudioSource != null) PlayerAudioSource.volume = vfxVolume;
        if (EnemyAudioSource != null) EnemyAudioSource.volume = vfxVolume;
    }
}
