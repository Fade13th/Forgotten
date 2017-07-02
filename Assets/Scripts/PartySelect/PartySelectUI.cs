using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartySelectUI : MonoBehaviour {
    public PartySelectRow row;
    public RectTransform memberList;
    public RectTransform content;
    public static int selectAllowed = 4;

    private static Entity selectedEntity;
    private static int selected = 0;
    private static Dictionary<Entity, Position> assigned;

    void Start() {
        assigned = new Dictionary<Entity, Position>();
    }

    public static void SelectEntity(Entity e) {
        selectedEntity = e;
    }

    public static void SelectPosition(Position pos) {
        if (selectedEntity != null && selected < selectAllowed) {
            if (assigned.ContainsKey(selectedEntity)) {
                assigned[selectedEntity].Clear();
                assigned.Remove(selectedEntity);
            }

            pos.Set(selectedEntity);
            assigned.Add(selectedEntity, pos);
        }
    }

	public void MakeList() {
        foreach (Transform p in content.GetComponentsInChildren<Transform>()) {
            if (p != content)
                Destroy(p.gameObject);
        }

        int y = 40 * GameManager.game.guild.members.Count + 130;
        int i = 0;

        if (GameManager.game == null) return;

        foreach (Classes member in GameManager.game.guild.members) {
            i++;
            PartySelectRow r = Instantiate(row);

            content.GetComponent<RectTransform>().sizeDelta = new Vector2(332, 80 * i);
            memberList.GetComponent<ScrollRect>().verticalNormalizedPosition = 1;

            r.transform.parent = content;
            r.transform.localPosition = new Vector3(0, y, 0);

            y -= 72;
            r.Setup(member);

        }
    }

}
