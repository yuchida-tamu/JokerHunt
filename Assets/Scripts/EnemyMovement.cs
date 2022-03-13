using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private int currentTile = 5;
    [SerializeField] GameObject[] map;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = map[currentTile].transform.position;
        gameObject.transform.position = new Vector3(position.x, position.y, -5);
    }

    
}
