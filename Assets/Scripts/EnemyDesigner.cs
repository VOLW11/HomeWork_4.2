using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDesigner : MonoBehaviour
{
    [SerializeField] private EnemyActiveState _activeState;
    [SerializeField] private EnemyPassiveState _passiveState;
    [SerializeField] private Transform _enemyPrafabs;

    [SerializeField] private Enemy _enemy;

    [SerializeField] private Transform _player;
    private Transform _spawnPoint;

    private void Awake()
    {
        _spawnPoint = GetComponent<Transform>();

       // Instantiate(_enemyPrafabs, _spawnPoint.position, Quaternion.identity);

        if (_activeState == EnemyActiveState.RunsAway)
        {
            Enemy ork = Instantiate(_enemy, _spawnPoint.position, Quaternion.identity);
            ork.Initialize(new EnemyAgr1(), _player);
        }
    }
}
