namespace LooCast.Core
{
    using Core.Data;

    public class ExampleComponent : Component
    {
        public ExampleComponentData Data;

        public float RuntimeData1 { get; private set; }
        public float RuntimeData2 { get; private set; }
        public float RuntimeData3 { get; private set; }

        private void Start()
        {
            RuntimeData1 = Data.Data1.Value;
            RuntimeData2 = Data.Data2.Value;
            RuntimeData3 = Data.Data3.Value;
        }
    } 
}