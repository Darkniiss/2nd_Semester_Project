using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float patrolSpeed;
    public float chaseSpeed;
    public float attackSpeed;
    public float attackFrequency;
    public float detectionRange;
    public float attackRange;
    public float DistanceToPlayer { get; private set; }
    public Animator enemyAnim;

    [SerializeField] private PlayerController Player;

    private void Awake()
    {
        enemyAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        DistanceToPlayer = (gameObject.transform.position - Player.transform.position).magnitude;
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
