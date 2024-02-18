using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : AEnemyStates
{
    private Queue<Transform> queue;

    public PatrolState(EnemyStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
    }

    public override void EnterState()
    {
        queue = new Queue<Transform>();

        stateMachine.agent.speed = stateMachine.enemy.patrolSpeed;

        foreach (Transform waypoint in stateMachine.waypoints) 
        {
            queue.Enqueue(waypoint);
        }

        stateMachine.agent.SetDestination(queue.Peek().position);
        stateMachine.enemy.enemyAnim.SetBool("IsWalking", true);
    }

    public override void UpdateState()
    {
        if(stateMachine.agent.remainingDistance <= 1f)
        {
            
            queue.Enqueue(queue.Dequeue());
        }

        stateMachine.agent.SetDestination(queue.Peek().position);
    }

    public override AEnemyStates CheckState()
    {
        if(stateMachine.enemy.DistanceToPlayer <= stateMachine.enemy.detectionRange && stateMachine.playerHealth.isAlive)
        {
            return new ChaseState(stateMachine);
        }
        return null;
    }

    public override void ExitState()
    {
        stateMachine.enemy.enemyAnim.SetBool("IsWalking", false);
    }
}
