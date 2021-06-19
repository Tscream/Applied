using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simon : MonoBehaviour
{
    public static Simon instance { get; private set; }
    public List<GameObject> cubesOrder = new List<GameObject>();
    public GameObject[] colors = new GameObject[4];
    public bool Running = false;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Update()
    {
        if(Running)
        {
            foreach(GameObject Cube in colors)
            {
                Cube.layer = 2;
            }
            
        }
        else
        {
            foreach (GameObject Cube in colors)
            {
                Cube.layer = 0;
            }
        }
            
    }

    private void OnTriggerEnter(Collider other)
    {
       cubesOrder.Add(colors[Random.Range(0, colors.Length)]);
       StartCoroutine(Show());
    }

    // Update is called once per frame
    public void CubePressed()
    {
        cubesOrder.Add(colors[Random.Range(0,4)]);
        StartCoroutine(Show());
    }
    IEnumerator Show()
    {
        Running = true;
        for (int i = 0; i < cubesOrder.Count; i++)
        {
            yield return new WaitForSeconds(0.5f);
            Color c = cubesOrder[i].GetComponent<Renderer>().material.color;
            cubesOrder[i].GetComponent<Renderer>().material.color = Color.white;
            yield return new WaitForSeconds(0.5f);
            cubesOrder[i].GetComponent<Renderer>().material.color = c;   
        }
        Running = false;
    }
}
