using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static SpawnManager;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public int value = 50;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
            Die();
    }

    void Die()
    {
        PlayerStats.money += value;
        Destroy(gameObject);
    }
}
