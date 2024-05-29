using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
// логика движения пули
public class WaveProjectile : MonoBehaviour
{
    Vector3 direction; // направление движения
    [SerializeField] float speed; // скорость пули
    public int damage = 5; // урон пули
    [SerializeField] float Range = 10.0f; // длина лучей в обе стороны
    Enemy closetsEnemy; // переменная самого близкого врага
    Vector3 bulletDirection;
    Vector3 shotStart;

    int lifeTime = 0;
    
    public int GetDamage() { 
        return damage;
    }
    public void SetDamage(int settetDamage) {
        damage = settetDamage;
    }
    public void SetDirection() { //выбор цели для пули
        var playerPos = GameObject.FindWithTag("Player");
            direction = new Vector3(playerPos.transform.position.x,
                0,
                playerPos.transform.position.z);

        lifeTime = 50;

     }   
    private void Start() {
        bulletDirection = direction - this.transform.position;
        shotStart = this.transform.position;
        this.transform.localScale = new Vector3(Range,
            this.transform.localScale.y, this.transform.localScale.z);
    }
    // движение пули каждый кадр
    void Update() {
        transform.right = direction;
        GetComponent<Rigidbody2D>().velocity = bulletDirection.normalized * speed;


        if (lifeTime <= 0) {
            Destroy(gameObject);
        }
        else
        {
            lifeTime--;
        }
        
    }
    void FixedUpdate() {
        if (Time.frameCount % 2 == 0) {
            var playerPos = GameObject.FindWithTag("Player").transform.position;

            Collider2D[] hit = Physics2D.OverlapCapsuleAll(playerPos,//transform.position,
                new Vector2(3.0f, 0.5f), CapsuleDirection2D.Horizontal,
                0.0f);

            foreach (Collider2D c in hit) {
            Enemy enemy = c.GetComponent<Enemy>();
            if (enemy != null) {
                enemy.TakeDamage(damage);
                break;
            }
        }
        }
    }
}

