using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Movement
{
    using Target;
    using Util;

    public class EnemyMovement : TargetedMovement
    {
        private GameObject playerObject;
        private CircleCollider2D playerCollider;
        private float baseDrag = 0.75f;

        public override void Initialize()
        {
            base.Initialize();
            playerObject = GameObject.FindGameObjectWithTag("Player");
            playerCollider = playerObject.GetComponent<CircleCollider2D>();
            SetTarget(new Target(playerCollider));
            SetMovementSpeed(0.75f * UnityEngine.Random.Range(0.9f, 1.1f));
        }

        public override void Accelerate()
        {
            if (isMovementEnabled)
            {
                Rigidbody.drag = baseDrag / SlownessMultiplier;
                Rigidbody.AddForce((target.transform.position - transform.position).normalized * Constants.INERTIAL_COEFFICIENT * MovementSpeed * SlownessMultiplier);

                Vector2 lookDir = target.transform.position - transform.position;
                float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90.0f;
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, angle);
            }
        }
    } 
}
