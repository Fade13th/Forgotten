using UnityEngine;
using System.Collections;

[System.Serializable]
public class Game {

    public static Game current;
    public Dungeon currDungeon;
    public Guild guild;
    public string name;

    public Game(string name) {
        this.name = name;
        currDungeon = new Dungeon();
        guild = new Guild();

        current = this;
    }

}