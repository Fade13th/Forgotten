using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    public Entity e;

    public bool Occupied() {
        if (e == null) return false;
        else return true;
    }

    public virtual void StandOn(Entity entity) {
        e = entity;
    }

    public virtual void MoveThrough(Entity entity) {

    }
}
