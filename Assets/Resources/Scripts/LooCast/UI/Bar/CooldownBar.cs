using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.UI.Bar
{
    using Manager;
    using Weapon;
    using Sound;

    public class CooldownBar : Bar
    {
        [SerializeField]
        private string weaponName;
        private Weapon weapon;

        public void Initialize()
        {
            GameSceneManager.Instance.Player.Weapons.TryGetValue(weaponName, out Weapon weapon);
            this.weapon = weapon;
            SetMaxValue(weapon.attackDelay + 0.25f);
            SetValue(weapon.attackTimer);
        }

        private void Update()
        {
            SetValue(weapon.attackTimer);
        }
    }
}
