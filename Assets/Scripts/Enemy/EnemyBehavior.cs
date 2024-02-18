using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float patrolSpeed;
    public float chaseSpeed;
    public float attackWait;
    public float detectionRange;
    public float attackRange;
    public float DistanceToPlayer { get; private set; }
    public Animator enemyAnim;

    [SerializeField] private PlayerController playerCon;

    private void Awake()
    {
        enemyAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        DistanceToPlayer = (gameObject.transform.position - playerCon.transform.position).magnitude;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("LightSource"))
        {
            var torchScript = other.gameObject.GetComponent<LightSource>();

            if (torchScript.isLit)
            {
                detectionRange = 10;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("LightSource"))
        {
            detectionRange = 5;
        }
    }
}
