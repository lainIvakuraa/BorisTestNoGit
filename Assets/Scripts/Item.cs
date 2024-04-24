using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string Name;
    public int armor;

    public void Equip(Charachter charachter) {
        charachter.armor += armor;
    }
    public void UnEquip(Charachter charachter) {
        charachter.armor -= armor;
    }
}
