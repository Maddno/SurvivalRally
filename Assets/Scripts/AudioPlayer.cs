using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField][Range(0f, 1f)] float shootingVolume = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField][Range(0f, 1f)] float damageVolume = 1f;

    [Header("Destroyed")]
    [SerializeField] AudioClip destroyedClip;
    [SerializeField][Range(0f, 1f)] float destroyedVolume = 1f;

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

    public void PlayDamageClip()
    {
        PlayClip(damageClip, damageVolume);
    }

    public void PlayDestroyedClip()
    {
        PlayClip(destroyedClip, destroyedVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        Vector3 camerafPos = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(clip, camerafPos, volume);
    }
}
