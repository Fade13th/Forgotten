using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Position : MonoBehaviour {
    public int x;
    public int y;

    private Image image;
    private Text name;

    void Start() {
        image = Helper.FindInChildren(gameObject, "CharacterImage").GetComponent<Image>();
        name = Helper.FindInChildren(gameObject, "Name").GetComponent<Text>();
    }

    public void Set(Entity e) {
        name.text = e.name;
    }

    public void Clear() {
        name.text = "";
    }

    public void Clicked() {
        PartySelectUI.SelectPosition(this);

        print(this);
    }

    public Vector2 getPos() {
        return new Vector2(x, y);
    }
}
