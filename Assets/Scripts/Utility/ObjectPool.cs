using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private EnemyFactory factory;

    [Serializable]
    private struct PooledEnemy
    {
        public GameObject prefab;
        public int numToSpawn;
    }

    [SerializeField] private PooledEnemy[] pools;

    private readonly Queue<GameObject> pooledEnemies = new Queue<GameObject>();

    void Start()
    {
        pooledEnemies.Clear();

        foreach (PooledEnemy pool in pools)
        {
            factory = new EnemyFactory(pool.prefab);
            for (int i = 0; i < pool.numToSpawn; i++)
            {
                GameObject eb = factory.SpawnEnemy();
                eb.gameObject.SetActive(false);
                pooledEnemies.Enqueue(eb);
            }
        }
    }

    public GameObject GetPooledEnemy()
    {
        if (pooledEnemies.Count == 0)
        {
            GameObject eb = factory.SpawnEnemy();
            eb.gameObject.SetActive(false);
            pooledEnemies.Enqueue(eb);
        }

        GameObject enemy = pooledEnemies.Dequeue();
        enemy.SetActive(true);
        return enemy;
    }

    public void PoolEnemy(GameObject obj)
    {
        obj.SetActive(false);
        pooledEnemies.Enqueue(obj);
    }
}
