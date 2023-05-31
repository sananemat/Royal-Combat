using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SyncMovement : MonoBehaviour, IPunObservable
    {
    private Vector3 networkPosition;
    private Quaternion networkRotation;
    private Rigidbody rb;
    private PhotonView photonView;

    private void Awake()
        {
        rb=GetComponent<Rigidbody>();
        photonView=GetComponent<PhotonView>();

        }

    private void FixedUpdate()
        {
        if (photonView.IsMine)
            {
            // Update the local movement logic
            // ...

            // Send the movement data to other players
            photonView.RPC("SyncMovementData", RpcTarget.Others, transform.position, transform.rotation);
            }
        else
            {
            // Update the remote player's position and rotation based on received data
            transform.position=Vector3.Lerp(transform.position, networkPosition, Time.fixedDeltaTime*10f);
            transform.rotation=Quaternion.Lerp(transform.rotation, networkRotation, Time.fixedDeltaTime*10f);
            }
        }

    [PunRPC]
    private void SyncMovementData(Vector3 position, Quaternion rotation)
        {
        networkPosition=position;
        networkRotation=rotation;
        }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
        if (stream.IsWriting)
            {
            // Send the movement data to other players
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
            }
        else
            {
            // Receive the movement data from the owner and apply it to the remote player
            networkPosition=(Vector3)stream.ReceiveNext();
            networkRotation=(Quaternion)stream.ReceiveNext();
            }
        }
    }
