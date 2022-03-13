using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIbulletCount : MonoBehaviour{

    [SerializeField] Image[] bulletImage;

    public void initialize(){
        foreach (var item in bulletImage){
            item.color = Color.green;
        }
    }

    public void updateColorGreen(int reference){
         bulletImage[reference].GetComponent<Image>().color = Color.green;
    }
    public void updateColorRed(int reference){
         bulletImage[reference].GetComponent<Image>().color = Color.red;            
    }

}
