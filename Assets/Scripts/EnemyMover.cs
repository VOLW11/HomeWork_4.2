using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private float _speed = 7f;
    private float _rotationSpeed = 700f;

    private Transform _target;
    private Vector3 _direction;

    public void Initialize(Vector3 direction)
    {
        _direction = direction;
    }

    private void Update()
    {
        ProcessMoveTo(_direction);

        ProcessRotateTo(_direction);
    }

    private void ProcessRotateTo(Vector3 direction)
    {
        if (_direction == Vector3.zero)
            return;

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        float step = _rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
    }

    private void ProcessMoveTo(Vector3 direction)
    {
        transform.Translate(direction * _speed * Time.deltaTime, Space.World);
    }
}
