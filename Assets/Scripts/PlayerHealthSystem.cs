using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    public float MaxHealth {  get; private set; }
    public float CurHealth;
    private float maxHealth = 3f;

    private void Start()
    {
        MaxHealth = maxHealth;
        CurHealth = maxHealth;
    }

    private void Update()
    {
        if(CurHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
