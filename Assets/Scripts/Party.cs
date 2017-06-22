using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Party : Group {

    [SerializeField] protected int maxSize = 4;

    public void AddMember(Classes member) {
        if (size < maxSize) {
            members.Add(member);
            size++;
        }
    }    
}
