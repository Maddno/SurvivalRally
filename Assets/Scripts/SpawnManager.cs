using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    RoadSpawner roadSpawner;

    private void Start()
    {
        roadSpawner = GetComponent<RoadSpawner>();
    }

    public void RoadSpawnTriggerEntered()
    {
        roadSpawner.MoveRoad();
    }
    public void EnemySpawnTriggerExited()
    {
        roadSpawner.SpawnEnemys();
    }
}
