using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerManagerDev : MonoBehaviour
{
    PhotonView pv;
    public GameObject spawnPoint;

    private void Awake()
    {
        pv = GetComponent<PhotonView>();
    }

    void Start()
    {
        if (pv.IsMine)
        {
            CreatePlayer();
        }
    }

    void CreatePlayer()
    {
        Debug.Log("Created Player");
        spawnPoint = GameObject.Find("DevSpawnPoint").gameObject;
        PhotonNetwork.Instantiate("Developer", spawnPoint.transform.position, Quaternion.identity);
    }
}