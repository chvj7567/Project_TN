using System.Collections.Generic;

namespace CHCard
{
    public class CardData
    {
        public int number;
        public int count;
        public bool isInDeck;
    }

    public partial class CardSystem
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

        public void AddCard(CardData cardData)
        {
            if (_dicCard.ContainsKey(cardData.number))
                return;

            _dicCard.Add(cardData.number, cardData);
        }

        public void UpdateCard(CardData cardData)
        {
            if (_dicCard.TryGetValue(cardData.number, out CardData value) == false)
                return;

            value.number = cardData.number;
            value.count = cardData.count;
            value.isInDeck = cardData.isInDeck;
        }

        public bool RemoveCard(int cardNumber)
        {
            if (_dicCard.ContainsKey(cardNumber) == false)
                return default;

            return _dicCard.Remove(cardNumber);
        }
    }
}
