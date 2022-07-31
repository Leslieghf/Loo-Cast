namespace LooCast.Experience.Data
{
    using LooCast.Core.Data;
    using LooCast.Data;

    public abstract class ExperienceData : UniqueComponentData
    {
        public FloatReference InitialExperience;
        public FloatReference InitialLevelExperienceMax;
        public IntReference InitialLevel;
    } 
}