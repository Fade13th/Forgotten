using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartySelectRow : MonoBehaviour {

    private Text name;
    private Text level;
    private Text clas;
    private Text health;
    private Text sanity;

    private Classes character;

    void Awake() {
        name = Helper.FindInChildren(gameObject, "Name").GetComponent<Text>();
        level = Helper.FindInChildren(gameObject, "Level").GetComponent<Text>();
        clas = Helper.FindInChildren(gameObject, "Class").GetComponent<Text>();
        health = Helper.FindInChildren(gameObject, "HP").GetComponent<Text>();
        sanity = Helper.FindInChildren(gameObject, "Sanity").GetComponent<Text>();
    }

    public void Setup(Classes member) {
        name.text = member.name;
        level.text = Helper.TwoDigit(member.level);
        clas.text = member.clas;
        health.text = Helper.TwoDigit(member.health);
        sanity.text = Helper.TwoDigit(member.sanity);

        character = member;
    }

    public void Clicked() {
        PartySelectUI.SelectEntity(character);
        print(character.name);

    }
}
