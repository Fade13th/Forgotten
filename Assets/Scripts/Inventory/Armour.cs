using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armour : Equippable {
    public int health;

    public override void OnEquip(Classes user) {
        base.OnEquip(user);
    }

    public override void OnUnequip(Classes user) {
        base.OnUnequip(user);
    }

    public void Block(int physicalDamage, int magicalDamage) {

    }
}
