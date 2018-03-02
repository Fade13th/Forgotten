using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    public int x, y;
    public Tile tile;

    public virtual void StandOn(Entity entity) {

    }

    public virtual void MoveThrough(Entity entity) {

    }
}
