using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricField1 : WeaponBase
{
    [SerializeField] float attack;
    private SpriteRenderer sprRend;
    int damage;
    float attackAreaSize;
    public override void Attack() {
        attackAreaSize = weaponStats.bulletRange;
        sprRend = GetComponent<SpriteRenderer>();
        sprRend.color = new Color(1f,1f,1f,.3f);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackAreaSize);
        sprRend.size = new Vector2(attackAreaSize * 2, attackAreaSize * 2);
        ApplyDamage(colliders);
    }
}
