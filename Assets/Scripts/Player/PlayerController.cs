using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private ICommand currentCommand;

    public float _speed = 5f;
    public float _rotSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalRot = Input.GetAxis("Horizontal");
        float verticalRot = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        Vector3 rotation = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        transform.Translate(movement * _speed * Time.deltaTime, Space.World);

        if (rotation != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(rotation, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, _rotSpeed * Time.deltaTime);
        }
    }

    public void CommandEnemy(ICommand command, EnemyBehaviour enemy)
    {
        currentCommand = command;
        currentCommand.Execute(enemy);
    }
}
