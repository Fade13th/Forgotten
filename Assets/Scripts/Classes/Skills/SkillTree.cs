using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Classes.Skills {

    [System.Serializable]
    public class SkillTree {
        protected Dictionary<Skill, Skill> parentSkill;
        protected Dictionary<Skill, bool> unlocked;
    }
}
