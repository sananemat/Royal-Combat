using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class PhotonManger : MonoBehaviourPunCallbacks
{
    public TMP_InputField username;

    private void Update()
        {
        Debug.Log("NetworkState"+PhotonNetwork.NetworkClientState);
        }

    public void OnLoginClick()
        {
        string name = username.text;
        if (!string.IsNullOrEmpty(name))
            {
            PhotonNetwork.LocalPlayer.NickName=name;
            PhotonNetwork.ConnectUsingSettings();
            }
        else
            {
            Debug.Log("Name is not entered!");
            }
        }

    public override void OnConnected()
        {
        Debug.Log("Connected to Internet!");
        }

    public override void OnConnectedToMaster()
        {
        Debug.Log(PhotonNetwork.LocalPlayer.NickName + "is connected to photon ...");
        }
    }
