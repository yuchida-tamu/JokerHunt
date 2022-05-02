using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    [SerializeField] int health = 100;

   
    void Die()
    {
        Debug.Log("Deaad");
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
       
        if (health <= 0)
        {
            Die();
        }
    }
}
