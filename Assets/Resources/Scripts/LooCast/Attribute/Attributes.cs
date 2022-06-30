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

        public void Cheat()
        {
            Charisma.Level.Value = Charisma.MaxLevel.Value;
            Constitution.Level.Value = Constitution.MaxLevel.Value;
            Defense.Level.Value = Defense.MaxLevel.Value;
            Dexterity.Level.Value = Dexterity.MaxLevel.Value;
            Intelligence.Level.Value = Intelligence.MaxLevel.Value;
            Luck.Level.Value = Luck.MaxLevel.Value;
            Perception.Level.Value = Perception.MaxLevel.Value;
            Strength.Level.Value = Strength.MaxLevel.Value;
            Willpower.Level.Value = Willpower.MaxLevel.Value;
            Wisdom.Level.Value = Wisdom.MaxLevel.Value;
        }

        public void Uncheat()
        {
            Charisma.Level.Value = 0;
            Constitution.Level.Value = 0;
            Defense.Level.Value = 0;
            Dexterity.Level.Value = 0;
            Intelligence.Level.Value = 0;
            Luck.Level.Value = 0;
            Perception.Level.Value = 0;
            Strength.Level.Value = 0;
            Willpower.Level.Value = 0;
            Wisdom.Level.Value = 0;
        }
    } 
}
