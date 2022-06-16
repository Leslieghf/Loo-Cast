using System;

namespace LooCast.Data
{
    [Serializable]
    public class StringReference
    {
        public bool UseConstant = true;
        public string ConstantValue;
        public StringVariable Variable;

        public string Value
        {
            get
            {
                return UseConstant ? ConstantValue : Variable.Value;
            }
        }
    } 
}
