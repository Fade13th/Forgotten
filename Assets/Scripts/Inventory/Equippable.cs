using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Equippable : Item {
    bool equipped = false;
    Classes user;

    public int Str; //Melee damage and natural armour
    public int Dex; //Ranged weapon damage and dodge
    public int Con; //Health
    public int Int; //Magic resist and damage
    public int Will; //Stamina and sanity
    public int End; //Resistance to effects and sanity

    public int speed;

    public int level = 1;

    public int initiative;

    public int AR;
    public int SR;
    public int BAB;
    public int dodge;
    
    public float poisonResist = 0;
    public float fireResist = 0;
    public float slowResist = 0;
    public float stunResist = 0;
    public float blindResist = 0;
    public float dazeResist = 0;
    public float possessResist = 0;

    public virtual void OnEquip(Classes user) {
        if (equipped) return;
        equipped = true;
        this.user = user;

        user.AddStats(Str, Dex, Con, Int, Will, End);

        user.UpdateStats();

        user.AR += AR;
        user.initiative += initiative;
        user.speed += speed;
        user.SR += SR;
        user.BAB += BAB;

        user.AddResistences(stunResist, fireResist, poisonResist, dazeResist, blindResist, slowResist, possessResist);
    }

    public virtual void OnUnequip(Classes user) {
        if (!this.user.Equals(user)) return;

        equipped = false;
        this.user = null;

        user.AddStats(-Str, -Dex, -Con, -Int, -Will, -End);

        user.UpdateStats();

        user.AddResistences(-stunResist, -fireResist, -poisonResist, -dazeResist, -blindResist, -slowResist, -possessResist);
    }
}
