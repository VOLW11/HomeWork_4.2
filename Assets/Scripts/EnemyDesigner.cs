using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyDesigner : MonoBehaviour
{
    [SerializeField] private EnemyPassiveState _passiveState;
    [SerializeField] private EnemyActiveState _activeState;

    [SerializeField] List<Transform> _targetList;
    [SerializeField] Transform _targetRandom;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _player;
    [SerializeField] private ParticleSystem _enemyDeath;

    private Transform _spawnPoint;

    private void Awake()
    {
        _spawnPoint = GetComponent<Transform>();

        Enemy enemy = Instantiate(_enemy, _spawnPoint.position, Quaternion.identity, null);

        switch (_passiveState)
        {
            case EnemyPassiveState.StandsStill:
                enemy.InitializePassiveState(new EnemyStandsStill(), _player);
                break;

            case EnemyPassiveState.PatrolsArea:
                enemy.InitializePassiveState(new EnemyPatrol(_targetList), _player);
                break;

            case EnemyPassiveState.MovesRandom:
                enemy.InitializePassiveState(new EnemyMoveRandom(_targetRandom), _player);
                break;
        }

        switch (_activeState)
        {
            case EnemyActiveState.RunsAway:
                enemy.InitializeActiveState(new EnemyRunAway(_player));
                break;

            case EnemyActiveState.Pursues:
                enemy.InitializeActiveState(new EnemyPursuit(_player));
                break;

            case EnemyActiveState.Death:
                enemy.InitializeActiveState(new EnemyDeath(_enemyDeath));
                break;
        }
    }
}
