using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerManager : MonoBehaviour
{
    PhotonView pv;

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
        PhotonNetwork.Instantiate("Player", transform.position, Quaternion.identity);
    }
}