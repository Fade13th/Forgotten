using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour {
    public delegate int roll();

    public static int RollDie(roll dice, int times) {
        int tot = 0;

        for (int i = 0; i < times; i++) {
            tot += dice();
        }

        return tot;
    }

	public static int d2() {
        return Random.Range(1, 3);
    }

    public static int d3() {
        return Random.Range(1, 4);
    }

    public static int d4() {
        return Random.Range(1, 5);
    }

    public static int d6() {
        return Random.Range(1, 7);
    }

    public static int d8() {
        return Random.Range(1, 9);
    }

    public static int d10() {
        return Random.Range(1, 11);
    }

    public static int d20() {
        return Random.Range(1, 21);
    }

    public static int d100() {
        return Random.Range(1, 101);
    }
}
