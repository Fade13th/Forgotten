using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sorcerer : Classes {

	// Use this for initialization
	public Sorcerer (string name) {
        this.name = name;

        Str = 6 + (Roll.d6() - 3);
        Dex = 10 + (Roll.d6() - 3);
        Con = 8 + (Roll.d6() - 3);
        Int = 18 + (Roll.d6() - 3);
        Will = 16 + (Roll.d6() - 3);
        End = 11 + (Roll.d6() - 3);

        hitDie = Roll.d6;
        hitDieCount = 4;
        sanityDie = Roll.d10;
        sanityDieCount = 2;

        speed = 2;

        UpdateStats();

        healthMax = Mathf.Max(6, Roll.RollDie(hitDie, hitDieCount));
        sanityMax = Mathf.Max(6, Roll.RollDie(sanityDie, sanityDieCount));

        health = healthMax;
        sanity = sanityMax;

        clas = "Sorcerer";
	}


    public override void UpdateStats() {
        base.UpdateStats();

        AR = 7 + (Str/2);
        SR = (Int-10)/4;
        BAB = 0;
        dodge = (Dex - 10)/2;
        initiative = Mathf.Max(dodge, (Will/4));
    }
}
