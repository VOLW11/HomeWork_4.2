using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgr1 : IBehaviour
{
    private EnemyMover _enemyMover;
    private Transform _player;

    public EnemyAgr1(Transform player)
    {
        _player = player;
    }

    public void EnemyBehaviour(EnemyMover enemyMover)
    {
        _enemyMover = enemyMover;
        Vector3 direction = _player.position - _enemyMover.transform.position;
        _enemyMover.Initialize(direction.normalized); 
    }
}

