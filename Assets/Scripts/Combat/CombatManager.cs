using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CombatManager {
    private static Arena arena;
    private static Entity[] order;
    private static Dictionary<Entity, Vector2> positions;
    private static int turns, turnsGone;

    public static void StartCombat(Arena a, Party party, Group enemies) {
        arena = a;

        positions = new Dictionary<Entity, Vector2>();
        Dictionary<Entity, int> inspirations = new Dictionary<Entity, int>();

        foreach(Classes e in party.GetMembers()) {
            inspirations.Add(e, e.initiative);
            positions.Add(e, party.formation[e]);
        }

        foreach(Entity e in enemies.GetMembers()) {
            inspirations.Add(e, e.initiative);
            positions.Add(e, enemies.formation[e]);
        }

        turns = inspirations.Count;

        order = new Entity[turns];

        for (int i = 0; i < turns; i++) {
            int max = 0;
            Entity next = null;

            foreach(Entity e in inspirations.Keys) {
                if (max == 0 || inspirations[e] > max || (inspirations[e] == max && e.Dex > next.Dex)) {
                    max = inspirations[e];
                    next = e;
                }
            }

            order[i] = next;

            inspirations.Remove(next);
        }
    }

    private static void Turn() {
        turnsGone = 0;
        while ( turnsGone < turns) {

        }
    }
}
