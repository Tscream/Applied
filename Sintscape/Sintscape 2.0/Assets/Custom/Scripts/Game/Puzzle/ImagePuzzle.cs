using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ImagePuzzle : MonoBehaviour
{
    public static ImagePuzzle _instance2 { get; set; }

    public TMP_Text puzzleLetter;
    public Material[] randomMaterials = new Material[6];
    Material descriptionmaterial;
    Material descriptionObject;
    private void Awake()
    {
        if (_instance2 != null && _instance2 != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance2 = this;
        }
    }

    private void Start()
    {
        descriptionmaterial = randomMaterials[Random.Range(0, randomMaterials.Length)];
        GameObject.Find("PuzzleImagesArtistDescription").GetComponent<MeshRenderer>().material = descriptionmaterial;
        descriptionObject = GameObject.Find("PuzzleImagesArtistDescription").GetComponent<MeshRenderer>().material;
    }
    public void WrongImage()
    {
        print("o oh stinky");
        GameObject.Find("Timer").GetComponent<DigitalClock>().timer -= 30;
        //punishment, like time decrease but i dont know what you want to do if you choose the wrong image so here i am
    }

    public void RightImage()
    {
        puzzleLetter.GetComponent<MeshRenderer>().enabled = true;
        //particle maybe
        print("Good choice");
    }

    public void CheckMaterial(Material material)
    {
        if (material.name == descriptionObject.name)
        {
            RightImage();
        }
        else 
        {
            WrongImage();
        }


    }

}
