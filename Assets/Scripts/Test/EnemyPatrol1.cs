using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol1 : IBehaviour
{
   // private float _minDistanceToTarget = 0.05f;
    private EnemyMover _enemyMover;
    private List<Transform> _patrolTargets;

    public EnemyPatrol1(List<Transform> patrolTargets)
    {
        _patrolTargets = patrolTargets;  
    }

    public void EnemyBehaviour(EnemyMover enemyMover)
    {
        _enemyMover = enemyMover;

        for (int i = 0; i < _patrolTargets.Count; i++)
        { 
            Vector3 direction = _patrolTargets[i].position - _enemyMover.transform.position;

            _enemyMover.Initialize(direction.normalized);
        }
    }
}
