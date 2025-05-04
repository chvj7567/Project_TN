

using System.Collections.Generic;

namespace CHCard
{
    public class CardData
    {
        public int number;
        public int count;
        public bool isInDeck;
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

        public void AddOrSetCard(CardData cardData)
        {
            if (_dicCard.ContainsKey(cardData.number))
                return;

            if (_dicCard.TryGetValue(cardData.number, out CardData value) == false)
            {
                _dicCard.Add(cardData.number, cardData);
            }
            else
            {
                value.number = cardData.number;
                value.count = cardData.count;
                value.isInDeck = cardData.isInDeck;
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
