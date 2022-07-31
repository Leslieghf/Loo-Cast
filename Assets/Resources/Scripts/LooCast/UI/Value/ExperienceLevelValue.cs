using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LooCast.UI.Value
{
    using LooCast.Player.Data.Runtime;

    public class ExperienceLevelValue : Value
    {
        public PlayerExperienceRuntimeData PlayerExperienceRuntimeData;

        private void Start()
        {
            PlayerExperienceRuntimeData.CurrentLevel.OnValueChanged.AddListener( () => { Refresh(); });
        }

        public override void Refresh()
        {
            Text.text = $"Lvl {PlayerExperienceRuntimeData.CurrentLevel.Value}";
        }
    }
}
