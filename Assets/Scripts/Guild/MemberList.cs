using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemberList : MonoBehaviour {
    public MemberRow row;
    public Transform content;

    public void MakeList() {
        int y = 240;

        if (GameManager.game == null) return;

        foreach(Classes member in GameManager.game.guild.members) {
            MemberRow r = Instantiate(row);

            r.transform.parent = content;
            r.transform.localPosition = new Vector3(165, y - 275, 0);
            print(r.transform.localPosition);

            y -= 72;
            r.Setup(member);
        }
    }
}
