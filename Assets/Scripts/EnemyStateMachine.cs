using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public EnemyBehavior Enemy;
    public PlayerController Player;
    public List<Transform> Waypoints;

    private AEnemyStates curState;
    private AEnemyStates newState;

    private void Start()
    {
        //curState = new PatrolState(this);
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
