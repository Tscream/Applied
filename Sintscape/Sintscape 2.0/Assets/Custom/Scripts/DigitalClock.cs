using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DigitalClock : MonoBehaviour
{
    public TMP_Text textTimer; //Digital fond = https://www.1001fonts.com/digital-dismay-font.html

    public float timer = 300.0f;  //Timer is in seconds 

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer  <= 0)
        {
            //You lose
        }

        int minutes = Mathf.FloorToInt(timer / 60.0f); //Time in minutes
        int seconds = Mathf.FloorToInt(timer - minutes * 60); //Time still remaing in seconds
        textTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds); 
        //0 is for first in line so in this case minutes, 1 is the second in line so in this case seconds, :00 means display in two digits
    }
}
