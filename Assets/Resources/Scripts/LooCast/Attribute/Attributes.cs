using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Attribute
{
    public static class Attributes
    {
        private static readonly StrengthAttribute strength = new StrengthAttribute();
        private static readonly ConstitutionAttribute constitution = new ConstitutionAttribute();
        private static readonly DefenseAttribute defense = new DefenseAttribute();
        private static readonly DexterityAttribute dexterity = new DexterityAttribute();
        private static readonly IntelligenceAttribute intelligence = new IntelligenceAttribute();
        private static readonly CharismaAttribute charisma = new CharismaAttribute();
        private static readonly WisdomAttribute wisdom = new WisdomAttribute();
        private static readonly WillpowerAttribute willpower = new WillpowerAttribute();
        private static readonly PerceptionAttribute perception = new PerceptionAttribute();
        private static readonly LuckAttribute luck = new LuckAttribute();
        

        private static Dictionary<string, Attribute> attributes;

        public static void Initialize()
        {
            attributes = new Dictionary<string, Attribute>();
            TryAdd(strength.GetType().Name, strength);
            TryAdd(constitution.GetType().Name, constitution);
            TryAdd(defense.GetType().Name, defense);
            TryAdd(dexterity.GetType().Name, dexterity);
            TryAdd(intelligence.GetType().Name, intelligence);
            TryAdd(charisma.GetType().Name, charisma);
            TryAdd(wisdom.GetType().Name, wisdom);
            TryAdd(willpower.GetType().Name, willpower);
            TryAdd(perception.GetType().Name, perception);
            TryAdd(luck.GetType().Name, luck);


            foreach (KeyValuePair<string, Attribute> attributeKeyValuePair in attributes)
            {
                attributeKeyValuePair.Value.Initialize();
            }
        }

        public static Attribute GetAttribute(string statClassName)
        {
            return attributes.TryGetValue(statClassName, out Attribute attribute) ? attribute : null;
        }

        public static bool TryAdd(string name, Attribute attribute)
        {
            return attributes.TryAdd(name, attribute);
        }
    } 
}
