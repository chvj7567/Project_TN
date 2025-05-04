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

    public partial class BattleSystem
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

        public void SetBattleHistoryData(BattleHistoryData battleHistoryData)
        {
            if (_battleHistoryData == null)
                return;

            _battleHistoryData.totalBattleCount = battleHistoryData.totalBattleCount;
            _battleHistoryData.winCount = battleHistoryData.winCount;
            _battleHistoryData.loseCount = battleHistoryData.loseCount;
        }

        public void SetBattleCurrentData(BattleCurrentData battleCurrentData)
        {
            if (_battleCurrentData == null)
                return;

            _battleCurrentData.ruleNumber = battleCurrentData.ruleNumber;
            _battleCurrentData.missionID = battleCurrentData.missionID;
        }

        public void SetBattleCardDeck(List<int> liCardDeck)
        {
            if (_battleCurrentData == null)
                return;

            _battleCurrentData.liRemainCard = liCardDeck;
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