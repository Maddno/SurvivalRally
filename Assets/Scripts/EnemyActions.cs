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

    private bool playerInSightRange;
    private bool playAwakeZombiSound;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        enemyAnimator = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player").transform;

        playerInSightRange = false;
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (!playerInSightRange)
        {
            OnIdle();
            playAwakeZombiSound = false;
        }

        if (playerInSightRange)
        {
            OnChasePlayer();
            if(!playAwakeZombiSound) 
            {
                audioPlayer.PlayZombieAwakeClip();
                playAwakeZombiSound = true;
            }
        }
    }

    private void OnIdle()
    {
        enemyAnimator.SetBool("isMove", false);
        enemyAnimator.SetBool("isAtack", false);
    }

    private void OnChasePlayer()
    {
        enemyAnimator.SetBool("isMove", true);
        transform.LookAt(player.transform);
        transform.position = Vector3.MoveTowards(this.transform.position, player.position, enemySpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HealthHolder>().GetDamage(enemyDamage);
        }
    }
}
