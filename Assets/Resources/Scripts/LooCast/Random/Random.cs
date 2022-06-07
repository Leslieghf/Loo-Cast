using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Random
{
    public static class Random
    {
        public static Vector2 InsideUnitCircle()
        {
            return UnityEngine.Random.insideUnitCircle;
        }

        public static Vector2 InsidePartialUnitCircle(float angleDegrees)
        {
            throw new System.NotImplementedException();
        }

        public static Vector2 OnUnitCircle()
        {
            Vector2 point = UnityEngine.Random.insideUnitCircle;
            return point == Vector2.zero ? Vector2.one : point;
        }

        public static Vector2 OnPartialUnitCircle(float angleDegrees)
        {
            float x = 0;
            float y = 0;
            float angleRadians = 0;
            Vector2 returnVector;

            angleRadians = angleDegrees * Mathf.Deg2Rad;

            x = Mathf.Cos(angleRadians);
            y = Mathf.Sin(angleRadians);

            returnVector = new Vector2(x, y);

            return returnVector;
        }

        public static Vector2 InBounds(Bounds bounds)
        {
            Vector2 point = new Vector2(
            UnityEngine.Random.Range(bounds.min.x, bounds.max.x),
            UnityEngine.Random.Range(bounds.min.y, bounds.max.y)
            );

            return point;
        }

        public static float Range(float minInclusive, float maxInclusive)
        {
            return UnityEngine.Random.Range(minInclusive, maxInclusive);
        }
    } 
}
