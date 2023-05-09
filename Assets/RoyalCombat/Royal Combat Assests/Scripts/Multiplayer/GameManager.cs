using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        if(PhotonNetwork.IsConnectedAndReady)
            {


            /*int playerSpawnposition =Random.Range(9,-0);*/
            Vector3 position = new Vector3(9, 0, -1);
            PhotonNetwork.Instantiate(playerPrefab.name, position, Quaternion.identity);
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
