using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    [SerializeField] int damage = 10;
    [SerializeField] Rigidbody rb;
    [SerializeField] float angle = 60.0f;
    [SerializeField] int range = 12;
    


    private void Start()
    {
        Vector3 target = new Vector3(gameObject.transform.position.x + range, gameObject.transform.position.y, gameObject.transform.position.z);
        Shoot(target, angle);
    }

     void OnTriggerEnter(Collider hitInfo)
    {

        EnemyState enemy = hitInfo.GetComponent<EnemyState>();
        if (enemy != null) 
        {
            //   enemy.TakeDamage(damage);
            return;
        }
            Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void Shoot(Vector3 target, float angle)
    {
        float speedVec = ComputeVectorFromAngle(target, angle);
        if(speedVec <= 0.0f)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 vec = ConvertVectorToVector3(speedVec, angle, target);
        InstantiateShootObject(vec);
    }

    private Vector3 ConvertVectorToVector3(float speedVec, float angle, Vector3 target)
    {
        Vector3 startPos = gameObject.transform.position;
        Vector3 targetPos = target;
        startPos.y = 0.0f;
        targetPos.y = 0.0f;

        Vector3 dir = (targetPos - startPos).normalized;
        Quaternion yawRot = Quaternion.FromToRotation(Vector3.right, dir);
        Vector3 vec = speedVec * Vector3.right;

        vec = yawRot * Quaternion.AngleAxis(angle, Vector3.forward) * vec;

        return vec;
    }

    private void InstantiateShootObject(Vector3 i_shootVector)
    {
        if (gameObject == null)
        {
            throw new NullReferenceException("m_shootObject");
        }

        if (gameObject == null)
        {
            throw new System.NullReferenceException("m_shootPoint");
        }

      
        var rigidbody = GetComponent<Rigidbody>();

        
        Vector3 force = i_shootVector * rigidbody.mass;

        rigidbody.AddForce(force, ForceMode.Impulse);
    }

    private float ComputeVectorFromAngle(Vector3 target, float angle) 
    {
      
        Vector2 startPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.z);
        Vector2 targetPos = new Vector2(target.x, target.z);
        float distance = Vector2.Distance(targetPos, startPos);

        float x = distance;
        float g = Physics.gravity.y;
        float y0 = gameObject.transform.position.y;
        float y = target.y;

        float rad = angle * Mathf.Deg2Rad;

        float cos = Mathf.Cos(rad);
        float tan = Mathf.Tan(rad);

        float v0Square = g * x * x / (2 * cos * cos * (y - y0 - x * tan));

        if (v0Square <= 0.0f)
        {
            return 0.0f;
        }

        float v0 = Mathf.Sqrt(v0Square);
        return v0;
    }
    
    
}
