using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : Tile {
    public int damage;
    public int rounds;
    public int DC;

    public override void StandOn(Entity entity) {
        entity.Poisoned(damage, rounds, DC);
    }

    public override void MoveThrough(Entity entity) {
        entity.Poisoned(damage, rounds, DC - 3);
    }
}
