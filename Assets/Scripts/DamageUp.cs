using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUp : MonoBehaviour
{
    [SerializeField] bulletProjectile targetWeapon;
    public void DamageUpBuff() {
        targetWeapon.SetDamage(targetWeapon.GetDamage() + 5);
    }
    
}
