/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.InputSystem;

public class PlayerSetup : MonoBehaviourPunCallbacks
    {
    [SerializeField] GameObject[] localPlayerItems;
    [SerializeField] GameObject[] remotePlayerItems;
    [SerializeField] GameObject PlayerCanvas;
    [SerializeField] GameObject EnemyCanvas;



    //public GameObject prefab;
    // Start is called before the first frame update
    void 
        {
        *//* var inp = InputSystem.devices;*//*
      

        if (photonView.IsMine)//local
            {
            foreach (GameObject g in localPlayerItems)
                {
                g.SetActive(true);
               
                }
            foreach (GameObject g in remotePlayerItems)
                {
                g.SetActive(false);
           
                }
            EnemyCanvas.SetActive(false);
            PlayerCanvas.SetActive(true);
          


            }
        else//remote
            {
            foreach (GameObject g in localPlayerItems)
                {
                g.SetActive(false);
            

                }
            foreach (GameObject g in remotePlayerItems)
                {
                g.SetActive(true);
               
                }
            PlayerCanvas.SetActive(false);
            EnemyCanvas.SetActive(true);
          


            }
       
        }
    }

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.InputSystem;

public class PlayerSetup : MonoBehaviourPunCallbacks
    {
    [SerializeField] GameObject[] localPlayerItems;
    [SerializeField] GameObject[] remotePlayerItems;
 



    //public GameObject prefab;
    // Start is called before the first frame update
    void Start()
        { 
        if (photonView.IsMine)//local
            {
            foreach (GameObject g in localPlayerItems)
                {
                g.SetActive(true);

                }
            foreach (GameObject g in remotePlayerItems)
                {
                g.SetActive(false);

                }
            


            }
        else//remote
            {
            foreach (GameObject g in localPlayerItems)
                {
                g.SetActive(false);


                }
            foreach (GameObject g in remotePlayerItems)
                {
                g.SetActive(true);

                }
            }
        }
    }

 