using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.Target;

namespace LooCast.Movement
{
    public abstract class TargetedMovement : Movement
    {
        protected LooCast.Target.Target target;

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Accelerate()
        {

        }

        public virtual LooCast.Target.Target GetTarget()
        {
            return target;
        }

        public virtual void SetTarget(LooCast.Target.Target target)
        {
            this.target = target;
        }
    } 
}
