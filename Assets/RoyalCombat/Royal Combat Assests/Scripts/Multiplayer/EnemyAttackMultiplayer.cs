using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class EnemyAttackMultiplayer : MonoBehaviour
{
    private PlayerAnimation player_Animation;
    // Start is called before the first frame update
    void Start()
    {
        player_Animation=GetComponentInChildren<PlayerAnimation>();
        }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Punch1AttackOnClick()
        {

        player_Animation.Punch_1();

        }
    public void Punch2AttackOnClick()
        {

        player_Animation.Punch_2();

        }
    public void Punch3AttackOnClick()
        {

        player_Animation.Punch_3();

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
