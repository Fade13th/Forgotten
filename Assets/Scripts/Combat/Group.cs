using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Group {
    protected int size = 0;
    protected List<Entity> members;
    public Dictionary<Entity, Pair> formation;

    public Group() {
        members = new List<Entity>();
        formation = new Dictionary<Entity, Pair>();
    }

    public void AddMember(Entity member, Pair coord) {
        members.Add(member);
        formation.Add(member, coord);
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
