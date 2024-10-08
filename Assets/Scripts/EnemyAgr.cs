using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgr : MonoBehaviour
{
    private float _speed = 7f;
    private float _rotationSpeed = 700f;

    private float _agroDistance = 15f;
    [SerializeField] private Transform _heroTarget;

    private void Update()
    {
        Vector3 direction = GetDirectionToHero();

        if (direction.magnitude <= _agroDistance / 3)
            return;

        if (direction.magnitude <= _agroDistance)
        {
            Vector3 normalizeDirection = direction.normalized;

            ProcessMoveTo(normalizeDirection);

            ProcessRotateTo(normalizeDirection);
        }
    }

    public Vector3 GetDirectionToHero() => _heroTarget.position - transform.position;

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
}

