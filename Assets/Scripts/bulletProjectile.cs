using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletProjectile : MonoBehaviour
{
    Vector3 direction;
    Vector3 PlayerPosition;
    Charachter centerCharacter;
    GunWeapon gunWeapon;
    [SerializeField] float speed;
    public int damage = 5;
    [SerializeField] float Range;
    bool hitDetected = false;
    //List<Enemy> NearEnemies = new List<Enemy>();
    Enemy closetsEnemy;
    //[SerializeField] GameObject targetEnemy;
    public int GetDamage() {
        return damage;
    }
    public void SetDamage(int settetDamage) {
        damage = settetDamage;
    }
    public void SetDirection() { //Vector3 center
        //PlayerPosition = center;
        if (FindObjectsOfType<Enemy>() == null) {
            direction = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
        } else {
        var NearEnemies = FindObjectsOfType<Enemy>();
        closetsEnemy = FindClosestEnemy(this.transform.position, NearEnemies);
        
        direction = closetsEnemy.transform.position;
        }
        /*if (targetObjects != null) {

        }*/
        /*
        if (dir_x < 0) {
            Vector3 scale = transform.localScale;
            scale.x = scale.x * -1;
            transform.localScale = scale;
        }*/
        //Collider[] hitColliders = Physics.OverlapSphere(center, radius);
    }
   /* private Enemy ClosestEnemy(Vector3 origin, IEnumerable<Enemy> Enemies)
    {
    Enemy closest = null;
    float closestSqrDist = 0f;
 
    foreach(Enemy targetEnemy in Enemies) {
        float sqrDist = (targetEnemy.transform.position - origin).sqrMagnitude; //sqrMagnitude because it's faster to calculate than magnitude
 
        if (!closest || sqrDist < closestSqrDist) {
            closest = targetEnemy;
            closestSqrDist = sqrDist;
        }
    }
    return closest;
    } */
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
   /* void Fire ()
    {
        Vector2 direction = target.transform.position - transform.position;
        //link to spawned arrow, you dont need it, if the arrow has own moving script
        GameObject shotBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        shotBullet.transform.right = direction;
        shotBullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * speedArrow;
    }*/
}
