using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyPatrol : MonoBehaviour
{
    private float _speed = 7f;
    private float _rotationSpeed = 700f;

    private float _minDistanceToTarget = 0.05f;
    [SerializeField] private Transform _heroTarget;
    [SerializeField] private List<Transform> _patrolTargets;

    private Queue<Vector3> _targetPositions;
    private Vector3 _currentTarget;

    private void Awake()
    {
        _targetPositions = new Queue<Vector3>();

        foreach (Transform target in _patrolTargets)
            _targetPositions.Enqueue(target.position);

        _currentTarget = _targetPositions.Dequeue();
    }

    private void Update()
    {
        Vector3 direction = GetDirectionToHero();

        Vector3 normalizeDirection = direction.normalized;

        ProcessMoveTo(normalizeDirection);

        ProcessRotateTo(normalizeDirection);

        if (direction.magnitude <= _minDistanceToTarget)
            SwitchTarget();

    }

    private void SwitchTarget()
    {
        _targetPositions.Enqueue(_currentTarget);

        _currentTarget = _targetPositions.Dequeue();
    }

    public Vector3 GetDirectionToHero() => _currentTarget - transform.position;

    private void ProcessRotateTo(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        float step = _rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
    }

    private void ProcessMoveTo(Vector3 direction)
    {
        transform.Translate(direction * _speed * Time.deltaTime, Space.World);
    }

    public void EnemyBehaviour(Vector3 direction)
    {
        throw new NotImplementedException();
    }
}
