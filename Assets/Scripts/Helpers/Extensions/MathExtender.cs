using UnityEngine;

namespace SideScroller.Helpers.Extensions
{
    public static class MathExtender
    {
        /// <summary>
        /// Is two numbers is approximately equal 
        /// </summary>
        /// <param name="firstValue"></param>
        /// <param name="secondValue"></param>
        /// <returns></returns>
        public static bool IsApproximatelyEqual(float firstValue, float secondValue)
        {
            if (Mathf.FloorToInt(firstValue) == Mathf.FloorToInt(secondValue))
            {
                return true;
            }
            return false;
        }
    }
}
