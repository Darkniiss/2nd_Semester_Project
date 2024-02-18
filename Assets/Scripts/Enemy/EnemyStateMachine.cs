using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine : MonoBehaviour
{
    public EnemyBehavior enemy;
    public PlayerController playerCon;
    public PlayerHealthSystem playerHealth;
    public NavMeshAgent agent;
    public List<Transform> waypoints;

    private AEnemyStates curState;
    private AEnemyStates newState;

    private void Start()
    {
        curState = new PatrolState(this);
        curState.EnterState();
    }

    private void Update()
    {
        newState = curState.CheckState();

        if (newState != null)
        {
            curState.ExitState();
            curState = newState;
            newState.EnterState();
        }

        curState.UpdateState();
    }
}
