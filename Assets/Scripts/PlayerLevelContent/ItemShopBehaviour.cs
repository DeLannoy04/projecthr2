using System;
using UnityEngine;

namespace PlayerLevelContent
{
    public class ItemShopBehaviour : MonoBehaviour
    {
        [SerializeField] private Transform parent; 
        [SerializeField] private GameObject unlockablePrefab; 
        public UnlockableBase[] unlockables;

        private void Start()
        {
            foreach (var unlockable in unlockables)
            {
                var go = Instantiate(unlockablePrefab, parent);
                var item = go.GetComponent<ItemShopItemBehaviour>();
                item.label.text = unlockable.name;
                item.requiredLevel.text = unlockable.requiredLevel.ToString();
            }
        }
    }
}