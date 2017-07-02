using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Classes.Skills.Sorcerer {
    [System.Serializable]
    class ArcaneRay : Skill {
        public ArcaneRay(Entity u) : base(u) {
        }

        public override void Use(List<Entity> targets) {
            int damage = Roll.d3();
            int DC = baseDC + user.GetSpellDC();

            foreach (Entity e in targets) {
                e.TakeMagicDamage(damage, DC);
            }
        }
    }
}
