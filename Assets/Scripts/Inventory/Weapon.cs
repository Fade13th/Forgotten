using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon : Equippable {
    public int health;
    public int physicalDamageDie;
    public int physicalDamageCount;
    public int physicalDamageBase;

    public int magicalDamageDie;
    public int magicalDamageCount;
    public int magicalDamageBase;

    public override void OnEquip(Classes user) {
        base.OnEquip(user);
    }

    public override void OnUnequip(Classes user) {
        base.OnUnequip(user);
    }

    public void Attack(Tile target) {

    }
}
