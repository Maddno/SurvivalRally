using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject ground;
    [SerializeField] private int numbersOfEnemy;
   
    private void Start()
    {
        SpawnEnemys(); 
    }

    private void SpawnEnemys()
    {
        Vector3 groundCoordinate = ground.transform.position;
        List<Vector3> enemySpawnCoordinats = new List<Vector3>();

        for (int i = 0; i < numbersOfEnemy; i++)
        {
            enemySpawnCoordinats.Add((new Vector3(Random.Range(-20f, 20f), 0, Random.Range(-60f, 90f))) + groundCoordinate);
        }

        foreach (var enemyCoordinat in enemySpawnCoordinats) 
        {
            Instantiate(enemyPrefab, enemyCoordinat, Quaternion.Euler(-90f, 0f, 0f));
        }
    }

    public void RespawnEnemys()
    {
        SpawnEnemys();
    }
}
