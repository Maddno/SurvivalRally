using UnityEngine;

public class HealthHolder : MonoBehaviour
{
    [SerializeField] private float health = 50f;
    [SerializeField] private bool isPlayer;
    [SerializeField] private ParticleSystem deathEffect;
    [SerializeField] private Collider objectColider;
    

    CanvaControle canvaControle;
    AudioPlayer audioPlayer;
    

    private void Awake()
    {
        canvaControle = FindObjectOfType<CanvaControle>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    public void GetDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Death();
        }
    }

    public float GetHealth()
    {
        return health;
    }

    private void Death()
    {
        
        if (!isPlayer)
        {
            audioPlayer.PlayZombieDeathClip();
        }
        else
        {
            audioPlayer.PlayExplosionClip();
            PlayDeathParticle();
            Destroy(gameObject);
            canvaControle.GameOver();
        }
        objectColider.enabled = false;
    }

    private void PlayDeathParticle()
    {
        ParticleSystem deathEffectInstance = Instantiate(deathEffect, transform.position, Quaternion.identity);
        deathEffectInstance.Play();
        Destroy(deathEffectInstance.gameObject, deathEffectInstance.main.duration + deathEffectInstance.main.startLifetime.constantMax);
    }
}
