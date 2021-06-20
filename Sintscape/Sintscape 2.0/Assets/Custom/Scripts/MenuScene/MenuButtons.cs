using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public GameObject startUI, hostUI, helpUI, createGameUI, joinGameUI;

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
        hostUI.SetActive(false);
        createGameUI.SetActive(true);
    }
    public void b_JoinGame()
    {
        hostUI.SetActive(false);
        joinGameUI.SetActive(true);
    }
    public void b_BackToStartUI()
    {
        startUI.SetActive(true);
        hostUI.SetActive(false);
        helpUI.SetActive(false);
    }
    public void b_BackToHostUI()
    {
        hostUI.SetActive(true);
        createGameUI.SetActive(false);
        joinGameUI.SetActive(false);
    }


}
