using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Classes.Skills {

    [System.Serializable]
    public class Skill {
        public int range;
        public Vector2 aoe;
        public int baseDC;

        protected Entity user;

        public Skill(Entity u) {
            user = u;
        }

        public virtual void Use(List<Entity> targets) { }


    }
}
