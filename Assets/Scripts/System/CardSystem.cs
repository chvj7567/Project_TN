

using System.Collections.Generic;

namespace CHCard
{
    public class CardData
    {
        public int number;
        public int count;
    }

    public class CardSystem
    {
        Dictionary<int, CardData> _dicCard = null;

        public CardSystem()
        {
            _dicCard = new Dictionary<int, CardData>();
        }

        public void Clear()
        {
            _dicCard.Clear();
        }

        public void AddCard(int number, int count = 1)
        {
            if (_dicCard.TryGetValue(number, out CardData cardData) == false)
            {
                cardData = new CardData();
                cardData.number = number;
                cardData.count = count;
            }
            else
            {
                cardData.count += count;
            }
        }

        public void RemoveCard(int number, int count = 1)
        {
            if (_dicCard.TryGetValue(number, out CardData cardData) == false)
                return;

            if (cardData.count <= 0)
                return;

            cardData.count -= count;
        }
    }
}
