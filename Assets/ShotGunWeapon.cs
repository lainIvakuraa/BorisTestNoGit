using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunWeapon : WeaponBase
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float spread = 0.5f;
    GameObject closestEnemy; // переменная самого близкого врага
    Vector3 direction; // направление противника
    Vector3 bulletDirection; // направление пули

    public void SetEnemyDirection() { //выбор цели для пули
        GameObject[] NearEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        closestEnemy = FindClosestEnemy(this.transform.position, NearEnemies);
        if (closestEnemy == null) {
            bulletDirection = new Vector3(Random.Range(-5f, 5.0f),  Random.Range(-5f, 5.0f), 0);
            Debug.Log(bulletDirection);
        } else {
            bulletDirection = closestEnemy.transform.position;
        }
        
    }
    private GameObject FindClosestEnemy(Vector3 playerPosition, GameObject[] enemies) 
    {
        if (enemies != null) {
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

            for (int i = 0; i < enemies.Length; i++) {
                float distance = Vector3.Distance(playerPosition, enemies[i].transform.position);
    
                if (distance < closestDistance)
                {
                    closestEnemy = enemies[i];
                    closestDistance = distance;
                }
            }
            return closestEnemy;
        } else return null;
    }

    public override void Attack() {
        SetEnemyDirection();
        if (weaponStats.numberOfAttacks > 1) {
            for (int i = 0; i < weaponStats.numberOfAttacks; i++) {
                
                GameObject shotBullet = Instantiate(bulletPrefab);
                //multiple bullets
                Vector3 newBulltPosition = bulletDirection;
                newBulltPosition.y -= (spread * (weaponStats.numberOfAttacks - 1)) / 2; // calculating offset
                newBulltPosition.y += i * spread; // spreading bullets along the line
                shotBullet.transform.position = transform.position;

                bulletProjectile bulletProjectileCurrent = shotBullet.GetComponent<bulletProjectile>();
                bulletProjectileCurrent.SetDirection(newBulltPosition); //FindObjectOfType<Charachter>().transform.position
                bulletProjectileCurrent.damage = weaponStats.damage;
                bulletProjectileCurrent.SetHitCount(weaponStats.pierceCount);
            }
        } else {
            GameObject shotBullet = Instantiate(bulletPrefab);
            shotBullet.transform.position = transform.position;

            bulletProjectile bulletProjectileCurrent = shotBullet.GetComponent<bulletProjectile>();
            bulletProjectileCurrent.SetDirection(bulletDirection); //FindObjectOfType<Charachter>().transform.position
            bulletProjectileCurrent.SetHitCount(weaponStats.pierceCount);
            bulletProjectileCurrent.SetDamage(weaponStats.damage);
        }
    }
    
}