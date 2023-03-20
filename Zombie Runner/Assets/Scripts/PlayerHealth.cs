using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int healthPoints = 100;
    DeathHandler deathHandler;

    private void Start()
    {
        deathHandler = GetComponent<DeathHandler>();
    }


    public void TakeDamage(int damage)
    {
        healthPoints -= damage;
        Debug.Log($"You suffer {damage} points of damage ");

        if(healthPoints <= 0)
        {
            deathHandler.HandleDeath();
        }
    }
}
