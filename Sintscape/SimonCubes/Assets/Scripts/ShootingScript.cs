using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootingScript : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public Transform bulletspawn;
    private int i;
    private int roundNumber;

    void Update()
    {
        Debug.DrawRay(bulletspawn.transform.position, bulletspawn.transform.forward * 10);
        if(Input.GetMouseButtonUp(0))
        {
            ray = new Ray(bulletspawn.transform.position, bulletspawn.transform.forward);
            
            if(Physics.Raycast(ray, out hit, 10f ))
            {
                if (Simon.instance.cubesOrder[i].GetComponent<Renderer>().material.color == hit.collider.gameObject.GetComponent<Renderer>().material.color)
                {
                    i++; print("Good");
                    if (i == Simon.instance.cubesOrder.Count)
                    {
                        i = 0;
                        Simon.instance.NewColors();
                        roundNumber++;
                    }
                }
                else               
                {
                    print("You are fucked up");
                    for (int i = 0; i < Simon.instance.colors.Length; i++)
                    {
                        Simon.instance.colors[i].GetComponent<Renderer>().material.color = Color.black;
                    }
                }     
            }
        }
        if(roundNumber == 4)
        {
            print("Hier! heb een letter... {yeet}");
        }
    }
}
