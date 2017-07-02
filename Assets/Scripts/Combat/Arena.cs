using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour {
    public Tile ground;
    public List<Tile> hazardTiles;
    public int hazardDC;

    public List<Transform> tileSlots;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < tileSlots.Count; i++) {
            if ((i < 3 || i > (tileSlots.Count - 4)) || Roll.d20() < hazardDC) {
                Tile t = Instantiate(ground);
                t.transform.parent = tileSlots[i];
                t.transform.localPosition = new Vector3(0, 0, 0);
                t.transform.localEulerAngles = new Vector3(0, 0, 0);
            }
            else {
                int x = Random.Range(0, hazardTiles.Count);
                for (int j = 0; j < hazardTiles.Count; j++) {
                    if (x <= j) {
                        Tile t = Instantiate(hazardTiles[j]);
                        t.transform.parent = tileSlots[i];
                        t.transform.localPosition = new Vector3(0, 0, 0);
                        t.transform.localEulerAngles = new Vector3(0, 0, 0);
                        break;
                    }
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
