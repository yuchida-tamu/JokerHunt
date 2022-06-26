using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
   [SerializeField] int health = 100;
    private bool _isAttacking = false;
    public bool IsAttacking => _isAttacking;

    private bool isTalking;



    void Start(){
        isTalking = false;
    }

    public bool GetTalking(){
        return isTalking;
    }
    public void SetTalking(bool talkingState){
        isTalking = talkingState;
    }

}
