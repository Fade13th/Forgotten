using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prefabs : MonoBehaviour {
    private static Tileset tileset;

    public static Tileset getTileset(string name) {
        if (!tileset || !tileset.name.Contains(name)) {
            GameObject o = Instantiate(Resources.Load(name)) as GameObject;
            tileset = o.GetComponent<Tileset>();
        }
        
        return tileset;
    }
}
