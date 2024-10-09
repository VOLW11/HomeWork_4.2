using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private IBehaviour _behaviour;

   // private Transform _target;
    private EnemyMover _enemyMover;

    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
    }

    public void Initialize(IBehaviour behaviour)
    {
        _behaviour = behaviour;
    }

    private void Update()
    {
        _behaviour.EnemyBehaviour(_enemyMover);
    }
}
