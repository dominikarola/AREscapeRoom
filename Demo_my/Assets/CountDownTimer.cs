using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CountDownTimer : MonoBehaviour
{

   public int countDownTime;
   public Text countDownDisplay;


   IEnumerator CountDownToStart()
   {
      while (countDownTime > 0)
      {
          countDownDisplay.text = countDownTime.ToString();
          yield return new WaitForSeconds(1f);

          countDownTime--;
          
      }

      countDownDisplay.text = "GO!";
      
   }

}
