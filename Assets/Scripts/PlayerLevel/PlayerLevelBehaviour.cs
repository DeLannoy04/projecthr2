using System;
using Extensions;
using UnityEngine;

namespace PlayerLevel
{
    public class PlayerLevelBehaviour : MonoBehaviour
    {
        public PlayerLevelValues values;
        public PlayerLevelSettings settings;

        /// <summary>
        /// The current level based on <see cref="settings"/>.
        /// </summary>
        public int Level => GetLevel();

        /// <summary>
        /// Is the current level the maximum according to <see cref="settings"/>?
        /// </summary>
        public bool IsMaxLevel =>
            Level == (int) settings.experiencePerLevel.LastTime();

        public int Coins
        {
            get => values.coins;
            set
            {
                var before = values.coins;
                values.coins = Mathf.Clamp(value, 0, settings.maxCoins);
                if (before != values.coins)
                {
                    CoinsChanged?.Invoke(null, (before, values.coins));
                }
            }
        }
        
        /// <summary>
        /// Gets or sets the experience of the player.
        /// </summary>
        public int Experience
        {
            get => values.experience;
            set
            {
                var expBefore = values.experience;
                var levelBefore = Level;
                values.experience = Mathf.Clamp(value, 0, (int) settings.experiencePerLevel.LastValue());
                if (expBefore != values.experience)
                {
                    ExperienceChanged?.Invoke(this, (expBefore, values.experience));
                }

                if (levelBefore != Level)
                {
                    LevelChanged?.Invoke(this, (levelBefore, Level));
                }
            }
        }

        /// <summary>
        /// Triggered when the <see cref="Level"/> changes due to experience change. Called after <see cref="ExperienceChanged"/>.
        /// </summary>
        public event EventHandler<(int Before, int After)> LevelChanged;
        
        /// <summary>
        /// Triggered when <see cref="Experience"/> changed.
        /// </summary>
        public event EventHandler<(int Before, int After)> ExperienceChanged;
        
        public event EventHandler<(int Before, int After)> CoinsChanged; 


        private int GetLevel()
        {
            // try get the highest level where exp are enough for
            var level = (int) settings.experiencePerLevel[0].time;
            foreach (var key in settings.experiencePerLevel.keys)
            {
                if (key.value <= Experience)
                {
                    level = (int) key.time;
                }
                else
                {
                    // return the current level if no higher key frames match
                    break;
                }
            }

            return level;
        }
    }
}