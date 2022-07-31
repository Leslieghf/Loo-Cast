using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Arc
{
    using Core;

    [RequireComponent(typeof(LineRenderer))]
    public class ArcSegment : ExtendedMonoBehaviour
    {
        public LineRenderer lineRenderer { get; protected set; }
        public Vector3 startPos
        {
            get
            {
                return lineRenderer.GetPosition(0);
            }
            set
            {
                lineRenderer.SetPosition(0, value);
            }
        }
        public Vector3 endPos
        {
            get
            {
                return lineRenderer.GetPosition(1);
            }
            set
            {
                lineRenderer.SetPosition(1, value);
            }
        }

        public virtual void Initialize(Vector3 startPos, Vector3 endPos, float width)
        {
            lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.material = Resources.Load<Material>("Materials/Plasma");
            lineRenderer.startWidth = width;
            lineRenderer.endWidth = width;
            this.startPos = startPos;
            this.endPos = endPos;
        }
    } 
}
