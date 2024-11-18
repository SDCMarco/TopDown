using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject prefabProjectile;
    public float ejectionProjectileStrength;
    public float shootPerSecond=2;

    public void Shoot()
    {
        GameObject createdProjectile = Instantiate(prefabProjectile);
        createdProjectile.transform.position = gameObject.GetComponentInChildren<ProjectileSpawnPoint>().transform.position;
        createdProjectile.GetComponent<Projectile>().InitializeProjectile(GetHoldingCharacter());

        
        Rigidbody rigidbodyProjectile = createdProjectile.GetComponent<Rigidbody>();
        rigidbodyProjectile.AddForce(transform.forward * ejectionProjectileStrength);
    }

    public Character GetHoldingCharacter()
    {
        return GetComponentInParent<Character>();
    }
    public void StartShoot()
    {
        InvokeRepeating(nameof(Shoot), shootPerSecond, shootPerSecond);
    }

    public void EndShoot()
    {
        CancelInvoke(nameof(Shoot));
    }


}
