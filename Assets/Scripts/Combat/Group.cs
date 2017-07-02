using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Group {
    protected int size = 0;
    protected List<Entity> members;
    public Dictionary<Entity, Vector2> formation;

    public Group() {
        members = new List<Entity>();
        formation = new Dictionary<Entity, Vector2>();
    }

    public void AddMember(Entity member, Vector2 pos) {
        members.Add(member);
        formation.Add(member, pos);
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
