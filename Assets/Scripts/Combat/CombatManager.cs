using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour {
    private static Entity[] order;
    private static int turns, turnsGone;
    private static Party party;
    private static Group enemies;
    private static CanvasGroup canvas;

    void Start() {
        canvas = GetComponent<CanvasGroup>();
    }

    public static void StartCombat(Party p, Group foes) {
        canvas.alpha = 1;
        canvas.blocksRaycasts = true;

        party = p;
        enemies = foes;

        Dictionary<Entity, int> initiatives = new Dictionary<Entity, int>();

        foreach(Classes e in party.GetMembers()) {
            initiatives.Add(e, e.initiative);

            Pair pos = party.formation[e];
            Arena.addEntity(e, pos.x, pos.y);
        }

        foreach(Entity e in enemies.GetMembers()) {
            initiatives.Add(e, e.initiative);

            Pair pos = enemies.formation[e];
            Arena.addEntity(e, pos.x, pos.y);
        }

        turns = initiatives.Count;

        order = new Entity[turns];

        for (int i = 0; i < turns; i++) {
            int max = 0;
            Entity next = null;

            foreach(Entity e in initiatives.Keys) {
                if (max == 0 || initiatives[e] > max || (initiatives[e] == max && e.Dex > next.Dex)) {
                    max = initiatives[e];
                    next = e;
                }
            }

            order[i] = next;

            initiatives.Remove(next);
        }

        RunTurns();
    }

    private static void RunTurns() {
        int x = 0;

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

            if (x > 10) return;
            x++;
        }
    }

    private static void Turn() {
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
