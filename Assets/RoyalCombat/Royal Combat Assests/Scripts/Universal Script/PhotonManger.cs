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
    public GameObject ConnectingPannel;
    public GameObject CreateRoomPannel;
    public GameObject ShowRoomList;

    private Dictionary<string, RoomInfo> roomListData;
    public GameObject roomListPrefab;
    public GameObject roomListParent;

    public GameObject insideRoomPanel;
    public GameObject playerListItemPrefab;
    public GameObject playerListItemParent;
    public GameObject PlayButton;


    private Dictionary<string, GameObject> roomListGameobject;
    private Dictionary<int, GameObject> PlayerListGameobject;


    private void Start()
        {
        ActivateMyPannel(PlayerNamePannel.name);
        roomListData=new Dictionary<string, RoomInfo>();
        roomListGameobject=new Dictionary<string, GameObject>();
        PhotonNetwork.AutomaticallySyncScene=true;
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
        if (string.IsNullOrEmpty(roomName))
            {
            roomName=roomName+Random.Range(0, 1000);
            }
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers=(byte)PlayerNo;
        PhotonNetwork.CreateRoom(roomName, roomOptions);
        }
    public void OnCancelClick()
        {
        ActivateMyPannel(LobbyPannel.name);
        }
    public void RoomListButtonClicked()
        {
        if (!PhotonNetwork.InLobby)
            {
            PhotonNetwork.JoinLobby();
            }
        ActivateMyPannel(ShowRoomList.name);
        }
    public void BackFromRoomList()
        {
        if(PhotonNetwork.InLobby)
            {
            PhotonNetwork.LeaveLobby();
            }
        ActivateMyPannel(LobbyPannel.name);

        }
    public void BackFromPlayerList()
        {
        if (PhotonNetwork.InRoom)
            {
            PhotonNetwork.LeaveRoom();
            }
        ActivateMyPannel(LobbyPannel.name);

        }
    public override void OnLeftLobby()
        {
        ClearRoomList();
        roomListData.Clear();
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
        ActivateMyPannel(insideRoomPanel.name);

        if(PlayerListGameobject== null)
            {
            PlayerListGameobject=new Dictionary<int, GameObject>();
            }

        if (PhotonNetwork.IsMasterClient)
            {
            PlayButton.SetActive(true);
            }
        else
            {
            PlayButton.SetActive(false);
            }
        foreach (Player p in PhotonNetwork.PlayerList)
            {
            /* GameObject playerListItem = Instantiate(playerListItemPrefab, this.transform.position, Quaternion.identity);
             playerListItem.transform.SetParent(playerListItemParent.transform);
             playerListItem.transform.localScale=Vector3.one;*/

            /*GameObject playerListItem = Instantiate(playerListItemPrefab, new Vector3(transform.position.x*1.0F, transform.position.y*1, transform.position.z), Quaternion.identity);
            playerListItem.transform.parent=playerListItemParent.transform;*/

            /*playerListItem.transform.position=new Vector3(550, 255, 0);*/

            Vector3 position = new Vector3(0, 0, 0);
            GameObject playerListItem = Instantiate(playerListItemPrefab);
            playerListItem.transform.position=playerListItemParent.transform.position;
            playerListItem.transform.parent=playerListItemParent.transform;

            playerListItem.transform.GetChild(1).gameObject.SetActive(true);
            if (p.ActorNumber==PhotonNetwork.LocalPlayer.ActorNumber)
                {
                playerListItem.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text=p.NickName;

                }
            else
                { 
                playerListItem.transform.GetChild(1).gameObject.SetActive(false);
                }
            PlayerListGameobject.Add(p.ActorNumber, playerListItem);
            }
        }

    public override void OnPlayerEnteredRoom(Player newPlayer)
        {
        Vector3 position = new Vector3(0, 0, 0);
        GameObject playerListItem = Instantiate(playerListItemPrefab);
        playerListItem.transform.position=playerListItemParent.transform.position;
        playerListItem.transform.parent=playerListItemParent.transform;

        /* GameObject playerListItem = Instantiate(playerListItemPrefab, this.transform.position, Quaternion.identity);
         playerListItem.transform.SetParent(playerListItemParent.transform);
         playerListItem.transform.localScale=Vector3.one;*/

        playerListItem.transform.GetChild(1).gameObject.SetActive(true);
        if (newPlayer.ActorNumber==PhotonNetwork.LocalPlayer.ActorNumber)
            {
            playerListItem.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text=newPlayer.NickName;

            }
        else
            {
            playerListItem.transform.GetChild(1).gameObject.SetActive(false);
            }
        PlayerListGameobject.Add(newPlayer.ActorNumber, playerListItem);
        }

    public override void OnPlayerLeftRoom(Player otherPlayer)
        {
        Destroy(PlayerListGameobject[otherPlayer.ActorNumber]);
        PlayerListGameobject.Remove(otherPlayer.ActorNumber);
        if (PhotonNetwork.IsMasterClient)
            {
            PlayButton.SetActive(true);
            }
        else
            {
            PlayButton.SetActive(false);
            }
        }

    public void OnClickPlayButton()
        {
        if (PhotonNetwork.IsMasterClient)
            {
            PhotonNetwork.LoadLevel("MultiplayerScene");
            }
        else
            {
            Debug.Log("Online masterclient can load scene");
            }
            
        }

    public override void OnLeftRoom()
        {
        ActivateMyPannel(LobbyPannel.name);
        foreach (GameObject obj in PlayerListGameobject.Values)
            {
            Destroy(obj);
            }
        }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
        ClearRoomList();
        foreach (RoomInfo rooms in roomList)
            {
            Debug.Log("Room Names: "+rooms.Name);
            if (!rooms.IsOpen||!rooms.IsVisible||rooms.RemovedFromList)
                {
                if (roomListData.ContainsKey(rooms.Name))
                    {
                    roomListData.Remove(rooms.Name);
                    }
                }
            else
                {
                if (roomListData.ContainsKey(rooms.Name))
                    {//Update List
                    roomListData[rooms.Name]=rooms;
                    }
                else
                    {
                    roomListData.Add(rooms.Name, rooms);
                    }
                }
            }
        foreach (RoomInfo roomItem in roomListData.Values)
            {
            /*GameObject roomListItemObject = Instantiate(roomListPrefab, this.transform.position, Quaternion.identity);
            roomListItemObject.transform.SetParent(roomListParent.transform);
            roomListItemObject.transform.localScale=Vector3.one;*/

            Vector3 position = new Vector3(1, 1, 1);
            GameObject roomListItemObject = Instantiate(roomListPrefab);
            roomListItemObject.transform.position=roomListParent.transform.position;
            roomListItemObject.transform.parent=roomListParent.transform;


            //RoomName PlayerNo JoinButton

            roomListItemObject.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text=roomItem.Name;
            roomListItemObject.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text=roomItem.PlayerCount+"/"+roomItem.MaxPlayers; ;
            roomListItemObject.transform.GetChild(2).gameObject.GetComponent<Button>().onClick.AddListener(() => RoomJoinFromList(roomItem.Name));
            roomListGameobject.Add(roomItem.Name, roomListItemObject);
            }
        }
    public void RoomJoinFromList(string roomName)
        {
        if (PhotonNetwork.InLobby)
            {
            PhotonNetwork.LeaveLobby();
            PhotonNetwork.JoinRoom(roomName);
            }
        }
    public void ClearRoomList()
        {
        if (roomListGameobject.Count>0)
            {
            foreach (var v in roomListGameobject.Values)
                {
                Destroy(v);
                }
            roomListGameobject.Clear();
            }
        }
    public void ActivateMyPannel(string PannelName)
        {
        PlayerNamePannel.SetActive(PannelName.Equals(PlayerNamePannel.name));
   /*     RoomPannel.SetActive(PannelName.Equals(RoomPannel.name));
        RoomList.SetActive(PannelName.Equals(RoomList.name));*/
        LobbyPannel.SetActive(PannelName.Equals(LobbyPannel.name));
        ShowRoomList.SetActive(PannelName.Equals(ShowRoomList.name));
        ConnectingPannel.SetActive(PannelName.Equals(ConnectingPannel.name));
        CreateRoomPannel.SetActive(PannelName.Equals(CreateRoomPannel.name));
        insideRoomPanel.SetActive(PannelName.Equals(insideRoomPanel.name));
        }
    }

