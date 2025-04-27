using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;

namespace CHItem
{
    public class ItemData
    {
        public long uid;
        public int id;
        public int count;
    }

    public class ItemSystem
    {
        private Dictionary<long, ItemData> _dicItem = null;

        public bool IsEmpty => _dicItem.Count <= 0;

        public ItemSystem()
        {
            _dicItem = new Dictionary<long, ItemData>();
        }

        public void Clear()
        {
            _dicItem.Clear();
        }

        public void AddItem(ItemData itemData)
        {
            if (_dicItem.ContainsKey(itemData.uid))
                return;

            _dicItem.Add(itemData.uid, itemData);
        }

        public bool RemoveItem(long itemUID)
        {
            if (_dicItem.ContainsKey(itemUID) == false)
                return default;

            return _dicItem.Remove(itemUID);
        }

        public ItemData GetItem(long itemUID)
        {
            if (_dicItem.TryGetValue(itemUID, out ItemData itemData) == false)
                return null;

            return itemData;
        }

        public int GetItemID(long itemUID)
        {
            ItemData itemData = GetItem(itemUID);
            if (itemData == null)
                return default;

            return itemData.id;
        }

        public int GetItemCount(long itemUID)
        {
            ItemData itemData = GetItem(itemUID);
            if (itemData == null)
                return default;

            return itemData.count;
        }

        public ReadOnlyCollection<ItemData> GetItemList(Predicate<ItemData> predicate)
        {
            List<ItemData> liItemData = new List<ItemData>();
            foreach (ItemData itemData in _dicItem.Values)
            {
                if (predicate(itemData))
                {
                    liItemData.Add(itemData);
                }
            }

            return liItemData.AsReadOnly();
        }
    }
}
