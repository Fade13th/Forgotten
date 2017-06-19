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

    public void AddSorcerer() {
        bool gender = (Roll.d2() == 1);

        string name = NameGenerator.GenerateName(gender);

        members.Add(new Sorcerer(name));

    }
}
