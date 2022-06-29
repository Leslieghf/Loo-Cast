using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Attribute
{
    [CreateAssetMenu(fileName = "Attributes", menuName = "Data/Attribute/Attributes", order = 0)]
    public class Attributes : ScriptableObject
    {
        public CharismaAttribute Charisma;
        public ConstitutionAttribute Constitution;
        public DefenseAttribute Defense;
        public DexterityAttribute Dexterity;
        public IntelligenceAttribute Intelligence;
        public LuckAttribute Luck;
        public PerceptionAttribute Perception;
        public StrengthAttribute Strength;
        public WillpowerAttribute Willpower;
        public WisdomAttribute Wisdom;
    } 
}
