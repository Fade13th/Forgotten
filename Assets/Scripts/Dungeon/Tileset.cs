using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tileset : MonoBehaviour{
    public List<Obstacle> obstacleList;
    public List<Obstacle> hazardTiles;
    public Tile ground;
    public Obstacle empty;
    public int level;
    public List<Entity> enemies;
    public List<Entity> minibosses;
    public List<Entity> bosses;

    public Group GetGroup(int level) {
        Group group = new Group();

        group.AddMember(enemies[0], new Pair(15, 15));

        return group;
    }
}
