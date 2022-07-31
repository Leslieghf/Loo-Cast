namespace LooCast.Core
{
    using Core.Data;
    using Core.Data.Runtime;

    public class ExampleUniqueComponent : UniqueComponent
    {
        public ExampleUniqueComponentData Data;

        public ExampleUniqueComponentRuntimeData RuntimeData;

        private void Start()
        {
            RuntimeData.RuntimeData1 = Data.Data1.Value;
            RuntimeData.RuntimeData2 = Data.Data2.Value;
            RuntimeData.RuntimeData3 = Data.Data3.Value;
        }
    } 
}