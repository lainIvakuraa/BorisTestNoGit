using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHaste : MonoBehaviour
{
    GameObject targetGameObject;
    [SerializeField] int currentHP;
    [SerializeField] int experienceRewards;
    [SerializeField] int rangeHaste;
    [SerializeField] float timerToHaste;
    GameObject player;

    Rigidbody2D rgbd2d;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.instance.playerTransform.gameObject;
        targetGameObject = player;
        //Set the tag of this GameObject to Player
        gameObject.tag = "Enemy";
    }
    private void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
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

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            FindEnemysToHaste();
            timer = timerToHaste;
        }
    }
    private void FindEnemysToHaste()
    {
        Vector3 ThisPosition = this.transform.position;
        var enemies = FindObjectsOfType<Enemy>();
        Stack myStack = new Stack();
        foreach (Enemy enemy in enemies)
        {
            float distance = Vector3.Distance(ThisPosition, enemy.transform.position);

            if (distance < rangeHaste)
            {
                myStack.Push(enemy);
            }
        }
        GoHaste(myStack);
    }
    private void GoHaste(IEnumerable myCollection)
    {
        foreach (Enemy obj in myCollection)
        {
            obj.Haste(5);
        }
    }
}

