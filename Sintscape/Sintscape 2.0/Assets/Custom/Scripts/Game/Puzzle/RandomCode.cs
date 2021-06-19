using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RandomCode : MonoBehaviour
{
    public static RandomCode _instance { get; set; }

    string show;
    public TMP_Text showText;
    public float numberStayTime, timeBetweenNumber, timeForNewCode;
    public int[] timeBasedCode = new int[8];

    public int[] inputCode = new int[8];
    int indexNumber;


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        float newCode = numberStayTime * 8 + timeBetweenNumber * 8 + timeForNewCode;
        InvokeRepeating("RandomCodeGen", 0, newCode);
    }

    void Update()
    {
        showText.text = show;
    }

    void RandomCodeGen()
    {
        for (int i = 0; i < timeBasedCode.Length; i++)
        {
            timeBasedCode[i] = Random.Range(1, 9);
        }

        StartCoroutine(ShowCode());
    }

    IEnumerator ShowCode()
    {
        show = timeBasedCode[0].ToString();
        yield return new WaitForSeconds(numberStayTime);
        show = "";
        yield return new WaitForSeconds(timeBetweenNumber);
        show = timeBasedCode[1].ToString();
        yield return new WaitForSeconds(numberStayTime);
        show = "";
        yield return new WaitForSeconds(timeBetweenNumber);
        show = timeBasedCode[2].ToString();
        yield return new WaitForSeconds(numberStayTime);
        show = "";
        yield return new WaitForSeconds(timeBetweenNumber);
        show = timeBasedCode[3].ToString();
        yield return new WaitForSeconds(numberStayTime);
        show = "";
        yield return new WaitForSeconds(timeBetweenNumber);
        show = timeBasedCode[4].ToString();
        yield return new WaitForSeconds(numberStayTime);
        show = "";
        yield return new WaitForSeconds(timeBetweenNumber);
        show = timeBasedCode[5].ToString();
        yield return new WaitForSeconds(numberStayTime);
        show = "";
        yield return new WaitForSeconds(timeBetweenNumber);
        show = timeBasedCode[6].ToString();
        yield return new WaitForSeconds(numberStayTime);
        show = "";
        yield return new WaitForSeconds(timeBetweenNumber);
        show = timeBasedCode[7].ToString();
        yield return new WaitForSeconds(numberStayTime);
        show = "";
    }

    public void Inputnumber(string number)
    {
        int input = int.Parse(number);

        inputCode[indexNumber] = input;
        if (inputCode[7] != 0)
        {
            int goodanswer = 0;
            for (int i = 0; i < timeBasedCode.Length; i++)
            {
                if(timeBasedCode[i] != inputCode[i])
                {
                    Debug.Log("wrong code");
                    for (int f = 0; f < inputCode.Length; f++)
                    {
                        inputCode[f] = 0;
                    }
                    indexNumber = 0;
                    //play wrong input sound
                    return;
                }
                else
                {
                    goodanswer++;
                }
            }
            if(goodanswer == 8)
            {
                Debug.Log("Goed antwoord");
            }
        }
        indexNumber++;

    }

}
