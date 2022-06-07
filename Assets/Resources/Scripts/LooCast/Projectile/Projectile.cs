using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LooCast.Projectile
{
    using Util;
    using Target;

    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Projectile : ExtendedMonoBehaviour
    {
        public readonly static List<Projectile> projectiles = new List<Projectile>();

        protected Rigidbody2D rb;
        protected Target target;
        public GameObject origin { get; protected set; }

        public float damage { get; protected set; }
        public float critChance { get; protected set; }
        public float critDamage { get; protected set; }
        public float knockback { get; protected set; }
        public float speed { get; protected set; }
        public float size { get; protected set; }
        public float lifetime { get; protected set; }
        public int piercing { get; protected set; }
        public int pierced { get; protected set; }
        public int armorPenetration { get; protected set; }

        protected bool isAlive = true;

        public UnityEvent onEngageTargetLockFail { get; protected set; }
        public UnityEvent onEngageTargetLockSuccess { get; protected set; }
        public UnityEvent onDisengageTargetLock { get; protected set; }
        public UnityEvent onAcquireTarget { get; protected set; }
        public UnityEvent onLostTarget { get; protected set; }

        private Vector3 PAUSE_currentVelocity;

        protected virtual void Initialize(Target target, GameObject origin, float damage, float critChance, float critDamage, float knockback, float speed, float size, float lifetime, int piercing, int armorPenetration)
        {
            projectiles.Add(this);

            rb = GetComponent<Rigidbody2D>();
            this.target = target;
            this.origin = origin;
            this.damage = damage;
            this.critChance = critChance;
            this.critDamage = critDamage;
            this.knockback = knockback;
            this.speed = speed;
            this.size = size;
            transform.localScale *= size;
            this.lifetime = lifetime;
            this.piercing = piercing;
            this.pierced = 0;
            this.armorPenetration = armorPenetration;

            onEngageTargetLockFail = new UnityEvent();
            onEngageTargetLockSuccess = new UnityEvent();
            onDisengageTargetLock = new UnityEvent();
            onAcquireTarget = new UnityEvent();
            onLostTarget = new UnityEvent();

            
            onEngageTargetLockFail.AddListener(OnEngageTargetLockFail);
            onEngageTargetLockSuccess.AddListener(OnEngageTargetLockSuccess);
            onDisengageTargetLock.AddListener(OnDisengageTargetLock);
            onAcquireTarget.AddListener(OnAcquireTarget);
            onLostTarget.AddListener(OnLostTarget);
        }

        protected override void Cycle()
        {
            lifetime -= Time.deltaTime;
            if (lifetime <= 0)
            {
                Kill();
            }
        }

        protected override void OnPause()
        {
            PAUSE_currentVelocity = rb.velocity;
            rb.velocity = Vector3.zero;
        }

        protected override void OnResume()
        {
            rb.velocity = PAUSE_currentVelocity;
            PAUSE_currentVelocity = Vector3.zero;
        }

        protected virtual void Kill()
        {
            if (isAlive)
            {
                isAlive = false;
                projectiles.Remove(this);
                DisengageTargetLock();
                LoseTarget();
                Destroy(gameObject);
            }
        }

        protected void EngageTargetLock(Target target, out bool success)
        {
            Target.EngageTargetLock(target, out success);
            if (success)
            {
                target.onInvalidated.AddListener(LoseTarget);

                onEngageTargetLockSuccess.Invoke();
            }
            else
            {
                onEngageTargetLockFail.Invoke();
            }
        }

        protected void DisengageTargetLock()
        {
            Target.DisengageTargetLock(target);

            onDisengageTargetLock.Invoke();
        }

        protected void LoseTarget()
        {
            target = null;

            onLostTarget.Invoke();
        }

        protected void AcquireTarget(Target target)
        {
            this.target = target;

            onAcquireTarget.Invoke();
        }

        protected virtual void OnEngageTargetLockFail()
        {

        }

        protected virtual void OnEngageTargetLockSuccess()
        {

        }

        protected virtual void OnDisengageTargetLock()
        {

        }

        protected virtual void OnAcquireTarget()
        {

        }

        protected virtual void OnLostTarget()
        {

        }
    } 
}
