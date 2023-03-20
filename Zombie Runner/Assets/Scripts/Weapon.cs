using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] int weaponDamage = 10;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] AmmoType ammoType;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] float weaponDelay;

    bool cantFire;

    private void OnEnable()
    {
        cantFire = false;
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0 && !cantFire)
        {
            PlayMuzzleFlash();
            ProcessRayCast();
            ammoSlot.SpendAmmo(ammoType);
            StartCoroutine(WeaponDelay());
        }
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRayCast()
    {
        RaycastHit hit;        
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target != null)
            {
                target.TakeDamage(weaponDamage);
            }

        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
       GameObject spark = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(spark, 0.1f);
    }

    IEnumerator WeaponDelay()
    {
        cantFire = true;
        yield return new WaitForSeconds(weaponDelay);
        cantFire = false;
    }
}
