using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDistant : MonoBehaviour
{
    GameObject targetGameObject;
    Charachter targetCharacter;
    [SerializeField] float speed;
    [SerializeField] int damage = 1;
    [SerializeField] int currentHP = 5;
    [SerializeField] int experienceRewards = 400;

    [SerializeField] int timeToAtack = 5;
    [SerializeField] float rangeAtack = 2.5f;
    [SerializeField] float rangeGoBack = 1.5f;
    [SerializeField] GameObject EnemyBullet;
    

    private float timer;
    private Rigidbody2D rgbd2d;
    void Start()
    {
        //Set the tag of this GameObject to Player
        gameObject.tag = "Enemy";
        rgbd2d = GetComponent<Rigidbody2D>();
        targetCharacter = FindObjectOfType<Charachter>();
    }
    private void Update()
    {
        if (rangeAtack < Vector3.Distance(targetCharacter.transform.position, transform.position))
        {
            Vector3 direction = (targetCharacter.transform.position - transform.position).normalized;
            rgbd2d.velocity = direction * speed;
        }
        else if (rangeGoBack > Vector3.Distance(targetCharacter.transform.position, transform.position))
        {
            Vector3 direction = (targetCharacter.transform.position + transform.position).normalized;
            rgbd2d.velocity = direction * speed;
        }
        
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            timer = timeToAtack;
            DistantAtack();
            Debug.Log("shoot");
        }
        
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == targetGameObject)
        {
            Attack();
        }
    }// нужно создать зону курсирования между дистанцией стрельбы и зоной атаки персонажа??
    // Опционально: сделать условие - если в радиусе есть враг, то стрелять и не двигаться, а если близко - отбегать и не стрелять.
    private void Attack()
    {
        if (targetCharacter == null)
        {
            targetCharacter = targetGameObject.GetComponent<Charachter>();
        }
        targetCharacter.TakeDamage(damage);
    }// нужно с зоны стрелять снарядом и при попадании повторять поведение пули.

    private void DistantAtack()
    {
        GameObject EnemySimpleBullet = Instantiate(EnemyBullet);
        EnemyBullet.transform.position = transform.position;
        EnemyBullet bulletProjectileCurrent = EnemySimpleBullet.GetComponent<EnemyBullet>();
        // bulletProjectileCurrent.SetDirection(); //FindObjectOfType<Charachter>().transform.position
        bulletProjectileCurrent.damage = damage;
    }
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            targetGameObject.GetComponent<Level>().AddExperience(experienceRewards);
            Destroy(gameObject);
        }
    }
}
