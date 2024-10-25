using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class EnemyFactory
{
    private GameObject enemyPrefab;

    public EnemyFactory(GameObject enemyPrefab)
    {
        this.enemyPrefab = enemyPrefab;
    }

    public GameObject SpawnEnemy(Vector3 position)
    {
        GameObject enemy = Object.Instantiate(enemyPrefab, position, Quaternion.identity);
        EnemyBehaviour script = enemy.GetComponent<EnemyBehaviour>();

        return enemy;
    }
}
