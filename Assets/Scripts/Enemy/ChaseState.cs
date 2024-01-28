using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : AEnemyStates
{
    public ChaseState(EnemyStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
    }

    public override void EnterState()
    {
        stateMachine.Agent.speed = stateMachine.Enemy.chaseSpeed;
        stateMachine.Enemy.enemyAnim.SetBool("IsChasing", true);
    }

    public override void UpdateState()
    {
        stateMachine.Agent.SetDestination(stateMachine.PlayerCon.transform.position);
    }

    public override AEnemyStates CheckState()
    {
        if(stateMachine.Enemy.DistanceToPlayer > stateMachine.Enemy.detectionRange)
        {
            return new PatrolState(stateMachine);
        }
        else if(stateMachine.Enemy.DistanceToPlayer <= stateMachine.Enemy.attackRange)
        {
            return new AttackState(stateMachine);
        }
        return null;
    }

    public override void ExitState()
    {
        stateMachine.Enemy.enemyAnim.SetBool("IsChasing", false);
    }
}
