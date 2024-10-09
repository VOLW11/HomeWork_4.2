using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : IBehaviour
{
    private float _minDistanceToTarget = 0.05f;
    private EnemyMover _enemyMover;
    private List<Transform> _patrolTargets;
    private int _numberTarget = 0;

    public EnemyPatrol(List<Transform> patrolTargets)
    {
        _patrolTargets = patrolTargets;
    }

    public void EnemyBehaviour(EnemyMover enemyMover)
    {
        _enemyMover = enemyMover;

        Vector3 direction = _patrolTargets[_numberTarget].position - _enemyMover.transform.position;

        if (direction.magnitude <= _minDistanceToTarget)
            _numberTarget++;

        if (_numberTarget == _patrolTargets.Count)
            _numberTarget = 0;

        _enemyMover.Initialize(direction.normalized);

    }
}
