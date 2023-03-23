using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class PhotonManger : MonoBehaviourPunCallbacks
{
    public TMP_InputField username;
    public TMP_InputField GetEnteredRoomName;
    private int PlayerNo = 2;
    public GameObject PlayerNamePannel;
    public GameObject LobbyPannel;
    public GameObject RoomPannel;
    public GameObject RoomList;
    public GameObject ConnectingPannel;
    public GameObject CreateRoomPannel;


    private void Start()
        {
        ActivateMyPannel(PlayerNamePannel.name);
        }
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
            ActivateMyPannel(ConnectingPannel.name);
            }
        else
            {
            Debug.Log("Name is not entered!");
            }
        }
    public void OnClickCreateRoom()
        {
        string roomName = GetEnteredRoomName.text;
        if(string.IsNullOrEmpty(roomName))
            {
            roomName=roomName+Random.Range(0, 1000);
            }
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers=(byte)PlayerNo;
        PhotonNetwork.CreateRoom(roomName , roomOptions);
        }
    public void OnCancelClick()
        {
        ActivateMyPannel(LobbyPannel.name);
        }
    public override void OnConnected()
        {
        Debug.Log("Connected to Internet!");
        }

    public override void OnConnectedToMaster()
        {
        Debug.Log(PhotonNetwork.LocalPlayer.NickName + " is connected to photon ...");
        ActivateMyPannel(LobbyPannel.name);
        }
    public override void OnCreatedRoom()
        {
        Debug.Log(PhotonNetwork.CurrentRoom.Name+" is created");
        }
    public override void OnJoinedRoom()
        {
        Debug.Log(PhotonNetwork.LocalPlayer.NickName +" Joined Room");
        }
    public void ActivateMyPannel(string PannelName)
        {
        PlayerNamePannel.SetActive(PannelName.Equals(PlayerNamePannel.name));
        RoomPannel.SetActive(PannelName.Equals(RoomPannel.name));
        RoomList.SetActive(PannelName.Equals(RoomList.name));
        LobbyPannel.SetActive(PannelName.Equals(LobbyPannel.name));

        ConnectingPannel.SetActive(PannelName.Equals(ConnectingPannel.name));
        CreateRoomPannel.SetActive(PannelName.Equals(CreateRoomPannel.name));

        }
    }
