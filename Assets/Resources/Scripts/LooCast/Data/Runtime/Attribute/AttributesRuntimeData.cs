using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute
{
    [CreateAssetMenu(fileName = "AttributesRuntimeData", menuName = "Data/Runtime/Attribute/AttributesRuntimeData", order = 0)]
    public sealed class AttributesRuntimeData : ScriptableObject
    {
        public CharismaAttributeRuntimeData CharismaAttributeRuntimeData;
        public ConstitutionAttributeRuntimeData ConstitutionAttributeRuntimeData;
        public DefenseAttributeRuntimeData DefenseAttributeRuntimeData;
        public DexterityAttributeRuntimeData DexterityAttributeRuntimeData;
        public IntelligenceAttributeRuntimeData IntelligenceAttributeRuntimeData;
        public LuckAttributeRuntimeData LuckAttributeRuntimeData;
        public PerceptionAttributeRuntimeData PerceptionAttributeRuntimeData;
        public StrengthAttributeRuntimeData StrengthAttributeRuntimeData;
        public WillpowerAttributeRuntimeData WillpowerAttributeRuntimeData;
        public WisdomAttributeRuntimeData WisdomAttributeRuntimeData;
    } 
}
