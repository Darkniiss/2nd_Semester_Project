using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AEnemyStates : MonoBehaviour
{
    protected EnemyStateMachine stateMachine;
    protected EnemyBehavior enemy;

    public virtual void EnterState() { }

    public virtual void UpdateState() { }

    public virtual void ExitState() { }

    public virtual AEnemyStates CheckState() { return null; }
}
