using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guildhall : MonoBehaviour {

    private static Guild guild;

    private static PlayerStats playerStats;
    private static MemberList memberList;

    public static void SetStats () {
        playerStats = GameObject.Find("PlayerStats").GetComponent<PlayerStats>();
        memberList = GameObject.Find("MemberList").GetComponent<MemberList>();
	}

    public static void SetGuild(Guild g) {
        guild = g;
    }

    public static void Show() {
        playerStats.UpdateStats(guild.leader);
        memberList.MakeList();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
