using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dungeon {
    public Party party;
    public string tileset;

    public Dungeon(string tiles) {
        party = new Party();

        party.AddMember(new Warrior("afwaf"), new Pair(0, 0));
        party.AddMember(new Priest("wa"), new Pair(2, 1));
        party.AddMember(new Sorcerer("gr"), new Pair(1, 2));

        tileset = tiles;
    }

    public void StartCombat() {
        Arena.create(95, 92, Prefabs.getTileset(tileset));

        CombatManager.StartCombat(party, GetEnemies());
    }

    //private int CalculateHazardDC() {
      //  return tileset.level;
    //}

    private Group GetEnemies() {
        return Prefabs.getTileset(tileset).GetGroup(1);
    }
}
