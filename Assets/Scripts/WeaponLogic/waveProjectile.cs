using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
// логика движения пули
public class WaveProjectile : MonoBehaviour
{
    Vector3 direction; // направление движения
    public int damage = 1; // урон пули
    [SerializeField] float Range = 10.0f; // длина лучей в обе стороны
    Vector3 bulletDirection;
    Vector3 shotStart;
    int lifeTime = 0;
    
    public int GetDamage() { 
        return damage;
    }
    public void SetDamage(int settetDamage) {
        this.damage = settetDamage;
    }
    public void SetRange(int settetRange) {
        this.Range = settetRange;
    }
    public void SetLifetime(int settetLifetime) {
        this.lifeTime = settetLifetime;
    }
    public void SetDirection() {
        var playerPos = GameObject.FindWithTag("Player");
            direction = new Vector3(playerPos.transform.position.x,
                0,
                playerPos.transform.position.z);

        lifeTime = 50;

     }   
    private void Start() {
        this.transform.localScale = new Vector3(Range,
            this.transform.localScale.y, this.transform.localScale.z);
    }
    // движение пули каждый кадр
    void Update() {
        //transform.right = direction;
        var playerPos = GameObject.FindWithTag("Player");
        this.transform.position = playerPos.transform.position;
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

