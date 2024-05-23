using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charachter : MonoBehaviour
{
    public int maxHP = 1000;
    public int currentHP = 1000;
    public int armor = 0;
    [SerializeField] StatusBar HpBar;
    bool isDead = false;
    void Awake() {
        HpBar.SetState(currentHP, maxHP);
    }
    void Start()
    {
        //Set the tag of this GameObject to Player
        gameObject.tag = "Player";
    }
    public void TakeDamage(int damage) {
        if (isDead == true) {return;}
        ApplyArmor(ref damage); //ApplyArmor изменяет весь damage внутри функции
        currentHP -= damage;
        if (currentHP <= 0 ) {
            GetComponent<CharachterGameOver>().GameOverFunc();
            isDead = true;
        }
        HpBar.SetState(currentHP, maxHP);
    }
    private void ApplyArmor(ref int damage) {
        damage -= armor;
        if (damage < 0) {damage = 0;}
    }
    public void Heal(int amount) {
        if (currentHP <= 0) {return;}
        currentHP += amount;
        if (currentHP > maxHP) {
            currentHP = maxHP;
        }
    }
}
