using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float lifeTime;
    [SerializeField] public int damage = 500;
    [SerializeField] public int Range;
    bool hitDetected = false;

    Charachter target;
    Vector3 direction;

    Vector3 bulletDirection;
    Vector3 shotStart;

    private void Start()
    {
        target = FindObjectOfType<Charachter>();
        //Destroy(gameObject, lifeTime);

        direction = target.transform.position;
        bulletDirection = direction - this.transform.position;
        shotStart = this.transform.position;

    }
    void Update()
    {
        transform.right = direction;
        GetComponent<Rigidbody2D>().velocity = bulletDirection.normalized * speed;

        if (Vector3.Distance(shotStart, transform.position) > Range)
        {
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        if (Time.frameCount % 2 == 0)
        {
            Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 0.1f);
            foreach (Collider2D c in hit)
            {
                Charachter CrossHitBox = c.GetComponent<Charachter>();
                if (CrossHitBox != null)
                {
                    CrossHitBox.TakeDamage(damage);
                    hitDetected = true;
                    break;
                }
            }
            if (hitDetected == true)
            {
                Destroy(gameObject);
            }
        }
    }
}
