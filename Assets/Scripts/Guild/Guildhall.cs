using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guildhall : MonoBehaviour {

    private static Guild guild;

    private static PlayerStats playerStats;

    public static void SetStats () {
        playerStats = GameObject.Find("PlayerStats").GetComponent<PlayerStats>();
	}

    public static void SetGuild(Guild g) {
        guild = g;
    }

    public static void Show() {
        playerStats.UpdateStats(guild.leader);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
