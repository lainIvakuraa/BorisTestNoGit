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
    
    Enemy closetsEnemy; // переменная самого близкого врага

    Vector3 bulletDirection;
    Vector3 shotStart;
    
    public int GetDamage() { 
        return damage;
    }
    public void SetDamage(int settetDamage) {
        damage = settetDamage;
    }
    public void SetDirection() { //выбор цели для пули
        
        if (FindObjectsOfType<Enemy>() == null) {
            direction = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
        } else {
        var NearEnemies = FindObjectsOfType<Enemy>();
        closetsEnemy = FindClosestEnemy(this.transform.position, NearEnemies);
        
        direction = closetsEnemy.transform.position;
        }
        
    }
    // поиск ближайшего врага
    private Enemy FindClosestEnemy(Vector3 playerPosition, IEnumerable<Enemy> enemies) 
    {
        Enemy closestEnemy = null;
        float closestDistance = Mathf.Infinity;
 
        foreach (Enemy enemy in enemies) {
        float distance = Vector3.Distance(playerPosition, enemy.transform.position);
 
       if (distance < closestDistance)
      {
           closestEnemy = enemy;
           closestDistance = distance;
       }
   }
   return closestEnemy;
}
    private void Start() {
        bulletDirection = direction - this.transform.position;
        shotStart = this.transform.position;
    }
    // движение пули каждый кадр
    void Update() {
        transform.right = direction;
        GetComponent<Rigidbody2D>().velocity = bulletDirection.normalized * speed;
        if (Time.frameCount % 6 == 0) {
        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 0.1f);
        foreach(Collider2D c in hit) {
            Enemy enemy = c.GetComponent<Enemy>();
            if (enemy != null) {
                enemy.TakeDamage(damage);
                hitDetected = true;
                break;
            }
        }
        if (Vector3.Distance(shotStart, transform.position) > Range) {
            Destroy(gameObject);
        }
        if (hitDetected == true) {
        Destroy(gameObject);
        }
        }
    }
}
