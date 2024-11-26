using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPosManager : MonoBehaviour
{
    public static SpawnPosManager Instance = null;

    public Vector3 spawnPosition;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void SetPosition(Vector3 inPos)
    {
        //Debug.Log($"Spawn Position Set to {inPos}");
        spawnPosition = inPos;
    }

    public Vector3 GetPosition()
    {
        return spawnPosition;
    }

}
