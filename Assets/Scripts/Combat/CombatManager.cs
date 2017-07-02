using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour {
    public Arena arena;
    private Entity[] order;
    private Dictionary<Entity, Vector2> positions;
    private int turns, turnsGone;
    private Party party;
    private Group enemies;

    public void StartCombat(Arena a, Party p, Group foes) {
        arena = a;
        party = p;
        enemies = foes;

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

        RunTurns();
    }

    private void RunTurns() {
        while (true) {
            bool playerAlive = false, enemyAlive = false;

            foreach (Entity e in party.GetMembers()) {
                if (e.alive) {
                    playerAlive = true;
                    break;
                }
            }

            foreach (Entity e in enemies.GetMembers()) {
                if (e.alive) {
                    enemyAlive = true;
                    break;
                }
            }

            if (!playerAlive || !enemyAlive) return;
            else Turn();
        }
    }

    private void Turn() {
        turnsGone = 0;
        while ( turnsGone < turns) {
            CombatUI.Turn(order[turnsGone]);
            turnsGone++;
        }
    }

    public void UseAbility(Ability ability, Entity user, Entity[] targets) {
        ability.Use(user, targets);
    }

    public void UseItem(Consumable item, Entity target) {
        item.Use(target);
    }
}
