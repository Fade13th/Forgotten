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

        Str.text = TwoDigit(character.Str);
        Dex.text = TwoDigit(character.Dex);
        Con.text = TwoDigit(character.Con);
        Int.text = TwoDigit(character.Int);
        Will.text = TwoDigit(character.Will);
        End.text = TwoDigit(character.End);

        HP.text = TwoDigit(character.health);
        Sanity.text = TwoDigit(character.sanity);
        Speed.text = TwoDigit(character.speed);
        Init.text = TwoDigit(character.initiative);

        AR.text = TwoDigit(character.AR);
        SR.text = TwoDigit(character.SR);
        BAB.text = TwoDigit(character.BAB);
        Dodge.text = TwoDigit(character.dodge);

        Stun.text = TwoDigitf(character.stunResist);
        Fire.text = TwoDigitf(character.fireResist);
        Poison.text = TwoDigitf(character.poisonResist);
        Daze.text = TwoDigitf(character.dazeResist);
        Blind.text = TwoDigitf(character.blindResist);
        Slow.text = TwoDigitf(character.slowResist);
        Possess.text = TwoDigitf(character.possessResist);

        Level.text = TwoDigit(character.level);
    }

    private string TwoDigit(int i) {
        string s = i + "";

        if (s.Length < 2)
            return "0" + s;

        else if (s.Length > 2)
            return s.Substring(s.Length - 3);

        else
            return s;
    }

    private string TwoDigitf(float f) {
        return f + "";
    }

    // Update is called once per frame
    void Update () {
		
	}
}
