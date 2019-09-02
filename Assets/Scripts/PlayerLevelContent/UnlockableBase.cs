using UnityEngine;

namespace PlayerLevelContent
{
    public class UnlockableBase : ScriptableObject
    {
        public int requiredLevel = 1;
        public new string name;
        public int price;
    }
}