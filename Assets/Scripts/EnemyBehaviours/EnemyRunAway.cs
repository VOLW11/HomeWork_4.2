using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRunAway : IBehaviour
{
    private EnemyMover _enemyMover;
    private Transform _player;

    public EnemyRunAway(Transform player)
    {
        _player = player;
    }

    public void EnemyBehaviour(EnemyMover enemyMover)
    {
        _enemyMover = enemyMover;
        Vector3 direction = _enemyMover.transform.position - _player.position;
        _enemyMover.Initialize(direction.normalized); 
    }
}

