using UnityEngine;
using Photon.Pun;

public class SyncAnimator : MonoBehaviour, IPunObservable
    {
    private Animator animator;

    private int baseLayerIndex;

    private bool isAnimating;
    private float currentNormalizedTime;

    private void Awake()
        {
        animator=GetComponent<Animator>();
        baseLayerIndex=animator.GetLayerIndex("Base Layer");
        }

    private void Update()
        {
        // Update the local animator based on user input or other game logic
        // ...

        if (animator)
            {
            // Update isAnimating and currentNormalizedTime from the local animator's base layer
            isAnimating=animator.GetBool("Movement");
            currentNormalizedTime=animator.GetCurrentAnimatorStateInfo(baseLayerIndex).normalizedTime;
            }
        }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
        if (stream.IsWriting)
            {
            // Send the animation state to other players
            stream.SendNext(isAnimating);
            stream.SendNext(currentNormalizedTime);
            }
        else
            {
            // Receive the animation state from the owner and apply it to the animator's base layer
            isAnimating=(bool)stream.ReceiveNext();
            currentNormalizedTime=(float)stream.ReceiveNext();

            if (animator)
                {
                animator.SetBool("Movement", isAnimating);
                animator.Play("Walk", baseLayerIndex, currentNormalizedTime);
                }
            }
        }
    }
