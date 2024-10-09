using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStandsStill : IBehaviour
{
    private EnemyMover _enemyMover;

    public void EnemyBehaviour(EnemyMover enemyMover)
    {
        _enemyMover = enemyMover;
        Vector3 direction = Vector3.zero;
        _enemyMover.Initialize(direction); 
    }
}

