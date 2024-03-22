using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeapon : MonoBehaviour
{
    
    // Start is called before the first frame update
   [SerializeField] float TimeToAttack;
   float Timer;
   [SerializeField] Charachter playerCharachter;
   //PlayerMove playerMove;
    [SerializeField] GameObject bulletPrefab;

    /*private void Awake() {
        playerMove = GetComponentInParent<PlayerMove>();
    }*/

    private void Update() {
        if (Timer < TimeToAttack) {
            Timer += Time.deltaTime;
            return;
        }
        Timer = 0;
        SpawnBullet();
    }
    private void SpawnBullet() {
        GameObject shotBullet = Instantiate(bulletPrefab);
        shotBullet.transform.position = transform.position;
        shotBullet.GetComponent<bulletProjectile>().SetDirection(playerCharachter.transform.position);
        Debug.Log(transform.position);
    }
    /*
    [SerializeField] float shootingDistance = 7f;
    [SerializeField] float speedArrow = 5f;
    [SerializeField] float fireRate = 3f;
    [SerializeField] GameObject bulletPrefab;

    GameObject target;
    bool canShoot = true;
 
    void Update ()
    {
        if (canShoot) {
            canShoot = false;
            //Coroutine for delay between shooting
            StartCoroutine("AllowToShoot");
            //array with enemies
            //you can put in start, iff all enemies are in the level at beginn (will be not spawn later)
            GameObject[] allTargets = GameObject.FindGameObjectsWithTag("Enemy");
            if (allTargets != null)
            {
                target = allTargets[0];
                //look for the closest
                foreach (GameObject tmpTarget in allTargets)
                {
                    if (Vector2.Distance(transform.position, tmpTarget.transform.position) < Vector2.Distance(transform.position, target.transform.position))
                    {
                        target = tmpTarget;
                    }
                }
                //shoot if the closest is in the fire range
                if (Vector2.Distance(transform.position, target.transform.position) < shootingDistance)
                {
                    Fire();
                }
            }
        }
    }
 
    
 
    IEnumerator AllowToShoot ()
    {
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
    */
}
