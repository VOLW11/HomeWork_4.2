using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed = 7f;
  //  private float _rotationSpeed = 700f;
    private float _agroDistance = 15f;

    private IBehaviour _behaviour;
    private Transform _target;
    private List<Transform> _targetList;

    public void Initialize(IBehaviour behaviour, Transform target)
    {
        _behaviour = behaviour;
        _target = target;
    }

    public void Initialize(IBehaviour behaviour, List<Transform> targetList)
    {
        _behaviour = behaviour;
        _targetList = targetList;
    }

    private void Update()
    {
        _behaviour.EnemyBehaviour(_target, _speed, _agroDistance, this.transform);
    }
}
