using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    private EnemyFactory factory;
    public int enemyCount;

    void Start()
    {
        factory = new EnemyFactory(enemy);
        for (int i = 0; i < enemyCount; i++)
        {
            var position = new Vector3(Random.Range(-10.5f, 10.0f), 0, Random.Range(14.5f, 35.5f));
            SpawnEnemyAtPosition(position);
        }
    }

    public void SpawnEnemyAtPosition(Vector3 position)
    {
        factory.SpawnEnemy(position);
    }
}
