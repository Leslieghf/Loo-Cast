namespace LooCast.Health.Data
{
    using LooCast.Core.Data;
    using LooCast.Data;

    public abstract class HealthData : Data
    {
        public FloatReference BaseMaxHealth;
        public FloatReference BaseRegenerationAmount;
        public IntReference BaseDefense;
    } 
}
