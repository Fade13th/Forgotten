using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper {
    public static GameObject FindInChildren(GameObject gameObject, string name) {
        foreach (Transform t in gameObject.GetComponentsInChildren<Transform>()) {
            if (t.name == name)
                return t.gameObject;
        }

        return null;
    }

    public static string TwoDigit(int i) {
        string s = i + "";

        if (s.Length < 2)
            return "0" + s;

        else if (s.Length > 2)
            return s.Substring(s.Length - 3);

        else
            return s;
    }

    public static string TwoDigitf(float f) {
        return f + "";
    }
}