using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LooCast.Target
{
    public class Targeting : MonoBehaviour
    {
        public float radius;
        public string[] targetTags;
        public bool drawGizmos;
        private System.Random random;
        public List<Target> ignoredTargets;
        public List<Target> closestTargets
        {
            get
            {
                return FilterTargets(GetClosestTargets(), ignoredTargets);
            }
            protected set
            {
                _closestTargets = value;
            }
        }
        protected List<Target> _closestTargets;

        public List<Target> furthestTargets
        {
            get
            {
                return FilterTargets(GetFurthestTargets(), ignoredTargets);
            }
            protected set
            {
                _furthestTargets = value;
            }
        }
        protected List<Target> _furthestTargets;

        public List<Target> randomTargets
        {
            get
            {
                return FilterTargets(GetRandomTargets(), ignoredTargets);
            }
            protected set
            {
                _randomTargets = value;
            }
        }
        protected List<Target> _randomTargets;

        public List<Target> randomOnscreenTargets
        {
            get
            {
                return FilterTargets(GetRandomOnscreenTargets(), ignoredTargets);
            }
            protected set
            {
                _randomOnscreenTargets = value;
            }
        }
        protected List<Target> _randomOnscreenTargets;

        public List<Target> randomProximityTargets
        {
            get
            {
                return FilterTargets(GetRandomProximityTargets(), ignoredTargets);
            }
            protected set
            {
                _randomProximityTargets = value;
            }
        }
        protected List<Target> _randomProximityTargets;

        private void OnDrawGizmos()
        {
            if (drawGizmos)
            {
                Gizmos.DrawWireSphere(transform.position, radius);
            }
        }

        private void LateUpdate()
        {
            _closestTargets = null;
            _furthestTargets = null;
            _randomTargets = null;
            _randomOnscreenTargets = null;
        }

        public void Initialize()
        {
            radius = 20.0f;
            targetTags = new string[] {"Enemy", "EnemyStation"};
            drawGizmos = false;
            random = new System.Random(Mathf.RoundToInt(Time.time));
            ignoredTargets = new List<Target>();
        }

        bool CheckTags(Collider2D collider, params string[] tags)
        {
            foreach (string tag in tags)
            {
                if (collider.gameObject.CompareTag(tag))
                {
                    return true;
                }
            }
            return false;
        }

        public List<Target> FilterTargets(List<Target> targets, List<Target> ignoredTargets)
        {
            if (targets == null || targets.Count == 0)
            {
                return null;
            }
            if (ignoredTargets == null || ignoredTargets.Count == 0)
            {
                return targets;
            }

            foreach (Target ignoredTarget in ignoredTargets)
            {
                targets.RemoveAll(target => target.Equals(ignoredTarget));
            }

            if (targets.Count == 0)
            {
                return null;
            }
            return targets;
        }

        public List<Target> ValidateTargets(List<Target> targets)
        {
            targets.RemoveAll((target) => !target.IsValid() || target.IsLocked());
            if (targets == null || targets.Count == 0)
            {
                return null;
            }
            return targets;
        }

        protected List<Target> GetClosestTargets()
        {
            if (_closestTargets == null || _closestTargets.Count == 0)
            {
                List<Collider2D> collisions = Physics2D.OverlapCircleAll(transform.position, radius).ToList();

                if (collisions == null || collisions.Count == 0)
                {
                    return null;
                }

                collisions.RemoveAll(collision => !CheckTags(collision, targetTags));

                if (collisions.Count <= 0)
                {
                    return null;
                }

                collisions = collisions.OrderBy(x => Vector2.Distance(transform.position, x.transform.position)).ToList();

                List<Target> targets = new List<Target>();
                foreach (Collider2D collision in collisions)
                {
                    targets.Add(new Target(collision));
                }

                targets = ValidateTargets(targets);

                _closestTargets = targets;
                return targets;
            }
            else
            {
                return ValidateTargets(_closestTargets);
            }
        }

        protected List<Target> GetFurthestTargets()
        {
            if (_furthestTargets == null || _furthestTargets.Count == 0)
            {
                List<Collider2D> collisions = Physics2D.OverlapCircleAll(transform.position, radius).Reverse().ToList();

                if (collisions == null || collisions.Count == 0)
                {
                    return null;
                }

                collisions.RemoveAll(collision => !CheckTags(collision, targetTags));

                if (collisions.Count == 0)
                {
                    return null;
                }

                collisions = collisions.OrderBy(x => Vector2.Distance(transform.position, x.transform.position)).ToList();

                List<Target> targets = new List<Target>();
                foreach (Collider2D collision in collisions)
                {
                    targets.Add(new Target(collision));
                }

                targets = ValidateTargets(targets);

                _furthestTargets = targets;
                return targets;
            }
            else
            {
                return ValidateTargets(_furthestTargets);
            }
        }

        protected List<Target> GetRandomTargets()
        {
            if (_randomTargets == null || _randomTargets.Count == 0)
            {
                List<Target> targets = new List<Target>();
                foreach (string targetTag in targetTags)
                {
                    targets.AddRange(GameObject.FindGameObjectsWithTag(targetTag).ToList().ConvertAll(x => new Target(x.GetComponent<Collider2D>())));
                }
                if (targets == null || targets.Count == 0)
                {
                    return null;
                }
                targets = targets.OrderBy(x => random.Next()).ToList();
                targets = ValidateTargets(targets);

                _randomTargets = targets;
                return targets;
            }
            else
            {
                return ValidateTargets(_randomTargets);
            }
        }

        protected List<Target> GetRandomOnscreenTargets()
        {
            if (_randomOnscreenTargets == null || _randomOnscreenTargets.Count == 0)
            {
                List<Collider2D> collisions = Physics2D.OverlapAreaAll(Camera.main.ScreenToWorldPoint(Vector3.zero), Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height))).ToList();

                if (collisions == null || collisions.Count <= 0)
                {
                    return null;
                }

                collisions.RemoveAll(collision => !CheckTags(collision, targetTags));

                if (collisions.Count <= 0)
                {
                    return null;
                }

                List<Target> targets = new List<Target>();
                foreach (Collider2D collision in collisions)
                {
                    targets.Add(new Target(collision));
                }

                targets = ValidateTargets(targets);

                _randomOnscreenTargets = targets;
                return targets;
            }
            else
            {
                return ValidateTargets(_randomOnscreenTargets);
            }
        }

        protected List<Target> GetRandomProximityTargets()
        {
            if (_randomProximityTargets == null || _randomProximityTargets.Count == 0)
            {
                List<Target> targets = closestTargets;
                if (targets == null || targets.Count == 0)
                {
                    return null;
                }
                targets = targets.OrderBy(x => random.Next()).ToList();
                targets = ValidateTargets(targets);

                _randomProximityTargets = targets;
                return targets;
            }
            else
            {
                return ValidateTargets(_randomProximityTargets);
            }
        }
    }
    public enum TargetingMode
    {
        Closest,
        Furthest,
        Random,
        RandomOnscreen,
        RandomProximity
    }
}
