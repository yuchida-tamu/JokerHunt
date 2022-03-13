using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour{
   [SerializeField] int damage = 10;
    [SerializeField] float speed = 20f;
    [SerializeField] Rigidbody2D rb;
    
    private void Start(){
        rb.velocity = transform.right * speed;
    }

     void OnTriggerEnter2D(Collider2D hitInfo){
        EnemyState enemy = hitInfo.GetComponent<EnemyState>();
        Debug.Log(hitInfo);
        if (enemy != null) {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

    private void OnBecameInvisible(){
        Destroy(gameObject);
    }
    
    
}
