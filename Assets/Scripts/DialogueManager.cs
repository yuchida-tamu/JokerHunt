using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour{
    public Queue<string> sentences;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject chatBox;
    public PlayerState player;

    public void StartDialogue(dialogue dialogue){
        player.SetTalking(true);//set boolean value true
        sentences = new Queue<string>();  
        chatBox.SetActive(true);
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach ( string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        if(sentences.Count  == 0){
            EndDialogue();
            player.SetTalking(false);//set boolean value false
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        //Debug.Log(sentence);
    }

    IEnumerator TypeSentence(string sentence){
        dialogueText.text ="";
        foreach(char letter in sentence.ToCharArray()){
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue(){
        chatBox.SetActive(false);    
        Debug.Log("end of convo");
    }


    void Update(){
        //if(Input.GetKeyDown("space") )
         //   Debug.Log("continue");
        
        if(player.GetTalking() && Input.GetKeyDown("space") ){
            Debug.Log("continue");
            DisplayNextSentence();
        }
    }

    public bool getPlayerTalkingState(){
        return player.GetTalking();
    }
}
