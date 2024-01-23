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

        stateMachine.Agent.speed = stateMachine.Enemy.patrolSpeed;

        foreach (Transform waypoint in stateMachine.Waypoints) 
        {
            queue.Enqueue(waypoint);
        }

        stateMachine.Agent.SetDestination(queue.Peek().position);
        stateMachine.Enemy.EnemyAnim.SetBool("IsRunning", true);
    }

    public override void UpdateState()
    {
        if(stateMachine.Agent.remainingDistance == 0f)
        {
            queue.Enqueue(queue.Dequeue());
        }

        stateMachine.Agent.SetDestination(queue.Peek().position);
    }

    public override AEnemyStates CheckState()
    {
        if(stateMachine.Enemy.DistanceToPlayer <= stateMachine.Enemy.detectionRange)
        {
            return new ChaseState(stateMachine);
        }
        return null;
    }

    public override void ExitState()
    {
        stateMachine.Enemy.EnemyAnim.SetBool("IsRunning", false);
    }
}
