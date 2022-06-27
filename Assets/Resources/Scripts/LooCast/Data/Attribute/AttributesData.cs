using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Attribute
{
    [CreateAssetMenu(fileName = "AttributesData", menuName = "Data/Attribute/AttributesData", order = 0)]
    public sealed class AttributesData : ScriptableObject
    {
        public CharismaAttributeData CharismaAttributeData;
        public ConstitutionAttributeData ConstitutionAttributeData;
        public DefenseAttributeData DefenseAttributeData;
        public DexterityAttributeData DexterityAttributeData;
        public IntelligenceAttributeData IntelligenceAttributeData;
        public LuckAttributeData LuckAttributeData;
        public PerceptionAttributeData PerceptionAttributeData;
        public StrengthAttributeData StrengthAttributeData;
        public WillpowerAttributeData WillpowerAttributeData;
        public WisdomAttributeData WisdomAttributeData;
    } 
}
