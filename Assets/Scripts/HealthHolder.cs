using UnityEngine;

public class HealthHolder : MonoBehaviour
{
    [SerializeField] private float health = 50f;
    [SerializeField] private ParticleSystem deathEffect;
    [SerializeField] private bool isPlayer;

    CanvaControle canvaControle;

    private void Awake()
    {
        canvaControle = FindObjectOfType<CanvaControle>();
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
        if(!isPlayer)
        {
            deathEffect.Play();
            Destroy(gameObject, 0.2f);
        }
        else
        {
            deathEffect.Play();
            Destroy(gameObject, 0.5f);
            canvaControle.GameOver();
        }
    }
}
