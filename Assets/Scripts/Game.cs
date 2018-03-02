using UnityEngine;
using System.Collections;

[System.Serializable]
public class Game {

    public static Game current;
    public Dungeon currDungeon;
    public Guild guild;
    public Classes character;
    public string name;

    public Game(string name) {
        this.name = name;
        CreatePlayer(name);

        currDungeon = new Dungeon("Tileset_cave");
        guild = new Guild(character);

        GameManager.game = this;
    }

    public void LoadDetails() {
        Guildhall.SetGuild(guild);
        Guildhall.SetStats();
        Guildhall.Show();

        currDungeon.StartCombat();

        current = this;
    }

    public void CreatePlayer(string name) {
        character = new Sorcerer(name);
    }
}