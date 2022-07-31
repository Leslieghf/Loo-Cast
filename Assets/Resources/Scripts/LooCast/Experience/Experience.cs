namespace LooCast.Experience
{
    using LooCast.Core;

    public abstract class Experience : Component
    {
        public abstract void AddExperience(float xp);

        protected abstract void UpdateLevelProgress(float overflowXP);

        protected abstract void IncreaseLevel();
    } 
}
