using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDesigner : MonoBehaviour
{
    [SerializeField] private EnemyActiveState _activeState;
    [SerializeField] private EnemyPassiveState _passiveState;

    [SerializeField] List<Transform> _targetList;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _player;

    private Transform _spawnPoint;

    private void Awake()
    {
        _spawnPoint = GetComponent<Transform>();

        if (_activeState == EnemyActiveState.RunsAway)
        {
            Enemy runsAway = Instantiate(_enemy, _spawnPoint.position, Quaternion.identity);
            runsAway.Initialize(new EnemyAgr1(_player));
        }

        if (_activeState == EnemyActiveState.Pursues)
        {
            Enemy pursues = Instantiate(_enemy, _spawnPoint.position, Quaternion.identity);
            pursues.Initialize(new EnemyPatrol1(_targetList));
        }
    }
}
