using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgr1 : IBehaviour
{


    public void EnemyBehaviour(Transform target, float speed, float agroDistance, Transform enemy)
    {
        Vector3 direction = target.position - enemy.position;

        if (direction.magnitude <= agroDistance / 3)
            return;

        if (direction.magnitude <= agroDistance)
        {
            Vector3 normalizeDirection = direction.normalized;

            enemy.Translate(normalizeDirection * speed * Time.deltaTime, Space.World);
        }
    }

}

