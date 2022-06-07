using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.Attribute.Stat;
using LooCast.UI.Value;

namespace LooCast.UI.Panel
{
    public class StatsListPanel : Panel
    {
        [SerializeField]
        private StatValue[] values;

        public override void Initialize()
        {
            int i = 0;
            foreach (KeyValuePair<string, Stat> keyValuePair in Stats.stats)
            {
                int level = keyValuePair.Value.GetLevel();
                values[i].Initialize(keyValuePair.Value, level);
                i++;
            }
        }

        public override void Refresh()
        {
            int i = 0;
            foreach (KeyValuePair<string, Stat> keyValuePair in Stats.stats)
            {
                values[i].Refresh();
                i++;
            }
        }

        public StatValue GetStatValue(string statClassName)
        {
            int index = 0;
            foreach (string key in Stats.stats.Keys)
            {
                if (key.Equals(statClassName))
                {
                    break;
                }

                index++;
            }
            return values[index];
        }
    } 
}
