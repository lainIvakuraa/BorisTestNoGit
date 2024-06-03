using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject Enemy2;

    [SerializeField] GameObject Boss;

    [SerializeField] Vector2 SpawnZone;
    [SerializeField] float SpawnTimer;
     GameObject player;

    float timer;
    float timerToBoss = 10f;
    private void Start() {
        player = GameManager.instance.playerTransform.gameObject;
    }
    
    private void Update() {
        timer -= Time.deltaTime;
        timerToBoss -= Time.deltaTime;
        if (timer < 0f) {
            SpawnEnemy();
            timer = SpawnTimer;
        }
        if (timerToBoss < 0f)
        {
            SpawnBoss();
            timerToBoss = 20f;
        }
    }
    private void SpawnEnemy() {
        Vector3 position = GenerateRandomPostition();
            position += player.transform.position;
            GameObject newEnemy = Instantiate(Enemy);
            newEnemy.transform.position = position;
            newEnemy.GetComponent<EnemyBat>().SetTarget(player);
            newEnemy.transform.parent = transform;
        Vector3 position2 = GenerateRandomPostition();
            position2 += player.transform.position;
            GameObject newEnemy2 = Instantiate(Enemy2);
            newEnemy2.transform.position = position2;
            newEnemy2.GetComponent<EnemyRange>().SetTarget(player); ;
            newEnemy2.transform.parent = transform;
    }
    // потом для спавна босса, принцып тот-же, разница лишь в таймингах
    private void SpawnBoss()
    {
        Vector3 position = GenerateRandomPostition();
        position += player.transform.position;
        GameObject newBoss = Instantiate(Boss);
        newBoss.transform.position = position;
        newBoss.GetComponent<BossStageOne>().SetTarget(player);
        newBoss.transform.parent = transform;
    }
        private Vector3 GenerateRandomPostition() {
        Vector3 position = new Vector3();
        float f = UnityEngine.Random.value > 0.5f ? -1f : 1f;
        if (UnityEngine.Random.value > 0.5f) {
            position.x = UnityEngine.Random.Range(-SpawnZone.x, SpawnZone.x);
            position.y = SpawnZone.y * f;
        } else {
            position.y = UnityEngine.Random.Range(-SpawnZone.y, SpawnZone.y);
            position.x = SpawnZone.x * f;
        }
        
        position.z = 0;
        
        return position;
    }

}