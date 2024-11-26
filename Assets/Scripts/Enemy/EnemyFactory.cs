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

    public GameObject SpawnEnemy()
    {
        Vector3 position = GetRndPosition();
        GameObject enemy = Object.Instantiate(enemyPrefab, position, Quaternion.identity);

        return enemy;
    }

    public Vector3 GetRndPosition()
    {
        Vector3 spawnPoint = SpawnPosManager.Instance.GetPosition();
        var position = new Vector3(Random.Range(spawnPoint.x - 10, spawnPoint.x + 10f), 0, Random.Range(spawnPoint.z - 10, spawnPoint.z + 10f));
        return position;
    }
}
