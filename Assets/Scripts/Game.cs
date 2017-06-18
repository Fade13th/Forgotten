using UnityEngine;
using System.Collections;

[System.Serializable]
public class Game {

    public static Game current;
    Party party;
    public string name;

    public Game() {
        party = new Party();

        current = this;
    }

}