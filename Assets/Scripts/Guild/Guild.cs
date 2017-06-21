using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Guild {
    public List<Classes> members;
    public Classes leader;

    public Guild(Classes l) {
        leader = l;
        members = new List<Classes>();
    }

    public void AddMember() {
        int clas = Roll.d4();

        switch (clas) {
            case 1:
                AddSorcerer();
                break;

            case 2:
                AddWarrior();
                break;

            case 3:
                AddRanger();
                break;

            case 4:
                AddPriest();
                break;

            default:
                break;
        }

        Guildhall.Show();
    }

    public void AddSorcerer() {
        bool gender = (Roll.d2() == 1);

        string name = NameGenerator.GenerateName(gender);

        members.Add(new Sorcerer(name));
    }

    public void AddWarrior() {
        bool gender = (Roll.d2() == 1);

        string name = NameGenerator.GenerateName(gender);

        members.Add(new Warrior(name));
    }

    public void AddRanger() {
        bool gender = (Roll.d2() == 1);

        string name = NameGenerator.GenerateName(gender);

        members.Add(new Ranger(name));
    }

    public void AddPriest() {
        bool gender = (Roll.d2() == 1);

        string name = NameGenerator.GenerateName(gender);

        members.Add(new Priest(name));
    }
}
