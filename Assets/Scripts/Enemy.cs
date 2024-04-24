using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
     Transform targetDestination;
   GameObject targetGameObject;
   Charachter targetCharacter;
   [SerializeField] float speed;
   [SerializeField] int damage = 1;
   [SerializeField] int currentHP = 5;
   [SerializeField] int experienceRewards = 400;
  

   Rigidbody2D rgbd2d;
   void Start()
    {
        //Set the tag of this GameObject to Player
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
}
