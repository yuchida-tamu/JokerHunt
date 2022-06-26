using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameWorldPlayerControl : MonoBehaviour{
    public CharacterController controller;
    [SerializeField] float speed = 14f;

    // Update is called once per frame
    void Update(){
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= .01f){
            controller.Move(direction * speed * Time.deltaTime);
        }
    }
}
