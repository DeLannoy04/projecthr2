using System;
using UnityEngine;

namespace PlayerLevel
{
    [Serializable]
    public struct PlayerLevelValues
    {
        [ReadOnly] [SerializeField] internal int experience;
        [ReadOnly] [SerializeField] internal int coins;
    }
}