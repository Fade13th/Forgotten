using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {
    [SerializeField] protected int Str; //Melee damage and natural armour
    [SerializeField] protected int Dex; //Ranged weapon damage and dodge
    [SerializeField] protected int Con; //Health
	[SerializeField] protected int Int; //Magic resist and damage
    [SerializeField] protected int Will; //Stamina and sanity
    [SerializeField] protected int End; //Resistance to effects and sanity

    protected int speed;

    protected int healthMax;
    protected int health;
    protected Roll.roll hitDie { get; set; }
    protected int hitDieCount { get; set; }

    protected int sanityMax;
    protected int sanity;
    protected Roll.roll sanityDie { get; set; }
    protected int sanityDieCount { get; set; }

    protected int level = 1;
    protected int exp = 0;

    protected int initiative;

    protected int AR;
    protected int SR;
    protected int BAB;
    protected int dodge;


    protected float poisonResist = 0;
    protected int poisonDamage = 0;
    protected int poisonRounds = 0;

    protected float fireResist = 0;
    protected int fireDamage = 0;

    protected float slowResist = 0;
    protected int slowRounds = 0;
    protected int slowAmount = 0;
    protected int prevInitiative;

    protected float stunResist = 0;
    protected int stunRounds = 0;
    protected bool stunned = false;

    protected float blindResist = 0;
    protected float dazeResist = 0;
    protected int missRounds = 0;
    protected bool blinded = false;
    protected bool dazed = false;

    protected float possessResist = 0;
    protected bool possessed = false;
    protected int possessedRounds = 0;

    protected bool guaranteedMiss = false;

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

    protected virtual void UpdateStats() {

    }
	
}
