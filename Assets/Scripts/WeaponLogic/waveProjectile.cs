using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
// логика движения пули
public class WaveProjectile : MonoBehaviour
{
    Vector3 direction; // направление движения
    [SerializeField] float speed; // скорость пули
    //[SerializeField] float Shift = 20; // растояние смещения луча от игрока
    public int damage = 5; // урон пули
     float Range = 6; // дальность пули
    

    
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
        //var playerPos = FindObjectsOfType<Player>();
        var playerPos = GameObject.FindWithTag("Player");

        //direction = playerPos.transform.position;

        /*
        if (playerPos.GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            direction = new Vector3(playerPos.transform.position.x + Shift, 
                0,
                playerPos.transform.position.z);
        }
        else
        {
            direction = new Vector3(playerPos.transform.position.x - Shift,
                0,
                playerPos.transform.position.z);
        }
        */

        //{
            direction = new Vector3(playerPos.transform.position.x,
                0,
                playerPos.transform.position.z);

            lifeTime = 60;

     }
        

    

    private void Start() {
        bulletDirection = direction - this.transform.position;
        shotStart = this.transform.position;
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
            //Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 0.1f);
            Collider2D[] hit = Physics2D.OverlapCapsuleAll(transform.position,
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Output the Collider's GameObject's name
        //UnityEngine.Debug.Log(collision.collider.name);
        UnityEngine.Debug.Log(collision);
    }
}

