using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour {
    public static int tiles = 16;

    private static float space = 1.5f;
    private static Tile[,] arena;
    private static int buff = 4;
    private static Dictionary<string, GameObject> entities;
    private static Transform parent;

    public static void create(int obstacleDC, int hazardDC, Tileset tileset) {
        entities = new Dictionary<string, GameObject>();

        arena = new Tile[tiles, tiles];
        arena.Initialize();

        parent = GameObject.Find("Arena").transform;

        for (int x = 0; x < tiles; x++) {
            for (int y = 0; y < tiles; y++) {
                if (arena[x,y] != null) {
                    continue;
                }

                bool placed = false;

                if ((x >= buff && y < tiles - buff) || (x < tiles - buff && y >= buff)) {
                    if (Roll.d100() > obstacleDC) {
                        Obstacle o = tileset.obstacleList[UnityEngine.Random.Range(0, tileset.obstacleList.Count)];

                        if ((x + o.x) < tiles && (y + o.y) < tiles) {
                            for (int i = x; i < x + o.x; i++) {
                                for (int j = y; j < y + o.y; j++) {
                                    arena[i, j] = Instantiate(o.tile, parent);
                                    arena[i, j].transform.position = new Vector3(space * i, space * j, 1);
                                    arena[i, j].transform.localScale = new Vector3(0.1f, 0.1f, 1);
                                    placed = true;
                                }
                            }
                        }
                    }
                    else if (Roll.d100() > hazardDC) {
                        Obstacle h = tileset.hazardTiles[UnityEngine.Random.Range(0, tileset.hazardTiles.Count)];

                        if ((x + h.x) < tiles && (y + h.y) < tiles) {
                            for (int i = x; i < x + h.x; i++) {
                                for (int j = y; j < y + h.y; j++) {
                                    arena[i, j] = Instantiate(h.tile, parent);
                                    arena[i, j].transform.position = new Vector3(space * i, space * j, 1);
                                    arena[i, j].transform.localScale = new Vector3(0.1f, 0.1f, 1);
                                    placed = true;
                                }
                            }
                        }
                    }
                }
                if (!placed) {
                    arena[x, y] = Instantiate(tileset.ground, parent);
                    arena[x, y].transform.position = new Vector3(space * x, space * y, 1);
                    arena[x, y].transform.localScale = new Vector3(0.1f, 0.1f, 1);
                }
            }
        }

        parent.transform.localScale = new Vector3(1.8f, 1, 1);
        parent.transform.position = new Vector3(-20.25f, -9.35f, 1);
    }

    public static Tile getTile(int x, int y) {
        return arena[x, y];
    }

    public static void addEntity(Entity e, int x, int y) {
        GameObject entity = Instantiate(Resources.Load(e.sprite)) as GameObject;
        entity.transform.parent = arena[x, y].transform;
        entity.GetComponent<SpriteRenderer>().sortingLayerName = "Entity";

        entity.transform.localScale = new Vector3(1, 1, 1);
        entity.transform.localPosition = new Vector3(0, 0, 0);

        entities.Add(e.name, entity);
    }
}
