using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] int range;
    private bool hasReached = false;

    protected void HasReachedEnd()
    {
        hasReached = false;
    }
}
