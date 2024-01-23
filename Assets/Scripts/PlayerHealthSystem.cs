using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    private Animator playerAnim;
    [SerializeField] private float curHealth;
    [SerializeField] private float maxHealth;

    private void Awake()
    {
        playerAnim = GetComponent<Animator>();
    }

    private void Start()
    {
        curHealth = maxHealth;
    }

    public void TakeDamage()
    {
        curHealth--;
        playerAnim.SetTrigger("HitTrigger");
        if(curHealth <= 0)
        {
            playerAnim.SetBool("IsAlive", false);
        }
    }
}
