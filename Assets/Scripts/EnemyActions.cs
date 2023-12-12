using UnityEngine;

public class EnemyActions : MonoBehaviour
{
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private Transform player;
    [SerializeField] private float sightRange;
    [SerializeField] private float enemySpeed = 1f;
    [SerializeField] private float enemyDamage = 10f;

    AudioPlayer audioPlayer;
    HealthHolder healthHolder;

    private bool playerInSightRange;
    private bool playAwakeZombiSound;

    private void Awake()
    {
        healthHolder = FindObjectOfType<HealthHolder>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        enemyAnimator = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player").transform;

        playerInSightRange = false;
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (!playerInSightRange && healthHolder.GetHealth() > 0)
        {
            OnIdle();
            playAwakeZombiSound = false;
        }

        if (playerInSightRange && healthHolder.GetHealth() > 0)
        {
            OnChasePlayer();
            if(!playAwakeZombiSound) 
            {
                audioPlayer.PlayZombieAwakeClip();
                playAwakeZombiSound = true;
            }
        }

        if (healthHolder.GetHealth() <= 0)
        {
            enemyAnimator.SetBool("isDead", true);
            Destroy(gameObject, 3f);
        }
    }

    private void OnIdle()
    {
        enemyAnimator.SetBool("isMove", false);
    }

    private void OnChasePlayer()
    {
        enemyAnimator.SetBool("isMove", true);
        transform.LookAt(player.transform);
        transform.position = Vector3.MoveTowards(this.transform.position, player.position, enemySpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && healthHolder.GetHealth() > 0)
        {
            collision.gameObject.GetComponent<HealthHolder>().GetDamage(enemyDamage);
        }
    }
}
