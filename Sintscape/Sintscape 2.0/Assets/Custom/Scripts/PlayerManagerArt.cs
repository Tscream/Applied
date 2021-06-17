using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerManagerArt : MonoBehaviour
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
        spawnPoint = GameObject.Find("ArtSpawnPoint").gameObject;
        PhotonNetwork.Instantiate("Artist", spawnPoint.transform.position, Quaternion.identity);
    }
}