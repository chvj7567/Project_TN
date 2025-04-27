

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
        Dictionary<int, CardSystem> _dicCard = null;

        public CardSystem()
        {
            _dicCard = new Dictionary<int, CardSystem>();
        }

        public void Clear()
        {
            _dicCard.Clear();
        }
    }
}
