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
        stateMachine.agent.speed = stateMachine.enemy.chaseSpeed;
        stateMachine.enemy.enemyAnim.SetBool("IsChasing", true);
    }

    public override void UpdateState()
    {
        stateMachine.agent.SetDestination(stateMachine.playerCon.transform.position);
    }

    public override AEnemyStates CheckState()
    {
        if(stateMachine.enemy.DistanceToPlayer > stateMachine.enemy.detectionRange)
        {
            return new PatrolState(stateMachine);
        }
        else if(stateMachine.enemy.DistanceToPlayer <= stateMachine.enemy.attackRange)
        {
            return new AttackState(stateMachine);
        }
        return null;
    }

    public override void ExitState()
    {
        stateMachine.enemy.enemyAnim.SetBool("IsChasing", false);
    }
}
