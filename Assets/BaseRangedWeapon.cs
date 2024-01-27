using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRangedWeapon : MonoBehaviour
{
    [SerializeField] GameObject projectile, firePoint;
    [SerializeField] GameObject weaponSprite;

    public void Attack()
    {
        Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation);
    }
}
