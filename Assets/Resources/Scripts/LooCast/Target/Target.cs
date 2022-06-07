using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

namespace LooCast.Target
{
    using Health;

    //When the gameObject is null, the Target should be Destructed
    public class Target : IEquatable<Target>
    {
        public GameObject gameObject { get; }
        public Transform transform { get { return gameObject.transform; } }
        public Health health { get; }
        private bool targetLockEngaged;
        /// <summary>
        /// Invoked, when this Target is invalid, and right before it will be destroyed
        /// </summary>
        public UnityEvent onInvalidated;

        public Target(GameObject gameObject)
        {
            this.gameObject = gameObject;
            health = null;
            targetLockEngaged = false;
            onInvalidated = new UnityEvent();
        }

        public Target(GameObject gameObject, Health health)
        {
            this.gameObject = gameObject;
            this.health = health;
            targetLockEngaged = false;
            onInvalidated = new UnityEvent();
        }

        public Target(Collision2D collision)
        {
            gameObject = collision.gameObject;
            health = gameObject.GetComponent<Health>();
            targetLockEngaged = false;
            onInvalidated = new UnityEvent();
        }

        public Target(Collider2D collider)
        {
            gameObject = collider.gameObject;
            health = gameObject.GetComponent<Health>();
            targetLockEngaged = false;
            onInvalidated = new UnityEvent();
        }

        public static void EngageTargetLock(Target target, out bool success)
        {
            if (target == null || !target.IsValid() || target.IsLocked())
            {
                success = false;
            }
            else
            {
                target.targetLockEngaged = true;
                success = true;
            }
        }

        public static void DisengageTargetLock(Target target)
        {
            if (target != null && target.IsLocked())
            {
                target.targetLockEngaged = false;
            }
        }

        public bool IsLocked()
        {
            return targetLockEngaged;
        }

        public bool IsValid()
        {
            if (gameObject == null)
            {
                onInvalidated.Invoke();
                return false;
            }
            return true;
        }

        public bool Equals(Target other)
        {
            return gameObject.GetInstanceID() == other.gameObject.GetInstanceID();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Target);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    } 
}
