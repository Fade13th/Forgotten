using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Warrior : Classes {
    public Warrior(string name) {
        this.name = name;

        Str = 16 + (Roll.d6() - 3);
        Dex = 8 + (Roll.d6() - 3);
        Con = 18 + (Roll.d6() - 3);
        Int = 6 + (Roll.d6() - 3);
        Will = 10 + (Roll.d6() - 3);
        End = 11 + (Roll.d6() - 3);

        hitDie = Roll.d10;
        hitDieCount = 4;
        sanityDie = Roll.d8;
        sanityDieCount = 2;

        speed = 2;

        UpdateStats();

        health = healthMax;
        sanity = sanityMax;

        clas = "Warrior";
    }


    protected override void UpdateStats() {
        base.UpdateStats();

        AR = 7 + (Str / 2);
        SR = (Int - 10) / 4;
        BAB = 0;
        dodge = (Dex - 10) / 2;
        initiative = Mathf.Max(dodge, (Will / 4));

        healthMax = Mathf.Max(16, Roll.RollDie(hitDie, hitDieCount));
        sanityMax = Mathf.Max(6, Roll.RollDie(sanityDie, sanityDieCount));
    }
}
