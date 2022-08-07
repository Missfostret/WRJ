using UnityEngine;

namespace Helpers
{
    public class FunctionLibrary
    {
        public static float RoundTo1D(float value)
        {
            return Mathf.Round(value * 10.0f) * 0.1f;
        }
    }
}
