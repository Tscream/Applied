using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public GameObject startUI, hostUI, helpUI;

    public void b_Start()
    {
        startUI.SetActive(false);
        hostUI.SetActive(true);
    }
    public void b_Help()
    {
        startUI.SetActive(false);
        helpUI.SetActive(true);
    }
    public void b_Quit()
    {
        Application.Quit();
    }
    public void b_HostGame()
    {
        print("Host");
    }
    public void b_JoinGame()
    {
        print("Joining");
    }
    public void b_Back()
    {
        startUI.SetActive(true);
        hostUI.SetActive(false);
        helpUI.SetActive(false);
    }
}
