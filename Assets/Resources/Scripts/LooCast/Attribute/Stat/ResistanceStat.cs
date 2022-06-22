using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;

namespace LooCast.Attribute.Stat
{
    public class ResistanceStat : Stat
    {
        public int DefenseIncrease
        {
            get
            {
                int.TryParse(new DataTable().Compute($"{Level} * 5", "").ToString(), out int value);
                return value;
            }
        }

        public override string ValueToString()
        {
            return $"+{new DataTable().Compute($"{Level} * 5", "")}";
        }
    } 
}
