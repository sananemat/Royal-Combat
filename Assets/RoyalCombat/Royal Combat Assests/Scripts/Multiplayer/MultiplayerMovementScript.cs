using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class MultiplayerMovementScript : MonoBehaviour {
   
    public Joystick joystick;
    private RigidbodyFirstPersonController rigidbodyFirstPersonController;
    private Animator playerAnimator;
    private PlayerAnimation player_Animation;
// Start is called before the first frame update
void Start()
    {
        rigidbodyFirstPersonController=GetComponent<RigidbodyFirstPersonController>();
        playerAnimator=GetComponentInChildren<Animator>();
   player_Animation=GetComponentInChildren<PlayerAnimation>();
        }
  
  
    // Update is called once per frame
    void FixedUpdate()
    {
     

        if (rigidbodyFirstPersonController!=null)
            {
            rigidbodyFirstPersonController.joystickInputAxis.x=joystick.Horizontal; // 0 to 1  
            rigidbodyFirstPersonController.joystickInputAxis.y=joystick.Vertical;
            }

        if (joystick.Horizontal!=0||joystick.Horizontal!=0)
            {
            player_Animation.Walk(true);
            }
        else
            {
            player_Animation.Walk(false);
            }
            





        }
        }
