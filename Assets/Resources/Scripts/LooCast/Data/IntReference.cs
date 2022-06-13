using System;

[Serializable]
public class IntReference 
{
    public bool UseConstant = true;
    public int ConstantValue;
    public IntReference Variable;

    public int Value
    {
        get
        {
            return UseConstant ? ConstantValue : Variable.Value;
        }
    }
}
