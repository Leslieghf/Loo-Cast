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
        [SerializeField] private string weaponName;
        private Weapon weapon;

        public void Initialize()
        {
            GameSceneManager.Instance.Player.Weapons.TryGetValue(weaponName, out Weapon weapon);
            this.weapon = weapon;
        }

        public override void Refresh()
        {
            Slider.maxValue = weapon.attackDelay;
            Slider.value = weapon.attackTimer;
        }

        private void Update()
        {
            Refresh();
        }
    }
}
