using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour {
    public Tile ground;
    public List<Tile> hazardTiles;
    public int hazardDC;

    private int width = 800;

    private int size = 10;
    private List<Tile> tiles;

	// Use this for initialization
	void Start () {
        int tileWidth = width / size;
        int nextPos = 3;

        for (int i = 0; i < size; i++) {
            if (i < 3 || i > (size-4)) {
                Tile t = Instantiate(ground);
                t.transform.localPosition = new Vector3(nextPos, t.transform.localPosition.y, t.transform.localPosition.z);
                tiles.Add(t);
            }
            else {
                if (Roll.d20() < hazardDC) {
                    int x = Random.Range(0, hazardTiles.Count);
                    for (int j = 0; j < hazardTiles.Count; j++) {
                        if (x < j) {
                            Tile t = Instantiate(hazardTiles[j]);
                            t.transform.localPosition = new Vector3(nextPos, t.transform.localPosition.y, t.transform.localPosition.z);
                            tiles.Add(t);
                            break;
                        }
                    }
                }
            }

            nextPos += 6 + tileWidth;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
