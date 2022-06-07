using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Health
{
    public struct DamageInfo
    {
        public GameObject origin { get; set; }
        public GameObject carrier { get; set; }
        public float damage { get; set; }
        public float knockback { get; set; }
        public int armorPenetration { get; set; }

        public DamageInfo(GameObject origin, GameObject carrier, float damage, float knockback, int armorPenetration)
        {
            this.origin = origin;
            this.carrier = carrier;
            this.damage = damage;
            this.knockback = knockback;
            this.armorPenetration = armorPenetration;
        }
    } 
}
