using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    public EnemyBehaviour [] enemy;
    private bool command;

    void Start()
    {
        StartCoroutine(SetEnemy());
    }

    void OnEnable()
    {
        Detection.PlayerDetected += Command;
    }
    
    void OnDisable()
    {
        Detection.PlayerDetected += Command;
    }

    

    IEnumerator SetEnemy()
    {
        yield return new WaitForSeconds(1f);
        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");

        enemy = new EnemyBehaviour[enemyObjects.Length];

        for (int i = 0; i < enemyObjects.Length; i++)
        {
            enemy[i] = enemyObjects[i].GetComponent<EnemyBehaviour>();
        }
    }

    void Update()
    {
        if(command)
        {
            if (Input.GetKey(KeyCode.I))
            {
                for (int i = 0; i < enemy.Length; i++)
                {
                    player.CommandEnemy(new SeekCommands(), enemy[i]);
                    Debug.Log(i);
                }
            }

            if (Input.GetKey(KeyCode.O))
            {
                for (int i = 0; i < enemy.Length; i++)
                {
                    player.CommandEnemy(new FleeCommands(), enemy[i]);
                }
            }

            if (Input.GetKey(KeyCode.P))
            {
                for (int i = 0; i < enemy.Length; i++)
                {
                    player.CommandEnemy(new WanderCommands(), enemy[i]);
                }
            }
        }
    }
    void Command(GameObject obj)
    {
        command = true;
    }
}
