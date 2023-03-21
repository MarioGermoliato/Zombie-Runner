using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoAmount;
    [SerializeField] AmmoType ammoType;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Ammo playerAmmo = other.GetComponent<Ammo>();
            playerAmmo.IncreaseAmmo(ammoType, ammoAmount);           
            Destroy(gameObject);
        }
    }
}
