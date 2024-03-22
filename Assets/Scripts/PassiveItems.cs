using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItems : MonoBehaviour
{
    [SerializeField] List<Item> items;
    [SerializeField] Item armorTest;
    Charachter charachter;
    private void Awake() {
        charachter = GetComponent<Charachter>();
    }
    private void Start() {
        Equip(armorTest);
    }
    public void Equip(Item itemToEquip) {
        if (items == null) {
            items = new List<Item>();
        }
        items.Add(itemToEquip);
        itemToEquip.Equip(charachter);
    }
    public void UnEquip(Item itemToUnEquip) {
        
    }
}
