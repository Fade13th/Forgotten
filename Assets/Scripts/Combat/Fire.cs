using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Tile {
    public int damage;

    public override void StandOn(Entity entity) {
        entity.Ignite(damage);
    }

}
