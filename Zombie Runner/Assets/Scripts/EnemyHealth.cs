using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    EnemyAI enemyAI;

   
    public void TakeDamage(int damageAmount)
    {
        BroadcastMessage("GetProvoked");
         hitPoints -= damageAmount;
        Debug.Log(hitPoints);
        if(hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
