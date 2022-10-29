using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ComboState{
  NONE,
  PUNCH_1,
  PUNCH_2,
  PUNCH_3,
  KICK_1,
  KICH_2
}
[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerAttack : MonoBehaviour
{
      private bool activateTimerToReset;
      private float default_Combo_Timer = 0.4f;
      private float current_Combo_Timer;
      private ComboState current_Combo_State;
      private PlayerAnimation player_Animation;
  
    // Start is called before the first frame update
    void Awake()
    {
         player_Animation= GetComponentInChildren<PlayerAnimation>();    
    }

    void Start()
    {
      current_Combo_Timer = default_Combo_Timer;
      current_Combo_State = ComboState.NONE;  
        current_Combo_State = (ComboState)1;  
    }




    // Update is called once per frame
    void Update()
    {
        ComboAttacks();
         KickAttack();
        ResetComboState();
       
    }

    public void ComboAttacks(){
      if(Input.GetMouseButton(0))
      {
        current_Combo_State++;
        activateTimerToReset=true;
         current_Combo_Timer = default_Combo_Timer;
        // player_Animation.Punch_1();
        if(current_Combo_State== ComboState.PUNCH_1)
        {
          player_Animation.Punch_1();
        }
         if(current_Combo_State== ComboState.PUNCH_2)
        {
          player_Animation.Punch_2();
        }
       
        if(current_Combo_State== ComboState.PUNCH_3)
        {
          player_Animation.Punch_3();
        }        
      }
    
    }
    public void KickAttack(){
      if(Input.GetMouseButton(0))
      {
        current_Combo_State++;
        activateTimerToReset=true;
         current_Combo_Timer = default_Combo_Timer;
        // player_Animation.Punch_1();
        if(current_Combo_State== ComboState.KICK_1)
        {
          player_Animation.Kick_1();
        }
         
      }
    
     }
    void ResetComboState()
      {
        if(activateTimerToReset)
        {
          current_Combo_Timer -=Time.deltaTime;

          if (current_Combo_Timer <=0f)
          {
            current_Combo_State=ComboState.NONE;
            activateTimerToReset= false;
            current_Combo_Timer=default_Combo_Timer;
          }

        }
      }
}

