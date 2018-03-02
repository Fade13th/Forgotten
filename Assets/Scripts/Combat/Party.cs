using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Party : Group {

    [SerializeField] protected int maxSize = 4;

    public Party() : base() {
    }

    public void AddMember(Classes member, Pair coord) {
        if (size < maxSize) {
            members.Add(member);
            formation.Add(member, coord);
            size++;
        }
    }    
}
