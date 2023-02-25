using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttackAnimation : MonoBehaviour
{
    public GameObject Left_Hand_Attack_Point,
    Right_Hand_Attack_Point,
    Left_Leg_Attack_Point,

    Right_Leg_Attack_Point;

    public float stand_UP_Timer = 2f;
    private  PlayerAnimation animationScript;
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip Whoosh, PlayerKnockDown, Drop, PlayerDeath;

    private EnemyMovement enemyMovement;

    private ShakeCamera shakeCamera;

     void Awake() {
       animationScript = GetComponent<PlayerAnimation>();
        audioSource= GetComponent<AudioSource>();

        if (gameObject.CompareTag(Tags.ENEMY_TAG))
            {
            enemyMovement= GetComponentInParent<EnemyMovement>();
            }
        shakeCamera=GameObject.FindWithTag(Tags.MAIN_CAMERA_TAG).GetComponent<ShakeCamera>();
    }
    
    public void Left_Arm_Attack_On()
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
    void TagLeft_Arm()
    {
        Left_Hand_Attack_Point.tag = Tags.LEFT_ARM_TAG;
    }
    void UnTagLeft_Arm()
    {
         Left_Hand_Attack_Point.tag = Tags.UNTAGGED_TAG;
    }

     void TagLeft_leg()
    {
        Left_Leg_Attack_Point.tag = Tags.LEFT_LEG_TAG;
    }
    void UnTagLeft_legs()
    {
         Left_Leg_Attack_Point.tag = Tags.UNTAGGED_TAG;
    } 

    void Enemy_StandUp()
    {
        StartCoroutine(StandUpAfterTime());
    }
    IEnumerator StandUpAfterTime()
    {
        yield return new WaitForSeconds(stand_UP_Timer);
        animationScript.StandUP();  

    }

    public void Attack_FX_Sound()
        {
        audioSource.volume=0.2f;
        audioSource.clip=Whoosh;
        audioSource.Play();
        }
    public void CharacterDiedSound()
        {
        audioSource.volume=1f;
        audioSource.clip=PlayerDeath;
        audioSource.Play();
        }
    public void Enemy_KnockedDown()
        {
        audioSource.clip=PlayerKnockDown;
        audioSource.Play();
        }
    public void Hit_Ground()
        {
        audioSource.clip=Drop;
        audioSource.Play();
        }
    public void DisableMovement()
        {
        enemyMovement.enabled=false;

        //set enemy parent to default layer
        transform.parent.gameObject.layer=0;

        }
    public void EnableMovement()
        {
       
        enemyMovement.enabled=true;

        //set enemy parent to enemy layer
        transform.parent.gameObject.layer=6;
        }

    void ShakeCameraOnFall()
        {
        shakeCamera.ShouldShake=true;
        }

    void CharaterDied()
        {
         Invoke("DeactivateGameObject", 2f);
        }

    void DeactivateGameObject()
        {
        gameObject.SetActive(false);
        }
    }
