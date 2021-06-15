using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomCode : MonoBehaviour
{
    string show;
    public Text showText;
    int one, two, three, four, five, six, seven, eight;
    public float numberStayTime, timeBetweenNumber, timeForNewCode;
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
        one = Random.Range(1, 9);
        two = Random.Range(1, 9);
        three = Random.Range(1, 9);
        four = Random.Range(1, 9);
        five = Random.Range(1, 9);
        six = Random.Range(1, 9);
        seven = Random.Range(1, 9);
        eight = Random.Range(1, 9);
        StartCoroutine(ShowCode());
    }

    IEnumerator ShowCode()
    {
        show = one.ToString();
        yield return new WaitForSeconds(numberStayTime);
        show = "";
        yield return new WaitForSeconds(timeBetweenNumber);
        show = two.ToString();
        yield return new WaitForSeconds(numberStayTime);
        show = "";
        yield return new WaitForSeconds(timeBetweenNumber);
        show = three.ToString();
        yield return new WaitForSeconds(numberStayTime);
        show = "";
        yield return new WaitForSeconds(timeBetweenNumber);
        show = four.ToString();
        yield return new WaitForSeconds(numberStayTime);
        show = "";
        yield return new WaitForSeconds(timeBetweenNumber);
        show = five.ToString();
        yield return new WaitForSeconds(numberStayTime);
        show = "";
        yield return new WaitForSeconds(timeBetweenNumber);
        show = six.ToString();
        yield return new WaitForSeconds(numberStayTime);
        show = "";
        yield return new WaitForSeconds(timeBetweenNumber);
        show = seven.ToString();
        yield return new WaitForSeconds(numberStayTime);
        show = "";
        yield return new WaitForSeconds(timeBetweenNumber);
        show = eight.ToString();
        yield return new WaitForSeconds(numberStayTime);
        show = "";
    }

}
