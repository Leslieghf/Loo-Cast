using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Util
{
    using Core;

    public class LerpFollower : ExtendedMonoBehaviour
    {
        public GameObject target;

        public float speed = 1.0f;

        protected override void OnPauseableUpdate()
        {
            float interpolation = speed * Time.deltaTime * (target.transform.position - transform.position).magnitude;

            Vector3 position = this.transform.position;
            position.y = Mathf.Lerp(this.transform.position.y, target.transform.position.y, interpolation);
            position.x = Mathf.Lerp(this.transform.position.x, target.transform.position.x, interpolation);

            transform.position = position;
        }
    } 
}
