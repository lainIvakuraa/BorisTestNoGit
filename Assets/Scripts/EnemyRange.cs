using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : Enemy
{
    // Start is called before the first frame update
    [SerializeField] GameObject EnemyRangeBulletPrefab;

    [SerializeField] float timerToAttack;
    [SerializeField] float Range;
    [SerializeField] int RangeDamage;
    [SerializeField] float distance;


    Vector3 bulletDirection; // направление пули
    float timer;


    private void FixedUpdate()
    {
        if (Vector3.Distance(targetDestination.position, transform.position) > distance)
        {
            Vector3 direction = (targetDestination.position - transform.position).normalized;
            rgbd2d.velocity = direction * speed;
            //Debug.Log(this.transform.position.normalized);
        }
        else if (Vector3.Distance(targetDestination.position, transform.position) < distance - 1f)
        {
            Vector3 direction = -(targetDestination.position - transform.position).normalized;
            rgbd2d.velocity = direction * speed;
            //Debug.Log(this.transform.position.normalized);
        }
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            RangeAttack();
            timer = timerToAttack;
        }
    }
    private void RangeAttack()
    {
        Charachter target = targetGameObject.GetComponent<Charachter>();

        bulletDirection = target.transform.position;

        GameObject shotBullet = Instantiate(EnemyRangeBulletPrefab);
        shotBullet.transform.position = transform.position;

        EnemyBullet EnemyBulletProjectileCurrent = shotBullet.GetComponent<EnemyBullet>();
        EnemyBulletProjectileCurrent.SetDirection(bulletDirection); //FindObjectOfType<Charachter>().transform.position
        EnemyBulletProjectileCurrent.SetRange(Range);
        EnemyBulletProjectileCurrent.SetDamage(RangeDamage);
    }
}
