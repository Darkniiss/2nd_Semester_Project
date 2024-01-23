using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : AEnemyStates
{
    private float timePassed;
    public AttackState(EnemyStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
    }

    public override void EnterState()
    {
        timePassed = 0f;
        stateMachine.Agent.speed = stateMachine.Enemy.attackSpeed;
    }

    public override void UpdateState()
    {
        timePassed += Time.deltaTime;
        Attack();
    }

    public override AEnemyStates CheckState()
    {
        if(stateMachine.Enemy.DistanceToPlayer > stateMachine.Enemy.attackRange)
        {
            return new ChaseState(stateMachine);
        }
        return null;
    }

    public override void ExitState()
    {
        
    }

    private void Attack()
    {
        if(timePassed >= stateMachine.Enemy.attackFrequency)
        {
            stateMachine.PlayerHealth.CurHealth--;
            timePassed = 0f;
        }
    }
}