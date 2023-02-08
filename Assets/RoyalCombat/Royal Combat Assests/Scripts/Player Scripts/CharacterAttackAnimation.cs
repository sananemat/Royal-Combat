using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttackAnimation : MonoBehaviour
{
    public GameObject Left_Hand_Attack_Point,
    Right_Hand_Attack_Point,
    Left_Leg_Attack_Point,
    Right_Leg_Attack_Point;
    
 public   void Left_Arm_Attack_On()
    {
        Left_Hand_Attack_Point.SetActive(true);
    }
  public   void Left_Arm_Attack_Off()
    {
        if(Left_Hand_Attack_Point.activeInHierarchy)
        {
             Left_Hand_Attack_Point.SetActive(false);
        }
       
    }

   public void Right_Arm_Attack_On()
    {
        Right_Hand_Attack_Point.SetActive(true);
    }
  public   void Right_Arm_Attack_Off()
    {
        if(Right_Hand_Attack_Point.activeInHierarchy)
        {
             Right_Hand_Attack_Point.SetActive(false);
        }
       
    }

   public  void Left_Leg_Attack_On()
    {
        Left_Leg_Attack_Point.SetActive(true);
    }

   public void Left_Leg_Attack_Off()
    {
        if(Left_Leg_Attack_Point.activeInHierarchy)
        {
             Left_Leg_Attack_Point.SetActive(false);
        }
       
    }
   public  void Right_Leg_Attack_On()
    {
    Right_Leg_Attack_Point.SetActive(true);
    }

    public void Right_Leg_Attack_Off()
    {
        if(Right_Leg_Attack_Point.activeInHierarchy)
        {
             Right_Leg_Attack_Point.SetActive(false);
        }
       
    }


}
