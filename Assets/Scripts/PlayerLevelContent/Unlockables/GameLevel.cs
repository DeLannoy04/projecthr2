using UnityEngine;

namespace PlayerLevelContent.Unlockables
{
    [CreateAssetMenu(menuName = "PlayerLevel/Unlockables/Game Level", fileName = "GameLevel.asset")]
    public class GameLevel : UnlockableBase
    {
        [Scene] public string scene;
    }
}