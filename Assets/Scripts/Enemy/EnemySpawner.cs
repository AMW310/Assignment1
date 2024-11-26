using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool objectPool;

    private EnemyFactory factory;
    public int enemyCount;

    private int totalEnemies;

    void OnEnable()
    {
        Detection.PlayerEnter += SpawnEnemyAtPosition;
    }

    void OnDisable()
    {
        Detection.PlayerEnter -= SpawnEnemyAtPosition;
    }

public void SpawnEnemyAtPosition(GameObject obj)
    {
        //Debug.Log(obj.transform.position);
        for (int i = 0; i < enemyCount; i++)
        {
            if (totalEnemies >= enemyCount)
                break;

            GameObject enemy = objectPool.GetPooledEnemy();
            factory = new EnemyFactory(enemy);
            enemy.transform.position = factory.GetRndPosition();
            totalEnemies++;
        }
        
    }
}
