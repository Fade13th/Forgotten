using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    public Entity back, center, front;

    public bool Occupied(int pos) {
        if (pos == 0 && back != null) return true;
        else if (pos == 1 && center != null) return true;
        else if (pos == 2 && front != null) return true;
        else return false;
    }

    public virtual void StandOn(Entity entity) {

    }

    public virtual void MoveThrough(Entity entity) {

    }
}
