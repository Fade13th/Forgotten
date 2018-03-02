using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guildhall : MonoBehaviour {

    private static Guild guild;

    private static PlayerStats playerStats;
    private static MemberList memberList;
    private static CanvasGroup canvas;

    public static void SetStats () {
        playerStats = GameObject.Find("PlayerStats").GetComponent<PlayerStats>();
        memberList = GameObject.Find("MemberList").GetComponent<MemberList>();
	}

    public static void SetGuild(Guild g) {
        canvas = GameObject.Find("Guild").GetComponent<CanvasGroup>();
        guild = g;
    }

    public static void Show() {
        canvas.alpha = 1;
        canvas.blocksRaycasts = true;

        playerStats.UpdateStats(guild.leader);
        memberList.MakeList();
        GameObject.Find("PartySelect").GetComponent<PartySelectUI>().MakeList();
    }
	
    public static void Hide() {
        canvas.alpha = 0;
        canvas.blocksRaycasts = false;
    }
}
