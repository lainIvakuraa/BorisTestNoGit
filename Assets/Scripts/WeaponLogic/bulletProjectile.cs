using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// логика движения пули
public class bulletProjectile : MonoBehaviour
{
    Vector3 direction; // направление движения
    [SerializeField] float speed; // скорость пули
    public int damage = 5; // урон пули
    [SerializeField] float Range; // дальность пули
    bool hitDetected = false; // флаг попадания по противнику
    
    Enemy closetsEnemy; // переменная самого близкого врага
    
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
    // движение пули каждый кадр
    void Update() {
        Vector2 BulletDirection = direction - this.transform.position;
        transform.right = direction;
        GetComponent<Rigidbody2D>().velocity = BulletDirection.normalized * speed;
        //transform.position += direction.normalized * speed * Time.deltaTime;
        //Debug.Log(direction.normalized);
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
        if (hitDetected == true) {
        Destroy(gameObject);
        }
        }
    }
}
