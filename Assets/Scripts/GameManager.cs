using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static Game game { get; set; }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.L)) {
            print(game.name);
            foreach(Classes i in game.guild.members) {
                print(i.Str);
            }
        }

        if (Input.GetKeyDown(KeyCode.K)) {
            game.guild.AddSorcerer();
        }

        if (Input.GetKeyDown(KeyCode.T)) {
            SaveLoad.Save(game);
        }

        if (Input.GetKeyDown(KeyCode.Y)) {
            SaveLoad.Load();
        }
    }
}
