using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;

    public void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Walk(bool move)
    {
        anim.SetBool(AnimationTags.MOVEMENT, move);
    }

    public void Punch_1()
    {
        anim.SetTrigger(AnimationTags.PUNCH_1_TRIGGER);
    }

    public void Punch_2()
    {
        anim.SetTrigger(AnimationTags.PUNCH_2_TRIGGER);
    }

    public void Punch_3()
    {
        anim.SetTrigger(AnimationTags.PUNCH_3_TRIGGER);
    }

    public void Kick_1()
    {
        anim.SetTrigger(AnimationTags.KICK_1_TRIGGER);
    }

    public void Kick_2()
    {
        anim.SetTrigger(AnimationTags.KICK_2_TRIGGER);
    }

    //-------------------------------------------------------------------------
    public void EnemyAttack(int attack)
    {
        if (attack == 0)
        {
            anim.SetTrigger(AnimationTags.ATTACK_1_TRIGGER);
        }
        if (attack == 1)
        {
            anim.SetTrigger(AnimationTags.ATTACK_2_TRIGGER);
        }
        if (attack == 2)
        {
            anim.SetTrigger(AnimationTags.ATTACK_2_TRIGGER);
        }
    }

    public void Play_idleAnimation()
    {
        anim.Play(AnimationTags.IDLE_ANIMATION);
    }

    public void KnockDown()
    {
        anim.Play(AnimationTags.KNOCK_DOWN_TRIGGER);
    }

    public void StandUP()
    {
        anim.Play(AnimationTags.STAND_UP_TRIGGER);
    }

    public void Hit()
    {
        anim.Play(AnimationTags.HIT_TRIGGER);
    }

    public void Death()
    {
        anim.Play(AnimationTags.DEATH_TRIGGER);
    }
}
