using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform _player;

    private IBehaviour _activeState;
    private IBehaviour _passiveState;

    private EnemyMover _enemyMover;
    private float _agroDistance = 15f;

    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
    }

    public void InitializePassiveState(IBehaviour passiveState, Transform player)
    {
        _passiveState = passiveState;
        _player = player;
    }

    public void InitializeActiveState(IBehaviour activeState)
    {
        _activeState = activeState;
    }

    private void Update()
    {
        Vector3 directionToPlayer = _player.position - transform.position;

        if (directionToPlayer.magnitude > _agroDistance)
            _passiveState.EnemyBehaviour(_enemyMover);

        if (directionToPlayer.magnitude < _agroDistance)
            _activeState.EnemyBehaviour(_enemyMover);
    }
}
