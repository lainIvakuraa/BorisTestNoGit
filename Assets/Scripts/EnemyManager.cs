using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] Vector2 SpawnZone;
    [SerializeField] float SpawnTimer;
     GameObject player;

    float timer;
    private void Start() {
        player = GameManager.instance.playerTransform.gameObject;
    }
    
    private void Update() {
        timer -= Time.deltaTime;
        if (timer < 0f) {
            SpawnEnemy();
            timer = SpawnTimer;
        }
    }
    private void SpawnEnemy() {
        Vector3 position = GenerateRandomPostition();
            position += player.transform.position;
            GameObject newEnemy = Instantiate(Enemy);
            newEnemy.transform.position = position;
            newEnemy.GetComponent<Enemy>().SetTarget(player);
            newEnemy.transform.parent = transform;
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