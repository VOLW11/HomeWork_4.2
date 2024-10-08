using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBehaviour 
{
    void EnemyBehaviour(Transform target, float speed, float agroDistance, Transform enemy);
}
