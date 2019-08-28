using UnityEngine;

namespace Extensions
{
    public static class AnimationExtensions
    {
        public static float LastValue(this AnimationCurve curve)
        {
            return curve[curve.length - 1].value;
        }
        
        public static float LastTime(this AnimationCurve curve)
        {
            return curve.keys[curve.keys.Length - 1].time;
        }
    }
}