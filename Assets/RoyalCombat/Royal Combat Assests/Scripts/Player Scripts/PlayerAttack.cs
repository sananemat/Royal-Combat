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



    private PlayerAnimation player_Animation;
  
      
  
    // Start is called before the first frame update
    void Awake()
    {
        
       
        player_Animation = GetComponentInChildren<PlayerAnimation>();    
    }

    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void ComboAttacksOnClick(){
   
         player_Animation.Punch_1();
      
      }

    public void Kick1AttackOnCLick()
    {
            player_Animation.Kick_1();
       }

    public void Kick2AttackOnCLick()
    {
        player_Animation.Kick_2();
    }


}