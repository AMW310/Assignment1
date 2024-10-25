using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public static event Action<GameObject> PlayerDetected;

    public AudioClip huntPlayer;
    /*[SerializeField] 
    private string _enemyName;

    public string EnemyName { get { return _enemyName; } }*/
    private void OnTriggerStay(Collider other)
    {
        if (PlayerDetected != null && other.name == "Cube")
        {
            //Debug.Log($"{other.gameObject.name} has entered the Danger Zone");
            PlayerDetected(other.GameObject());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (PlayerDetected != null && other.name == "Cube")
            AudioManager.Instance.Play(huntPlayer);
    }
}
