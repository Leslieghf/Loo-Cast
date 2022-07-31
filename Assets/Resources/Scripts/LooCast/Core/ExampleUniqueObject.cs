namespace LooCast.Core
{
    using Core.Data;

    public class ExampleUniqueObject : UniqueObject
    {
        public ExampleUniqueObjectData Data { get; private set; }

        public ExampleUniqueObjectRuntimeData RuntimeData { get; private set; }

        public ExampleComponent Component { get; private set; }

        private void Start()
        {
            RuntimeData.RuntimeData1 = Data.Data1.Value;
            RuntimeData.RuntimeData2 = Data.Data2.Value;
            RuntimeData.RuntimeData3 = Data.Data3.Value;
        }
    } 
}