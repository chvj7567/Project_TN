using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using CHCard;

namespace CHItem
{
    public class ItemData
    {
        public long uid;
        public int id;
        public int count;
    }

    public partial class ItemSystem
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

        public void UpdateItem(ItemData itemData)
        {
            if (_dicItem.TryGetValue(itemData.uid, out ItemData value) == false)
                return;

            value.uid = itemData.uid;
            value.id = itemData.id;
            value.count = itemData.count;
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

        public int GetItemCountByUID(long itemUID)
        {
            ItemData itemData = GetItem(itemUID);
            if (itemData == null)
                return default;

            return itemData.count;
        }

        public int GetItemCountByItemID(long itemID)
        {
            int count = 0;

            foreach (var pair in _dicItem)
            {
                if (pair.Value.id == itemID)
                {
                    count += pair.Value.count;
                }
            }

            return count;
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
