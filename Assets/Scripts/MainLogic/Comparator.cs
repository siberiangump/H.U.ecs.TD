
using UnityEngine;

namespace Assets.Scripts
{
    class Comparator
    {
        public bool Equal(Color32 first, Color32 second)
        {
            if (first.a == second.a && first.r == second.r && first.g == second.g && first.b == second.b)
                return true;
            return false;
        }
    }
}
