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

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Torch"))
        {
            var torchScript = other.gameObject.GetComponent<Torch>();

            if (torchScript.isLit)
            {
                detectionRange = 6;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Torch"))
        {
            detectionRange = 3;
        }
    }
}
