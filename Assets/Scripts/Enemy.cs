using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{
     Transform targetDestination;
   GameObject targetGameObject;
   Charachter targetCharacter;
   [SerializeField] float speed;
   [SerializeField] int damage;
   [SerializeField] int currentHP;
   [SerializeField] int experienceRewards;
  

   Rigidbody2D rgbd2d;
   void Start()
    {
        gameObject.tag = "Enemy";
    }
   private void Awake() {
        rgbd2d = GetComponent<Rigidbody2D>();  
   }
   public void SetTarget(GameObject Target) {
     targetGameObject = Target;
     targetDestination = Target.transform;
   }
   private void FixedUpdate() {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rgbd2d.velocity = direction * speed;
        //Debug.Log(this.transform.position.normalized);
   }
   private void OnCollisionStay2D(Collision2D collision) {
     if (collision.gameObject == targetGameObject) {
          Attack();
     }
   }
   private void Attack() {
     if (targetCharacter == null) {
      targetCharacter = targetGameObject.GetComponent<Charachter>();
     }
     targetCharacter.TakeDamage(damage);
   }
    public void TakeDamage(int damage) {
        currentHP -= damage;
        if (currentHP <= 0 ) {
          targetGameObject.GetComponent<Level>().AddExperience(experienceRewards);
            Destroy(gameObject);
        }
    }
    public void Haste(float timer)
    {
        speed = speed * 5f;
        float timerToSlow = timer;
        float currentTime = Time.time;

    }
    public void speedDown()
    {

    }
}
