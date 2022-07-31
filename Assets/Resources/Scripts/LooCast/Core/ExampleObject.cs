namespace LooCast.Core
{
    using Core.Data;

    public class ExampleObject : Object
    {
        public ExampleObjectData Data { get; protected set; }

        public float RuntimeData1;
        public float RuntimeData2;
        public float RuntimeData3;

        public ExampleObjectRuntimeSet RuntimeSet { get; protected set; }

        public ExampleComponent ExampleComponent;

        private void Start()
        {
            RuntimeSet.Add(this);

            RuntimeData1 = Data.Data1.Value;
            RuntimeData2 = Data.Data2.Value;
            RuntimeData3 = Data.Data3.Value;
        }
    } 
}