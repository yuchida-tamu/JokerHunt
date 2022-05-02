using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
   [SerializeField] int damage = 10;
    [SerializeField] float speed = 20f;
    [SerializeField] Rigidbody rb;
    private void Start()
    {
        rb.velocity = transform.right  * speed;
    }

     void OnTriggerEnter(Collider hitInfo)
    {

        EnemyState enemy = hitInfo.GetComponent<EnemyState>();
        if (enemy != null) 
        {
        Debug.Log(enemy);
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    
    
}
