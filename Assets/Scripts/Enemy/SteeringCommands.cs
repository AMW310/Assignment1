using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekCommands : ICommand
{
    public void Execute(EnemyBehaviour enemy)
    {
        enemy.Seek();
    }
}
public class FleeCommands : ICommand
{
    public void Execute(EnemyBehaviour enemy)
    {
        enemy.Flee();
    }
}
public class WanderCommands : ICommand
{
    public void Execute(EnemyBehaviour enemy)
    {
        enemy.Wander();
    }
}
