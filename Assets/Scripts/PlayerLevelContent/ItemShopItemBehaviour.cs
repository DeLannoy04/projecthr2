using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerLevelContent
{
    public class ItemShopItemBehaviour : MonoBehaviour
    {
        [HideInInspector] public ItemShopBehaviour itemShop;
        [HideInInspector] public UnlockableBase unlockable;
        [SerializeField] private TextMeshProUGUI label;
        [SerializeField] private TextMeshProUGUI price;
        [SerializeField] private TextMeshProUGUI requiredLevel;
        [SerializeField] private Button button;
        
        private bool _initialized;

        private void Start()
        {
            _initialized = true;
            Initialize();
        }
        private void OnEnable()
        {
            // initialize first time via Start (wait for fields to be set because OnEnable is called to early)
            if (!_initialized) return;
            Initialize();
        }

        private void Initialize()
        {
            itemShop.player.CoinsChanged += PlayerValuesOnCoinsChanged;
            itemShop.player.LevelChanged += PlayerOnLevelChanged;
            label.text = unlockable.name;
            price.text = unlockable.price.ToString();
            requiredLevel.text = unlockable.requiredLevel.ToString();
            UpdateDisabled();
        }

        private void OnDisable()
        {
            itemShop.player.CoinsChanged -= PlayerValuesOnCoinsChanged;
            itemShop.player.LevelChanged -= PlayerOnLevelChanged;
        }

        private void PlayerOnLevelChanged(object sender, (int Before, int After) e)
        {
            UpdateDisabled();
        }

        private void PlayerValuesOnCoinsChanged(object sender, (int before, int after) e)
        {
            UpdateDisabled();
        }

        private void UpdateDisabled()
        {
            button.interactable = unlockable.requiredLevel <= itemShop.player.Level &&
                                  unlockable.price <= itemShop.player.Coins;
        }
    }
}