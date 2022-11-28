using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static SpawnManager;

public class Enemy : MonoBehaviour
{
    public EnemyBlueprint enemy;
    public void TakeDamage(int damage)
    {
        enemy.health -= damage;

        if (enemy.health <= 0)
            Die();
    }

    void Die()
    {
        PlayerStats.money += enemy.value;
        Destroy(gameObject);
    }
}
