using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviourPun
    {
    private Rigidbody playerRigidbody;
    private Vector2 movementInput;

    private void Start()
        {
        playerRigidbody=GetComponent<Rigidbody>();
        }

    private void Update()
        {
        if (photonView.IsMine)
            {
            // Handle player movement
            Vector3 movement = new Vector3(movementInput.x, 0f, movementInput.y);
            playerRigidbody.velocity=movement*5f;

            // Call the method to update the state of all players
            photonView.RPC("UpdatePlayerState", RpcTarget.Others, transform.position, transform.rotation);
            }
        }

    private void OnMovement(InputValue value)
        {
        movementInput=value.Get<Vector2>();
        }

    [PunRPC]
    private void UpdatePlayerState(Vector3 position, Quaternion rotation)
        {
        if (!photonView.IsMine)
            {
            // Update the state of the remote player
            transform.position=position;
            transform.rotation=rotation;
            Debug.Log("UpdateplayerState main gaya");
            }
        }
    }