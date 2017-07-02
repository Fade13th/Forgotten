using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Classes.Skills.Sorcerer {
[System.Serializable]
    public class SkillTreeSorcerer : SkillTree {
        public SkillTreeSorcerer() {
            parentSkill = new Dictionary<Skill, Skill>();
            unlocked = new Dictionary<Skill, bool>();


        }
    }
}