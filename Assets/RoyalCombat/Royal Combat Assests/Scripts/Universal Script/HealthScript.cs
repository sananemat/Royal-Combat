using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
    {
    public float health = 100f;
    private PlayerAnimation animationScript;
    private EnemyMovement enemymovement;
    private bool characterDied;
    public bool is_Player, is_Enemy;
    private HealthUI health_UI;
    private DecideWinner winStatus;
  


    void Awake()
        {
        animationScript=GetComponentInChildren<PlayerAnimation>();

        health_UI=GetComponent<HealthUI>();

        winStatus=GetComponent<DecideWinner>();
      



        }

    public void ApplyDamage(float damage, bool KnockDown)
        {
        if (characterDied)
            return;

        health-=damage;


        if (is_Player)
            {
            health_UI.DisplayHealth(health);
            }
        else
            {
            health_UI.EnemyDisplayHealth(health);
            }


        if (health<=0f||health==0)
            {
            animationScript.Death();
            characterDied=true;

            if (is_Player)//if is player deactivate enemy script
                {
                GameObject.FindWithTag(Tags.ENEMY_TAG).GetComponent<EnemyMovement>().enabled=false;
                winStatus.Setloser();
           
                }
            else
                {
                GameObject.FindWithTag(Tags.ENEMY_TAG).GetComponent<EnemyMovement>().enabled=false;
                winStatus.SetWinner();
                
                }
            }
        if (!is_Player)
            {
            if (KnockDown)
                {
                if (Random.Range(0, 2)>0)
                    {
                    animationScript.KnockDown();
                    }
                }
            else
                {
                if (Random.Range(0, 3)>1)
                    {
                    animationScript.Hit();
                    }
                }
            }
        }

    }

