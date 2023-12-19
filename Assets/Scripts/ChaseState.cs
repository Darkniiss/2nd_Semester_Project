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
    }

    public override void UpdateState()
    {
        stateMachine.Agent.SetDestination(stateMachine.Player.transform.position);
    }

    public override AEnemyStates CheckState()
    {
        if(stateMachine.Enemy.distanceToPlayer > stateMachine.Enemy.detectionRange)
        {
            return new PatrolState(stateMachine);
        }
        return null;
    }

    public override void ExitState()
    {
       
    }
}
