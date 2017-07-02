using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dungeon {
    public Party party;

    public Dungeon() {
        party = new Party();
    }
}
