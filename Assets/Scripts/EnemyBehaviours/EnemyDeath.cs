using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : IBehaviour
{
    private EnemyMover _enemyMover;
    private ParticleSystem _particleSystem;

     public EnemyDeath(ParticleSystem particleSystem)
     {
         _particleSystem = particleSystem;
     }

    public void EnemyBehaviour(EnemyMover enemyMover)
    {
        _enemyMover = enemyMover;
        _particleSystem.transform.position = _enemyMover.transform.position;
        _enemyMover.gameObject.SetActive(false);
        _particleSystem.Play();
    }
}

