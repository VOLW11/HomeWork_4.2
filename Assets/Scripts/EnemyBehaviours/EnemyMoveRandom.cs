using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.GraphicsBuffer;

public class EnemyMoveRandom : IBehaviour
{
    private EnemyMover _enemyMover;
    private Transform _target;

    private float _maxRandomX = 20f;
    private float _maxRandomZ = 30f;
    private float _minRandomX = -50f;
    private float _minRandomZ = -30f;
    private float _targetUpdateTime = 1f;
    private float _time;

    public EnemyMoveRandom(Transform target)
    {
        _target = target;
    }

    public void EnemyBehaviour(EnemyMover enemyMover)
    {
        _enemyMover = enemyMover;
        _time += Time.deltaTime;

        if (_time >= _targetUpdateTime)
        {
            _target.position = new Vector3(Random.Range(_minRandomX, _maxRandomX), _target.transform.position.y, Random.Range(_minRandomZ, _maxRandomZ));
            Vector3 direction = _target.transform.position - _enemyMover.transform.position;
            
            _enemyMover.Initialize(direction.normalized);

            _time = 0;
        }
    }
}
