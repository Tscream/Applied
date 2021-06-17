using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ImagePuzzle : MonoBehaviour
{
    public TMP_Text puzzleLetter;
    public void WrongImage()
    {
        print("o oh stinky");
        //punishment, like time decrease but i dont know what you want to do if you choose the wrong image so here i am
    }

    public void RightImage()
    {
        puzzleLetter.GetComponent<MeshRenderer>().enabled = true;
        //particle maybe
        print("Good choice");
    }

}
