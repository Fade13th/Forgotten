using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Entity {
    public string name;
    public bool alive = true;
    public string sprite = "icon";

    public int Str; //Melee damage and natural armour
    public int Dex; //Ranged weapon damage and dodge
    public int Con; //Health
	public int Int; //Magic resist and damage
    public int Will; //Stamina and sanity
    public int End; //Resistance to effects and sanity

    public int speed;

    protected int healthMax;
    public int health;
    protected Roll.roll hitDie { get; set; }
    protected int hitDieCount { get; set; }

    protected int sanityMax;
    public int sanity;
    protected Roll.roll sanityDie { get; set; }
    protected int sanityDieCount { get; set; }

    public int level = 1;
    public int exp = 0;

    public int initiative;

    public int AR;
    public int SR;
    public int BAB;
    public int dodge;


    public float poisonResist = 0;
    protected int poisonDamage = 0;
    protected int poisonRounds = 0;

    public float fireResist = 0;
    protected int fireDamage = 0;

    public float slowResist = 0;
    protected int slowRounds = 0;
    protected int slowAmount = 0;
    protected int prevInitiative;

    public float stunResist = 0;
    protected int stunRounds = 0;
    protected bool stunned = false;

    public float blindResist = 0;
    public float dazeResist = 0;
    protected int missRounds = 0;
    protected bool blinded = false;
    protected bool dazed = false;

    public float possessResist = 0;
    protected bool possessed = false;
    protected int possessedRounds = 0;

    protected bool guaranteedMiss = false;

    public void TakePhysicalDamage(int amount, int DC) {
        int save = Roll.d20() + dodge;

        if (DC > save) {
            int damage = Mathf.Max(0, amount - AR);

            Damage(damage);
        }
    }

    public void TakeMagicDamage(int amount, int DC) {
        int save = Roll.d20() + ((Int -10)/2);

        if (DC > save) {
            int damage = Mathf.Max(0, amount - SR);

            Damage(damage);
        }
    }

    public void TakeSanityDamage(int amount, int DC) {
        int sanityBonus = Mathf.Max(((Will - 10) / 2), ((End - 10) / 2));

        int save = Roll.d20() + sanityBonus;

        if (DC > save) {
            //Sanity Damage
        }
    }

    public int GetSpellDC() {
        return BAB + ((Int - 10) / 2);
    }

    public int GetMeleeDC() {
        return BAB + ((Str - 10) / 2);
    }

    public int GetRangedDC() {
        return BAB + ((Dex - 10) / 2);
    }

    protected void Damage(int amount) {
        health -= amount;
    }

    public void Poisoned(int damage, int rounds, int DC) {
        int save = Roll.d20() + (End-10);

        if (save < DC) {
            poisonDamage = damage;
            poisonRounds = rounds;
        }
    }

    public void Ignite(int damage) {
        if (fireDamage < damage) {
            fireDamage = damage;
        }
    }

    public void PutOut() {
        fireDamage = 0;
    }

    public void Stun(int rounds, int DC) {
        int save = Roll.d20() + (End - 10) + ((int) (10 * stunResist));

        if (save < DC) {
            stunRounds = rounds;
            stunned = true;
        }
    }

    public void Blind(int rounds, int DC) {
        int save = Roll.d20() + (End - 10) + ((int)(10 * blindResist));

        if (save < DC) {
            missRounds = rounds;
            blinded = true;
        }
    }

    public void Daze(int rounds, int DC) {
        int save = Roll.d20() + (End - 10) + ((int)(10 * dazeResist));

        if (save < DC) {
            missRounds = rounds;
            dazed = true;
        }
    }

    public void Possess(int rounds, int DC) {
        int save = Roll.d20() + (End - 10) + ((int)(10 * possessResist));

        if (save < DC) {
            possessedRounds = rounds;
            possessed = true;
        }
    }

    public void Turn () {
        StatusEffects();

        if (stunned) {
            //TODO: Stun animation
            return;
        }

        if (dazed || blinded) {
            if ((blinded && Random.value < 0.5) || (dazed && Random.value < 0.2)) {
                guaranteedMiss = true;
            }
            else {
                guaranteedMiss = false;
            }
        }
	}

    protected void StatusEffects() {
        if (poisonRounds > 0) {
            Damage((int) Mathf.Ceil(poisonDamage * (1-poisonResist)));
            poisonRounds--;
        }

        if (fireDamage > 0) {
            Damage((int)Mathf.Ceil(fireDamage * (1 - fireResist)));
        }

        if (slowAmount > 0) {
            if (slowRounds > 0) {
                slowRounds--;
            }
            else {
                initiative = prevInitiative;
                slowAmount = 0;
            }
        }

        if (stunned) {
            if (stunRounds > 0) {
                stunRounds--;
            }
            else {
                stunned = false;
            }
        }

        if (dazed || blinded) {
            if (missRounds > 0) {
                missRounds--;
            }
            else {
                dazed = false;
                blinded = false;
                guaranteedMiss = false;
            }
        }

        if (possessed) {
            if (possessedRounds > 0) {
                possessedRounds--;
            }
            else {
                possessed = false;
            }
        }

    }

    public virtual void UpdateStats() {

    }

    public void AddStats(int Str, int Dex, int Con, int Int, int Will, int End) {
        this.Str = Mathf.Max(0, Str);
        this.Dex = Mathf.Max(0, Dex);
        this.Con = Mathf.Max(0, Con);
        this.Int = Mathf.Max(0, Int);
        this.Will = Mathf.Max(0, Will);
        this.End = Mathf.Max(0, End);
    }

    public void AddResistences(float stun, float fire, float poison, float daze, float blind, float slow, float poss) {
        stunResist += Mathf.Clamp(stun, 0, 1);
        fireResist += Mathf.Clamp(fire, 0, 1);
        poisonResist += Mathf.Clamp(poison, 0, 1);
        dazeResist += Mathf.Clamp(daze, 0, 1);
        blindResist += Mathf.Clamp(blind, 0, 1);
        slowResist += Mathf.Clamp(slow, 0, 1);
        possessResist += Mathf.Clamp(poss, 0, 1);
    }

}
