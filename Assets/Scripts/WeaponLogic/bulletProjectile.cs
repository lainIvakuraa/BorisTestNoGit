using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// логика движения пули
public class bulletProjectile : MonoBehaviour
{
    Vector3 direction; // направление движения
    [SerializeField] float speed; // скорость пули
    public int damage = 5; // урон пули
     float Range = 6; // дальность пули
    bool hitDetected = false; // флаг попадания по противнику
    Vector3 bulletDirection;
    Vector3 shotStart;
    
    public int GetDamage() { 
        return damage;
    }
    public void SetDamage(int settetDamage) {
        damage = settetDamage;
    }
    
    public void SetDirection(Vector3 direction) { //выбор цели для пули
        this.direction = direction;
    }
    
    private void Start() {
        bulletDirection = direction - this.transform.position;
        shotStart = this.transform.position;
    }
    // движение пули каждый кадр
    void Update() {
        transform.right = direction;
        GetComponent<Rigidbody2D>().velocity = bulletDirection.normalized * speed;
        
        if (Vector3.Distance(shotStart, transform.position) > Range) {
            Destroy(gameObject);
        }
        
    }
    void FixedUpdate() {
        if (Time.frameCount % 2 == 0) {
        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 0.1f);
        foreach(Collider2D c in hit) {
            Enemy enemy = c.GetComponent<Enemy>();
            if (enemy != null) {
                enemy.TakeDamage(damage);
                hitDetected = true;
                break;
            }
        }
        if (hitDetected == true) {
                Destroy(gameObject);
            }
        }
    }
}
