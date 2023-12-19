using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float patrolSpeed;
    public float chaseSpeed;
    public float detectionRange;
    public float distanceToPlayer;

    [SerializeField] private EnemyStateMachine stateMachine;

    private void Update()
    {
        distanceToPlayer = (gameObject.transform.position - stateMachine.Player.transform.position).magnitude;
    }
}
