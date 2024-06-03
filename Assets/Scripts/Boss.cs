using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    protected Transform targetDestination;
    protected GameObject targetGameObject;
    protected Charachter targetCharacter;
    [SerializeField] protected float speed;
    [SerializeField] protected int damage;

    protected Rigidbody2D rgbd2d;

    private void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        gameObject.tag = "Boss";
    }
    public void SetTarget(GameObject Target)
    {
        targetGameObject = Target;
        targetDestination = Target.transform;
    }
    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rgbd2d.velocity = direction * speed;
        //Debug.Log(this.transform.position.normalized);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == targetGameObject)
        {
            Attack();
        }
    }
    private void Attack()
    {
        if (targetCharacter == null)
        {
            targetCharacter = targetGameObject.GetComponent<Charachter>();
        }
        targetCharacter.TakeDamage(damage);
    }
}
