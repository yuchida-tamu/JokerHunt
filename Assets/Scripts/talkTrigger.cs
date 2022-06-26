using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talkTrigger : MonoBehaviour{
    public dialogue dialogue;
    public GameObject talkRange;
    public DialogueManager dm;
    private bool isNear = false;


    public void TriggerDialogue(){
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    
    void Update(){
        if(Input.GetKeyDown("space") && isNear && !dm.getPlayerTalkingState()){
            dm.StartDialogue(dialogue);
        }
    }
    private void OnTriggerEnter(Collider other){
        talkRange.SetActive(true);
        isNear=true;
    }
    private void OnTriggerExit(Collider other){
        talkRange.SetActive(false);
        dm.EndDialogue();
        isNear=false;
    }

    
}
