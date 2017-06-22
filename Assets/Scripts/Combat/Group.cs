using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Group {
    protected int size = 0;
    protected List<Entity> members;
    public Dictionary<Entity, Vector2> formation;

    public void AddMember(Entity member) {
        members.Add(member);
        size++;
    }

    public void RemoveMember(Entity member) {
        if (members.Contains(member)) {
            members.Remove(member);
            size--;
        }
    }

    public List<Entity> GetMembers() {
        return members;
    }
}
