using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("GunShooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField][Range(0f, 1f)] float shootingVolume = 1f;

    [Header("ZombieAwake")]
    [SerializeField] AudioClip awakeClip;
    [SerializeField][Range(0f, 1f)] float awakeVolume = 1f;

    [Header("ZombieDeath")]
    [SerializeField] AudioClip deathClip;
    [SerializeField][Range(0f, 1f)] float deathVolume = 1f;

    [Header("CarExplosion")]
    [SerializeField] AudioClip explosionClip;
    [SerializeField][Range(0f, 1f)] float explosionVolume = 1f;

    static AudioPlayer instance;

    void Awake()
    {
        ManageSingletone();
    }

    private void ManageSingletone()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }

    public void PlayZombieAwakeClip()
    {
        PlayClip(awakeClip, awakeVolume);
    }

    public void PlayZombieDeathClip()
    {
        PlayClip(deathClip, deathVolume);
    }

    public void PlayExplosionClip()
    {
        PlayClip(explosionClip, explosionVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        Vector3 camerafPos = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(clip, camerafPos, volume);
    }
}
