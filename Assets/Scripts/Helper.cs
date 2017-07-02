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

    public static void RemoveByValue<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TValue someValue) {
        List<TKey> itemsToRemove = new List<TKey>();

        foreach (var pair in dictionary) {
            if (pair.Value.Equals(someValue))
                itemsToRemove.Add(pair.Key);
        }

        foreach (TKey item in itemsToRemove) {
            dictionary.Remove(item);
        }
    }
}