using UnityEngine;

namespace PlayerLevelContent.Unlockables
{
    [CreateAssetMenu(menuName = "PlayerLevel/Unlockables/Weapon", fileName = "Weapon.asset")]
    public class Weapon : UnlockableBase
    {
        public Texture2D icon;
    }
}