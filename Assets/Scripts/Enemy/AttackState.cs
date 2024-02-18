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
        stateMachine.agent.speed = 0f;
        stateMachine.enemy.enemyAnim.SetBool("IsInAttackRange", true);

    }

    public override void UpdateState()
    {
        timePassed += Time.deltaTime;
        Attack();
    }

    public override AEnemyStates CheckState()
    {
        if (stateMachine.enemy.DistanceToPlayer > stateMachine.enemy.attackRange)
        {
            return new ChaseState(stateMachine);
        }
        if (!stateMachine.playerHealth.isAlive && timePassed > 0.6f)
        {
            return new PatrolState(stateMachine);
        }
        return null;
    }

    public override void ExitState()
    {
        stateMachine.enemy.enemyAnim.SetBool("IsInAttackRange", false);
        stateMachine.enemy.enemyAnim.SetBool("IsAttacking", false);
    }

    private void Attack()
    {
        if (timePassed >= stateMachine.enemy.attackWait)
        {
            stateMachine.enemy.enemyAnim.SetBool("IsAttacking", true);
            stateMachine.playerHealth.TakeDamage();
            timePassed = 0f;
        }
    }
}
