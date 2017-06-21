using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ranger : Classes {
    public Ranger(string name) {
        this.name = name;

        Str = 6 + (Roll.d6() - 3);
        Dex = 18 + (Roll.d6() - 3);
        Con = 10 + (Roll.d6() - 3);
        Int = 8 + (Roll.d6() - 3);
        Will = 11 + (Roll.d6() - 3);
        End = 16 + (Roll.d6() - 3);

        hitDie = Roll.d8;
        hitDieCount = 4;
        sanityDie = Roll.d10;
        sanityDieCount = 2;

        speed = 2;

        UpdateStats();

        health = healthMax;
        sanity = sanityMax;

        clas = "Ranger";
    }


    protected override void UpdateStats() {
        base.UpdateStats();

        AR = 7 + (Str / 2);
        SR = (Int - 10) / 4;
        BAB = 0;
        dodge = (Dex - 10) / 2;
        initiative = Mathf.Max(dodge, (Will / 4));

        healthMax = Mathf.Max(10, Roll.RollDie(hitDie, hitDieCount));
        sanityMax = Mathf.Max(6, Roll.RollDie(sanityDie, sanityDieCount));
    }
}
