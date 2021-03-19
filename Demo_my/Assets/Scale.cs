using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{

   // public float tweenTime;
    
    void Start()
    {
        Tween();
    }

    public void Tween()
    {
        
        LeanTween.scale(gameObject,  new Vector3(1f,1f,1f),  3f );
    }
}
