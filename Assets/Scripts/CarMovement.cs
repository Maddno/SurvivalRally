using UnityEngine;
using UnityEngine.UIElements;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private float carSpeed = 10f;
    [SerializeField] SpawnManager spawnManager;

    private int distance;
    private Vector3 startPoint;

    private void Awake()
    {
        startPoint = transform.position;
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + carSpeed * Time.deltaTime);
        distance = (int)transform.position.z - (int)startPoint.z;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RoadSpawnTrigger")
        {
            spawnManager.RoadSpawnTriggerEntered();
        }

        if (other.tag == "EnemySpawnTrigger")
        {
            spawnManager.EnemySpawnTriggerExited();
        }
    }

    public int GetDistanvce()
    {
        return distance;
    }
}
