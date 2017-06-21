using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemberList : MonoBehaviour {
    public MemberRow row;
    public Transform content;

    public void MakeList() {
        foreach(Transform p in content.GetComponentsInChildren<Transform>()) {
            if (p != content)
                Destroy(p.gameObject);
        }

        int y = 40 * GameManager.game.guild.members.Count - 40;
        int i = 0;

        if (GameManager.game == null) return;

        foreach(Classes member in GameManager.game.guild.members) {
            i++;
            MemberRow r = Instantiate(row);

            content.GetComponent<RectTransform>().sizeDelta = new Vector2(332, 80 * i);
            GetComponent<ScrollRect>().verticalNormalizedPosition = 1;

            r.transform.parent = content;
            r.transform.localPosition = new Vector3(0, y, 0);
            print(r.transform.localPosition);

            y -= 72;
            r.Setup(member);

        }
    }
}
