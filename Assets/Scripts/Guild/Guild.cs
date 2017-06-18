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
        members.Add(new Sorcerer("FAESF AFEWFD"));

    }
}
