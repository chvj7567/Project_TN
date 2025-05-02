using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CHBattle
{
    public class BattleHistoryData
    {
        public int totalBattleCount;
        public int winCount;
        public int loseCount;
    }

    public class BattleCurrentData
    {
        public int ruleNumber;
        public int missionID;
        public List<int> liRemainCard = new List<int>();
    }

    public class BattleSystem
    {
        private BattleHistoryData _battleHistoryData = null;
        private BattleCurrentData _battleCurrentData = null;

        public BattleSystem()
        {
            _battleHistoryData = new BattleHistoryData();
            _battleCurrentData= new BattleCurrentData();
        }

        public void Clear()
        {
            _battleHistoryData = null;
            _battleCurrentData = null;
        }

        public void SetHistory(int winCount, int loseCount)
        {
            if (_battleHistoryData == null)
                return;

            _battleHistoryData.totalBattleCount = winCount + loseCount;
            _battleHistoryData.winCount = winCount;
            _battleHistoryData.loseCount = loseCount;
        }

        public void SetCurrentBattle(int ruleNumber, int missionID)
        {
            if (_battleCurrentData == null)
                return;

            _battleCurrentData.ruleNumber = ruleNumber;
            _battleCurrentData.missionID = missionID;
        }

        public void SetCurrentBattleCardList(List<int> liRemainCard)
        {
            if (_battleCurrentData == null)
                return;

            _battleCurrentData.liRemainCard = liRemainCard;
        }

        public bool UseCard(int cardNumber)
        {
            if (_battleCurrentData == null)
                return false;

            if (_battleCurrentData.liRemainCard.Contains(cardNumber) == false)
                return false;

            return _battleCurrentData.liRemainCard.Remove(cardNumber);
        }

        public ReadOnlyCollection<int> GetRemainCardList()
        {
            if (_battleCurrentData == null)
                return default;

            return _battleCurrentData.liRemainCard.AsReadOnly();
        }

        public int GetBattleMissionID()
        {
            if (_battleCurrentData == null)
                return default;

            return _battleCurrentData.missionID;
        }
    }
}