using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    [Header("Road Spawn")]
    [SerializeField] private List<GameObject> roads;
    [SerializeField] private float offset = 210f;

    [Header("Enemy Spawn")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int numbersOfEnemy;

    private void Start()
    {
        if (roads != null && roads.Count > 0)
        {
            roads = roads.OrderBy(r  => r.transform.position.z).ToList();
        }
    }

    public void MoveRoad()
    {
        GameObject movedRoad = roads[0];
        roads.Remove(movedRoad);
        float newZ = roads[roads.Count - 1].transform.position.z + offset;
        movedRoad.transform.position = new Vector3(0, 0, newZ);
        roads.Add(movedRoad);
    }

    public void SpawnEnemys()
    {
        Vector3 groundCoordinate = roads[0].transform.position + new Vector3(0, 0, offset);
        List<Vector3> enemySpawnCoordinats = new List<Vector3>();

        for (int i = 0; i < numbersOfEnemy; i++)
        {
            enemySpawnCoordinats.Add((new Vector3(Random.Range(-15f, 15f), 0, Random.Range(-100f, 110f))) + groundCoordinate);
        }

        foreach (var enemyCoordinat in enemySpawnCoordinats)
        {
            Instantiate(enemyPrefab, enemyCoordinat, Quaternion.Euler(0f, Random.Range(0f, 360f), 0f));
        }
    }
}
