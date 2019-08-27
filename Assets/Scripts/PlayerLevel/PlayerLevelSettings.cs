using UnityEngine;

namespace PlayerLevel
{
    [CreateAssetMenu(menuName = "Player/Level Settings", fileName = "PlayerLevelSettings.asset")]
    public class PlayerLevelSettings : ScriptableObject
    {
        [Tooltip("Define levels and their required experience. Time (x) represents the level. Value (y) represents the experience needed. X and Y are used as integers.")]
        public AnimationCurve experiencePerLevel;
    }
}