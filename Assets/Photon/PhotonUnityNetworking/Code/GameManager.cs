using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace Photon.Pun.Demo.PunBasics
    {
#pragma warning disable 649

    public class GameManager : MonoBehaviourPunCallbacks
        {
        [SerializeField] GameObject player;
        [SerializeField] GameObject Enemy;




        // Start is called before the first frame update
        void Start()
            {
        
            if (PhotonNetwork.IsConnectedAndReady)
                {
        

                if (PhotonNetwork.IsMasterClient)//local player
                    {
                    // Create the player instance for the local client
                    Vector3 position = new Vector3(9f, 0.7f, -1f);
                    PhotonNetwork.Instantiate(player.name, position, Quaternion.identity);
                
                    }
                else 
                    {
                    Vector3 enemyposition = new Vector3(3.3f, 0.7f, -1f);
                    PhotonNetwork.Instantiate(Enemy.name, enemyposition, Quaternion.identity);
                 
                    }

                }
            }

            public void LeaveRoom()
                {
                if (PhotonNetwork.InRoom)
                    {
                    PhotonNetwork.LeaveRoom();
                    }
                }
            }
        }
    

    