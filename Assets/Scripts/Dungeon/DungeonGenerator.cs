using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour {

    public Tileset t;

    private static Tileset tileset;

    void Start() {
        tileset = t;
    }

	public static Dungeon Generate() {
        return new Dungeon(tileset.name);
    }
}
