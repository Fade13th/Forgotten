using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {
    private Text charName;

    private Text Str;
    private Text Dex;
    private Text Con;
    private Text Int;
    private Text Will;
    private Text End;

    private Text HP;
    private Text Sanity;
    private Text Speed;
    private Text Init;

    private Text AR;
    private Text SR;
    private Text BAB;
    private Text Dodge;

    private Text Stun;
    private Text Fire;
    private Text Poison;
    private Text Daze;
    private Text Blind;
    private Text Slow;
    private Text Possess;

    private Text Level;

    // Use this for initialization
    void Start () {
        charName = Helper.FindInChildren(gameObject, "CharName").GetComponent<Text>();

        Str = Helper.FindInChildren(gameObject, "Str").GetComponent<Text>();
        Dex = Helper.FindInChildren(gameObject, "Dex").GetComponent<Text>();
        Con = Helper.FindInChildren(gameObject, "Con").GetComponent<Text>();
        Int = Helper.FindInChildren(gameObject, "Int").GetComponent<Text>();
        Will = Helper.FindInChildren(gameObject, "Will").GetComponent<Text>();
        End = Helper.FindInChildren(gameObject, "End").GetComponent<Text>();

        HP = Helper.FindInChildren(gameObject, "HP").GetComponent<Text>();
        Sanity = Helper.FindInChildren(gameObject, "Sanity").GetComponent<Text>();
        Speed = Helper.FindInChildren(gameObject, "Speed").GetComponent<Text>();
        Init = Helper.FindInChildren(gameObject, "Initiative").GetComponent<Text>();

        AR = Helper.FindInChildren(gameObject, "AR").GetComponent<Text>();
        SR = Helper.FindInChildren(gameObject, "SR").GetComponent<Text>();
        BAB = Helper.FindInChildren(gameObject, "BAB").GetComponent<Text>();
        Dodge = Helper.FindInChildren(gameObject, "Dodge").GetComponent<Text>();

        Stun = Helper.FindInChildren(gameObject, "StunResist").GetComponent<Text>();
        Fire = Helper.FindInChildren(gameObject, "FireResist").GetComponent<Text>();
        Poison = Helper.FindInChildren(gameObject, "PoisonResist").GetComponent<Text>();
        Daze = Helper.FindInChildren(gameObject, "DazeResist").GetComponent<Text>();
        Blind = Helper.FindInChildren(gameObject, "BlindResist").GetComponent<Text>();
        Slow = Helper.FindInChildren(gameObject, "SlowResist").GetComponent<Text>();
        Possess = Helper.FindInChildren(gameObject, "PossessionResist").GetComponent<Text>();

        Level = Helper.FindInChildren(gameObject, "PlayerLevel").GetComponent<Text>();
    }

    public void UpdateStats(Classes character) {
        charName.text = character.name;

        Str.text = Helper.TwoDigit(character.Str);
        Dex.text = Helper.TwoDigit(character.Dex);
        Con.text = Helper.TwoDigit(character.Con);
        Int.text = Helper.TwoDigit(character.Int);
        Will.text = Helper.TwoDigit(character.Will);
        End.text = Helper.TwoDigit(character.End);

        HP.text = Helper.TwoDigit(character.health);
        Sanity.text = Helper.TwoDigit(character.sanity);
        Speed.text = Helper.TwoDigit(character.speed);
        Init.text = Helper.TwoDigit(character.initiative);

        AR.text = Helper.TwoDigit(character.AR);
        SR.text = Helper.TwoDigit(character.SR);
        BAB.text = Helper.TwoDigit(character.BAB);
        Dodge.text = Helper.TwoDigit(character.dodge);

        Stun.text = Helper.TwoDigitf(character.stunResist);
        Fire.text = Helper.TwoDigitf(character.fireResist);
        Poison.text = Helper.TwoDigitf(character.poisonResist);
        Daze.text = Helper.TwoDigitf(character.dazeResist);
        Blind.text = Helper.TwoDigitf(character.blindResist);
        Slow.text = Helper.TwoDigitf(character.slowResist);
        Possess.text = Helper.TwoDigitf(character.possessResist);

        Level.text = Helper.TwoDigit(character.level);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
