using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EnemyHaste : Enemy
{

    [SerializeField] int rangeHaste;
    [SerializeField] float timerToHaste;

    float timer;

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
        GameObject [] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        // var enemies = FindObjectsOfType<Enemy>(); прошлый вариант ( тип - Enemy )
        Stack myStack = new Stack();
        foreach (GameObject enemy in enemies)
        {
            if (enemy != this) { 
            float distance = Vector3.Distance(ThisPosition, enemy.transform.position);

            if (distance < rangeHaste)
            {
                myStack.Push(enemy);
            }
            }
        }
        GoHaste(myStack);
    }
    private void GoHaste(IEnumerable myCollection)
    {
        foreach (GameObject obj in myCollection)
        {
            // obj.SendMessage("Haste", 5);
            obj.GetComponent<Enemy>().Haste(5);
        }
        UnityEngine.Debug.Log("uscorenie");
    }
}

