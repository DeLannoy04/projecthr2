using System;
using PlayerLevel;
using TMPro;
using UnityEngine;

namespace PlayerLevelContent
{
    public class ItemShopBehaviour : MonoBehaviour
    {
        [SerializeField] private Transform parent; 
        [SerializeField] private GameObject unlockablePrefab; 
        [SerializeField] private TextMeshProUGUI coinsText;
        [SerializeField] private TextMeshProUGUI levelsText;
        public PlayerLevelBehaviour player;
        public UnlockableBase[] unlockables;

        private void OnEnable()
        {
            player.CoinsChanged += PlayerOnCoinsChanged;
            player.LevelChanged += PlayerOnLevelChanged;
        }

        private void OnDisable()
        {
            player.CoinsChanged -= PlayerOnCoinsChanged;
            player.LevelChanged -= PlayerOnLevelChanged;
        }

        private void PlayerOnLevelChanged(object sender, (int Before, int After) e)
        {
            levelsText.text = e.After.ToString();
        }

        private void PlayerOnCoinsChanged(object sender, (int Before, int After) e)
        {
            coinsText.text = e.After.ToString();
        }

        private void Start()
        {
            foreach (var unlockable in unlockables)
            {
                var go = Instantiate(unlockablePrefab, parent);
                var item = go.GetComponent<ItemShopItemBehaviour>();
                item.itemShop = this;
                item.unlockable = unlockable;
            }
        }

        public void AddCoins(int amount)
        {
            player.Coins += amount;
        }

        public void AddLevel(int amount)
        {
            var exp = (int) player.settings.experiencePerLevel.Evaluate(player.Level + amount);
            player.Experience = exp;
        }
    }
}