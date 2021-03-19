using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Slide : MonoBehaviour
{
   
    public GameObject doorLeft;
    public GameObject doorRight;
    public GameObject nameOfGame;
    public Button start;
    

    void Start()
    {
       
    }
    
    public void OpenDoor()
    {
        LeanTween.moveX(doorLeft.GetComponent<RectTransform>(), -658f, 1f);
        LeanTween.moveX(doorRight.GetComponent<RectTransform>(), 600f, 1f);
        LeanTween.moveY(nameOfGame.GetComponent<RectTransform>(), 643f, 1f);
        LeanTween.moveY(start.GetComponent<RectTransform>(), -624f, 1f);

    }
}
